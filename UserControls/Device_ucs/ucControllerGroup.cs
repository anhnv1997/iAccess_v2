using iAccess.Databases;
using iAccess.Forms.Customer_frms;
using iAccess.Forms.Device_frms;
using iAccess.Objects.Customers;
using iAccess.Objects.Customers.Cards;
using iAccess.Objects.Devices;
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

namespace iAccess.UserControls.Device_ucs
{
    public partial class ucControllerGroup : UserControl
    {
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 11;

        /// //////////////////////////////////////////////////////////////////////////////

        #region:Properties
        private const string Tittle = "Controller Group Information";

        private int currentPage = 0;
        private int maxPage = 1;
        private int maxRecordPerPage = 50;

        #endregion: End Properties

        /// //////////////////////////////////////////////////////////////////////////////
       #region: Constructor
        public ucControllerGroup()
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
            DatagridViewHelper.EnableFastLoadGridView(dgvControllerGroup);
            LoadControllerGroupData(_currentPage);
            DatagridViewHelper.DisableFastLoadGridView(dgvControllerGroup);
        }

        void LoadControllerGroupData(int _currentPage)
        {
            txtCurrentPage.Text = (currentPage + 1).ToString();
            dgvControllerGroup.Rows.Clear();
            List<ControllerGroup> controllerGroups = null;
            string nameSearch = txtNameSearch.Text;
            string codeSearch = txtNameSearch.Text;
            string descriptionSearch = txtNameSearch.Text;

            controllerGroups = (from ControllerGroup controllerGroup in Staticpool.controllerGroups
                                where controllerGroup.Name.ToLower().Contains(nameSearch.ToLower())
                                   || controllerGroup.Code.ToLower().Contains(codeSearch.ToLower())
                                   || controllerGroup.Description.ToLower().Contains(descriptionSearch.ToLower())
                                select controllerGroup).ToList();

            txtCurrentPage.Text = (_currentPage + 1).ToString();
            this.maxPage = controllerGroups.Count % maxRecordPerPage > 0 ? controllerGroups.Count / maxRecordPerPage + 1 : controllerGroups.Count / maxRecordPerPage;
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
                if (controllerGroups.Count - 1 < i)
                {
                    break;
                }
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvControllerGroup);
                ControllerGroup controllerGroup = controllerGroups[i];
                row.Cells[0].Value = controllerGroup.ID;
                row.Cells[1].Value = false;
                row.Cells[2].Value = i + 1;
                row.Cells[3].Value = controllerGroup.Name;
                row.Cells[4].Value = controllerGroup.Code;
                row.Cells[5].Value = controllerGroup.Description;
                rows.Add(row);
            }
            dgvControllerGroup.Rows.AddRange(rows.ToArray());
            SendMessage(dgvControllerGroup.Handle, WM_SETREDRAW, true, 0);
            dgvControllerGroup.Refresh();

        }

        #endregion:END LOAD

        /// //////////////////////////////////////////////////////////////////////////////

        #region: CRUD
        private void tsbADD_Click(object sender, EventArgs e)
        {
            frmControllerGroup frm = new frmControllerGroup("");
            frm.Tag = "Add New ControllerGroup";
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                LoadControllerGroupData(currentPage);
            }
        }

        private void tsbEDIT_Click(object sender, EventArgs e)
        {
            string selectedID = Staticpool.Id(dgvControllerGroup);
            if (selectedID == "")
            {
                MessageBox.Show("Select one record to edit");
                return;
            }
            frmControllerGroup frm = new frmControllerGroup(selectedID);
            frm.Tag = "Edit Controller Group Infor";
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                LoadControllerGroupData(currentPage);
            }
        }

        private void tsbDELETE_Click(object sender, EventArgs e)
        {
            List<string> controllerGroupIDs = new List<string>();
            foreach (DataGridViewRow row in dgvControllerGroup.Rows)
            {
                if (Convert.ToBoolean(row.Cells["dgv_ControllerGroup_Select"].Value) == true)
                {
                    controllerGroupIDs.Add(row.Cells["_ID"].Value.ToString());
                }
            }
            if (controllerGroupIDs.Count == 0)
            {
                MessageBox.Show("Select at least one record to delete");
                return;
            }
            string deleteCMD = "";
            List<ControllerGroup> deleteControllerGroups = new List<ControllerGroup>();

            foreach (string controllerGroupID in controllerGroupIDs)
            {
                deleteCMD += $"Delete {tblControllerGroup.TBL_NAME} where {tblControllerGroup.TBL_COL_ID} = '{controllerGroupID}' \r\n";
                ControllerGroup controllerGroup = Staticpool.controllerGroups.GetControllerGroupByID(controllerGroupID);
                deleteControllerGroups.Add(controllerGroup);
            }
            if (!Staticpool.mdb.ExecuteCommand(deleteCMD))
            {
                if (!Staticpool.mdb.ExecuteCommand(deleteCMD))
                {
                    MessageBox.Show("Delete record fail, please try again later!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            foreach (ControllerGroup controllerGroup in deleteControllerGroups)
            {
                Staticpool.controllerGroups.Remove(controllerGroup);
            }
            LoadControllerGroupData(currentPage);
        }

        private void tsbREFRESH_Click(object sender, EventArgs e)
        {
            tblControllerGroup.LoadDataControllerGroup(Staticpool.controllerGroups);
            LoadControllerGroupData(currentPage);
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
            //        List<Department> insertDepartments = new List<Department>();
            //        //STT,Name,Description,Card Number,Card Code,Start Time,End Time,Type,Group,Privilege,In Use

            //        foreach (List<string> rowData in rowdatas)
            //        {
            //            Department Department = LoadDepartmentImportData(rowData);
            //            insertDepartments.Add(Department);
            //        }
            //        tblCardGroup.InsertMultyCardGroup(insertDepartments);
            //    }
            //}
        }
        private void tsbEXPORT_Click(object sender, EventArgs e)
        {
            ExcelTools.CreatReportFile(dgvControllerGroup, Tittle);
        }
        #endregion: END EXCEL

        /// //////////////////////////////////////////////////////////////////////////////

        #region: SEARCH
        private void TxtNameSearch_TextChanged(object sender, EventArgs e)
        {
            LoadControllerGroupData(currentPage);
        }
        #endregion: END SEARCH

        /// //////////////////////////////////////////////////////////////////////////////

        #region: OTHER CONTROLS IN FORM
        private void dgvDepartment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvControllerGroup.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        private void chbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvControllerGroup.Rows)
            {
                row.Cells["dgv_ControllerGroup_Select"].Value = chbSelectAll.Checked;
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
            LoadControllerGroupData(currentPage);
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            currentPage = maxPage - 1;
            SetLastPageView();
            LoadControllerGroupData(currentPage);

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
            LoadControllerGroupData(currentPage);
        }

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            currentPage = 0;
            SetFirstPageView();
            LoadControllerGroupData(currentPage);
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
                    else if (Convert.ToInt32(txtCurrentPage.Text) >= Staticpool.controllerGroups.Count)
                    {
                        txtCurrentPage.Text = Staticpool.controllerGroups.Count + "";
                    }
                }
                currentPage = Convert.ToInt32(txtCurrentPage.Text) - 1;
                LoadControllerGroupData(currentPage);
            }
        }
        #endregion: END EXCEL IMPORT

        #endregion: END INTERNAL

        /// //////////////////////////////////////////////////////////////////////////////
    }
}
