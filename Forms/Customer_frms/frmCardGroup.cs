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
    public partial class frmCardGroup : Form
    {
        private string ID;
        public frmCardGroup(string id)
        {
            InitializeComponent();
            this.ID = id;
        }

        private void frmCardGroup_Load(object sender, EventArgs e)
        {
            if (this.ID != "")
            {
                CardGroup cardGroup = Staticpool.CardGroups.GetCardGroupByID(this.ID);
                if (cardGroup != null)
                {
                    txtName.Text = cardGroup.Name;
                    txtCode.Text = cardGroup.Code;
                    txtDescription.Text = cardGroup.Description;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckCardGroupName())
            {
                MessageBox.Show("This card group name is already used, please try another name!");
                return;
            }

            CardGroup cardGroup = this.ID == "" ? new CardGroup() : Staticpool.CardGroups.GetCardGroupByID(this.ID);
            cardGroup.Name = txtName.Text;
            cardGroup.Code = txtCode.Text;
            cardGroup.Description = txtDescription.Text;
            if (this.ID != "")
            {
                if (EditCardGroupInfor(cardGroup))
                {
                    MessageBox.Show("Edit Card  group Infor Success");
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Edit Card group Infor Error, please try again later!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                string cardGroupID = AddNewCard(cardGroup);
                if (cardGroupID != "")
                {
                    cardGroup.ID = cardGroupID;
                    Staticpool.CardGroups.Add(cardGroup);
                    if (MessageBox.Show("Add Card Group Infor Success, do you want to add another card group?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
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
        private bool EditCardGroupInfor(CardGroup cardGroup)
        {
            return tblCardGroup.Modify(cardGroup, cardGroup.ID);
        }
        private string AddNewCard(CardGroup cardGroup)
        {
            return tblCardGroup.InsertAndGetLastID(cardGroup);
        }
        private void RefreshForm()
        {
            txtName.Text = "";
            txtDescription.Text = "";
            txtCode.Text = "";
        }

        private bool CheckCardGroupName()
        {
            if (this.ID != "")
            {
                foreach (CardGroup cardGroup in Staticpool.CardGroups)
                {
                    if (cardGroup.ID != this.ID && cardGroup.Name == txtName.Text)
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                foreach (CardGroup cardGroup in Staticpool.CardGroups)
                {
                    if (cardGroup.Name == txtName.Text)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled =false;
            }
        }
    }
}
