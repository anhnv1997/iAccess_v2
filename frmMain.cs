using CryptorEngines;
using FileXMLs;
using iAccess.Databases;
using iAccess.Forms.Device_frms;
using iAccess.Objects;
using iAccess.Objects.Customers;
using iAccess.Objects.Devices;
using iParking.Database;
using KztekObject;
using KztekObject.Controllers;
using KztekObject.enums;
using SQLConns;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iAccess
{
    public partial class frmMain : Form
    {
        List<string> datasource = new List<string>();
        SQLConn[] sqls = null;
        private ImageList imageStatusList = new ImageList();
        private const int CONNECTED_INDEX = 0;
        private const int WEAK_SIGNAL_INDEX = 1;
        private const int DISCONNECTED_INDEX = 2;
        private const int DOOR_INDEX = 3;
        private const int SELECTED_DOOR_INDEX = 4;

        private const int DEVICE_TYPE_ACCESS_CONTROLLER = 0;
        private const int DEVICE_TYPE_CAMERA = 1;


        public static List<IController> iControllers = new List<IController>();
        private Image UnknowPersonImg = Image.FromFile(Images.IMAGE_Unknown_Person);

        private int max_controller_treeview_width = 0;

        public frmMain()
        {
            InitializeComponent();
        }

        private async void frmMain_Load(object sender, EventArgs e)
        {
            LoadControllerTreeview();

            controller_treeView.Width = max_controller_treeview_width + btnMenu.Width;
            btnMenu.Location = new Point(controller_treeView.Location.X + controller_treeView.Width - btnMenu.Width, controller_treeView.Location.Y);

            LoadIControllers();
            //await AssignEvent();
           // await AssignParallelEvent();
        }

        #region: Internal
        private void LoadControllerTreeview()
        {
            Image connected_img = Image.FromFile(Images.IMAGE_CONNECTED_PATH);
            Image Weak_Signal_img = Image.FromFile(Images.IMAGE_WEAK_SIGNAL_PATH);
            Image disconnected_img = Image.FromFile(Images.IMAGE_DISCONNECTED_PATH);
            Image door_img = Image.FromFile(Images.IMAGE_DOOR_PATH);
            Image selected_door_img = Image.FromFile(Images.IMAGE_SELECTED_DOOR_PATH);
            imageStatusList.Images.Add(connected_img);
            imageStatusList.Images.Add(Weak_Signal_img);
            imageStatusList.Images.Add(disconnected_img);
            imageStatusList.Images.Add(door_img);
            imageStatusList.Images.Add(selected_door_img);

            controller_treeView.ImageList = imageStatusList;
            foreach (AccessController controller in Staticpool.controllers)
            {
                TreeNode controllerNode = new TreeNode();
                controllerNode.Name = controller.ID;
                controllerNode.Text = controller.Name + "-" + controller.IP;
                controllerNode.ImageIndex = DISCONNECTED_INDEX;
                controllerNode.SelectedImageIndex = DISCONNECTED_INDEX;
                controller_treeView.Nodes.Add(controllerNode);

                List<Controller_Door_Detail> outputs = (from Controller_Door_Detail output
                                                        in Staticpool.Controller_Doors
                                                        where output.ControllerID == controller.ID
                                                        orderby output.ReaderIndex
                                                        select output).ToList();
                foreach (Controller_Door_Detail output in outputs)
                {
                    TreeNode outputNode = new TreeNode();
                    outputNode.Name = output.ID;
                    Door door = Staticpool.doors.GetDoorByID(output.DoorID);
                    outputNode.Text = door.Name;
                    outputNode.ImageIndex = DOOR_INDEX;
                    outputNode.SelectedImageIndex = SELECTED_DOOR_INDEX;
                    controllerNode.Nodes.Add(outputNode);

                }
            }
            foreach (TreeNode node in controller_treeView.Nodes)
            {
                Size textSize = TextRenderer.MeasureText(node.Text, controller_treeView.Font);
                if (max_controller_treeview_width < (textSize.Width + 50))
                {
                    max_controller_treeview_width = textSize.Width + 50;
                }
            }
        }
        private static async Task AssignEvent()
        {
            await Task.Run(new Action(() =>
            {
                foreach (IController iController in iControllers)
                {
                    iController.Connect();
                    iController.PollingStart();
                }
            }));
        }

        //private static async Task AssignParallelEvent()
        //{
        //    await Task.Run(new Action(() =>
        //    {
        //        ParallelLoopResult result = Parallel.For(0, iControllers.Count, (int i) =>
        //        {
        //            iControllers[i].Connect();
        //            iControllers[i].PollingStart();
        //        });
        //    }));
        //}
        private void LoadIControllers()
        {
            foreach (AccessController accessController in Staticpool.controllers)
            {
                IController iController = ControllerFactory.GetControllerByType(accessController.ControllerType);
                if (iController != null)
                {
                    iController.ControllerInfor.ID = accessController.ID;
                    iController.ControllerInfor.Name = accessController.Name;
                    iController.ControllerInfor.Comport = accessController.IP;
                    iController.ControllerInfor.Baudrate = accessController.Port;
                    iController.ControllerInfor.ControllerCommunicationType = accessController.CommunicationType;
                    iController.ControllerInfor.DisplayMode = accessController.DisplayMode;
                    iController.CardEvent += IController_CardEvent;
                    iController.InputEvent += IController_InputEvent;
                    iController.ErrorEvent += IController_ErrorEvent;
                    iController.ConnectStatusChangeEvent += IController_ConnectStatusChangeEvent;
                    iControllers.Add(iController);
                }
            }
        }
        #endregion


        private void IController_ConnectStatusChangeEvent(object sender, KztekObject.Events.ControllerEvent.ConnectStatusCHangeEventArgs e)
        {
            foreach (TreeNode node in controller_treeView.Nodes)
            {
                if (node.Name == e.ControllerID)
                {
                    controller_treeView?.Invoke(new Action(() =>
                    {
                        node.ImageIndex = e.CurrentStatus == true ? CONNECTED_INDEX : DISCONNECTED_INDEX;
                        node.SelectedImageIndex = e.CurrentStatus == true ? CONNECTED_INDEX : DISCONNECTED_INDEX;
                    }));
                    return;
                }
            }
        }

        private void IController_ErrorEvent(object sender, KztekObject.Events.ControllerEvent.ErrorEventArgs e)
        {
        }

        private void IController_InputEvent(object sender, KztekObject.Events.ControllerEvent.InputEventArgs e)
        {
        }

        private void IController_CardEvent(object sender, KztekObject.Events.ControllerEvent.CardEventArgs e)
        {
            tblEvent.InsertAndGetLastID(DateTime.Now, (int)e.EventType, (int)e.EventStatus, e.ControllerID, DEVICE_TYPE_ACCESS_CONTROLLER, e.CardNumber);

            Customer customer = e.EventStatus == EM_EventStatus.ACCESS_GRANT ? Staticpool.customers.GetCustomerByCardNumber(e.CardNumber) : null;

            Task.Run(() =>
            {
                dgvRealtimeCardEvent?.Invoke(new Action(() =>
                {
                    AccessController controller = Staticpool.controllers.GetControllerByID(e.ControllerID);
                    dgvRealtimeCardEvent.Rows.Add(customer == null ? "" : customer.FaceData, dgvRealtimeCardEvent.Rows.Count + 1, e.Date + " " + e.Time, controller == null ? "" : controller.Name, e.ReaderIndex, e.CardNumber, e.EventStatus.ToString());
                    if (dgvRealtimeCardEvent.Rows.Count > 0)
                    {
                        dgvRealtimeCardEvent.CurrentCell = dgvRealtimeCardEvent.Rows[dgvRealtimeCardEvent.Rows.Count - 1].Cells[1];
                        dgvRealtimeCardEvent.CurrentRow.DefaultCellStyle.BackColor = e.EventStatus == EM_EventStatus.ACCESS_DENIED ? Color.DarkRed : Color.FromArgb(81, 227, 52);
                        dgvRealtimeCardEvent.CurrentRow.DefaultCellStyle.ForeColor = e.EventStatus == EM_EventStatus.ACCESS_DENIED ? Color.White : Color.Black;
                    }
                }));
            });

            Task.Run(() =>
            {
                dgvRealTimeAllEvent?.Invoke(new Action(() =>
                {
                    AccessController controller = Staticpool.controllers.GetControllerByID(e.ControllerID);
                    dgvRealTimeAllEvent.Rows.Add(customer == null ? "" : customer.FaceData, dgvRealTimeAllEvent.Rows.Count + 1, e.Date + " " + e.Time, "ACCESS CONTROLLER", controller == null ? "" : controller.Name, e.UserID, e.EventType.ToString(), e.EventStatus.ToString());
                    if (dgvRealTimeAllEvent.Rows.Count > 0)
                    {
                        dgvRealTimeAllEvent.CurrentCell = dgvRealTimeAllEvent.Rows[dgvRealTimeAllEvent.Rows.Count - 1].Cells[1];
                        dgvRealTimeAllEvent.CurrentRow.DefaultCellStyle.BackColor = e.EventStatus == EM_EventStatus.ACCESS_DENIED ? Color.DarkRed : Color.FromArgb(81, 227, 52);
                        dgvRealTimeAllEvent.CurrentRow.DefaultCellStyle.ForeColor = e.EventStatus == EM_EventStatus.ACCESS_DENIED ? Color.White : Color.Black;
                    }
                }));
            });

            Task.Run(() =>
            {

                if (e.EventStatus == EM_EventStatus.ACCESS_GRANT)
                {
                    if (customer != null)
                    {
                        picCustomerFace?.Invoke(new Action(() =>
                        {
                            try
                            {
                                if (customer.FaceData != "")
                                    picCustomerFace.Image = Image.FromFile(customer.FaceData);
                                else
                                    picCustomerFace.Image = UnknowPersonImg;
                            }
                            catch
                            {
                                picCustomerFace.Image = UnknowPersonImg;
                            }
                        }));
                        lblEventCustomerName?.Invoke(new Action(() =>
                        {
                            lblEventCustomerName.Text = customer.Name;
                        }));

                        Department department = Staticpool.departments.GetDepartmentByID(customer.DepartmentID);
                        lblEventCustomerDepartment?.Invoke(new Action(() =>
                        {
                            lblEventCustomerDepartment.Text = department == null ? "" : department.Name;
                        }));

                        lblEventCustomerTime?.Invoke(new Action(() =>
                        {
                            lblEventCustomerTime.Text = e.Date + " " + e.Time;
                        }));

                    }
                    else
                    {
                        picCustomerFace?.Invoke(new Action(() =>
                        {
                            picCustomerFace.Image = UnknowPersonImg;
                        }));
                        lblEventCustomerName?.Invoke(new Action(() =>
                        {
                            lblEventCustomerName.Text = "UNKNOWN";
                        }));
                        lblEventCustomerDepartment?.Invoke(new Action(() =>
                        {
                            lblEventCustomerDepartment.Text = "UNKNOWN";
                        }));
                        lblEventCustomerTime?.Invoke(new Action(() =>
                        {
                            lblEventCustomerTime.Text = e.Date + " " + e.Time;
                        }));
                    }
                }
                else
                {
                    picCustomerFace?.Invoke(new Action(() =>
                    {
                        picCustomerFace.Image = UnknowPersonImg;
                    }));
                    lblEventCustomerName?.Invoke(new Action(() =>
                    {
                        lblEventCustomerName.Text = "UNKNOWN";
                    }));
                    lblEventCustomerDepartment?.Invoke(new Action(() =>
                    {
                        lblEventCustomerDepartment.Text = "UNKNOWN";
                    }));
                    lblEventCustomerTime?.Invoke(new Action(() =>
                    {
                        lblEventCustomerTime.Text = e.Date + " " + e.Time;
                    }));
                }
            });

        }

        private void ConnectToSQLServer()
        {
            if (sqls != null && sqls.Length > 0)
            {
                string cbSQLServerName = sqls[0].SQLServerName;
                string cbSQLDatabaseName = sqls[0].SQLDatabase;
                string cbSQLAuthentication = sqls[0].SQLAuthentication;
                string txtSQLUserName = sqls[0].SQLUserName;
                string txtSQLPassword = CryptorEngine.Decrypt(sqls[0].SQLPassword, true);
                Staticpool.mdb = new MDB(cbSQLServerName, cbSQLDatabaseName, cbSQLAuthentication, txtSQLUserName, txtSQLPassword);
            }
        }

        private void tsmSetting_Click(object sender, EventArgs e)
        {
            frmSetting frm = new frmSetting();
            frm.ShowDialog();
        }

        #region:Connect To SQL
        #endregion

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (controller_treeView.Width == btnMenu.Width)
            {
                controller_treeView.Width = max_controller_treeview_width + btnMenu.Width;
                btnMenu.Location = new Point(controller_treeView.Location.X + controller_treeView.Width - btnMenu.Width, controller_treeView.Location.Y);
                btnMenu.IconColor = Color.DarkRed;
                btnMenu.IconChar = FontAwesome.Sharp.IconChar.AlignLeft;
            }
            else
            {
                controller_treeView.Width = btnMenu.Width;
                btnMenu.Location = new Point(controller_treeView.Location.X, controller_treeView.Location.Y);
                btnMenu.IconColor = Color.DarkGreen;
                btnMenu.IconChar = FontAwesome.Sharp.IconChar.AlignRight;
            }
        }

        private void tsmControllerSetting_Click(object sender, EventArgs e)
        {
            frmControllerSetting frm = new frmControllerSetting();
            frm.ShowDialog();
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //foreach (IController iController in iControllers)
            //{
            //    Employee employee = new Employee();
            //    employee.MemoryID = 1;
            //    employee.CardNumber = "BF5BD020";
            //    employee.Doors = new List<int>() { 1, 3, 5, 7, 9 };
            //    employee.CardType = (int)EM_CardType.Mifare;
            //    employee.TimezoneID = 0;
            //    iController.DownloadUser(employee);

            //    iController.GetUserByUserId(1);
            //}

            string test = "Tiếng Việt";
            byte[] bytes = Encoding.UTF8.GetBytes(test);
            MessageBox.Show(Encoding.UTF8.GetString(bytes));

        }



    }
}
