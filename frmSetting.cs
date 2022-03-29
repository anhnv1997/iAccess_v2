using Extensions;
using FontAwesome.Sharp;
using iAccess.UserControls;
using iAccess.UserControls.Customer_ucs;
using iAccess.UserControls.Device_ucs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace iAccess
{
    public partial class frmSetting : Form
    {
        private IconButton currentBtn;
        private Panel LeftBorderBtn, LeftBorderBtn1, LeftBorderBtn2;
        private UserControl currenChildForm;
        private struct RGBColors
        {
            public static Color ControllerColor = Color.ForestGreen;
            public static Color ControllerGroupColors = Color.Navy;
            public static Color CameraColor = Color.FromArgb(128, 64, 0);
            public static Color DoorColor = Color.FromArgb(192, 0, 192);
            public static Color OutputColor = Color.Maroon;
            public static Color TimezoneColor = Color.DarkGreen;
            public static Color CardPrivilegeColor = Color.FromArgb(255, 128, 0);
            public static Color CardGroupColor = Color.DarkRed;
            public static Color CardColor = Color.DarkMagenta;
            public static Color CustomerColor = Color.FromArgb(255, 128, 0);
            public static Color DepartmentColor = Color.Green;
        }
        public frmSetting()
        {
            InitializeComponent();

        }
        private void frmSetting_Load(object sender, EventArgs e)
        {
            if (Staticpool.FaceImageSavePath != "")
            {
                btnImageSavePath.Text = Staticpool.FaceImageSavePath;
                Size textSize = TextRenderer.MeasureText(btnImageSavePath.Text, btnImageSavePath.Font);
                btnImageSavePath.Width = textSize.Width + 60;
            }
            LeftBorderBtn = new Panel();
            LeftBorderBtn1 = new Panel();
            LeftBorderBtn2 = new Panel();
            LeftBorderBtn.Size = new Size(7, 48);
            LeftBorderBtn1.Size = new Size(7, 48);
            LeftBorderBtn2.Size = new Size(7, 48);
            panelCardSubMenu.Controls.Add(LeftBorderBtn);
            panelCustomerSubMenu.Controls.Add(LeftBorderBtn1);
            panelDeviceSubMenu.Controls.Add(LeftBorderBtn2);
            this.DoubleBuffered = true;

            panelCardContent.ToggleDoubleBuffered(true);
            panelCustomerContent.ToggleDoubleBuffered(true);
            panelDeviceContent.ToggleDoubleBuffered(true);
            tabCard.ToggleDoubleBuffered(true);
            tabCustomer.ToggleDoubleBuffered(true);
            tabDevice.ToggleDoubleBuffered(true);
            tabSetting.ToggleDoubleBuffered(true);
        }
        private async Task ActiveButton(object senderBtn, Color color, Panel leftBorderBtn)
        {
            if (senderBtn != null)
            {
                await DisableButton();
                await Task.Run(new Action(() =>
                {
                    currentBtn = (IconButton)senderBtn;
                    currentBtn.TextAlign = ContentAlignment.MiddleCenter;
                    currentBtn.TextImageRelation = TextImageRelation.TextBeforeImage;
                    currentBtn.ImageAlign = ContentAlignment.MiddleRight;

                    leftBorderBtn?.Invoke(new Action(() =>
                    {
                        leftBorderBtn.BackColor = color;
                        leftBorderBtn.Location = new Point(0, currentBtn.Location.Y);
                        leftBorderBtn.Visible = true;
                        leftBorderBtn.BringToFront();
                    }));


                }));

            }
        }
        private async Task DisableButton()
        {
            await Task.Run(() =>
            {
                if (currentBtn != null)
                {
                    currentBtn?.Invoke(new Action(() =>
                    {
                        currentBtn.TextAlign = ContentAlignment.MiddleLeft;
                        currentBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
                        currentBtn.ImageAlign = ContentAlignment.MiddleLeft;
                    }));
                }
            });
        }

        private async Task DisplayUserControl(UserControl ChildForm, Panel parentPanel, Object sender)
        {
            await Task.Run(() =>
            {
                List<Control> deleteControls = new List<Control>();
                foreach (Control control in parentPanel.Controls)
                {
                    deleteControls.Add(control);
                }
                currenChildForm = ChildForm;
                ChildForm.Dock = DockStyle.Fill;
                parentPanel.BringToFront();
                parentPanel?.Invoke(new Action(() =>
                {
                    parentPanel.Controls.Add(ChildForm);
                    ChildForm.BringToFront();
                    foreach (Control deleteControl in deleteControls)
                    {
                        parentPanel.Controls.Remove(deleteControl);
                    }
                }));
            });
        }


        #region:Card Menu
        private void btnCard_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.CardColor, LeftBorderBtn);
            DisplayUserControl(new ucCard(), panelCardContent, sender);
        }
        private void btnCardGroup_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.CardGroupColor, LeftBorderBtn);
            DisplayUserControl(new ucCardGroup(), panelCardContent, sender);
        }
        private void btnTimezone_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.TimezoneColor, LeftBorderBtn);
            DisplayUserControl(new ucTimezone(), panelCardContent, sender);
        }
        private void btnCardPrivilege_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.CardPrivilegeColor, LeftBorderBtn);
            DisplayUserControl(new ucCardPrivilege(), panelCardContent, sender);
        }
        private void picCardLogo_Click(object sender, EventArgs e)
        {
            ActiveButton(btnCard, RGBColors.CardColor, LeftBorderBtn);
            DisplayUserControl(new ucCard(), panelCardContent, sender);
        }
        #endregion

        #region:Customer Menu
        private void btnCustomer_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.CustomerColor, LeftBorderBtn1);
            DisplayUserControl(new ucCustomer(), panelCustomerContent, sender);
        }

        private void btnDepartment_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.DepartmentColor, LeftBorderBtn1);
            DisplayUserControl(new ucDepartment(), panelCustomerContent, sender);
        }
        private void picCustomer(object sender, EventArgs e)
        {
            ActiveButton(btnCustomer, RGBColors.CustomerColor, LeftBorderBtn1);
            DisplayUserControl(new ucCustomer(), panelCustomerContent, sender);
        }
        #endregion

        #region:Devices Menu
        private void btnController_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.ControllerColor, LeftBorderBtn2);
            DisplayUserControl(new ucController(), panelDeviceContent, sender);
        }

        private void btnDoor_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.DoorColor, LeftBorderBtn2);
            DisplayUserControl(new ucDoor(), panelDeviceContent, sender);
        }

        private void btnAccessPrivilege_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.OutputColor, LeftBorderBtn2);
            DisplayUserControl(new uc_Controller_Door(), panelDeviceContent, sender);
        }

        private void btnControllerGroup_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.ControllerGroupColors, LeftBorderBtn2);
            DisplayUserControl(new ucControllerGroup(), panelDeviceContent, sender);
        }

        private void picController(object sender, EventArgs e)
        {
            ActiveButton(btnController, RGBColors.ControllerColor, LeftBorderBtn2);
            DisplayUserControl(new ucController(), panelDeviceContent, sender);
        }


        private void btnCamera_Click(object sender, EventArgs e)
        {
            ActiveButton(sender, RGBColors.CameraColor, LeftBorderBtn2);
            DisplayUserControl(new ucCamera(), panelDeviceContent, sender);
        }
        #endregion

        #region:Tab Other
        private void btnImageSavePath_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                if (Staticpool.FaceImageSavePath != "")
                {
                    if (Directory.Exists(Staticpool.FaceImageSavePath))
                    {
                        fbd.SelectedPath = Staticpool.FaceImageSavePath;
                    }
                    else
                    {
                        fbd.SelectedPath = Application.StartupPath;
                    }
                }
                else
                {
                    fbd.SelectedPath = Application.StartupPath;
                }
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    btnImageSavePath.Text = fbd.SelectedPath;
                    Properties.Settings.Default.FaceImageSavePath = fbd.SelectedPath;
                    Properties.Settings.Default.Save();
                    Staticpool.FaceImageSavePath = fbd.SelectedPath;
                    Size textSize = TextRenderer.MeasureText(btnImageSavePath.Text, btnImageSavePath.Font);
                    btnImageSavePath.Width = textSize.Width + 60;
                }
            }
        }
        #endregion
    }
}
