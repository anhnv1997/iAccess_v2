using iAccess.Databases;
using iAccess.Forms.Customer_frms;
using iAccess.Objects.Customers.Cards;
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

namespace iAccess.UserControls.Customer_ucs
{
    public partial class ucCardGroup : UserControl
    {
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 11;

        /// //////////////////////////////////////////////////////////////////////////////

        #region:Properties
        private const string Tittle = "Card Group Information";

        private int currentPage = 0;
        private int maxPage = 1;
        private int maxRecordPerPage = 1;

        #endregion: End Properties

        /// //////////////////////////////////////////////////////////////////////////////

        #region: Constructor
        public ucCardGroup()
        {
            InitializeComponent();
            ShowDataInGridView(currentPage);
            txtNameSearch.TextChanged += TxtNameSearch_TextChanged;
        }
        #endregion:End Constructor

        /// //////////////////////////////////////////////////////////////////////////////

        #region: LOAD

        public void ShowDataInGridView(int _currentPage)
        {
            DatagridViewHelper.EnableFastLoadGridView(dgvCardGroup);
            LoadCardGroupData(_currentPage);
            DatagridViewHelper.DisableFastLoadGridView(dgvCardGroup);
        }

        void LoadCardGroupData(int _currentPage)
        {
            txtCurrentPage.Text = (currentPage + 1).ToString();
            dgvCardGroup.Rows.Clear();
            List<CardGroup> cardGroups = null;
            string nameSearch = txtNameSearch.Text;
            string codeSearch = txtNameSearch.Text;
            string descriptionSearch = txtNameSearch.Text;

            cardGroups = (from CardGroup cardGroup in Staticpool.CardGroups
                          where cardGroup.Name.ToLower().Contains(nameSearch.ToLower())
                             || cardGroup.Code.ToLower().Contains(codeSearch.ToLower())
                             || cardGroup.Description.ToLower().Contains(descriptionSearch.ToLower())
                          select cardGroup).ToList();

            this.maxPage = cardGroups.Count % maxRecordPerPage > 0 ? cardGroups.Count / maxRecordPerPage + 1 : cardGroups.Count / maxRecordPerPage;
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
                if(currentPage == 0)
                    SetFirstPageView();
            }
            List<DataGridViewRow> rows = new List<DataGridViewRow>();

