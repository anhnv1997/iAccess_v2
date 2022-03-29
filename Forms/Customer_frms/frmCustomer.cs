using iAccess.Databases;
using iAccess.Objects.Cards;
using iAccess.Objects.Customers;
using iAccess.UserControls;
using iParking.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iAccess.Forms.Customer_frms
{
    public partial class frmCustomer : Form
    {
        public bool isHaveChange = false;
        private string ID;
        private string[] fingerPrints = new string[10];
        private ucSearchItem ucMainCard;
        private ucSearchItem ucSecondaryCard;

        public frmCustomer(string id)
        {
            InitializeComponent();
            this.ID = id;
        }
        ////////////////////////////////////////////////////////////////////////////
        #region: LOAD
        public static void LoadCard(ComboBox comboBox)
        {
            foreach (Card card in Staticpool.Cards)
            {
                ListItem listCard = new ListItem();
                listCard.Value = card.ID;
                listCard.Name = card.CardCode + " : " + card.CardNumber;
                comboBox.Items.Add(listCard);
            }
            comboBox.DisplayMember = "Name";
        }
        public static void LoadDepartment(ComboBox comboBox)
        {
            foreach (Department department in Staticpool.departments)
            {
                ListItem listDepartment = new ListItem();
                listDepartment.Value = department.ID;
                listDepartment.Name = department.Name;
                comboBox.Items.Add(listDepartment);
            }
            comboBox.DisplayMember = "Name";
            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = 0;
            }
        }
        private void frmCustomer_Load(object sender, EventArgs e)
        {
            List<Card> datas = new List<Card>();
            foreach (Card card in Staticpool.Cards)
            {
                datas.Add(card);
            }
            if (this.ID != "")
            {
                Customer customer = Staticpool.customers.GetCustomerByID(this.ID);
                if (customer != null)
                {
                    ucMainCard = new ucSearchItem(panelCardGroupInfor.Height - cbMainCard.Location.Y - cbMainCard.Height, cbMainCard.Width, typeof(Card), datas.Cast<Object>().ToList(), customer.MainCardID);
                    ucSecondaryCard = new ucSearchItem(panelCardGroupInfor.Height - cbSecondaryCard.Location.Y - cbSecondaryCard.Height, cbSecondaryCard.Width, typeof(Card), datas.Cast<Object>().ToList(), customer.SecondaryCardID);
                }
            }
            else
            {
                ucMainCard = new ucSearchItem(panelCardGroupInfor.Height - cbMainCard.Location.Y - cbMainCard.Height, cbMainCard.Width, typeof(Card), datas.Cast<Object>().ToList(), "");
                ucSecondaryCard = new ucSearchItem(panelCardGroupInfor.Height - cbSecondaryCard.Location.Y - cbSecondaryCard.Height, cbSecondaryCard.Width, typeof(Card), datas.Cast<Object>().ToList(), "");
            }
            ucMainCard.Location = new Point(cbMainCard.Location.X, cbMainCard.Location.Y);
            ucMainCard.BringToFront();
            panelCardGroupInfor.Controls.Add(ucMainCard);
            ucMainCard.Parent.Controls.SetChildIndex(ucMainCard, 1);

            ucSecondaryCard.Location = new Point(cbSecondaryCard.Location.X, cbSecondaryCard.Location.Y);
            ucSecondaryCard.BringToFront();
            panelCardGroupInfor.Controls.Add(ucSecondaryCard);
            ucSecondaryCard.Parent.Controls.SetChildIndex(ucSecondaryCard, 2);
            LoadDepartment(cbDepartment);
            if (this.ID != "")
            {
                Customer customer = Staticpool.customers.GetCustomerByID(this.ID);
                if (customer != null)
                {
                    txtID.Text = customer.ID;
                    txtName.Text = customer.Name;
                    txtCode.Text = customer.Code;
                    txtDescription.Text = customer.Description;
                    txtEmail.Text = customer.Email;
                    txtPhone.Text = customer.Phone;
                    txtAddr.Text = customer.Address;
                    Card mainCard = Staticpool.Cards.GetCardByID(customer.MainCardID);
                    if (mainCard != null)
                    {
                        cbMainCard.SelectedIndex = cbMainCard.FindString(mainCard.Name);
                    }

                    Card secondaryCard = Staticpool.Cards.GetCardByID(customer.SecondaryCardID);
                    if (secondaryCard != null)
                    {
                        cbSecondaryCard.SelectedIndex = cbSecondaryCard.FindString(secondaryCard.Name);
                    }

                    Department department = Staticpool.departments.GetDepartmentByID(customer.DepartmentID);
                    if (department != null)
                    {
                        cbDepartment.SelectedIndex = cbDepartment.FindString(department.Name);
                    }

                    fingerPrints[0] = customer.Finger1 == null?"":customer.Finger1;
                    fingerPrints[1] = customer.Finger2 == null ? "" : customer.Finger2;
                    fingerPrints[2] = customer.Finger3 == null ? "" : customer.Finger3;
                    fingerPrints[3] = customer.Finger4 == null ? "" : customer.Finger4;
                    fingerPrints[4] = customer.Finger5 == null ? "" : customer.Finger5;
                    fingerPrints[5] = customer.Finger6 == null ? "" : customer.Finger6;
                    fingerPrints[6] = customer.Finger7 == null ? "" : customer.Finger7;
                    fingerPrints[7] = customer.Finger8 == null ? "" : customer.Finger8;
                    fingerPrints[8] = customer.Finger9 == null ? "" : customer.Finger9;
                    fingerPrints[9] = customer.Finger10 == null ? "" : customer.Finger10;

                    for(int i = 0; i < fingerPrints.Length; i++)
                    {
                        dgvFingerDatas.Rows.Add(i+1, fingerPrints[i]);
                    }

                    try
                    {
                        var img = Image.FromFile(customer.FaceData);
                        var bmp = new Bitmap(img);
                        picFace.Image = bmp;
                        img.Dispose();
                    }
                    catch { }
                }
            }
            else
            {

                for (int i = 0; i < fingerPrints.Length; i++)
                {
                    dgvFingerDatas.Rows.Add(i + 1, "");
                }
            }


        }
        #endregion: End LOAD
        ////////////////////////////////////////////////////////////////////////////
        #region: SEARCH

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (txtName.Text == "")
            {
                btnSave.Enabled = false;
            }
            else
            {
                btnSave.Enabled = true;
            }
        }
        #endregion: END SEARCH


        #region: CONTROL IN FORM
        //FACE
        private void btnLoadPhotoFromFile(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All files|*.*|Bitmaps|*.bmp|PNG files|*.png|JPEG files|*.jpg|GIF files|*.gif|TIFF files|*.tif|Image files|*.bmp;*.jpg;*.gif;*.png;*.tif";
            ofd.Title = "Load Photo From File";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picFace.Image = Image.FromFile(ofd.FileName);
            }
        }
        private void btnLoadPhotoFromDevice(object sender, EventArgs e)
        {

        }
        #endregion: END CONTROL IN FORM

        ////////////////////////////////////////////////////////////////////////////
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckCustomerName())
            {
                MessageBox.Show("This customer name is already used, please try another name!");
                return;
            }
            if (!CheckCard(ucMainCard.SelectedID))
            {
                MessageBox.Show("This main card is already used by another customer, please set another main card for this customer!");
                return;
            }
            if (!CheckCard(ucSecondaryCard.SelectedID))
            {
                MessageBox.Show("This secondary card is already used by another customer, please set another secondary card for this customer!");
                return;
            }

            Customer customer = this.ID == "" ? new Customer() : Staticpool.customers.GetCustomerByID(this.ID);
            if (picFace.Image != null)
            {
                string faceSavePath = "";
                string rootFaceSavePath = "";
                if (Staticpool.FaceImageSavePath == "")
                {
                    rootFaceSavePath = Application.StartupPath;
                }
                else
                {
                    rootFaceSavePath = Staticpool.FaceImageSavePath;
                }
                faceSavePath = rootFaceSavePath + "\\" + txtName.Text + ".png";
                if (File.Exists(faceSavePath))
                {
                    File.Delete(faceSavePath);
                }
                picFace.Image.Save(faceSavePath);
                customer.FaceData = faceSavePath;
            }
            else
            {
                customer.FaceData = "";
            }
            customer.Name = txtName.Text;
            customer.Code = txtCode.Text;
            customer.Description = txtDescription.Text;
            customer.Email = txtEmail.Text;
            customer.Address = txtAddr.Text;
            customer.Phone = txtPhone.Text;
            customer.MainCardID = ucMainCard.SelectedID == null ? "" : ucMainCard.SelectedID;
            customer.SecondaryCardID = ucSecondaryCard.SelectedID == null ? "" : ucSecondaryCard.SelectedID;
            customer.DepartmentID = ((ListItem)cbDepartment.SelectedItem).Value;
            customer.Finger1 = dgvFingerDatas.Rows[0].Cells[1].Value.ToString();
            customer.Finger2 = dgvFingerDatas.Rows[1].Cells[1].Value.ToString();
            customer.Finger3 = dgvFingerDatas.Rows[2].Cells[1].Value.ToString();
            customer.Finger4 = dgvFingerDatas.Rows[3].Cells[1].Value.ToString();
            customer.Finger5 = dgvFingerDatas.Rows[4].Cells[1].Value.ToString();
            customer.Finger6 = dgvFingerDatas.Rows[5].Cells[1].Value.ToString();
            customer.Finger7 = dgvFingerDatas.Rows[6].Cells[1].Value.ToString();
            customer.Finger8 = dgvFingerDatas.Rows[7].Cells[1].Value.ToString();
            customer.Finger9 = dgvFingerDatas.Rows[8].Cells[1].Value.ToString();
            customer.Finger10 = dgvFingerDatas.Rows[9].Cells[1].Value.ToString();

            if (this.ID != "")
            {
                if (EditCustomerInfor(customer))
                {
                    MessageBox.Show("Edit Customer Infor Success");
                    this.isHaveChange = true;
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Edit Customer  Infor Error, please try again later!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                string customerID = AddNewCustomer(customer);
                if (customerID != "")
                {
                    customer.ID = customerID;
                    Staticpool.customers.Add(customer);
                    if (MessageBox.Show("Add customer infor success, do you want to add another  customer?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        RefreshForm();
                    }
                    else
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                    this.isHaveChange = true;
                }
                else
                {
                    MessageBox.Show("Add customer infor error, please try again later");
                }
            }
        }

        private bool EditCustomerInfor(Customer customer)
        {
            return tblCustomer.Modify(customer, customer.ID);
        }
        private string AddNewCustomer(Customer customer)
        {
            return tblCustomer.InsertAndGetLastID(customer);
        }
        private void RefreshForm()
        {
            txtName.Text = "";
            txtDescription.Text = "";
            txtCode.Text = "";
            txtEmail.Text = "";
            txtAddr.Text = "";
            txtPhone.Text = "";
            cbMainCard.SelectedIndex = -1;
            cbSecondaryCard.SelectedIndex = -1;
            cbDepartment.SelectedIndex = -1;
            picFace.Image = null;
        }
        private bool CheckCustomerName()
        {
            if (this.ID != "")
            {
                foreach (Customer customer in Staticpool.customers)
                {
                    if (customer.ID != this.ID && customer.Name == txtName.Text)
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                foreach (Customer customer in Staticpool.customers)
                {
                    if (customer.Name == txtName.Text)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        private bool CheckCard(string cardID)
        {
            if (this.ID != "")
            {
                foreach (Customer customer in Staticpool.customers)
                {
                    if (customer.ID != this.ID && (customer.MainCardID == cardID || customer.SecondaryCardID == cardID))
                    {
                        return false;
                    }
                }
                return true;

            }
            else
            {
                foreach (Customer customer in Staticpool.customers)
                {
                    if (customer.MainCardID == cardID || customer.SecondaryCardID == cardID)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        private void tsbEditByFile_Click(object sender, EventArgs e)
        {
            string _lcma = "";
            if (dgvFingerDatas != null)
            {
                if (dgvFingerDatas.Rows.Count > 0)
                {
                    DataGridViewRow _drv = dgvFingerDatas.CurrentRow;
                    try
                    {
                        _lcma = _drv.Cells[0].Value.ToString();
                    }
                    catch
                    {
                        _lcma = "";
                    }
                }
            }
            if(_lcma == "")
            {
                MessageBox.Show("Please Select One Record To Edit");
                return;
            }
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Text|*.txt|All|*.*";
            ofd.Title = "Load Finger Data From File";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    dgvFingerDatas.CurrentRow.Cells[1].Value = File.ReadAllText(ofd.FileName);
                    MessageBox.Show("Update Finger Data Success!");
                    return;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Update Finger Data Fail {ex.Message}");
                    return;
                }
                finally
                {
                    GC.Collect();
                }
                
            }
            MessageBox.Show("Update Finger Data Fail!");
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            string _lcma = "";
            if (dgvFingerDatas != null)
            {
                if (dgvFingerDatas.Rows.Count > 0)
                {
                    DataGridViewRow _drv = dgvFingerDatas.CurrentRow;
                    try
                    {
                        _lcma = _drv.Cells[0].Value.ToString();
                    }
                    catch
                    {
                        _lcma = "";
                    }
                }
            }
            if (_lcma == "")
            {
                MessageBox.Show("Please Select One Record To Delete");
                return;
            }
            dgvFingerDatas.CurrentRow.Cells[1].Value = "";
            MessageBox.Show("Delete Finger Data Success");
        }

        private void tsbEditByDevice_Click(object sender, EventArgs e)
        {
            string _lcma = "";
            if (dgvFingerDatas != null)
            {
                if (dgvFingerDatas.Rows.Count > 0)
                {
                    DataGridViewRow _drv = dgvFingerDatas.CurrentRow;
                    try
                    {
                        _lcma = _drv.Cells[0].Value.ToString();
                    }
                    catch
                    {
                        _lcma = "";
                    }
                }
            }
            if (_lcma == "")
            {
                MessageBox.Show("Please Select One Record To Edit");
                return;
            }
            int fingerIndex = Convert.ToInt32(dgvFingerDatas.CurrentRow.Cells[0].Value.ToString());
            string fingerData = dgvFingerDatas.CurrentRow.Cells[1].Value.ToString();
            frmFingerprintFromDevice frm = new frmFingerprintFromDevice(fingerIndex, fingerData);
            frm.ShowDialog();
            if(frm.DialogResult == DialogResult.OK)
            {
                fingerData = frm.FingerData;
                dgvFingerDatas.CurrentRow.Cells[1].Value = fingerData;
            }
        }
        ////////////////////////////////////////////////////////////////////////////
    }
}
