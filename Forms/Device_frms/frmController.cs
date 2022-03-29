using iAccess.Databases;
using iAccess.Enums;
using iAccess.Objects.Devices;
using iParking.Database;
using KztekObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static KztekObject.ControllerType;
using static KztekObject.enums.CommunicationType;

namespace iAccess.Forms.Device_frms
{
    public partial class frmController : Form
    {
        private string ID;
        public frmController(string id)
        {
            InitializeComponent();
            this.ID = id;
        }
        public static void LoadControllerType(ComboBox comboBox)
        {
            foreach (int i in Enum.GetValues(typeof(EM_ControllerType)))
            {
                comboBox.Items.Add(Enum.GetName(typeof(EM_ControllerType), i));
            }
            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = 0;
            }
        }
        public static void LoadCommunicationType(ComboBox comboBox)
        {
            foreach (int i in Enum.GetValues(typeof(EM_CommunicationType)))
            {
                comboBox.Items.Add(Enum.GetName(typeof(EM_CommunicationType), i));
            }
            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = 0;
            }
        }
        public static void LoadDisplayMode(ComboBox comboBox)
        {
            foreach (int i in Enum.GetValues(typeof(EM_DisplayMode)))
            {
                comboBox.Items.Add(Enum.GetName(typeof(EM_DisplayMode), i));
            }
            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = 0;
            }
        }
        public static void LoadControllerGroup(ComboBox comboBox)
        {
            foreach (ControllerGroup controllerGroup in Staticpool.controllerGroups)
            {
                ListItem listCardGroup = new ListItem();
                listCardGroup.Value = controllerGroup.ID;
                listCardGroup.Name = controllerGroup.Name;
                comboBox.Items.Add(listCardGroup);
            }
            comboBox.DisplayMember = "Name";
            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = 0;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            AccessController controller = this.ID == "" ? new AccessController() : Staticpool.controllers.GetControllerByID(this.ID);
            controller.Name = txtName.Text;
            controller.Code = txtCode.Text;
            controller.IP = txtIP.Text;
            controller.Port = Convert.ToInt32(txtPort.Text);
            controller.Username = txtUsername.Text;
            controller.Password = txtPassword.Text;
            controller.ControllerType = (EM_ControllerType)cbControllerType.SelectedIndex;
            controller.CommunicationType = (EM_CommunicationType)cbCommunicationType.SelectedIndex;
            controller.DisplayMode = (EM_DisplayMode)cbDisplayMode.SelectedIndex;
            controller.isInUse = chbInUse.Checked;
            string controllerGroupID = ((ListItem)cbControllerGroup.SelectedItem).Value;
            controller.ControllerGroupID = controllerGroupID;
            if (this.ID != "")
            {
                if (EditControllerInfor(controller))
                {
                    MessageBox.Show("Edit Controller Infor Success");
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Edit Controller Infor Error, please try again later!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                string controllerID = AddNewController(controller);
                if (controllerID != "")
                {
                    controller.ID = controllerID;
                    Staticpool.controllers.Add(controller);
                    if (MessageBox.Show("Add Controller Infor Success, do you want to add another controller?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        RefreshForm();
                    }
                    else
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
        }
        private bool EditControllerInfor(AccessController controller)
        {
            return tblController.Modify(controller, controller.ID);
        }
        private string AddNewController(AccessController controller)
        {
            return tblController.InsertAndGetLastID(controller);
        }
        private void RefreshForm()
        {
            txtName.Text = "";
            txtCode.Text = "";
            txtIP.Text = "";
            txtPort.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            cbControllerType.SelectedIndex = 0;
            cbCommunicationType.SelectedIndex = 0;
            cbDisplayMode.SelectedIndex = 0;
            cbControllerGroup.SelectedIndex = 0;
            chbInUse.Checked = true;
        }

        private void frmController_Load(object sender, EventArgs e)
        {
            if (!CheckControllerName())
            {
                MessageBox.Show("This controller name is already used, please try another name!");
                return;
            }
            LoadControllerType(cbControllerType);
            LoadCommunicationType(cbCommunicationType);
            LoadDisplayMode(cbDisplayMode);
            LoadControllerGroup(cbControllerGroup);
            if (this.ID != "")
            {
                AccessController controller = Staticpool.controllers.GetControllerByID(this.ID);
                txtID.Text = controller.ID;
                txtName.Text = controller.Name;
                txtCode.Text = controller.Code;
                txtIP.Text = controller.IP;
                txtPort.Text = controller.Port + "";
                txtUsername.Text = controller.Username;
                txtPassword.Text = controller.Password;
                cbControllerType.SelectedIndex = (int)controller.ControllerType;
                cbCommunicationType.SelectedIndex = (int)controller.CommunicationType;
                cbDisplayMode.SelectedIndex = (int)controller.DisplayMode;
                chbInUse.Checked = controller.isInUse;
                ControllerGroup controllerGroup = Staticpool.controllerGroups.GetControllerGroupByID(controller.ControllerGroupID);
                if (controllerGroup != null)
                    cbControllerGroup.SelectedIndex = cbControllerGroup.FindString(controllerGroup.Name);
                else
                    cbControllerGroup.SelectedIndex = 0;
            }
            else
            {
                chbInUse.Checked = true;
            }
        }
        private bool CheckControllerName()
        {
            if (this.ID != "")
            {
                foreach (AccessController controller in Staticpool.controllers)
                {
                    if (controller.ID != this.ID && controller.Name == txtName.Text)
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                foreach (AccessController controller in Staticpool.controllers)
                {
                    if (controller.Name == txtName.Text)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = txtName.Text != "";
        }
    }
}