            for (int i = (int)(maxRecordPerPage * (_currentPage)); i < (int)(maxRecordPerPage * (_currentPage + 1)); i++)
            {
                if (cardGroups.Count - 1 < i)
                {
                    break;
                }
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvCardGroup);
                CardGroup cardGroup = cardGroups[i];
                row.Cells[0].Value = cardGroup.ID;
                row.Cells[1].Value = false;
                row.Cells[2].Value = i + 1;
                row.Cells[3].Value = cardGroup.Name;
                row.Cells[4].Value = cardGroup.Code;
                row.Cells[5].Value = cardGroup.Description;
                rows.Add(row);
            }
            dgvCardGroup.Rows.AddRange(rows.ToArray());
            SendMessage(dgvCardGroup.Handle, WM_SETREDRAW, true, 0);
            dgvCardGroup.Refresh();

        }

        #endregion:END LOAD

        /// //////////////////////////////////////////////////////////////////////////////

        #region: CRUD
        private void tsbADD_Click(object sender, EventArgs e)
        {
            frmCardGroup frm = new frmCardGroup("");
            frm.Tag = "Add New card Group";
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                LoadCardGroupData(currentPage);
            }
        }

        private void tsbEDIT_Click(object sender, EventArgs e)
        {
            string selectedID = Staticpool.Id(dgvCardGroup);
            if (selectedID == "")
            {
                MessageBox.Show("Select one record to edit");
                return;
            }
            frmCardGroup frm = new frmCardGroup(selectedID);
            frm.Tag = "Edit Card Group Infor";
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                LoadCardGroupData(currentPage);
            }
        }

        private void tsbDELETE_Click(object sender, EventArgs e)
        {
            List<string> cardGroupIDs = new List<string>();
            foreach (DataGridViewRow row in dgvCardGroup.Rows)
            {
                if (Convert.ToBoolean(row.Cells["dgv_CardGroup_Select"].Value) == true)
                {
                    cardGroupIDs.Add(row.Cells["_ID"].Value.ToString());
                }
            }
            if (cardGroupIDs.Count == 0)
            {
                MessageBox.Show("Select at least one record to delete");
                return;
            }
            string deleteCMD = "";
            List<CardGroup> deleteCardGroups = new List<CardGroup>();

            foreach (string cardGroupID in cardGroupIDs)
            {
                deleteCMD += $"Delete {tblCardGroup.TBL_NAME} where {tblCardGroup.TBL_COL_ID} = '{cardGroupID}' \r\n";
                CardGroup cardGroup = Staticpool.CardGroups.GetCardGroupByID(cardGroupID);
                deleteCardGroups.Add(cardGroup);
            }
            if (!Staticpool.mdb.ExecuteCommand(deleteCMD))
            {
                if (!Staticpool.mdb.ExecuteCommand(deleteCMD))
                {
                    MessageBox.Show("Delete record fail, please try again later!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            MessageBox.Show("Delete Records Success");
            foreach (CardGroup deleteCardGroup in deleteCardGroups)
            {
                Staticpool.CardGroups.Remove(deleteCardGroup);
            }
            LoadCardGroupData(currentPage);
        }

        private void tsbREFRESH_Click(object sender, EventArgs e)
        {
            tblCardGroup.LoadDataCardGroup(Staticpool.CardGroups);
            LoadCardGroupData(currentPage);
        }
        #endregion: END CRUD
        /// //////////////////////////////////////////////////////////////////////////////

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
                    List<CardGroup> insertCardGroups = new List<CardGroup>();
                    //STT,Name,Description
                    foreach (List<string> rowData in rowdatas)
                    {
                        CardGroup cardGroup = LoadCardGroupDataImport(rowData);
                        insertCardGroups.Add(cardGroup);
                    }

                    if (tblCardGroup.InsertMultyCardGroup(insertCardGroups))
                    {
                        MessageBox.Show("Import Card Group Infor Success");
                        tsbREFRESH_Click(null,null);
                    }
                    else
                    {
                        MessageBox.Show("Import Card Group Infor Fail, Please Try Again Laiter");
                        return;
                    }
                }
            }
        }
        private void tsbEXPORT_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelTools.CreatReportFile(dgvCardGroup, Tittle);
                MessageBox.Show("Export Card Group Infor Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Export Card Group Error: "+ex.Message);

            }

        }
        #endregion: END EXCEL

        /// //////////////////////////////////////////////////////////////////////////////

        #region: SEARCH
        private void TxtNameSearch_TextChanged(object sender, EventArgs e)
        {
            LoadCardGroupData(currentPage);
        }
        #endregion: END SEARCH

        /// //////////////////////////////////////////////////////////////////////////////

        #region: OTHER CONTROLS IN FORM
        private void dgvCardGroup_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvCardGroup.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        private void chbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvCardGroup.Rows)
            {
                row.Cells["dgv_CardGroup_Select"].Value = chbSelectAll.Checked;
            }
        }
        #endregion

        /// //////////////////////////////////////////////////////////////////////////////

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
            LoadCardGroupData(currentPage);
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            currentPage = maxPage - 1;
            SetLastPageView();
            LoadCardGroupData(currentPage);

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
            LoadCardGroupData(currentPage);
        }

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            currentPage = 0;
            SetFirstPageView();
            LoadCardGroupData(currentPage);
        }

        #endregion: END SELECT PAGE

        /// //////////////////////////////////////////////////////////////////////////////

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
        private static CardGroup LoadCardGroupDataImport(List<string> rowData)
        {
            string name = rowData[1];
            string description = rowData[2];
            string code = "";
            CardGroup cardGroup = new CardGroup()
            {
                Name = name,
                Description = description,
                Code = code,
            };
            return cardGroup;
        }

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
                    else if (Convert.ToInt32(txtCurrentPage.Text) >= Staticpool.CardGroups.Count)
                    {
                        txtCurrentPage.Text = Staticpool.CardGroups.Count + "";
                    }                    
                }
                currentPage = Convert.ToInt32(txtCurrentPage.Text) - 1;
                LoadCardGroupData(currentPage);
            }
        }
        #endregion: END EXCEL IMPORT

        #endregion: END INTERNAL

        /// //////////////////////////////////////////////////////////////////////////////
    }
}
