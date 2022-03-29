using iAccess.Databases;
using iAccess.Objects;
using iAccess.Objects.Devices;
using iParking.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iAccess.Forms.Device_frms
{
    public partial class frmController_Door : Form
    {
        private string ID;
        public frmController_Door(string id)
        {
            InitializeComponent();
            this.ID = id;
        }
        public static void LoadController(ComboBox comboBox)
        {
            foreach (AccessController controller in Staticpool.controllers)
            {
                ListItem listCardGroup = new ListItem();
                listCardGroup.Value = controller.ID;
                listCardGroup.Name = controller.Name;
                comboBox.Items.Add(listCardGroup);
            }
            comboBox.DisplayMember = "Name";
            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = 0;
            }
        }

        public static void LoadDoor(ComboBox comboBox)
        {
            foreach (Door door in Staticpool.doors)
            {
                ListItem listCardGroup = new ListItem();
                listCardGroup.Value = door.ID;
                listCardGroup.Name = door.Name;
                comboBox.Items.Add(listCardGroup);
            }
            comboBox.DisplayMember = "Name";
            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = 0;
            }
        }
        private void frmController_Door_Load(object sender, EventArgs e)
        {
            LoadController(cbController);
            LoadDoor(cbDoor);
            if (this.ID != "")
            {
                Controller_Door_Detail controller_Door_Detail = Staticpool.Controller_Doors.GetControllerDoorByID(this.ID);
                if(controller_Door_Detail != null)
                {
                    txtID.Text = this.ID;
                    txtName.Text = controller_Door_Detail.Name;
                    txtCode.Text = controller_Door_Detail.Code;
                    txtDescription.Text = controller_Door_Detail.Description;
                    AccessController controller = Staticpool.controllers.GetControllerByID(controller_Door_Detail.ControllerID);
                    if (controller != null)
                        cbController.SelectedIndex = cbController.FindString(controller.Name);
                    Door door = Staticpool.doors.GetDoorByID(controller_Door_Detail.DoorID);
                    if (door != null)
                        cbDoor.SelectedIndex = cbDoor.FindString(door.Name);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckOutputName())
            {
                MessageBox.Show("This Output name is already used, please try another name!");
                return;
            }
            Controller_Door_Detail controller_door = this.ID != "" ? Staticpool.Controller_Doors.GetControllerDoorByID(this.ID) : new Controller_Door_Detail();
            controller_door.ID = this.ID;
            controller_door.Name = txtName.Text;
            controller_door.Code = txtCode.Text;
            controller_door.Description = txtDescription.Text;
            controller_door.ControllerID = ((ListItem)cbController.SelectedItem).Value;
            controller_door.DoorID = ((ListItem)cbDoor.SelectedItem).Value;
            controller_door.ReaderIndex = (int)numReaderIndex.Value;
            if (this.ID != "")
            {
                if (EditController_DoorInfo(controller_door))
                {
                    MessageBox.Show("Edit Output Infor Success");
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Edit Output Infor Error, please try again later!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                string controller_doorID = AddNewController_Door(controller_door);
                if (controller_doorID != "")
                {
                    controller_door.ID = controller_doorID;
                    Staticpool.Controller_Doors.Add(controller_door);
                    if (MessageBox.Show("Add Output Infor Success, do you want to add another output?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
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
        private bool EditController_DoorInfo(Controller_Door_Detail controller_door)
        {
            return tblController_Door.Modify(controller_door.Name, controller_door.Code, controller_door.Description, controller_door.ControllerID, controller_door.DoorID, controller_door.ReaderIndex, controller_door.ID);
        }
        private string AddNewController_Door(Controller_Door_Detail controller_door)
        {
            return tblController_Door.InsertAndGetLastID(controller_door);
        }
        private void RefreshForm()
        {
            txtName.Text = "";
            txtCode.Text = "";
            txtDescription.Text = "";
        }

        private void panelCardGroupInfor_Paint(object sender, PaintEventArgs e)
        {

        }
        private bool CheckOutputName()
        {
            if (this.ID != "")
            {
                foreach (Controller_Door_Detail output in Staticpool.Controller_Doors)
                {
                    if (output.ID != this.ID && output.Name == txtName.Text)
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                foreach (Controller_Door_Detail output in Staticpool.Controller_Doors)
                {
                    if (output.Name == txtName.Text)
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