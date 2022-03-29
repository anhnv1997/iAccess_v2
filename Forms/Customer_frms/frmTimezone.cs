using iAccess.Databases;
using iAccess.Objects.Customers.Cards;
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
    public partial class frmTimezone : Form
    {
        private string ID;
        public frmTimezone(string id)
        {
            InitializeComponent();
            this.ID = id;
        }
        private void frmTimezone_Load(object sender, EventArgs e)
        {
            if (this.ID != "")
            {
                AccessTimezone timezone = Staticpool.timezones.GetTimezoneByID(this.ID);
                txtID.Text = timezone.ID;
                txtName.Text = timezone.Name;
                txtCode.Text = timezone.Code;
                txtDescription.Text = timezone.Description;
                dtpStartMON.Value = timezone.StartMON;
                dtpEndMON.Value = timezone.EndMON;
                dtpStartTUE.Value = timezone.StartTUE;
                dtpEndTUE.Value = timezone.EndTUE;
                dtpStartWED.Value = timezone.StartWED;
                dtpEndWED.Value = timezone.EndWED;
                dtpStartTHU.Value = timezone.StartTHU;
                dtpEndTHU.Value = timezone.EndTHU;
                dtpStartFRI.Value = timezone.StartFRI;
                dtpEndFRI.Value = timezone.EndFRI;
                dtpStartSAT.Value = timezone.StartSAT;
                dtpEndSAT.Value = timezone.EndSAT;
                dtpStartSUN.Value = timezone.StartSUN;
                dtpEndSUN.Value = timezone.EndSUN;
                chbIsInUse.Checked = timezone.IsInUse;
            }
            else
            {
                chbIsInUse.Checked = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                MessageBox.Show("Please type the Timezone Name");
            }
            if (!CheckTimezoneName())
            {
                MessageBox.Show("This timezone name is already used, please try another name!");
                return;
            }

            AccessTimezone timezone = this.ID == "" ? new AccessTimezone() : Staticpool.timezones.GetTimezoneByID(this.ID);
            timezone.Name = txtName.Text;
            timezone.Code = txtCode.Text;
            timezone.Description = txtDescription.Text;
            timezone.StartMON = dtpStartMON.Value;
            timezone.EndMON = dtpEndMON.Value;
            timezone.StartTUE = dtpStartTUE.Value;
            timezone.EndTUE = dtpEndTUE.Value;
            timezone.StartWED = dtpStartWED.Value;
            timezone.EndWED = dtpEndWED.Value;
            timezone.StartTHU = dtpStartTHU.Value;
            timezone.EndTHU = dtpEndTHU.Value;
            timezone.StartFRI = dtpStartFRI.Value;
            timezone.EndFRI = dtpEndFRI.Value;
            timezone.StartSAT = dtpStartSAT.Value;
            timezone.EndSAT = dtpEndSAT.Value;
            timezone.StartSUN = dtpStartSUN.Value;
            timezone.EndSUN = dtpEndSUN.Value;
            timezone.IsInUse = chbIsInUse.Checked;
            if (this.ID != "")
            {
                if (EditTimezone(timezone))
                {
                    MessageBox.Show("Edit Timezone Infor Success");
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Edit Timezone Infor Error, please try again later!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                string TimezoneID = AddNewTimezone(timezone);
                if (TimezoneID != "")
                {
                    timezone.ID = TimezoneID;
                    Staticpool.timezones.Add(timezone);
                    if (MessageBox.Show("Add Timezone Infor Success, do you want to add another Timezone?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
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

        private bool CheckTimezoneName()
        {
            if (this.ID != "")
            {
                foreach (AccessTimezone timezone in Staticpool.timezones)
                {
                    if (timezone.ID != this.ID && timezone.Name == txtName.Text)
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                foreach (AccessTimezone timezone in Staticpool.timezones)
                {
                    if (timezone.Name == txtName.Text)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        private bool EditTimezone(AccessTimezone timezone)
        {
            return tblTimezone.Modify(timezone, timezone.ID);
        }
        private string AddNewTimezone(AccessTimezone timezone)
        {
            return tblTimezone.InsertAndGetLastID(timezone);
        }
        private void RefreshForm()
        {
            txtName.Text = "";
            txtDescription.Text = "";
            txtCode.Text = "";
            chbIsInUse.Checked = true;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if(txtName.Text == "")
            {
                btnSave.Enabled = false;
            }
            else
            {
                btnSave.Enabled = true;
            }
        }
    }
}