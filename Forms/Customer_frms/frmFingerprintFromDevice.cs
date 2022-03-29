using iAccess.Objects.Devices;
using iParking.Database;
using KztekObject.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iAccess.Forms.Customer_frms
{
    public partial class frmFingerprintFromDevice : Form
    {
        private int FingerIndex;
        public string FingerData { get; set; }
        private string CustomerID;
        public frmFingerprintFromDevice(int fingerIndex, string fingerData)
        {
            InitializeComponent();
            this.FingerData = fingerData;
            this.FingerIndex = fingerIndex;
        }

        private void frmFingerprintFromDevice_Load(object sender, EventArgs e)
        {
            LoadController(cbDevice);
            lblFingerIndex.Text = this.FingerIndex.ToString();
            txtFingerData.Text = this.FingerData;
        }

        public static void LoadController(ComboBox comboBox)
        {
            foreach (AccessController controller in Staticpool.controllers)
            {
                ListItem listController = new ListItem();
                listController.Value = controller.ID;
                listController.Name = controller.Name;
                comboBox.Items.Add(listController);
            }
            comboBox.DisplayMember = "Name";
            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = 0;
            }
        }

        private void btnLoadFinger_Click(object sender, EventArgs e)
        {
            if (cbDevice.Items.Count == 0)
            {
                MessageBox.Show("Please Add Device To Get Finger Data First");
                return;
            }


        }
    }
}
