using iAccess.Databases;
using iAccess.Enums;
using iAccess.Objects.Cards;
using iAccess.Objects.Customers.Cards;
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
using static KztekObject.Cards.CardFactory;

namespace iAccess.Forms.Customer_frms
{
    public partial class frmCard : Form
    {
        public string ID { get; set; }
        public frmCard(string id)
        {
            InitializeComponent();
            this.ID = id;
        }

        private void frmCard_Load(object sender, EventArgs e)
        {
            LoadCardType(cbCardType);
            LoadCardGroup(cbCardGroup);
            LoadCardPrivilege(cbCardPrivilege);
            if (this.ID != "")
            {
                Card card = Staticpool.Cards.GetCardByID(this.ID);
                txtName.Text = card.Name;
                txtDescription.Text = card.Description;
                txtCardNumber.Text = card.CardNumber;
                txtCardCode.Text = card.CardCode;
                dtpStartTime.Value = card.StartTime;
                dtpEndTime.Value = card.EndTime;

                cbCardType.SelectedIndex = (int)card.CardType;

                CardGroup cardGroup = Staticpool.CardGroups.GetCardGroupByID(card.CardGroupID);
                if (cardGroup != null)
                    cbCardGroup.SelectedIndex = cbCardGroup.FindString(cardGroup.Name);
                else
                    cbCardGroup.SelectedIndex = 0;

                CardPrivilege cardPrivilege = Staticpool.CardPrivileges.GetCardPrivilegeByID(card.CardPrivilegeID);
                if (cardPrivilege != null)
                    cbCardPrivilege.SelectedIndex = cbCardPrivilege.FindString(cardPrivilege.Name);
                else
                    cbCardPrivilege.SelectedIndex = 0;

                chbInUse.Checked = card.isInUse;
            }
            else
            {
                chbInUse.Checked = true;
            }
                
        }
        #region:Internal
        public static void LoadCardType(ComboBox comboBox)
        {
            foreach (int i in Enum.GetValues(typeof(EM_CardType)))
            {
                comboBox.Items.Add(Enum.GetName(typeof(EM_CardType), i));
            }
            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = 0;
            }
        }
        public static void LoadCardGroup(ComboBox comboBox)
        {
            foreach (CardGroup cardGroup in Staticpool.CardGroups)
            {
                ListItem listCardGroup = new ListItem();
                listCardGroup.Value = cardGroup.ID;
                listCardGroup.Name = cardGroup.Name;
                comboBox.Items.Add(listCardGroup);
            }
            comboBox.DisplayMember = "Name";
            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = 0;
            }
        }
        public static void LoadCardPrivilege(ComboBox comboBox)
        {
            foreach (CardPrivilege cardPrivilege in Staticpool.CardPrivileges)
            {
                ListItem listCardPrivilege = new ListItem();
                listCardPrivilege.Value = cardPrivilege.ID;
                listCardPrivilege.Name = cardPrivilege.Name;
                comboBox.Items.Add(listCardPrivilege);
            }
            comboBox.DisplayMember = "Name";
            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = 0;
            }
        }

        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckCardName())
            {
                MessageBox.Show("This card name is already used, please try another name!");
                return;
            }
            if (!CheckCardNumber())
            {
                MessageBox.Show("This card number is already used, please try another number!");
                return;
            }
            if (!CheckCardCode())
            {
                MessageBox.Show("This card code is already used, please try another code!");
                return;
            }

            Card card = this.ID != "" ? Staticpool.Cards.GetCardByID(this.ID) : new Card();
            card.ID = this.ID;
            card.Name = txtName.Text;
            card.Code = "";
            card.Description = txtDescription.Text;
            card.CardCode = txtCardCode.Text;
            card.CardNumber = txtCardNumber.Text;
            card.StartTime = dtpStartTime.Value;
            card.EndTime = dtpEndTime.Value;
            card.CardType = (EM_CardType)cbCardType.SelectedIndex;
            card.CardGroupID = ((ListItem)cbCardGroup.SelectedItem).Value;
            card.CardPrivilegeID = ((ListItem)cbCardPrivilege.SelectedItem).Value;
            card.isInUse = chbInUse.Checked;
            if (this.ID != "")
            {
                if (EditCardInfor(card))
                {
                    MessageBox.Show("Edit Card Infor Success");
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Edit Card Infor Error, please try again later!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                string cardID = AddNewCard(card);
                if (cardID != "")
                {
                    card.ID = cardID;
                    Staticpool.Cards.Add(card);
                    if(MessageBox.Show("Add Card Infor Success, do you want to add another card?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
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
        private bool EditCardInfor(Card card)
        {
            return tblCard.Modify(card, card.ID);
        }
        private string AddNewCard(Card card)
        {
            return tblCard.InsertAndGetLastID(card);
        }
        private void RefreshForm()
        {
            txtName.Text = "";
            txtDescription.Text = "";
            txtCardNumber.Text = "";
            txtCardCode.Text = "";
            dtpStartTime.Value = DateTime.Now;
            dtpEndTime.Value = DateTime.Now;
            cbCardType.SelectedIndex = 0;
            cbCardGroup.SelectedIndex = cbCardGroup.Items.Count > 0 ? 0 : -1;
            cbCardPrivilege.SelectedIndex = cbCardPrivilege.Items.Count > 0 ? 0 : -1;
            chbInUse.Checked = true;
        }

        private bool CheckCardName()
        {
            if (this.ID != "")
            {
                foreach (Card card in Staticpool.Cards)
                {
                    if (card.ID != this.ID && card.Name == txtName.Text)
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                foreach (Card card in Staticpool.Cards)
                {
                    if (card.Name == txtName.Text)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        private bool CheckCardNumber()
        {
            if (this.ID != "")
            {
                foreach (Card card in Staticpool.Cards)
                {
                    if (card.ID != this.ID && card.CardNumber == txtCardNumber.Text)
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                foreach (Card card in Staticpool.Cards)
                {
                    if (card.CardNumber == txtCardNumber.Text)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        private bool CheckCardCode()
        {
            if (this.ID != "")
            {
                foreach (Card card in Staticpool.Cards)
                {
                    if (card.ID != this.ID && card.CardCode == txtCardCode.Text)
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                foreach (Card card in Staticpool.Cards)
                {
                    if (card.CardCode == txtCardCode.Text)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        private void txtCardNumber_TextChanged(object sender, EventArgs e)
        {
            if(txtCardNumber.Text!=""&&txtCardCode.Text != "" && txtName.Text != "")
            {
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtCardNumber.Text != "" && txtCardCode.Text != "" && txtName.Text != "")
            {
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
            }
        }

        private void txtCardCode_TextChanged(object sender, EventArgs e)
        {
            if (txtCardNumber.Text != "" && txtCardCode.Text != "" && txtName.Text != "")
            {
                btnSave.Enabled = true;
            }
            else
            {
                btnSave.Enabled = false;
            }
        }
    }
}
