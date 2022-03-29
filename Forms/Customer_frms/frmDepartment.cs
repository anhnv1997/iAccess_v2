using iAccess.Databases;
using iAccess.Objects.Customers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iAccess.Forms.Customer_frms
{
    public partial class frmDepartment : Form
    {
        private string ID;
        public frmDepartment(string id)
        {
            InitializeComponent();
            this.ID = id;
        }

        private void frmDepartment_Load(object sender, EventArgs e)
        {
            if (this.ID != "")
            {
                Department department = Staticpool.departments.GetDepartmentByID(this.ID);
                if (department != null)
                {
                    txtName.Text = department.Name;
                    txtCode.Text = department.Code;
                    txtDescription.Text = department.Description;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckDepartmentName())
            {
                MessageBox.Show("This department name is already used, please try another name!");
                return;
            }
            Department department = this.ID == "" ? new Department() : Staticpool.departments.GetDepartmentByID(this.ID);
            department.Name = txtName.Text;
            department.Code = txtCode.Text;
            department.Description = txtDescription.Text;
            if (this.ID != "")
            {
                if (EditCardGroupInfor(department))
                {
                    MessageBox.Show("Edit Department Infor Success");
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Edit Department Infor Error, please try again later!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                string departmentID = AddNewDepartment(department);
                if (departmentID != "")
                {
                    department.ID = departmentID;
                    Staticpool.departments.Add(department);
                    if (MessageBox.Show("Add Department Infor Success, do you want to add another card group?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
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
        private bool EditCardGroupInfor(Department department)
        {
            return tblDepartment.Modify(department, department.ID);
        }
        private string AddNewDepartment(Department department)
        {
            return tblDepartment.InsertAndGetLastID(department);
        }
        private void RefreshForm()
        {
            txtName.Text = "";
            txtDescription.Text = "";
            txtCode.Text = "";
        }
        private bool CheckDepartmentName()
        {
            if (this.ID != "")
            {
                foreach (Department department in Staticpool.departments)
                {
                    if (department.ID != this.ID && department.Name == txtName.Text)
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                foreach (Department department in Staticpool.departments)
                {
                    if (department.Name == txtName.Text)
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