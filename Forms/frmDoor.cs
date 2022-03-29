using iAccess.Databases;
using iAccess.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iAccess.Forms
{
    public partial class frmDoor : Form
    {
        private string ID;
        public frmDoor(string id)
        {
            InitializeComponent();
            this.ID = id;
        }
        private void frmDoor_Load(object sender, EventArgs e)
        {
            if (this.ID != "")
            {
                Door door = Staticpool.doors.GetDoorByID(this.ID);
                if (door != null)
                {
                    txtName.Text = door.Name;
                    txtCode.Text = door.Code;
                    txtDescription.Text = door.Description;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckDoorName())
            {
                MessageBox.Show("This door name is already used, please try another name!");
                return;
            }
            Door door = this.ID == "" ? new Door() : Staticpool.doors.GetDoorByID(this.ID);
            door.Name = txtName.Text;
            door.Code = txtCode.Text;
            door.Description = txtDescription.Text;
            if (this.ID != "")
            {
                if (EditDoorInfor(door))
                {
                    MessageBox.Show("Edit Door Infor Success");
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Edit Door Infor Error, please try again later!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                string doorID = AddNewDoor(door);
                if (doorID != "")
                {
                    door.ID = doorID;
                    Staticpool.doors.Add(door);
                    if (MessageBox.Show("Add Door Infor Success, do you want to add another card group?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
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
        private bool EditDoorInfor(Door Door)
        {
            return tblDoor.Modify(Door, Door.ID);
        }
        private string AddNewDoor(Door Door)
        {
            return tblDoor.InsertAndGetLastID(Door);
        }
        private void RefreshForm()
        {
            txtName.Text = "";
            txtDescription.Text = "";
            txtCode.Text = "";
        }
        private bool CheckDoorName()
        {
            if (this.ID != "")
            {
                foreach (Door door in Staticpool.doors)
                {
                    if (door.ID != this.ID && door.Name == txtName.Text)
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                foreach (Door door in Staticpool.doors)
                {
                    if (door.Name == txtName.Text)
                    {
                        return false;
                    }
                }
                return true;
            }
        }
        private void txtName_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = txtName.Text!="";
        }
    }
}