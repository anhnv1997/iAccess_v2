using iAccess.Databases;
using iAccess.Objects.Customers.Cards;
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

namespace iAccess.Forms.Customer_frms
{
    public partial class frmCardPrivilege : Form
    {
        List<Controller_Door_Detail> UnUsedOutputs;
        List<Controller_Door_Detail> InUsedOutputs;

        private string ID;
        public frmCardPrivilege(string id)
        {
            InitializeComponent();
            this.ID = id;
        }

        private void frmCardPrivilege_Load(object sender, EventArgs e)
        {
            LoadTimezone(cbTimezone);
            chlbUnSelected.DisplayMember = "Text";
            chlbUnSelected.ValueMember = "Value";
            chlbSelected.DisplayMember = "Text";
            chlbSelected.ValueMember = "Value";
            UnUsedOutputs = new List<Controller_Door_Detail>();
            InUsedOutputs = new List<Controller_Door_Detail>();

            foreach (Controller_Door_Detail Output in Staticpool.Controller_Doors)
            {
                UnUsedOutputs.Add(Output);
            }
            if (this.ID != "")
            {
                CardPrivilege cardPrivilege = Staticpool.CardPrivileges.GetCardPrivilegeByID(this.ID);
                if (cardPrivilege != null)
                {
                    txtName.Text = cardPrivilege.Name;
                    txtCode.Text = cardPrivilege.Code;
                    txtDescription.Text = cardPrivilege.Description;
                    AccessTimezone timezone = Staticpool.timezones.GetTimezoneByID(cardPrivilege.TimezoneID);
                    if (timezone != null)
                        cbTimezone.SelectedIndex = cbTimezone.FindString(timezone.Name);
                    else
                        cbTimezone.SelectedIndex = 0;
                    foreach (string outputId in cardPrivilege.ControllerDoorIDs)
                    {
                        Controller_Door_Detail output = Staticpool.Controller_Doors.GetControllerDoorByID(outputId);
                        if (output != null)
                        {
                            InUsedOutputs.Add(output);
                            UnUsedOutputs.Remove(output);
                        }
                    }
                }
            }
            chlbSelected.Items.Clear();
            chlbUnSelected.Items.Clear();
            foreach (var item in UnUsedOutputs)
            {
                AccessController controller = Staticpool.controllers.GetControllerByID(item.ControllerID);
                chlbUnSelected.Items.Add(new { Text = item.Name + $" ({controller.Name})", Value = item });
            }
            foreach (var item in InUsedOutputs)
            {
                AccessController controller = Staticpool.controllers.GetControllerByID(item.ControllerID);
                chlbSelected.Items.Add(new { Text = item.Name + $" ({controller.Name})", Value = item });
            }
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            foreach (dynamic item in chlbUnSelected.CheckedItems)
            {
                var output = item.Value as Controller_Door_Detail;
                UnUsedOutputs.Remove(output);
                InUsedOutputs.Add(output);
            }
            chlbSelected.Items.Clear();
            chlbUnSelected.Items.Clear();
            foreach (var item in UnUsedOutputs)
            {
                AccessController controller = Staticpool.controllers.GetControllerByID(item.ControllerID);
                chlbUnSelected.Items.Add(new { Text = item.Name + $" ({controller.Name})", Value = item });
            }
            foreach (var item in InUsedOutputs)
            {
                AccessController controller = Staticpool.controllers.GetControllerByID(item.ControllerID);
                chlbSelected.Items.Add(new { Text = item.Name + $" ({controller.Name})", Value = item });
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (dynamic item in chlbUnSelected.Items)
            {
                var output = item.Value as Controller_Door_Detail;
                UnUsedOutputs.Remove(output);
                InUsedOutputs.Add(output);
            }
            chlbSelected.Items.Clear();
            chlbUnSelected.Items.Clear();
            foreach (var item in UnUsedOutputs)
            {
                AccessController controller = Staticpool.controllers.GetControllerByID(item.ControllerID);
                chlbUnSelected.Items.Add(new { Text = item.Name + $" ({controller.Name})", Value = item });
            }
            foreach (var item in InUsedOutputs)
            {
                AccessController controller = Staticpool.controllers.GetControllerByID(item.ControllerID);
                chlbSelected.Items.Add(new { Text = item.Name + $" ({controller.Name})", Value = item });
            }
        }

        private void btnUnSelect_Click(object sender, EventArgs e)
        {
            foreach (dynamic item in chlbSelected.CheckedItems)
            {
                var output = item.Value as Controller_Door_Detail;
                InUsedOutputs.Remove(output);
                UnUsedOutputs.Add(output);
            }
            chlbSelected.Items.Clear();
            chlbUnSelected.Items.Clear();
            foreach (var item in UnUsedOutputs)
            {
                AccessController controller = Staticpool.controllers.GetControllerByID(item.ControllerID);
                chlbUnSelected.Items.Add(new { Text = item.Name + $" ({controller.Name})", Value = item });
            }
            foreach (var item in InUsedOutputs)
            {
                AccessController controller = Staticpool.controllers.GetControllerByID(item.ControllerID);
                chlbSelected.Items.Add(new { Text = item.Name + $" ({controller.Name})", Value = item });
            }
        }

        private void btnUnSelectAll_Click(object sender, EventArgs e)
        {
            foreach (dynamic item in chlbSelected.Items)
            {
                var output = item.Value as Controller_Door_Detail;
                InUsedOutputs.Remove(output);
                UnUsedOutputs.Add(output);
            }
            chlbSelected.Items.Clear();
            chlbUnSelected.Items.Clear();
            foreach (var item in UnUsedOutputs)
            {
                AccessController controller = Staticpool.controllers.GetControllerByID(item.ControllerID);
                chlbUnSelected.Items.Add(new { Text = item.Name + $" ({controller.Name})", Value = item });
            }
            foreach (var item in InUsedOutputs)
            {
                AccessController controller = Staticpool.controllers.GetControllerByID(item.ControllerID);
                chlbSelected.Items.Add(new { Text = item.Name + $" ({controller.Name})", Value = item });
            }
        }
        public static void LoadTimezone(ComboBox comboBox)
        {
            foreach (AccessTimezone timezone in Staticpool.timezones)
            {
                ListItem listTimezone = new ListItem();
                listTimezone.Value = timezone.ID;
                listTimezone.Name = timezone.Name;
                comboBox.Items.Add(listTimezone);
            }
            comboBox.DisplayMember = "Name";
            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = 0;
            }
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            string controllerDoorIDs = "";
            foreach (var item in InUsedOutputs)
            {
                controllerDoorIDs += item.ID + ",";
            }
            string timezoneID = ((ListItem)cbTimezone.SelectedItem).Value;

            if (!CheckCardPrivilegeName())
            {
                MessageBox.Show("This card privilege name is already used, please try another name!");
                return;
            }
            CardPrivilege cardPrivilege = this.ID != "" ? Staticpool.CardPrivileges.GetCardPrivilegeByID(this.ID) : new CardPrivilege();
            cardPrivilege.ID = this.ID;
            cardPrivilege.Name = txtName.Text;
            cardPrivilege.Code = txtCode.Text;
            cardPrivilege.Description = txtDescription.Text;
            cardPrivilege.ControllerDoorIDs = controllerDoorIDs.Split(',').ToList();
            cardPrivilege.TimezoneID = timezoneID;
            if (this.ID != "")
            {
                if (EditCardPrivilegeInfor(cardPrivilege))
                {
                    MessageBox.Show("Edit Card Infor Success");
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Edit Card Privilege Infor Error, please try again later!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                string cardPrivilegeID = AddNewCardPrivilege(cardPrivilege);
                if (cardPrivilegeID != "")
                {
                    cardPrivilege.ID = cardPrivilegeID;
                    Staticpool.CardPrivileges.Add(cardPrivilege);
                    MessageBox.Show("Add Card Privilege Infor Success:");
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private bool EditCardPrivilegeInfor(CardPrivilege cardPrivilege)
        {
            return tblCardPrivilege.Modify(cardPrivilege, cardPrivilege.ID);
        }
        private string AddNewCardPrivilege(CardPrivilege cardPrivilege)
        {
            return tblCardPrivilege.InsertAndGetLastID(cardPrivilege);
        }

        private bool CheckCardPrivilegeName()
        {
            if (this.ID != "")
            {
                foreach (CardPrivilege cardPrivilege in Staticpool.CardPrivileges)
                {
                    if (cardPrivilege.ID != this.ID && cardPrivilege.Name == txtName.Text)
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                foreach (CardPrivilege cardPrivilege in Staticpool.CardPrivileges)
                {
                    if (cardPrivilege.Name == txtName.Text)
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
