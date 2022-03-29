using iAccess.Databases;
using iAccess.Forms;
using iAccess.Forms.Customer_frms;
using iAccess.Forms.Device_frms;
using iAccess.Objects;
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
    public partial class uc_Controller_Door : UserControl
    {
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 11;

        /// //////////////////////////////////////////////////////////////////////////////

        #region:Properties
        private const string Tittle = "Door Information";

        private int currentPage = 0;
        private int maxPage = 1;
        private int maxRecordPerPage = 50;

        #endregion: End Properties

        /// //////////////////////////////////////////////////////////////////////////////
       #region: Constructor
        public uc_Controller_Door()
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
            DatagridViewHelper.EnableFastLoadGridView(dgvController_Door);
            LoadController_DoorData(_currentPage);
            DatagridViewHelper.DisableFastLoadGridView(dgvController_Door);
        }

        void LoadController_DoorData(int _currentPage)
        {
            txtCurrentPage.Text = (currentPage + 1).ToString();
            dgvController_Door.Rows.Clear();
            List<Controller_Door_Detail> controller_doors = null;
            string nameSearch = txtNameSearch.Text ;
            string codeSearch = txtNameSearch.Text;
            string descriptionSearch = txtNameSearch.Text;

            controller_doors = (from Controller_Door_Detail controller_Door in Staticpool.Controller_Doors
                                where controller_Door.Name.ToLower().Contains(nameSearch.ToLower())
                                   || controller_Door.Code.ToLower().Contains(codeSearch.ToLower())
                                   || controller_Door.Description.ToLower().Contains(descriptionSearch.ToLower())
                                select controller_Door).ToList();

            txtCurrentPage.Text = (_currentPage + 1).ToString();
            this.maxPage = controller_doors.Count % maxRecordPerPage > 0 ? controller_doors.Count / maxRecordPerPage + 1 : controller_doors.Count / maxRecordPerPage;
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
                if (controller_doors.Count - 1 < i)
                {
                    break;
                }
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvController_Door);
                Controller_Door_Detail controller_Door = controller_doors[i];
                row.Cells[0].Value = controller_Door.ID;
                row.Cells[1].Value = false;
                row.Cells[2].Value = i + 1;
                row.Cells[3].Value = controller_Door.Name;
                row.Cells[4].Value = controller_Door.Code;
                row.Cells[5].Value = controller_Door.Description;

                AccessController controller = Staticpool.controllers.GetControllerByID(controller_Door.ControllerID);
                row.Cells[6].Value = controller == null ? "" : controller.Name;

                Door door = Staticpool.doors.GetDoorByID(controller_Door.DoorID);
                row.Cells[7].Value = door == null ? "" : door.Name;

                row.Cells[8].Value = controller_Door.ReaderIndex;
                rows.Add(row);
            }
            dgvController_Door.Rows.AddRange(rows.ToArray());
            SendMessage(dgvController_Door.Handle, WM_SETREDRAW, true, 0);
            dgvController_Door.Refresh();

        }

        #endregion:END LOAD

        /// //////////////////////////////////////////////////////////////////////////////

        #region: CRUD
        private void tsbADD_Click(object sender, EventArgs e)
        {
            frmController_Door frm = new frmController_Door("");
            frm.Tag = "Add New Output";
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                LoadController_DoorData(currentPage);
            }
        }

        private void tsbEDIT_Click(object sender, EventArgs e)
        {
            string selectedID = Staticpool.Id(dgvController_Door);
            if (selectedID == "")
            {
                MessageBox.Show("Select one record to edit");
                return;
            }
            frmController_Door frm = new frmController_Door(selectedID);
            frm.Tag = "Edit Output Infor";
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                LoadController_DoorData(currentPage);
            }
        }

        private void tsbDELETE_Click(object sender, EventArgs e)
        {
            List<string> controllerDoorIds = new List<string>();
            foreach (DataGridViewRow row in dgvController_Door.Rows)
            {
                if (Convert.ToBoolean(row.Cells["dgv_Controller_Door_Select"].Value) == true)
                {
                    controllerDoorIds.Add(row.Cells["_ID"].Value.ToString());
                }
            }
            if (controllerDoorIds.Count == 0)
            {
                MessageBox.Show("Select at least one record to delete");
                return;
            }
            string deleteCMD = "";
            List<Controller_Door_Detail> deleteOutputs = new List<Controller_Door_Detail>();

            foreach (string controller_door_id in controllerDoorIds)
            {
                deleteCMD += $"Delete {tblController_Door.TBL_NAME} where {tblController_Door.TBL_COL_ID} = '{controller_door_id}' \r\n";
                Controller_Door_Detail controller_door = Staticpool.Controller_Doors.GetControllerDoorByID(controller_door_id);
                deleteOutputs.Add(controller_door);
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
            foreach (Controller_Door_Detail controller_door in deleteOutputs)
            {
                Staticpool.Controller_Doors.Remove(controller_door);
            }
            LoadController_DoorData(currentPage);
        }
        private void tsbREFRESH_Click(object sender, EventArgs e)
        {
            tblController_Door.LoadDataController_Door(Staticpool.Controller_Doors);
            LoadController_DoorData(currentPage);
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
            ExcelTools.CreatReportFile(dgvController_Door, Tittle);
        }
        #endregion: END EXCEL

        /// //////////////////////////////////////////////////////////////////////////////

        #region: SEARCH
        private void TxtNameSearch_TextChanged(object sender, EventArgs e)
        {
            LoadController_DoorData(currentPage);
        }
        #endregion: END SEARCH

        /// //////////////////////////////////////////////////////////////////////////////

        #region: OTHER CONTROLS IN FORM
        private void dgvDepartment_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvController_Door.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        private void chbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvController_Door.Rows)
            {
                row.Cells["dgv_Controller_Door_Select"].Value = chbSelectAll.Checked;
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
            LoadController_DoorData(currentPage);
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            currentPage = maxPage - 1;
            SetLastPageView();
            LoadController_DoorData(currentPage);

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
            LoadController_DoorData(currentPage);
        }

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            currentPage = 0;
            SetFirstPageView();
            LoadController_DoorData(currentPage);
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
                    else if (Convert.ToInt32(txtCurrentPage.Text) >= Staticpool.Controller_Doors.Count)
                    {
                        txtCurrentPage.Text = Staticpool.Controller_Doors.Count + "";
                    }
                }
                currentPage = Convert.ToInt32(txtCurrentPage.Text) - 1;
                LoadController_DoorData(currentPage);
            }
        }
        #endregion: END EXCEL IMPORT

        #endregion: END INTERNAL

        /// //////////////////////////////////////////////////////////////////////////////
    }
}
