using iAccess.Databases;
using iAccess.Forms.Customer_frms;
using iAccess.Objects.Customers.Cards;
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
    public partial class ucTimezone : UserControl
    {
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 11;

        /// //////////////////////////////////////////////////////////////////////////////

        #region:Properties
        private const string Tittle = "Timezone Information";

        private int currentPage = 0;
        private int maxPage = 1;
        private int maxRecordPerPage = 50;

        #endregion: End Properties

        /// //////////////////////////////////////////////////////////////////////////////
       #region: Constructor
        public ucTimezone()
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
            DatagridViewHelper.EnableFastLoadGridView(dgvTimezone);
            LoadTimezoneData(_currentPage);
            DatagridViewHelper.DisableFastLoadGridView(dgvTimezone);
        }

        void LoadTimezoneData(int _currentPage)
        {
            txtCurrentPage.Text = (currentPage + 1).ToString();
            dgvTimezone.Rows.Clear();
            List<AccessTimezone> timezones = null;
            string nameSearch = txtNameSearch.Text ;
            string codeSearch = txtNameSearch.Text ;
            string descriptionSearch = txtNameSearch.Text ;

            timezones = (from AccessTimezone timezone in Staticpool.timezones
                           where timezone.Name.ToLower().Contains(nameSearch.ToLower())
                              || timezone.Code.ToLower().Contains(codeSearch.ToLower())
                              || timezone.Description.ToLower().Contains(descriptionSearch.ToLower())
                           select timezone).ToList();

            this.maxPage = timezones.Count % maxRecordPerPage > 0 ? timezones.Count / maxRecordPerPage + 1 : timezones.Count / maxRecordPerPage;
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
                if (timezones.Count - 1 < i)
                {
                    break;
                }
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvTimezone);
                AccessTimezone timezone = timezones[i];
                row.Cells[0].Value = timezone.ID;
                row.Cells[1].Value = false;
                row.Cells[2].Value = i + 1;
                row.Cells[3].Value = timezone.Name;
                row.Cells[4].Value = timezone.Code;
                row.Cells[5].Value = timezone.Description;
                row.Cells[6].Value = timezone.StartMON.ToString("HH : mm") + "-" + timezone.EndMON.ToString("HH : mm");
                row.Cells[7].Value = timezone.StartTUE.ToString("HH : mm") + "-" + timezone.EndTUE.ToString("HH : mm");
                row.Cells[8].Value = timezone.StartWED.ToString("HH : mm") + "-" + timezone.EndWED.ToString("HH : mm");
                row.Cells[9].Value = timezone.StartTHU.ToString("HH : mm") + "-" + timezone.EndTHU.ToString("HH : mm");
                row.Cells[10].Value = timezone.StartFRI.ToString("HH : mm") + "-" + timezone.EndFRI.ToString("HH : mm");
                row.Cells[11].Value = timezone.StartSAT.ToString("HH : mm") + "-" + timezone.EndSAT.ToString("HH : mm");
                row.Cells[12].Value = timezone.StartSUN.ToString("HH : mm") + "-" + timezone.EndSUN.ToString("HH : mm");
                row.Cells[13].Value = timezone.IsInUse;

                rows.Add(row);
            }
            dgvTimezone.Rows.AddRange(rows.ToArray());
            SendMessage(dgvTimezone.Handle, WM_SETREDRAW, true, 0);
            dgvTimezone.Refresh();

        }

        #endregion:END LOAD

        /// //////////////////////////////////////////////////////////////////////////////

        #region: CRUD
        private void tsbADD_Click(object sender, EventArgs e)
        {
            frmTimezone frm = new frmTimezone("");
            frm.Tag = "Add New Timezone";
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                LoadTimezoneData(currentPage);
            }
        }

        private void tsbEDIT_Click(object sender, EventArgs e)
        {
            string selectedID = Staticpool.Id(dgvTimezone);
            if (selectedID == "")
            {
                MessageBox.Show("Select one record to edit");
                return;
            }
            frmTimezone frm = new frmTimezone(selectedID);
            frm.Tag = "Edit Timezone Infor";
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                LoadTimezoneData(currentPage);
            }
        }

        private void tsbDELETE_Click(object sender, EventArgs e)
        {
            List<string> timezoneIDs = new List<string>();
            foreach (DataGridViewRow row in dgvTimezone.Rows)
            {
                if (Convert.ToBoolean(row.Cells["dgv_Timezone_Select"].Value) == true)
                {
                    timezoneIDs.Add(row.Cells["_ID"].Value.ToString());
                }
            }
            if (timezoneIDs.Count == 0)
            {
                MessageBox.Show("Select at least one record to delete");
                return;
            }
            string deleteCMD = "";
            List<AccessTimezone> deleteTimezones = new List<AccessTimezone>();

            foreach (string timezoneID in timezoneIDs)
            {
                deleteCMD += $"Delete {tblTimezone.TBL_NAME} where {tblTimezone.TBL_COL_ID} = '{timezoneID}' \r\n";
                AccessTimezone timezone = Staticpool.timezones.GetTimezoneByID(timezoneID);
                deleteTimezones.Add(timezone);
            }
            if (!Staticpool.mdb.ExecuteCommand(deleteCMD))
            {
                if (!Staticpool.mdb.ExecuteCommand(deleteCMD))
                {
                    MessageBox.Show("Delete record fail, please try again later!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            MessageBox.Show("Delete Records Success" );
            foreach (AccessTimezone deleteTimezone in deleteTimezones)
            {
                Staticpool.timezones.Remove(deleteTimezone);
            }
            LoadTimezoneData(currentPage);
        }

        private void tsbREFRESH_Click(object sender, EventArgs e)
        {
            tblTimezone.LoadDataTimezone(Staticpool.timezones);
            LoadTimezoneData(currentPage);
        }
        #endregion: END CRUD
        /// //////////////////////////////////////////////////////////////////////////////

        #region: EXCEL IMPORT/EXPORT
        private void tsbIMPORT_Click(object sender, EventArgs e)
        {
            //OpenFileDialog ofd = new OpenFileDialog();
            //ofd.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            //ofd.InitialDirectory = @"C:\";
            //ofd.Title = "Please select an image file to encrypt.";

            //if (ofd.ShowDialog() == DialogResult.OK)
            //{
            //    using (var doc = new SLDocument(ofd.FileName, "Sheet1"))
            //    {
            //        var stats1 = doc.GetWorksheetStatistics();
            //        char startChar = 'A';
            //        List<List<string>> rowdatas = new List<List<string>>();
            //        for (int row = 3; row <= stats1.NumberOfRows; row++)
            //        {
            //            List<string> rowData = new List<string>();
            //            for (int column = 0; column < stats1.NumberOfColumns; column++)
            //            {
            //                char columnName = ((char)(startChar + column));
            //                rowData.Add(doc.GetCellValueAsString(columnName.ToString() + row));
            //            }
            //            rowdatas.Add(rowData);
            //        }
            //        List<AccessTimezone> insertTimezone = new List<AccessTimezone>();
            //        //STT,Name,Description,Card Number,Card Code,Start Time,End Time,Type,Group,Privilege,In Use

            //        foreach (List<string> rowData in rowdatas)
            //        {
            //            AccessTimezone timezone = LoadDepartmentImportData(rowData);
            //            insertTimezone.Add(timezone);
            //        }
            //        tblCardGroup.InsertMultyCardGroup(insertTimezone);
            //    }
            //}
        }
        private void tsbEXPORT_Click(object sender, EventArgs e)
        {
            try
            {
                ExcelTools.CreatReportFile(dgvTimezone, Tittle);
                MessageBox.Show("Export Data Success");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Export Data Error: "+ex.Message);
            }
        }
        #endregion: END EXCEL

        /// //////////////////////////////////////////////////////////////////////////////

        #region: SEARCH
        private void TxtNameSearch_TextChanged(object sender, EventArgs e)
        {
            LoadTimezoneData(currentPage);
        }
        #endregion: END SEARCH

        /// //////////////////////////////////////////////////////////////////////////////

        #region: OTHER CONTROLS IN FORM
        private void dgvDepartment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvTimezone.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        private void chbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvTimezone.Rows)
            {
                row.Cells["dgv_Timezone_Select"].Value = chbSelectAll.Checked;
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
            LoadTimezoneData(currentPage);
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            currentPage = maxPage - 1;
            SetLastPageView();
            LoadTimezoneData(currentPage);

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
            LoadTimezoneData(currentPage);
        }

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            currentPage = 0;
            SetFirstPageView();
            LoadTimezoneData(currentPage);
        }

        private void txtCurrentPage_TextChanged(object sender, EventArgs e)
        {

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
        private static CardGroup LoadDepartmentImportData(List<string> rowData)
        {
            string name = rowData[1];
            string description = rowData[2];
            string code = rowData[3];
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
                    else if (Convert.ToInt32(txtCurrentPage.Text) >= Staticpool.timezones.Count)
                    {
                        txtCurrentPage.Text = Staticpool.timezones.Count + "";
                    }
                }
                currentPage = Convert.ToInt32(txtCurrentPage.Text) - 1;
                LoadTimezoneData(currentPage);
            }
        }

        private void ucTimezone_KeyDown(object sender, KeyEventArgs e)
        {

        }

        #endregion: END EXCEL IMPORT

        #endregion: END INTERNAL

        /// //////////////////////////////////////////////////////////////////////////////
    }
}
