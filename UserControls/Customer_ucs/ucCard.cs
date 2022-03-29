using iAccess.Databases;
using iAccess.Enums;
using iAccess.Forms.Customer_frms;
using iAccess.Objects.Cards;
using iAccess.Objects.Customers.Cards;
using iParking.Database;
using SpreadsheetLight;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ToolReport;
using static KztekObject.Cards.CardFactory;

namespace iAccess.UserControls.Customer_ucs
{
    public partial class ucCard : UserControl
    {
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 11;

        #region:Properties
        private int currentPage = 0;
        private int maxPage = 1;
        private int maxRecordPerPage = 1;
        #endregion

        #region: CONSTRUCTOR
        public ucCard()
        {
            InitializeComponent();
            ShowDataInGridView(currentPage);
            txtNameSearch.TextChanged += TxtNameSearch_TextChanged;
        }
        #endregion: END CONSTRUCTOR

        #region: CRUD
        private void tsbADD_Click(object sender, EventArgs e)
        {
            frmCard frm = new frmCard("");
            frm.Tag = "Add New card";
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                LoadCardData(currentPage);
            }
        }

        private void tsbEDIT_Click(object sender, EventArgs e)
        {
            string selectedID = Staticpool.Id(dgvCard);
            if (selectedID == "")
            {
                MessageBox.Show("Select one record to edit");
                return;
            }
            frmCard frm = new frmCard(selectedID);
            frm.Tag = "Edit card Infor";
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                LoadCardData(currentPage);
            }
        }

        private void tsbDELETE_Click(object sender, EventArgs e)
        {
            List<string> cardIDs = new List<string>();
            foreach (DataGridViewRow row in dgvCard.Rows)
            {
                if (Convert.ToBoolean(row.Cells["dgv_Cards_Select"].Value) == true)
                {
                    cardIDs.Add(row.Cells["_ID"].Value.ToString());
                }
            }
            if (cardIDs.Count == 0)
            {
                MessageBox.Show("Select at least record to delete");
                return;
            }
            string deleteCMD = "";
            List<Card> deleteCards = new List<Card>();

            foreach (string cardID in cardIDs)
            {
                deleteCMD += $"Delete {tblCard.TBL_NAME} where {tblCard.TBL_COL_ID} = '{cardID}' \r\n";
                Card card = Staticpool.Cards.GetCardByID(cardID);
                deleteCards.Add(card);
            }
            if (!Staticpool.mdb.ExecuteCommand(deleteCMD))
            {
                if (!Staticpool.mdb.ExecuteCommand(deleteCMD))
                {
                    MessageBox.Show("Delete record fail, please try again later!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            foreach (Card deleteCard in deleteCards)
            {
                Staticpool.Cards.Remove(deleteCard);
            }
            LoadCardData(currentPage);
        }

        private void tsbREFRESH_Click(object sender, EventArgs e)
        {
            tblCard.LoadCardData(Staticpool.Cards);
            LoadCardData(currentPage);
        }
        #endregion END CRUD

        #region: EXCEL IMPORT/EXPORT
        private void tsbIMPORT_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            ofd.InitialDirectory = @"C:\";
            ofd.Title = "Please select an excel file to read.";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using (var doc = new SLDocument(ofd.FileName, "Sheet1"))
                {
                    var stats1 = doc.GetWorksheetStatistics();
                    char startChar = 'A';
                    List<List<string>> rowdatas = new List<List<string>>();
                    for (int row = 3; row <= stats1.NumberOfRows; row++)
                    {
                        List<string> rowData = new List<string>();
                        for (int column = 0; column < stats1.NumberOfColumns; column++)
                        {
                            char columnName = ((char)(startChar + column));
                            rowData.Add(doc.GetCellValueAsString(columnName.ToString() + row));
                        }
                        rowdatas.Add(rowData);
                    }
                    List<Card> insertCards = new List<Card>();
                    //STT,Name,Description,Card Number,Card Code,Start Time,End Time,Type,Group,Privilege,In Use

                    foreach (List<string> rowData in rowdatas)
                    {
                        Card card = LoadCardDataImport(rowData);
                        insertCards.Add(card);
                    }
                    tblCard.InsertMultyCard(insertCards);
                }
            }
        }

        private void tsbEXPORT_Click(object sender, EventArgs e)
        {
            ExcelTools.CreatReportFile(dgvCard, "Bảng Hiển Thị Dữ Liệu Thẻ");
        }
        #endregion: END EXCEL IMPORT/EXPORT

        #region: SELECT PAGE
        private void btnNextPage_Click(object sender, EventArgs e)
        {
            if (currentPage == maxPage - 2)
            {
                SetLastPageView();
            }
            else
            {
                SetNormalPageView();
            }
            currentPage++;
            LoadCardData(currentPage);
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            currentPage = maxPage - 1;
            SetLastPageView();
            LoadCardData(currentPage);
        }

        private void btnPreviousPage_Click(object sender, EventArgs e)
        {
            if (currentPage == 1)
            {
                SetFirstPageView();
            }
            else
            {
                SetNormalPageView();
            }
            currentPage--;
            LoadCardData(currentPage);
        }

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            currentPage = 0;
            SetFirstPageView();
            LoadCardData(currentPage);
        }
        #endregion: END SELECT PAGE

        #region: OTHER CONTROLS IN FORM
        private void dgvCard_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvCard.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        private void chbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvCard.Rows)
            {
                row.Cells["dgv_Cards_Select"].Value = chbSelectAll.Checked;
            }
        }
        #endregion

        #region: SEARCH
        //Search Name, Code, Card Number
        private void TxtNameSearch_TextChanged(object sender, EventArgs e)
        {
            LoadCardData(currentPage);
        }
        // Used for both Card Privilege And Card Group
        private void CbSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = (ComboBox)sender;
            LoadCardData(currentPage);
            cb.DroppedDown = false;
        }
        #endregion: END SEARCH

        #region: LOAD
        // Card Group
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
        }
        //Card Privilege
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
        }
        //Card
        public void ShowDataInGridView(int _currentPage)
        {
            DatagridViewHelper.EnableFastLoadGridView(dgvCard);
            LoadCardData(_currentPage);
            DatagridViewHelper.DisableFastLoadGridView(dgvCard);
        }

        void LoadCardData(int _currentPage)
        {
            dgvCard.Rows.Clear();
            List<Card> cards = GetSearchCard();

            this.maxPage = cards.Count % maxRecordPerPage > 0 ? cards.Count / maxRecordPerPage + 1 : cards.Count / maxRecordPerPage;
            maxPage = maxPage > 0 ? maxPage : 1;
            _currentPage = _currentPage >= maxPage - 1 ? maxPage - 1 : _currentPage;

            txtCurrentPage.Text = (_currentPage + 1).ToString();
            lblMaxPage.Text = this.maxPage + "";
            bool isHaveOnly1Page = maxPage - 1 == 0;
            if (isHaveOnly1Page)
            {
                SetHaveOnlyOnePageView();
            }
            else
            {
                if (currentPage == 0)
                    SetFirstPageView();
            }
            List<DataGridViewRow> rows = new List<DataGridViewRow>();

            for (int i = (int)(maxRecordPerPage * (_currentPage)); i < (int)(maxRecordPerPage * (_currentPage + 1)); i++)
            {
                if (cards.Count - 1 < i)
                {
                    break;
                }
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvCard);
                Card card = cards[i];
                CardGroup cardGroup = Staticpool.CardGroups.GetCardGroupByID(card.CardGroupID);
                string cardGroupName = cardGroup == null ? "" : cardGroup.Name;

                CardPrivilege cardPrivilege = Staticpool.CardPrivileges.GetCardPrivilegeByID(card.CardPrivilegeID);
                string cardPrivilegeName = cardPrivilege == null ? "" : cardPrivilege.Name;

                row.Cells[0].Value = card.ID;
                row.Cells[1].Value = false;
                row.Cells[2].Value = i + 1;
                row.Cells[3].Value = card.Name;
                row.Cells[4].Value = card.Code;
                row.Cells[5].Value = card.Description;
                row.Cells[6].Value = card.CardNumber;
                row.Cells[7].Value = card.CardCode;
                row.Cells[8].Value = Staticpool.FormatDateTime(card.StartTime);
                row.Cells[9].Value = Staticpool.FormatDateTime(card.EndTime);
                row.Cells[10].Value = card.CardType;
                row.Cells[11].Value = cardGroupName;
                row.Cells[12].Value = cardPrivilegeName;
                row.Cells[13].Value = card.isInUse == true ? true : false;
                rows.Add(row);
            }
            dgvCard.Rows.AddRange(rows.ToArray());

            SendMessage(dgvCard.Handle, WM_SETREDRAW, true, 0);
            dgvCard.Refresh();


        }

        private List<Card> GetSearchCard()
        {
            List<Card> cards = null;
            string nameSearch = txtNameSearch.Text == "Name, Card Number, Card Code" ? "" : txtNameSearch.Text;
            string cardNumberSearch = txtNameSearch.Text == "Name, Card Number, Card Code" ? "" : txtNameSearch.Text;
            string cardCodeSearch = txtNameSearch.Text == "Name, Card Number, Card Code" ? "" : txtNameSearch.Text;
            string cardGroupID = "";
            string cardPrivilegeID = "";
            cards = (from Card card in Staticpool.Cards
                     where card.CardGroupID.ToLower().Contains(cardGroupID.ToLower())
                        && card.CardPrivilegeID.ToLower().Contains(cardPrivilegeID.ToLower())
                        && (card.CardNumber.ToLower().Contains(cardNumberSearch.ToLower()) || card.CardCode.ToLower().Contains(cardCodeSearch.ToLower()) || card.Name.ToLower().Contains(nameSearch.ToLower()))
                     select card).ToList();
            return cards;
        }
        #endregion: END LOAD

        #region: INTERNAL

        #region: VIEW
        private void SetNormalPageView()
        {
            btnNextPage.Enabled = true;
            btnLastPage.Enabled = true;
            btnFirstPage.Enabled = true;
            btnPreviousPage.Enabled = true;
        }
        private void SetLastPageView()
        {
            btnNextPage.Enabled = false;
            btnLastPage.Enabled = false;
            btnFirstPage.Enabled = true;
            btnPreviousPage.Enabled = true;
        }
        private void SetFirstPageView()
        {
            btnFirstPage.Enabled = false;
            btnPreviousPage.Enabled = false;
            btnNextPage.Enabled = true;
            btnLastPage.Enabled = true;
        }
        private void SetHaveOnlyOnePageView()
        {
            btnFirstPage.Enabled = false;
            btnPreviousPage.Enabled = false;
            btnNextPage.Enabled = false;
            btnLastPage.Enabled = false;
        }
        #endregion: END VIEW

        #region: EXCEL IMPORT
        private static Card LoadCardDataImport(List<string> rowData)
        {
            string name = rowData[1];
            string description = rowData[2];
            string cardNumber = rowData[3];
            string cardCode = rowData[4];
            string startTime = rowData[5];
            string endTime = rowData[6];
            string typeName = rowData[7];
            int cardType = Staticpool.GetCardTypeByName(typeName);
            string groupName = rowData[8];
            string cardGroupID = Staticpool.CardGroups.GetCardGroupIDByName(groupName);
            string privilege = rowData[9];
            string cardPrivilegeID = Staticpool.CardPrivileges.GetCardPrivilegeIDByName(privilege);
            string inUse = rowData[10];
            Card card = new Card()
            {
                Name = name,
                Description = description,
                CardNumber = cardNumber,
                CardCode = cardCode,
                StartTime = DateTime.Parse(startTime),
                EndTime = DateTime.Parse(endTime),
                CardType = (EM_CardType)cardType,
                CardGroupID = cardGroupID,
                CardPrivilegeID = cardPrivilegeID,
                isInUse = Convert.ToBoolean(inUse),
            };
            return card;
        }
        #endregion: END EXCEL IMPORT

        #endregion: END INTERNAL

        private void txtCurrentPage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (System.Text.RegularExpressions.Regex.IsMatch(txtCurrentPage.Text, "[^0-9]"))
                {
                    MessageBox.Show("Hãy nhập số");
                    txtCurrentPage.Text = "1";
                }
                else
                {
                    if (Convert.ToInt32(txtCurrentPage.Text) <= 1)
                    {
                        txtCurrentPage.Text = "1";
                    }
                    else if (Convert.ToInt32(txtCurrentPage.Text) >= Staticpool.Cards.Count)
                    {
                        txtCurrentPage.Text = Staticpool.Cards.Count + "";
                    }                    
                }
                currentPage = Convert.ToInt32(txtCurrentPage.Text) - 1;
                LoadCardData(currentPage);
            }
        }
    }
}

