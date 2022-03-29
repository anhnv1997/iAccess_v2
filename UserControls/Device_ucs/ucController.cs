using iAccess.Databases;
using iAccess.Forms.Device_frms;
using iAccess.Objects.Devices;
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
    public partial class ucController : UserControl
    {
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 11;

        /// //////////////////////////////////////////////////////////////////////////////

        #region:Properties
        private const string Tittle = "Controller Information";

        private int currentPage = 0;
        private int maxPage = 1;
        private int maxRecordPerPage = 50;

        #endregion: End Properties

        /// //////////////////////////////////////////////////////////////////////////////
       #region: Constructor
        /// 
        public ucController()
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
            DatagridViewHelper.EnableFastLoadGridView(dgvController);
            LoadControllerData(_currentPage);
            DatagridViewHelper.DisableFastLoadGridView(dgvController);
        }

        void LoadControllerData(int _currentPage)
        {
            txtCurrentPage.Text = (currentPage + 1).ToString();
            dgvController.Rows.Clear();
            List<AccessController> controllers = null;
            string nameSearch = txtNameSearch.Text == "Name, Card Number, Card Code" ? "" : txtNameSearch.Text;
            string codeSearch = txtNameSearch.Text == "Name, Card Number, Card Code" ? "" : txtNameSearch.Text;
            string descriptionSearch = txtNameSearch.Text == "Name, Card Number, Card Code" ? "" : txtNameSearch.Text;

            controllers = (from AccessController controller in Staticpool.controllers
                           where controller.Name.ToLower().Contains(nameSearch.ToLower())
                              || controller.Code.ToLower().Contains(codeSearch.ToLower())
                              || controller.Description.ToLower().Contains(descriptionSearch.ToLower())
                           select controller).ToList();

            this.maxPage = controllers.Count % maxRecordPerPage > 0 ? controllers.Count / maxRecordPerPage + 1 : controllers.Count / maxRecordPerPage;
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
                if (controllers.Count - 1 < i)
                {
                    break;
                }
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvController);
                AccessController controller = controllers[i];
                row.Cells[0].Value = controller.ID;
                row.Cells[1].Value = false;
                row.Cells[2].Value = i + 1;
                row.Cells[3].Value = controller.Name;
                row.Cells[4].Value = controller.Code;
                row.Cells[5].Value = controller.ControllerType.ToString();
                row.Cells[6].Value = controller.CommunicationType.ToString();
                ControllerGroup controllerGroup = Staticpool.controllerGroups.GetControllerGroupByID(controller.ControllerGroupID);
                row.Cells[7].Value = controllerGroup == null ? "" : controllerGroup.Name;
                row.Cells[8].Value = controller.IP;
                row.Cells[9].Value = controller.Port;
                row.Cells[10].Value = controller.Username;
                row.Cells[11].Value = controller.Password;
                row.Cells[12].Value = controller.DisplayMode.ToString();
                row.Cells[13].Value = controller.ReaderCount;
                row.Cells[14].Value = controller.isInUse;
                rows.Add(row);
            }
            dgvController.Rows.AddRange(rows.ToArray());
            SendMessage(dgvController.Handle, WM_SETREDRAW, true, 0);
            dgvController.Refresh();

        }

        #endregion:END LOAD

        /// //////////////////////////////////////////////////////////////////////////////

        #region: CRUD
        private void tsbADD_Click(object sender, EventArgs e)
        {
            frmController frm = new frmController("");
            frm.Tag = "Add New Controller";
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                LoadControllerData(currentPage);
            }
        }

        private void tsbEDIT_Click(object sender, EventArgs e)
        {
            string selectedID = Staticpool.Id(dgvController);
            if (selectedID == "")
            {
                MessageBox.Show("Select one record to edit");
                return;
            }
            frmController frm = new frmController(selectedID);
            frm.Tag = "Edit Controller Infor";
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                LoadControllerData(currentPage);
            }
        }

        private void tsbDELETE_Click(object sender, EventArgs e)
        {
            List<string> controllerIDs = new List<string>();
            foreach (DataGridViewRow row in dgvController.Rows)
            {
                if (Convert.ToBoolean(row.Cells["dgv_Controller_Select"].Value) == true)
                {
                    controllerIDs.Add(row.Cells["_ID"].Value.ToString());
                }
            }
            if (controllerIDs.Count == 0)
            {
                MessageBox.Show("Select at least one record to delete");
                return;
            }
            string deleteCMD = "";
            List<AccessController> deleteControllers = new List<AccessController>();

            foreach (string controllerID in controllerIDs)
            {
                deleteCMD += $"Delete {tblController.TBL_NAME} where {tblController.TBL_COL_ID} = '{controllerID}' \r\n";
                AccessController controller = Staticpool.controllers.GetControllerByID(controllerID);
                deleteControllers.Add(controller);
            }
            if (!Staticpool.mdb.ExecuteCommand(deleteCMD))
            {
                if (!Staticpool.mdb.ExecuteCommand(deleteCMD))
                {
                    MessageBox.Show("Delete record fail, please try again later!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            foreach (AccessController controller in deleteControllers)
            {
                Staticpool.controllers.Remove(controller);
            }
            LoadControllerData(currentPage);
        }

        private void tsbREFRESH_Click(object sender, EventArgs e)
        {
            tblController.LoadDataController(Staticpool.controllers);
            LoadControllerData(currentPage);
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
            ExcelTools.CreatReportFile(dgvController, Tittle);
        }
        #endregion: END EXCEL

        /// //////////////////////////////////////////////////////////////////////////////

        #region: SEARCH
        private void TxtNameSearch_TextChanged(object sender, EventArgs e)
        {
            LoadControllerData(currentPage);
        }
        #endregion: END SEARCH

        /// //////////////////////////////////////////////////////////////////////////////

        #region: OTHER CONTROLS IN FORM
        private void dgvCamera_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvController.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        private void chbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvController.Rows)
            {
                row.Cells["dgv_Controller_Select"].Value = chbSelectAll.Checked;
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
            LoadControllerData(currentPage);
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            currentPage = maxPage - 1;
            SetLastPageView();
            LoadControllerData(currentPage);

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
            LoadControllerData(currentPage);
        }
        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            currentPage = 0;
            SetFirstPageView();
            LoadControllerData(currentPage);
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
                    else if (Convert.ToInt32(txtCurrentPage.Text) >= Staticpool.controllers.Count)
                    {
                        txtCurrentPage.Text = Staticpool.controllers.Count + "";
                    }
                }
                currentPage = Convert.ToInt32(txtCurrentPage.Text) - 1;
                LoadControllerData(currentPage);
            }
        }
        #endregion: END VIEW

        #region: EXCEL IMPORT
        //private static CardGroup LoadDepartmentImportData(List<string> rowData)
        //{
        //    string name = rowData[1];
        //    string description = rowData[2];
        //    string code = rowData[3];
        //    CardGroup cardGroup = new CardGroup()
        //    {
        //        Name = name,
        //        Description = description,
        //        Code = code,
        //    };
        //    return cardGroup;
        //}
        #endregion: END EXCEL IMPORT

        #endregion: END INTERNAL

        /// //////////////////////////////////////////////////////////////////////////////
    }
}