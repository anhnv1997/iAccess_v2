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
    public partial class ucCamera : UserControl
    {
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 11;

        /// //////////////////////////////////////////////////////////////////////////////

        #region:Properties
        private const string Tittle = "Camera Information";

        private int currentPage = 0;
        private int maxPage = 1;
        private int maxRecordPerPage = 50;

        #endregion: End Properties

        /// //////////////////////////////////////////////////////////////////////////////
       #region: Constructor
        /// 
        public ucCamera()
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
            DatagridViewHelper.EnableFastLoadGridView(dgvCamera);
            LoadCameraData(_currentPage);
            DatagridViewHelper.DisableFastLoadGridView(dgvCamera);
        }

        void LoadCameraData(int _currentPage)
        {
            txtCurrentPage.Text = (currentPage + 1).ToString();
            dgvCamera.Rows.Clear();
            List<Camera> cameras = null;
            string nameSearch = txtNameSearch.Text == "Name, Card Number, Card Code" ? "" : txtNameSearch.Text;
            string codeSearch = txtNameSearch.Text == "Name, Card Number, Card Code" ? "" : txtNameSearch.Text;
            string descriptionSearch = txtNameSearch.Text == "Name, Card Number, Card Code" ? "" : txtNameSearch.Text;

            cameras = (from Camera camera in Staticpool.Cameras
                       where camera.Name.ToLower().Contains(nameSearch.ToLower())
                          || camera.Code.ToLower().Contains(codeSearch.ToLower())
                          || camera.Description.ToLower().Contains(descriptionSearch.ToLower())
                       select camera).ToList();

            txtCurrentPage.Text = (_currentPage + 1).ToString();
            this.maxPage = cameras.Count % maxRecordPerPage > 0 ? cameras.Count / maxRecordPerPage + 1 : cameras.Count / maxRecordPerPage;
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
                if (cameras.Count - 1 < i)
                {
                    break;
                }
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvCamera);
                Camera department = cameras[i];
                row.Cells[0].Value = department.ID;
                row.Cells[1].Value = false;
                row.Cells[2].Value = i + 1;
                row.Cells[3].Value = department.Name;
                row.Cells[4].Value = department.Code;
                row.Cells[5].Value = department.Description;
                row.Cells[6].Value = department.IP;
                row.Cells[7].Value = department.Port;
                row.Cells[8].Value = department.ServerPort;
                row.Cells[9].Value = department.Username;
                row.Cells[10].Value = department.Password;
                row.Cells[11].Value = department.Channel;
                row.Cells[12].Value = department.CameraType;
                row.Cells[13].Value = department.StreamType;
                row.Cells[14].Value = department.Resolution;
                row.Cells[15].Value = department.SDK;
                row.Cells[16].Value = department.isInUse;
                rows.Add(row);
            }
            dgvCamera.Rows.AddRange(rows.ToArray());
            SendMessage(dgvCamera.Handle, WM_SETREDRAW, true, 0);
            dgvCamera.Refresh();
        }

        #endregion:END LOAD

        /// //////////////////////////////////////////////////////////////////////////////

        #region: CRUD
        private void tsbADD_Click(object sender, EventArgs e)
        {
            frmCamera frm = new frmCamera("");
            frm.Tag = "Add New Camera";
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                LoadCameraData(currentPage);
            }
        }

        private void tsbEDIT_Click(object sender, EventArgs e)
        {
            string selectedID = Staticpool.Id(dgvCamera);
            if (selectedID == "")
            {
                MessageBox.Show("Select one record to edit");
                return;
            }
            frmCamera frm = new frmCamera(selectedID);
            frm.Tag = "Edit Camera Infor";
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                LoadCameraData(currentPage);
            }
        }

        private void tsbDELETE_Click(object sender, EventArgs e)
        {
            List<string> cameraIDs = new List<string>();
            foreach (DataGridViewRow row in dgvCamera.Rows)
            {
                if (Convert.ToBoolean(row.Cells["dgv_Camera_Select"].Value) == true)
                {
                    cameraIDs.Add(row.Cells["_ID"].Value.ToString());
                }
            }
            if (cameraIDs.Count == 0)
            {
                MessageBox.Show("Select at least one record to delete");
                return;
            }
            string deleteCMD = "";
            List<Camera> deleteCameras = new List<Camera>();

            foreach (string cameraID in cameraIDs)
            {
                deleteCMD += $"Delete {tblCamera.TBL_Name} where {tblCamera.TBL_COL_ID} = '{cameraID}' \r\n";
                Camera camera = Staticpool.Cameras.GetCameraByID(cameraID);
                deleteCameras.Add(camera);
            }
            if (!Staticpool.mdb.ExecuteCommand(deleteCMD))
            {
                if (!Staticpool.mdb.ExecuteCommand(deleteCMD))
                {
                    MessageBox.Show("Delete record fail, please try again later!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            foreach (Camera camera in deleteCameras)
            {
                Staticpool.Cameras.Remove(camera);
            }
            LoadCameraData(currentPage);
        }

        private void tsbREFRESH_Click(object sender, EventArgs e)
        {
            tblCamera.LoadDataCamera(Staticpool.Cameras);
            LoadCameraData(currentPage);
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
            ExcelTools.CreatReportFile(dgvCamera, Tittle);
        }
        #endregion: END EXCEL

        /// //////////////////////////////////////////////////////////////////////////////

        #region: SEARCH
        private void TxtNameSearch_TextChanged(object sender, EventArgs e)
        {
            LoadCameraData(currentPage);
        }
        #endregion: END SEARCH

        /// //////////////////////////////////////////////////////////////////////////////

        #region: OTHER CONTROLS IN FORM
        private void dgvCamera_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvCamera.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        private void chbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvCamera.Rows)
            {
                row.Cells["dgv_Camera_Select"].Value = chbSelectAll.Checked;
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
            LoadCameraData(currentPage);
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            currentPage = maxPage - 1;
            SetLastPageView();
            LoadCameraData(currentPage);

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
            LoadCameraData(currentPage);
        }

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            currentPage = 0;
            SetFirstPageView();
            LoadCameraData(currentPage);
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
                    else if (Convert.ToInt32(txtCurrentPage.Text) >= Staticpool.Cameras.Count)
                    {
                        txtCurrentPage.Text = Staticpool.Cameras.Count + "";
                    }
                }
                currentPage = Convert.ToInt32(txtCurrentPage.Text) - 1;
                LoadCameraData(currentPage);
            }
        }
        #endregion: END EXCEL IMPORT

        #endregion: END INTERNAL

        /// //////////////////////////////////////////////////////////////////////////////
    }
}
