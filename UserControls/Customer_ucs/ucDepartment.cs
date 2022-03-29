using iAccess.Databases;
using iAccess.Forms.Customer_frms;
using iAccess.Objects.Customers;
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
    public partial class ucDepartment : UserControl
    {
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 11;

        /// //////////////////////////////////////////////////////////////////////////////

        #region:Properties
        private const string Tittle = "Department Information";

        private int currentPage = 0;
        private int maxPage = 1;
        private int maxRecordPerPage = 50;

        #endregion: End Properties

        /// //////////////////////////////////////////////////////////////////////////////
       #region: Constructor
        public ucDepartment()
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
            DatagridViewHelper.EnableFastLoadGridView(dgvDepartment);
            LoadDepartmentData(_currentPage);
            DatagridViewHelper.DisableFastLoadGridView(dgvDepartment);
        }

        void LoadDepartmentData(int _currentPage)
        {
            txtCurrentPage.Text = (currentPage + 1).ToString();
            dgvDepartment.Rows.Clear();
            List<Department> departments = null;
            string nameSearch = txtNameSearch.Text == "Name, Card Number, Card Code" ? "" : txtNameSearch.Text;
            string codeSearch = txtNameSearch.Text == "Name, Card Number, Card Code" ? "" : txtNameSearch.Text;
            string descriptionSearch = txtNameSearch.Text == "Name, Card Number, Card Code" ? "" : txtNameSearch.Text;

            departments = (from Department department in Staticpool.departments
                          where department.Name.ToLower().Contains(nameSearch.ToLower())
                             || department.Code.ToLower().Contains(codeSearch.ToLower())
                             || department.Description.ToLower().Contains(descriptionSearch.ToLower())
                          select department).ToList();

            this.maxPage = departments.Count % maxRecordPerPage > 0 ? departments.Count / maxRecordPerPage + 1 : departments.Count / maxRecordPerPage;
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
                if(currentPage ==0)
                    SetFirstPageView();
            }
            List<DataGridViewRow> rows = new List<DataGridViewRow>();

            for (int i = (int)(maxRecordPerPage * (_currentPage)); i < (int)(maxRecordPerPage * (_currentPage + 1)); i++)
            {
                if (departments.Count - 1 < i)
                {
                    break;
                }
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvDepartment);
                Department department = departments[i];
                row.Cells[0].Value = department.ID;
                row.Cells[1].Value = false;
                row.Cells[2].Value = i + 1;
                row.Cells[3].Value = department.Name;
                row.Cells[4].Value = department.Code;
                row.Cells[5].Value = department.Description;
                rows.Add(row);
            }
            dgvDepartment.Rows.AddRange(rows.ToArray());
            SendMessage(dgvDepartment.Handle, WM_SETREDRAW, true, 0);
            dgvDepartment.Refresh();

        }

        #endregion:END LOAD

        /// //////////////////////////////////////////////////////////////////////////////

        #region: CRUD
        private void tsbADD_Click(object sender, EventArgs e)
        {
            frmDepartment frm = new frmDepartment("");
            frm.Tag = "Add New Department";
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                LoadDepartmentData(currentPage);
            }
        }

        private void tsbEDIT_Click(object sender, EventArgs e)
        {
            string selectedID = Staticpool.Id(dgvDepartment);
            if (selectedID == "")
            {
                MessageBox.Show("Select one record to edit");
                return;
            }
            frmDepartment frm = new frmDepartment(selectedID);
            frm.Tag = "Edit Department Infor";
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                LoadDepartmentData(currentPage);
            }
        }

        private void tsbDELETE_Click(object sender, EventArgs e)
        {
            List<string> departmentIDs = new List<string>();
            foreach (DataGridViewRow row in dgvDepartment.Rows)
            {
                if (Convert.ToBoolean(row.Cells["dgv_Department_Select"].Value) == true)
                {
                    departmentIDs.Add(row.Cells["_ID"].Value.ToString());
                }
            }
            if (departmentIDs.Count == 0)
            {
                MessageBox.Show("Select at least one record to delete");
                return;
            }
            string deleteCMD = "";
            List<Department> deleteDepartments = new List<Department>();

            foreach (string departmentID in departmentIDs)
            {
                deleteCMD += $"Delete {tblDepartment.TBL_NAME} where {tblDepartment.TBL_COL_ID} = '{departmentID}' \r\n";
                Department department = Staticpool.departments.GetDepartmentByID(departmentID);
                deleteDepartments.Add(department);
            }
            if (!Staticpool.mdb.ExecuteCommand(deleteCMD))
            {
                if (!Staticpool.mdb.ExecuteCommand(deleteCMD))
                {
                    MessageBox.Show("Delete record fail, please try again later!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            foreach (Department deleteCardGroup in deleteDepartments)
            {
                Staticpool.departments.Remove(deleteCardGroup);
            }
            LoadDepartmentData(currentPage);
        }

        private void tsbREFRESH_Click(object sender, EventArgs e)
        {
            tblDepartment.LoadDataDepartment(Staticpool.departments);
            LoadDepartmentData(currentPage);
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
            ExcelTools.CreatReportFile(dgvDepartment, Tittle);
        }
        #endregion: END EXCEL

        /// //////////////////////////////////////////////////////////////////////////////

        #region: SEARCH
        private void TxtNameSearch_TextChanged(object sender, EventArgs e)
        {
            LoadDepartmentData(currentPage);
        }
        #endregion: END SEARCH

        /// //////////////////////////////////////////////////////////////////////////////

        #region: OTHER CONTROLS IN FORM
        private void dgvDepartment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvDepartment.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        private void chbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvDepartment.Rows)
            {
                row.Cells["dgv_Department_Select"].Value = chbSelectAll.Checked;
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
            LoadDepartmentData(currentPage);
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            currentPage = maxPage - 1;
            SetLastPageView();
            LoadDepartmentData(currentPage);

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
            LoadDepartmentData(currentPage);
        }

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            currentPage = 0;
            SetFirstPageView();
            LoadDepartmentData(currentPage);
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
                    else if (Convert.ToInt32(txtCurrentPage.Text) >= Staticpool.departments.Count)
                    {
                        txtCurrentPage.Text = Staticpool.departments.Count + "";
                    }
                }
                currentPage = Convert.ToInt32(txtCurrentPage.Text) - 1;
                LoadDepartmentData(currentPage);
            }
        }
        #endregion: END EXCEL IMPORT

        #endregion: END INTERNAL

        /// //////////////////////////////////////////////////////////////////////////////
    }
}

