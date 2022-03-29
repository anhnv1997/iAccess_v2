using iAccess.Databases;
using iAccess.Enums;
using iAccess.Objects.Devices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iAccess.Forms.Device_frms
{
    public partial class frmCamera : Form
    {
        private string ID;
        public frmCamera(string id)
        {
            InitializeComponent();
            this.ID = id;
        }
        public static void LoadCameraType(ComboBox comboBox)
        {
            foreach (int i in Enum.GetValues(typeof(EM_CameraType)))
            {
                comboBox.Items.Add(Enum.GetName(typeof(EM_CameraType), i));
            }
            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = 0;
            }
        }
        public static void LoadStreammType(ComboBox comboBox)
        {
            foreach (int i in Enum.GetValues(typeof(EM_StreamType)))
            {
                comboBox.Items.Add(Enum.GetName(typeof(EM_StreamType), i));
            }
            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = 0;
            }
        }
        public static void LoadResolution(ComboBox comboBox)
        {
            foreach (int i in Enum.GetValues(typeof(EM_Resolution)))
            {
                comboBox.Items.Add(Enum.GetName(typeof(EM_Resolution), i));
            }
            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = 0;
            }
        }
        public static void LoadSDK(ComboBox comboBox)
        {
            foreach (int i in Enum.GetValues(typeof(EM_SDK)))
            {
                comboBox.Items.Add(Enum.GetName(typeof(EM_SDK), i));
            }
            if (comboBox.Items.Count > 0)
            {
                comboBox.SelectedIndex = 0;
            }
        }
        private void frmCamera_Load(object sender, EventArgs e)
        {
            LoadCameraType(cbCameraType);
            LoadStreammType(cbStreamType);
            LoadResolution(cbResolution);
            LoadSDK(cbSDK);
            if(this.ID != "")
            {
                Camera camera = Staticpool.Cameras.GetCameraByID(this.ID);
                txtID.Text = this.ID;
                txtName.Text = camera.Name;
                txtCode.Text = camera.Code;
                txtDescription.Text = camera.Description;
                txtIP.Text= camera.IP;
                txtPort.Text = camera.Port+"";
                txtServerPort.Text = camera.ServerPort.ToString();
                txtUsername.Text = camera.Username;
                txtPassword.Text = camera.Password;
                txtChannel.Text = camera.Channel.ToString();
                cbCameraType.SelectedIndex = (int)camera.CameraType;
                cbStreamType.SelectedIndex = (int)camera.StreamType;
                cbResolution.SelectedIndex = (int)camera.Resolution;
                cbSDK.SelectedIndex = (int)camera.SDK;
                chbInUse.Checked = camera.isInUse;
            }
            else
            {
                cbCameraType.SelectedIndex = cbCameraType.Items.Count>0?0:-1;
                cbStreamType.SelectedIndex = cbStreamType.Items.Count > 0 ? 0 : -1;
                cbResolution.SelectedIndex = cbResolution.Items.Count > 0 ? 0 : -1;
                chbInUse.Checked = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckCameraName())
            {
                MessageBox.Show("This camera name is already used, please try another name!");
                return;
            }
            Camera camera = this.ID == "" ? new Camera() : Staticpool.Cameras.GetCameraByID(this.ID);
            camera.Name = txtName.Text;
            camera.Code = txtCode.Text;
            camera.Description = txtDescription.Text;
            camera.IP = txtIP.Text;
            camera.Port = Convert.ToInt32(txtPort.Text);
            camera.ServerPort = Convert.ToInt32(txtServerPort.Text);
            camera.Username = txtUsername.Text;
            camera.Password = txtPassword.Text;
            camera.Channel = Convert.ToInt32(txtChannel.Text);
            camera.CameraType = (EM_CameraType)cbCameraType.SelectedIndex;
            camera.StreamType = (EM_StreamType)cbStreamType.SelectedIndex;
            camera.Resolution = (EM_Resolution)cbResolution.SelectedIndex;
            camera.SDK = (EM_SDK)cbSDK.SelectedIndex;
            camera.isInUse = chbInUse.Checked;
            if (this.ID != "")
            {
                if (EditCameraInfor(camera))
                {
                    MessageBox.Show("Edit Camera Infor Success");
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Edit Camera Infor Error, please try again later!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                string cameraID = AddNewCamera(camera);
                if (cameraID != "")
                {
                    camera.ID = cameraID;
                    Staticpool.Cameras.Add(camera);
                    if (MessageBox.Show("Add Camera Infor Success, do you want to add another camera?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        RefreshForm();
                    }
                    else
                    {
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
        }
        private bool EditCameraInfor(Camera camera)
        {
            return tblCamera.Modify(camera, camera.ID);
        }
        private string AddNewCamera(Camera camera)
        {
            return tblCamera.InsertAndGetLastID(camera);
        }
        private void RefreshForm()
        {
            txtName.Text = "";
            txtCode.Text = "";
            txtDescription.Text = "";
            txtIP.Text = "";
            txtPort.Text = "";
            txtServerPort.Text = "";
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtChannel.Text = "";
            cbCameraType.SelectedIndex = 0;
            cbStreamType.SelectedIndex = 0;
            cbResolution.SelectedIndex = 0;
            cbSDK.SelectedIndex = 0;
            chbInUse.Checked = true;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }
        private bool CheckCameraName()
        {
            if (this.ID != "")
            {
                foreach (Camera camera in Staticpool.Cameras)
                {
                    if (camera.ID != this.ID && camera.Name == txtName.Text)
                    {
                        return false;
                    }
                }
                return true;
            }
            else
            {
                foreach (Camera camera in Staticpool.Cameras)
                {
                    if (camera.Name == txtName.Text)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            btnSave.Enabled = txtName.Text != "";
        }
    }
}