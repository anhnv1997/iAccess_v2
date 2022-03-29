using iAccess.Databases;
using iAccess.Objects.Devices;
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
    public partial class frmControllerGroup : Form
    {
        private string ID;
        public frmControllerGroup(string id)
        {
            InitializeComponent();
            this.ID = id;
        }

        private void frmControllerGroup_Load(object sender, EventArgs e)
        {
            if (this.ID != "")
            {
                ControllerGroup controllerGroup = Staticpool.controllerGroups.GetControllerGroupByID(this.ID);
                if (controllerGroup != null)
                {
                    txtName.Text = controllerGroup.Name;
                    txtCode.Text = controllerGroup.Code;
                    txtDescription.Text = controllerGroup.Description;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckControllerGroupName())
            {
                MessageBox.Show("This controller group name is already used, please try another name!");
                return;
            }
            ControllerGroup controllerGroup = this.ID == "" ? new ControllerGroup() : Staticpool.controllerGroups.GetControllerGroupByID(this.ID);
            controllerGroup.Name = txtName.Text;
            controllerGroup.Code = txtCode.Text;
            controllerGroup.Description = txtDescription.Text;
            if (this.ID != "")
            {
                if (EditCardGroupInfor(controllerGroup))
                {
                    MessageBox.Show("Edit Controller Group Infor Success");
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Edit Controller Group Infor Error, please try again later!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                string controllerGroupID = AddNewDepartment(controllerGroup);
                if (controllerGroupID != "")
                {
                    controllerGroup.ID = controllerGroupID;
                    Staticpool.controllerGroups.Add(controllerGroup);
                    if (MessageBox.Show("Add Controller Group Infor Success, do you want to add another controller group?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
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
        private bool EditCardGroupInfor(ControllerGroup controllerGroup)
        {
            return tblControllerGroup.Modify(controllerGroup, controllerGroup.ID);
        }
        private string AddNewDepartment(ControllerGroup controllerGroup)
        {
            return tblControllerGroup.InsertAndGetLastID(controllerGroup);
        }
        private void RefreshForm()
        {
            txtName.Text = "";
            txtDescription.Text = "";
            txtCode.Text = "";
        }
        private bool CheckControllerGroupName()
        {
            if (this.ID != "")
            {
                foreach (ControllerGroup controllerGroup in Staticpool.controllerGroups)
                {
                    if (controllerGroup.ID != this.ID && controllerGroup.Name == txtName.Text)
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                foreach (ControllerGroup controllerGroup in Staticpool.controllerGroups)
                {
                    if (controllerGroup.Name == txtName.Text)
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