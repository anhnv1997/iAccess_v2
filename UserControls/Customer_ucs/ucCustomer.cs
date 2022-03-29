using iAccess.Databases;
using iAccess.Forms.Customer_frms;
using iAccess.Objects.Cards;
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
    public partial class ucCustomer : UserControl
    {
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, Int32 wMsg, bool wParam, Int32 lParam);
        private const int WM_SETREDRAW = 11;

        /// //////////////////////////////////////////////////////////////////////////////
        #region:Properties
        private const string Tittle = "Customer Information";

        private int currentPage = 0;
        private int maxPage = 1;
        private int maxRecordPerPage = 1;

        #endregion: End Properties
        /// //////////////////////////////////////////////////////////////////////////////
        public ucCustomer()
        {
            InitializeComponent();
            ShowDataInGridView(currentPage);
        }
        /// //////////////////////////////////////////////////////////////////////////////

        #region: LOAD

        public void ShowDataInGridView(int _currentPage)
        {
            DatagridViewHelper.EnableFastLoadGridView(dgvCustomer);
            LoadCustomerData(_currentPage);
            DatagridViewHelper.DisableFastLoadGridView(dgvCustomer);
        }

        void LoadCustomerData(int _currentPage)
        {
            txtCurrentPage.Text = (currentPage + 1).ToString();
            dgvCustomer.Rows.Clear();
            List<Customer> customers = null;
            string nameSearch = txtNameSearch.Text == "Name, Card Number, Card Code" ? "" : txtNameSearch.Text;
            string codeSearch = txtNameSearch.Text == "Name, Card Number, Card Code" ? "" : txtNameSearch.Text;
            string descriptionSearch = txtNameSearch.Text == "Name, Card Number, Card Code" ? "" : txtNameSearch.Text;

            customers = (from Customer customer in Staticpool.customers
                          where customer.Name.ToLower().Contains(nameSearch.ToLower())
                             || customer.Code.ToLower().Contains(codeSearch.ToLower())
                             || customer.Description.ToLower().Contains(descriptionSearch.ToLower())
                          select customer).ToList();

            txtCurrentPage.Text = (_currentPage + 1).ToString();
            this.maxPage = customers.Count % maxRecordPerPage > 0 ? customers.Count / maxRecordPerPage + 1 : customers.Count / maxRecordPerPage;
            maxPage = maxPage > 0 ? maxPage : 1;
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
                if (customers.Count - 1 < i)
                {
                    break;
                }
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dgvCustomer);
                Customer customer = customers[i];
                row.Cells[0].Value = customer.ID;
                row.Cells[1].Value = false;
                row.Cells[2].Value = i + 1;
                row.Cells[3].Value = customer.Name;
                row.Cells[4].Value = customer.Code;
                row.Cells[5].Value = customer.Description;
                row.Cells[6].Value = customer.Email;
                row.Cells[7].Value = customer.Phone;
                row.Cells[8].Value = customer.Address;
                row.Cells[9].Value = customer.Finger1;
                row.Cells[10].Value = customer.FaceData;
                Card mainCard = Staticpool.Cards.GetCardByID(customer.MainCardID);
                Card secondaryCard = Staticpool.Cards.GetCardByID(customer.SecondaryCardID);
                row.Cells[11].Value = mainCard !=null?mainCard.CardNumber:"";
                row.Cells[12].Value = secondaryCard != null ? secondaryCard.CardNumber : "";
                Department department = Staticpool.departments.GetDepartmentByID(customer.DepartmentID);

                row.Cells[13].Value = department != null ? department.Name : ""; 
                rows.Add(row);
            }
            dgvCustomer.Rows.AddRange(rows.ToArray());
            SendMessage(dgvCustomer.Handle, WM_SETREDRAW, true, 0);
            dgvCustomer.Refresh();

            txtNameSearch.TextChanged += TxtNameSearch_TextChanged;
        }

        #endregion:END LOAD

        /// //////////////////////////////////////////////////////////////////////////////

        #region: CRUD
        private void tsbADD_Click(object sender, EventArgs e)
        {
            frmCustomer frm = new frmCustomer("");
            frm.Tag = "Add New Customer";
            frm.Text = "Add New Customer";
            frm.ShowDialog();
            if (frm.isHaveChange)
            {
                LoadCustomerData(currentPage);
            }
        }

        private void tsbEDIT_Click(object sender, EventArgs e)
        {
            string selectedID = Staticpool.Id(dgvCustomer);
            if (selectedID == "")
            {
                MessageBox.Show("Select one record to edit");
                return;
            }
            frmCustomer frm = new frmCustomer(selectedID);
            frm.Tag = "Edit Customer Infor";
            frm.Text = "Edit Customer Infor";
            frm.ShowDialog();
            if (frm.DialogResult == DialogResult.OK)
            {
                LoadCustomerData(currentPage);
            }
        }

        private void tsbDELETE_Click(object sender, EventArgs e)
        {
            List<string> customerIDs = new List<string>();
            foreach (DataGridViewRow row in dgvCustomer.Rows)
            {
                if (Convert.ToBoolean(row.Cells["dgv_Customers_Select"].Value) == true)
                {
                    customerIDs.Add(row.Cells["_ID"].Value.ToString());
                }
            }
            if (customerIDs.Count == 0)
            {
                MessageBox.Show("Select at least one record to delete");
                return;
            }
            string deleteCMD = "";
            List<Customer> deleteCustomer = new List<Customer>();

            foreach (string customerID in customerIDs)
            {
                deleteCMD += $"Delete {tblCustomer.TBL_NAME} where {tblCustomer.TBL_COL_ID} = '{customerID}' \r\n";
                Customer customer = Staticpool.customers.GetCustomerByID(customerID);
                deleteCustomer.Add(customer);
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
            foreach (Customer customer in deleteCustomer)
            {
                Staticpool.customers.Remove(customer);
            }
            LoadCustomerData(currentPage);
        }

        private void tsbREFRESH_Click(object sender, EventArgs e)
        {
            tblCustomer.LoadCustomer(Staticpool.customers);
            LoadCustomerData(currentPage);
        }
        #endregion: END CRUD
        /// //////////////////////////////////////////////////////////////////////////////

        #region: EXCEL IMPORT/EXPORT
        private void tsbIMPORT_Click(object sender, EventArgs e)
        {
            
        }
        private void tsbEXPORT_Click(object sender, EventArgs e)
        {
            ExcelTools.CreatReportFile(dgvCustomer, Tittle);
        }
        #endregion: END EXCEL

        /// //////////////////////////////////////////////////////////////////////////////

        #region: SEARCH
        private void TxtNameSearch_TextChanged(object sender, EventArgs e)
        {
            LoadCustomerData(currentPage);
        }
        #endregion: END SEARCH

        /// //////////////////////////////////////////////////////////////////////////////

        #region: OTHER CONTROLS IN FORM
        private void dgvCustomer_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvCustomer.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }
        private void chbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvCustomer.Rows)
            {
                row.Cells["dgv_Customers_Select"].Value = chbSelectAll.Checked;
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
            LoadCustomerData(currentPage);
        }

        private void btnLastPage_Click(object sender, EventArgs e)
        {
            currentPage = maxPage - 1;
            SetLastPageView();
            LoadCustomerData(currentPage);

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
            LoadCustomerData(currentPage);
        }

        private void btnFirstPage_Click(object sender, EventArgs e)
        {
            currentPage = 0;
            SetFirstPageView();
            LoadCustomerData(currentPage);
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
        private static CardGroup LoadCardGroupDataImport(List<string> rowData)
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
                    else if (Convert.ToInt32(txtCurrentPage.Text) >= Staticpool.customers.Count)
                    {
                        txtCurrentPage.Text = Staticpool.customers.Count + "";
                    }
                }
                currentPage = Convert.ToInt32(txtCurrentPage.Text) - 1;
                LoadCustomerData(currentPage);
            }
        }
        #endregion: END EXCEL IMPORT

        #endregion: END INTERNAL

        /// //////////////////////////////////////////////////////////////////////////////

    }
}
