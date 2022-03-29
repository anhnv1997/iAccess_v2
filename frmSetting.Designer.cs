
namespace iAccess
{
    partial class frmSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSetting));
            this.tabSetting = new System.Windows.Forms.TabControl();
            this.tabDevice = new System.Windows.Forms.TabPage();
            this.panelDeviceContent = new System.Windows.Forms.Panel();
            this.panelDeviceMenu = new System.Windows.Forms.Panel();
            this.panelDeviceSubMenu = new System.Windows.Forms.Panel();
            this.btnAccessPrivilege = new FontAwesome.Sharp.IconButton();
            this.btnDoor = new FontAwesome.Sharp.IconButton();
            this.btnCamera = new FontAwesome.Sharp.IconButton();
            this.btnControllerGroup = new FontAwesome.Sharp.IconButton();
            this.btnController = new FontAwesome.Sharp.IconButton();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.tabCard = new System.Windows.Forms.TabPage();
            this.panelCardContent = new System.Windows.Forms.Panel();
            this.panelCardSideMenu = new System.Windows.Forms.Panel();
            this.panelCardSubMenu = new System.Windows.Forms.Panel();
            this.btnCard = new FontAwesome.Sharp.IconButton();
            this.btnCardGroup = new FontAwesome.Sharp.IconButton();
            this.btnCardPrivilege = new FontAwesome.Sharp.IconButton();
            this.btnTimezone = new FontAwesome.Sharp.IconButton();
            this.picCardLogo = new System.Windows.Forms.PictureBox();
            this.tabCustomer = new System.Windows.Forms.TabPage();
            this.panelCustomerContent = new System.Windows.Forms.Panel();
            this.panelCustomerMenu = new System.Windows.Forms.Panel();
            this.panelCustomerSubMenu = new System.Windows.Forms.Panel();
            this.btnDepartment = new FontAwesome.Sharp.IconButton();
            this.btnCustomer = new FontAwesome.Sharp.IconButton();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnImageSavePath = new FontAwesome.Sharp.IconButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panelActions = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tabSetting.SuspendLayout();
            this.tabDevice.SuspendLayout();
            this.panelDeviceMenu.SuspendLayout();
            this.panelDeviceSubMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.tabCard.SuspendLayout();
            this.panelCardSideMenu.SuspendLayout();
            this.panelCardSubMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCardLogo)).BeginInit();
            this.tabCustomer.SuspendLayout();
            this.panelCustomerMenu.SuspendLayout();
            this.panelCustomerSubMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabPage1.SuspendLayout();
            this.panelActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabSetting
            // 
            this.tabSetting.Controls.Add(this.tabDevice);
            this.tabSetting.Controls.Add(this.tabCard);
            this.tabSetting.Controls.Add(this.tabCustomer);
            this.tabSetting.Controls.Add(this.tabPage1);
            this.tabSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabSetting.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tabSetting.Location = new System.Drawing.Point(0, 0);
            this.tabSetting.Name = "tabSetting";
            this.tabSetting.SelectedIndex = 0;
            this.tabSetting.Size = new System.Drawing.Size(800, 399);
            this.tabSetting.TabIndex = 0;
            // 
            // tabDevice
            // 
            this.tabDevice.Controls.Add(this.panelDeviceContent);
            this.tabDevice.Controls.Add(this.panelDeviceMenu);
            this.tabDevice.Location = new System.Drawing.Point(4, 24);
            this.tabDevice.Name = "tabDevice";
            this.tabDevice.Size = new System.Drawing.Size(792, 371);
            this.tabDevice.TabIndex = 2;
            this.tabDevice.Text = "Device";
            this.tabDevice.UseVisualStyleBackColor = true;
            // 
            // panelDeviceContent
            // 
            this.panelDeviceContent.BackColor = System.Drawing.Color.Gray;
            this.panelDeviceContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDeviceContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDeviceContent.Location = new System.Drawing.Point(143, 0);
            this.panelDeviceContent.Name = "panelDeviceContent";
            this.panelDeviceContent.Size = new System.Drawing.Size(649, 371);
            this.panelDeviceContent.TabIndex = 2;
            // 
            // panelDeviceMenu
            // 
            this.panelDeviceMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelDeviceMenu.Controls.Add(this.panelDeviceSubMenu);
            this.panelDeviceMenu.Controls.Add(this.pictureBox3);
            this.panelDeviceMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelDeviceMenu.Location = new System.Drawing.Point(0, 0);
            this.panelDeviceMenu.Name = "panelDeviceMenu";
            this.panelDeviceMenu.Size = new System.Drawing.Size(143, 371);
            this.panelDeviceMenu.TabIndex = 0;
            // 
            // panelDeviceSubMenu
            // 
            this.panelDeviceSubMenu.Controls.Add(this.btnAccessPrivilege);
            this.panelDeviceSubMenu.Controls.Add(this.btnDoor);
            this.panelDeviceSubMenu.Controls.Add(this.btnCamera);
            this.panelDeviceSubMenu.Controls.Add(this.btnControllerGroup);
            this.panelDeviceSubMenu.Controls.Add(this.btnController);
            this.panelDeviceSubMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDeviceSubMenu.Location = new System.Drawing.Point(0, 100);
            this.panelDeviceSubMenu.Name = "panelDeviceSubMenu";
            this.panelDeviceSubMenu.Size = new System.Drawing.Size(141, 269);
            this.panelDeviceSubMenu.TabIndex = 3;
            // 
            // btnAccessPrivilege
            // 
            this.btnAccessPrivilege.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAccessPrivilege.IconChar = FontAwesome.Sharp.IconChar.Outdent;
            this.btnAccessPrivilege.IconColor = System.Drawing.Color.Maroon;
            this.btnAccessPrivilege.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAccessPrivilege.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAccessPrivilege.Location = new System.Drawing.Point(0, 192);
            this.btnAccessPrivilege.Name = "btnAccessPrivilege";
            this.btnAccessPrivilege.Size = new System.Drawing.Size(141, 44);
            this.btnAccessPrivilege.TabIndex = 5;
            this.btnAccessPrivilege.Text = "Outputs";
            this.btnAccessPrivilege.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAccessPrivilege.UseVisualStyleBackColor = true;
            this.btnAccessPrivilege.Click += new System.EventHandler(this.btnAccessPrivilege_Click);
            // 
            // btnDoor
            // 
            this.btnDoor.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDoor.IconChar = FontAwesome.Sharp.IconChar.DoorOpen;
            this.btnDoor.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            this.btnDoor.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDoor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDoor.Location = new System.Drawing.Point(0, 144);
            this.btnDoor.Name = "btnDoor";
            this.btnDoor.Size = new System.Drawing.Size(141, 48);
            this.btnDoor.TabIndex = 4;
            this.btnDoor.Text = "Door";
            this.btnDoor.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDoor.UseVisualStyleBackColor = true;
            this.btnDoor.Click += new System.EventHandler(this.btnDoor_Click);
            // 
            // btnCamera
            // 
            this.btnCamera.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCamera.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCamera.IconChar = FontAwesome.Sharp.IconChar.Camera;
            this.btnCamera.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.btnCamera.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCamera.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCamera.Location = new System.Drawing.Point(0, 96);
            this.btnCamera.Name = "btnCamera";
            this.btnCamera.Size = new System.Drawing.Size(141, 48);
            this.btnCamera.TabIndex = 3;
            this.btnCamera.Text = "Camera";
            this.btnCamera.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCamera.UseVisualStyleBackColor = true;
            this.btnCamera.Click += new System.EventHandler(this.btnCamera_Click);
            // 
            // btnControllerGroup
            // 
            this.btnControllerGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnControllerGroup.IconChar = FontAwesome.Sharp.IconChar.Whmcs;
            this.btnControllerGroup.IconColor = System.Drawing.Color.Navy;
            this.btnControllerGroup.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnControllerGroup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnControllerGroup.Location = new System.Drawing.Point(0, 48);
            this.btnControllerGroup.Name = "btnControllerGroup";
            this.btnControllerGroup.Size = new System.Drawing.Size(141, 48);
            this.btnControllerGroup.TabIndex = 2;
            this.btnControllerGroup.Text = "Controller Group";
            this.btnControllerGroup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnControllerGroup.UseVisualStyleBackColor = true;
            this.btnControllerGroup.Click += new System.EventHandler(this.btnControllerGroup_Click);
            // 
            // btnController
            // 
            this.btnController.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnController.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnController.IconChar = FontAwesome.Sharp.IconChar.CashRegister;
            this.btnController.IconColor = System.Drawing.Color.ForestGreen;
            this.btnController.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnController.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnController.Location = new System.Drawing.Point(0, 0);
            this.btnController.Name = "btnController";
            this.btnController.Size = new System.Drawing.Size(141, 48);
            this.btnController.TabIndex = 1;
            this.btnController.Text = "Controller";
            this.btnController.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnController.UseVisualStyleBackColor = true;
            this.btnController.Click += new System.EventHandler(this.btnController_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(141, 100);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.picController);
            // 
            // tabCard
            // 
            this.tabCard.Controls.Add(this.panelCardContent);
            this.tabCard.Controls.Add(this.panelCardSideMenu);
            this.tabCard.Location = new System.Drawing.Point(4, 24);
            this.tabCard.Name = "tabCard";
            this.tabCard.Padding = new System.Windows.Forms.Padding(3);
            this.tabCard.Size = new System.Drawing.Size(792, 371);
            this.tabCard.TabIndex = 0;
            this.tabCard.Text = "Card";
            this.tabCard.UseVisualStyleBackColor = true;
            // 
            // panelCardContent
            // 
            this.panelCardContent.BackColor = System.Drawing.Color.Gray;
            this.panelCardContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCardContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCardContent.Location = new System.Drawing.Point(146, 3);
            this.panelCardContent.Name = "panelCardContent";
            this.panelCardContent.Size = new System.Drawing.Size(643, 365);
            this.panelCardContent.TabIndex = 1;
            // 
            // panelCardSideMenu
            // 
            this.panelCardSideMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCardSideMenu.Controls.Add(this.panelCardSubMenu);
            this.panelCardSideMenu.Controls.Add(this.picCardLogo);
            this.panelCardSideMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelCardSideMenu.Location = new System.Drawing.Point(3, 3);
            this.panelCardSideMenu.Name = "panelCardSideMenu";
            this.panelCardSideMenu.Size = new System.Drawing.Size(143, 365);
            this.panelCardSideMenu.TabIndex = 0;
            // 
            // panelCardSubMenu
            // 
            this.panelCardSubMenu.Controls.Add(this.btnCard);
            this.panelCardSubMenu.Controls.Add(this.btnCardGroup);
            this.panelCardSubMenu.Controls.Add(this.btnCardPrivilege);
            this.panelCardSubMenu.Controls.Add(this.btnTimezone);
            this.panelCardSubMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCardSubMenu.Location = new System.Drawing.Point(0, 100);
            this.panelCardSubMenu.Name = "panelCardSubMenu";
            this.panelCardSubMenu.Size = new System.Drawing.Size(141, 263);
            this.panelCardSubMenu.TabIndex = 1;
            // 
            // btnCard
            // 
            this.btnCard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCard.IconChar = FontAwesome.Sharp.IconChar.AddressCard;
            this.btnCard.IconColor = System.Drawing.Color.DarkMagenta;
            this.btnCard.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCard.Location = new System.Drawing.Point(0, 144);
            this.btnCard.Name = "btnCard";
            this.btnCard.Size = new System.Drawing.Size(141, 48);
            this.btnCard.TabIndex = 1;
            this.btnCard.Text = "Card";
            this.btnCard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCard.UseVisualStyleBackColor = true;
            this.btnCard.Click += new System.EventHandler(this.btnCard_Click);
            // 
            // btnCardGroup
            // 
            this.btnCardGroup.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCardGroup.IconChar = FontAwesome.Sharp.IconChar.AddressBook;
            this.btnCardGroup.IconColor = System.Drawing.Color.DarkRed;
            this.btnCardGroup.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCardGroup.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCardGroup.Location = new System.Drawing.Point(0, 96);
            this.btnCardGroup.Name = "btnCardGroup";
            this.btnCardGroup.Size = new System.Drawing.Size(141, 48);
            this.btnCardGroup.TabIndex = 2;
            this.btnCardGroup.Text = "Card Group";
            this.btnCardGroup.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCardGroup.UseVisualStyleBackColor = true;
            this.btnCardGroup.Click += new System.EventHandler(this.btnCardGroup_Click);
            // 
            // btnCardPrivilege
            // 
            this.btnCardPrivilege.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCardPrivilege.IconChar = FontAwesome.Sharp.IconChar.Lock;
            this.btnCardPrivilege.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnCardPrivilege.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCardPrivilege.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCardPrivilege.Location = new System.Drawing.Point(0, 48);
            this.btnCardPrivilege.Name = "btnCardPrivilege";
            this.btnCardPrivilege.Size = new System.Drawing.Size(141, 48);
            this.btnCardPrivilege.TabIndex = 3;
            this.btnCardPrivilege.Text = "Card Privilege";
            this.btnCardPrivilege.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCardPrivilege.UseVisualStyleBackColor = true;
            this.btnCardPrivilege.Click += new System.EventHandler(this.btnCardPrivilege_Click);
            // 
            // btnTimezone
            // 
            this.btnTimezone.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnTimezone.IconChar = FontAwesome.Sharp.IconChar.Clock;
            this.btnTimezone.IconColor = System.Drawing.Color.DarkGreen;
            this.btnTimezone.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnTimezone.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTimezone.Location = new System.Drawing.Point(0, 0);
            this.btnTimezone.Name = "btnTimezone";
            this.btnTimezone.Size = new System.Drawing.Size(141, 48);
            this.btnTimezone.TabIndex = 4;
            this.btnTimezone.Text = "Timezone";
            this.btnTimezone.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnTimezone.UseVisualStyleBackColor = true;
            this.btnTimezone.Click += new System.EventHandler(this.btnTimezone_Click);
            // 
            // picCardLogo
            // 
            this.picCardLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.picCardLogo.Image = ((System.Drawing.Image)(resources.GetObject("picCardLogo.Image")));
            this.picCardLogo.Location = new System.Drawing.Point(0, 0);
            this.picCardLogo.Name = "picCardLogo";
            this.picCardLogo.Size = new System.Drawing.Size(141, 100);
            this.picCardLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picCardLogo.TabIndex = 0;
            this.picCardLogo.TabStop = false;
            this.picCardLogo.Click += new System.EventHandler(this.picCardLogo_Click);
            // 
            // tabCustomer
            // 
            this.tabCustomer.Controls.Add(this.panelCustomerContent);
            this.tabCustomer.Controls.Add(this.panelCustomerMenu);
            this.tabCustomer.Location = new System.Drawing.Point(4, 24);
            this.tabCustomer.Name = "tabCustomer";
            this.tabCustomer.Padding = new System.Windows.Forms.Padding(3);
            this.tabCustomer.Size = new System.Drawing.Size(792, 371);
            this.tabCustomer.TabIndex = 1;
            this.tabCustomer.Text = "Customer";
            this.tabCustomer.UseVisualStyleBackColor = true;
            // 
            // panelCustomerContent
            // 
            this.panelCustomerContent.BackColor = System.Drawing.Color.Gray;
            this.panelCustomerContent.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCustomerContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCustomerContent.Location = new System.Drawing.Point(156, 3);
            this.panelCustomerContent.Name = "panelCustomerContent";
            this.panelCustomerContent.Size = new System.Drawing.Size(633, 365);
            this.panelCustomerContent.TabIndex = 1;
            // 
            // panelCustomerMenu
            // 
            this.panelCustomerMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCustomerMenu.Controls.Add(this.panelCustomerSubMenu);
            this.panelCustomerMenu.Controls.Add(this.pictureBox2);
            this.panelCustomerMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelCustomerMenu.Location = new System.Drawing.Point(3, 3);
            this.panelCustomerMenu.Name = "panelCustomerMenu";
            this.panelCustomerMenu.Size = new System.Drawing.Size(153, 365);
            this.panelCustomerMenu.TabIndex = 0;
            // 
            // panelCustomerSubMenu
            // 
            this.panelCustomerSubMenu.Controls.Add(this.btnDepartment);
            this.panelCustomerSubMenu.Controls.Add(this.btnCustomer);
            this.panelCustomerSubMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelCustomerSubMenu.Location = new System.Drawing.Point(0, 100);
            this.panelCustomerSubMenu.Name = "panelCustomerSubMenu";
            this.panelCustomerSubMenu.Size = new System.Drawing.Size(151, 263);
            this.panelCustomerSubMenu.TabIndex = 2;
            // 
            // btnDepartment
            // 
            this.btnDepartment.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDepartment.IconChar = FontAwesome.Sharp.IconChar.Home;
            this.btnDepartment.IconColor = System.Drawing.Color.Green;
            this.btnDepartment.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDepartment.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDepartment.Location = new System.Drawing.Point(0, 48);
            this.btnDepartment.Name = "btnDepartment";
            this.btnDepartment.Size = new System.Drawing.Size(151, 48);
            this.btnDepartment.TabIndex = 3;
            this.btnDepartment.Text = "Department";
            this.btnDepartment.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDepartment.UseVisualStyleBackColor = true;
            this.btnDepartment.Click += new System.EventHandler(this.btnDepartment_Click);
            // 
            // btnCustomer
            // 
            this.btnCustomer.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnCustomer.IconChar = FontAwesome.Sharp.IconChar.UserAlt;
            this.btnCustomer.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnCustomer.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnCustomer.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCustomer.Location = new System.Drawing.Point(0, 0);
            this.btnCustomer.Name = "btnCustomer";
            this.btnCustomer.Size = new System.Drawing.Size(151, 48);
            this.btnCustomer.TabIndex = 1;
            this.btnCustomer.Text = "Customer";
            this.btnCustomer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCustomer.UseVisualStyleBackColor = true;
            this.btnCustomer.Click += new System.EventHandler(this.btnCustomer_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(151, 100);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.picCustomer);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnImageSavePath);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 371);
            this.tabPage1.TabIndex = 3;
            this.tabPage1.Text = "Other";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnImageSavePath
            // 
            this.btnImageSavePath.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnImageSavePath.IconChar = FontAwesome.Sharp.IconChar.FolderOpen;
            this.btnImageSavePath.IconColor = System.Drawing.Color.DarkRed;
            this.btnImageSavePath.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnImageSavePath.IconSize = 28;
            this.btnImageSavePath.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImageSavePath.Location = new System.Drawing.Point(106, 7);
            this.btnImageSavePath.Name = "btnImageSavePath";
            this.btnImageSavePath.Size = new System.Drawing.Size(190, 29);
            this.btnImageSavePath.TabIndex = 1;
            this.btnImageSavePath.Text = "Selected Path";
            this.btnImageSavePath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImageSavePath.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnImageSavePath.UseVisualStyleBackColor = true;
            this.btnImageSavePath.Click += new System.EventHandler(this.btnImageSavePath_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Image Save Path";
            // 
            // panelActions
            // 
            this.panelActions.Controls.Add(this.btnCancel);
            this.panelActions.Controls.Add(this.btnSave);
            this.panelActions.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelActions.Location = new System.Drawing.Point(0, 399);
            this.panelActions.Name = "panelActions";
            this.panelActions.Size = new System.Drawing.Size(800, 51);
            this.panelActions.TabIndex = 7;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(700, 6);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 40);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(605, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 40);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // frmSetting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabSetting);
            this.Controls.Add(this.panelActions);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSetting";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setting";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmSetting_Load);
            this.tabSetting.ResumeLayout(false);
            this.tabDevice.ResumeLayout(false);
            this.panelDeviceMenu.ResumeLayout(false);
            this.panelDeviceSubMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.tabCard.ResumeLayout(false);
            this.panelCardSideMenu.ResumeLayout(false);
            this.panelCardSubMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCardLogo)).EndInit();
            this.tabCustomer.ResumeLayout(false);
            this.panelCustomerMenu.ResumeLayout(false);
            this.panelCustomerSubMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.panelActions.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabSetting;
        private System.Windows.Forms.TabPage tabCard;
        private System.Windows.Forms.TabPage tabCustomer;
        private System.Windows.Forms.TabPage tabDevice;
        private System.Windows.Forms.Panel panelActions;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panelCardContent;
        private System.Windows.Forms.Panel panelCardSideMenu;
        private System.Windows.Forms.Panel panelCustomerContent;
        private System.Windows.Forms.Panel panelCustomerMenu;
        private System.Windows.Forms.Panel panelDeviceContent;
        private System.Windows.Forms.Panel panelDeviceMenu;
        private FontAwesome.Sharp.IconButton btnCard;
        private System.Windows.Forms.Panel panelCardSubMenu;
        private System.Windows.Forms.PictureBox picCardLogo;
        private FontAwesome.Sharp.IconButton btnCardGroup;
        private System.Windows.Forms.Panel panelCustomerSubMenu;
        private FontAwesome.Sharp.IconButton btnDepartment;
        private FontAwesome.Sharp.IconButton btnCustomer;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Panel panelDeviceSubMenu;
        private FontAwesome.Sharp.IconButton btnCamera;
        private FontAwesome.Sharp.IconButton btnControllerGroup;
        private FontAwesome.Sharp.IconButton btnController;
        private System.Windows.Forms.PictureBox pictureBox3;
        private FontAwesome.Sharp.IconButton btnCardPrivilege;
        private FontAwesome.Sharp.IconButton btnTimezone;
        private FontAwesome.Sharp.IconButton btnDoor;
        private FontAwesome.Sharp.IconButton btnAccessPrivilege;
        private System.Windows.Forms.TabPage tabPage1;
        private FontAwesome.Sharp.IconButton btnImageSavePath;
        private System.Windows.Forms.Label label1;
    }
}