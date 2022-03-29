
namespace iAccess
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.systemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmLanguage = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmVietNamese = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmEnglish = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmControllerSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmDownloadUser = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controller_treeView = new System.Windows.Forms.TreeView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.panelCustomerInfor = new System.Windows.Forms.Panel();
            this.lblEventCustomerTime = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblEventCustomerDepartment = new System.Windows.Forms.Label();
            this.lblEventCustomerName = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblCustomerName = new System.Windows.Forms.Label();
            this.picCustomerFace = new System.Windows.Forms.PictureBox();
            this.panelRealtimeEvent = new System.Windows.Forms.Panel();
            this.RealTimeEventTabControl = new System.Windows.Forms.TabControl();
            this.tabAllEvent = new System.Windows.Forms.TabPage();
            this.dgvRealTimeAllEvent = new System.Windows.Forms.DataGridView();
            this.FacePath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabCardEvent = new System.Windows.Forms.TabPage();
            this.dgvRealtimeCardEvent = new System.Windows.Forms.DataGridView();
            this.FacePath_CardEvent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabFingerEvent = new System.Windows.Forms.TabPage();
            this.dgvRealtimeFingerEvent = new System.Windows.Forms.DataGridView();
            this.tabFaceEvent = new System.Windows.Forms.TabPage();
            this.dgvRealTimeFaceEvent = new System.Windows.Forms.DataGridView();
            this.EventImageList = new System.Windows.Forms.ImageList(this.components);
            this.panelEvent = new System.Windows.Forms.Panel();
            this.timerRefreshStatus = new System.Windows.Forms.Timer(this.components);
            this.btnMenu = new FontAwesome.Sharp.IconButton();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.panelCustomerInfor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCustomerFace)).BeginInit();
            this.panelRealtimeEvent.SuspendLayout();
            this.RealTimeEventTabControl.SuspendLayout();
            this.tabAllEvent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRealTimeAllEvent)).BeginInit();
            this.tabCardEvent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRealtimeCardEvent)).BeginInit();
            this.tabFingerEvent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRealtimeFingerEvent)).BeginInit();
            this.tabFaceEvent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRealTimeFaceEvent)).BeginInit();
            this.panelEvent.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // systemToolStripMenuItem
            // 
            this.systemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmSetting,
            this.tsmLanguage,
            this.tsmExit});
            this.systemToolStripMenuItem.Name = "systemToolStripMenuItem";
            this.systemToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.systemToolStripMenuItem.Text = "System";
            // 
            // tsmSetting
            // 
            this.tsmSetting.Image = ((System.Drawing.Image)(resources.GetObject("tsmSetting.Image")));
            this.tsmSetting.Name = "tsmSetting";
            this.tsmSetting.Size = new System.Drawing.Size(126, 22);
            this.tsmSetting.Text = "Setting";
            this.tsmSetting.Click += new System.EventHandler(this.tsmSetting_Click);
            // 
            // tsmLanguage
            // 
            this.tsmLanguage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmVietNamese,
            this.tsmEnglish});
            this.tsmLanguage.Image = ((System.Drawing.Image)(resources.GetObject("tsmLanguage.Image")));
            this.tsmLanguage.Name = "tsmLanguage";
            this.tsmLanguage.Size = new System.Drawing.Size(126, 22);
            this.tsmLanguage.Text = "Language";
            // 
            // tsmVietNamese
            // 
            this.tsmVietNamese.Image = ((System.Drawing.Image)(resources.GetObject("tsmVietNamese.Image")));
            this.tsmVietNamese.Name = "tsmVietNamese";
            this.tsmVietNamese.Size = new System.Drawing.Size(135, 22);
            this.tsmVietNamese.Text = "Vietnamese";
            // 
            // tsmEnglish
            // 
            this.tsmEnglish.Image = ((System.Drawing.Image)(resources.GetObject("tsmEnglish.Image")));
            this.tsmEnglish.Name = "tsmEnglish";
            this.tsmEnglish.Size = new System.Drawing.Size(135, 22);
            this.tsmEnglish.Text = "English";
            // 
            // tsmExit
            // 
            this.tsmExit.Image = ((System.Drawing.Image)(resources.GetObject("tsmExit.Image")));
            this.tsmExit.Name = "tsmExit";
            this.tsmExit.Size = new System.Drawing.Size(126, 22);
            this.tsmExit.Text = "Exit";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmControllerSetting,
            this.tsmDownloadUser,
            this.testToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // tsmControllerSetting
            // 
            this.tsmControllerSetting.Name = "tsmControllerSetting";
            this.tsmControllerSetting.Size = new System.Drawing.Size(167, 22);
            this.tsmControllerSetting.Text = "Controller Setting";
            this.tsmControllerSetting.Click += new System.EventHandler(this.tsmControllerSetting_Click);
            // 
            // tsmDownloadUser
            // 
            this.tsmDownloadUser.Name = "tsmDownloadUser";
            this.tsmDownloadUser.Size = new System.Drawing.Size(167, 22);
            this.tsmDownloadUser.Text = "Download User";
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.testToolStripMenuItem.Text = "Test";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // controller_treeView
            // 
            this.controller_treeView.Dock = System.Windows.Forms.DockStyle.Left;
            this.controller_treeView.Location = new System.Drawing.Point(0, 24);
            this.controller_treeView.Name = "controller_treeView";
            this.controller_treeView.Size = new System.Drawing.Size(300, 404);
            this.controller_treeView.TabIndex = 1;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // panelCustomerInfor
            // 
            this.panelCustomerInfor.Controls.Add(this.textBox1);
            this.panelCustomerInfor.Controls.Add(this.lblEventCustomerTime);
            this.panelCustomerInfor.Controls.Add(this.label3);
            this.panelCustomerInfor.Controls.Add(this.lblEventCustomerDepartment);
            this.panelCustomerInfor.Controls.Add(this.lblEventCustomerName);
            this.panelCustomerInfor.Controls.Add(this.lblDepartment);
            this.panelCustomerInfor.Controls.Add(this.lblCustomerName);
            this.panelCustomerInfor.Controls.Add(this.picCustomerFace);
            this.panelCustomerInfor.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCustomerInfor.Location = new System.Drawing.Point(0, 0);
            this.panelCustomerInfor.Name = "panelCustomerInfor";
            this.panelCustomerInfor.Size = new System.Drawing.Size(500, 123);
            this.panelCustomerInfor.TabIndex = 0;
            // 
            // lblEventCustomerTime
            // 
            this.lblEventCustomerTime.AutoSize = true;
            this.lblEventCustomerTime.Location = new System.Drawing.Point(244, 66);
            this.lblEventCustomerTime.Name = "lblEventCustomerTime";
            this.lblEventCustomerTime.Size = new System.Drawing.Size(0, 15);
            this.lblEventCustomerTime.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(157, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Time";
            // 
            // lblEventCustomerDepartment
            // 
            this.lblEventCustomerDepartment.AutoSize = true;
            this.lblEventCustomerDepartment.Location = new System.Drawing.Point(244, 39);
            this.lblEventCustomerDepartment.Name = "lblEventCustomerDepartment";
            this.lblEventCustomerDepartment.Size = new System.Drawing.Size(0, 15);
            this.lblEventCustomerDepartment.TabIndex = 4;
            // 
            // lblEventCustomerName
            // 
            this.lblEventCustomerName.AutoSize = true;
            this.lblEventCustomerName.Location = new System.Drawing.Point(244, 11);
            this.lblEventCustomerName.Name = "lblEventCustomerName";
            this.lblEventCustomerName.Size = new System.Drawing.Size(0, 15);
            this.lblEventCustomerName.TabIndex = 3;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(158, 39);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(70, 15);
            this.lblDepartment.TabIndex = 2;
            this.lblDepartment.Text = "Department";
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = true;
            this.lblCustomerName.Location = new System.Drawing.Point(157, 9);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(39, 15);
            this.lblCustomerName.TabIndex = 1;
            this.lblCustomerName.Text = "Name";
            // 
            // picCustomerFace
            // 
            this.picCustomerFace.BackColor = System.Drawing.SystemColors.ControlDark;
            this.picCustomerFace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picCustomerFace.Dock = System.Windows.Forms.DockStyle.Left;
            this.picCustomerFace.Location = new System.Drawing.Point(0, 0);
            this.picCustomerFace.Name = "picCustomerFace";
            this.picCustomerFace.Size = new System.Drawing.Size(152, 123);
            this.picCustomerFace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCustomerFace.TabIndex = 0;
            this.picCustomerFace.TabStop = false;
            // 
            // panelRealtimeEvent
            // 
            this.panelRealtimeEvent.Controls.Add(this.RealTimeEventTabControl);
            this.panelRealtimeEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRealtimeEvent.Location = new System.Drawing.Point(0, 123);
            this.panelRealtimeEvent.Name = "panelRealtimeEvent";
            this.panelRealtimeEvent.Size = new System.Drawing.Size(500, 281);
            this.panelRealtimeEvent.TabIndex = 1;
            // 
            // RealTimeEventTabControl
            // 
            this.RealTimeEventTabControl.Controls.Add(this.tabAllEvent);
            this.RealTimeEventTabControl.Controls.Add(this.tabCardEvent);
            this.RealTimeEventTabControl.Controls.Add(this.tabFingerEvent);
            this.RealTimeEventTabControl.Controls.Add(this.tabFaceEvent);
            this.RealTimeEventTabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RealTimeEventTabControl.ImageList = this.EventImageList;
            this.RealTimeEventTabControl.Location = new System.Drawing.Point(0, 0);
            this.RealTimeEventTabControl.Name = "RealTimeEventTabControl";
            this.RealTimeEventTabControl.SelectedIndex = 0;
            this.RealTimeEventTabControl.Size = new System.Drawing.Size(500, 281);
            this.RealTimeEventTabControl.TabIndex = 0;
            // 
            // tabAllEvent
            // 
            this.tabAllEvent.Controls.Add(this.dgvRealTimeAllEvent);
            this.tabAllEvent.ImageIndex = 0;
            this.tabAllEvent.Location = new System.Drawing.Point(4, 24);
            this.tabAllEvent.Name = "tabAllEvent";
            this.tabAllEvent.Size = new System.Drawing.Size(492, 253);
            this.tabAllEvent.TabIndex = 3;
            this.tabAllEvent.Text = "ALL";
            this.tabAllEvent.UseVisualStyleBackColor = true;
            // 
            // dgvRealTimeAllEvent
            // 
            this.dgvRealTimeAllEvent.AllowUserToAddRows = false;
            this.dgvRealTimeAllEvent.AllowUserToDeleteRows = false;
            this.dgvRealTimeAllEvent.AllowUserToResizeColumns = false;
            this.dgvRealTimeAllEvent.AllowUserToResizeRows = false;
            this.dgvRealTimeAllEvent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvRealTimeAllEvent.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvRealTimeAllEvent.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvRealTimeAllEvent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRealTimeAllEvent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FacePath,
            this.Column7,
            this.Column9,
            this.Column8,
            this.Column10,
            this.Column12,
            this.Column11,
            this.Column13});
            this.dgvRealTimeAllEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRealTimeAllEvent.Location = new System.Drawing.Point(0, 0);
            this.dgvRealTimeAllEvent.Name = "dgvRealTimeAllEvent";
            this.dgvRealTimeAllEvent.ReadOnly = true;
            this.dgvRealTimeAllEvent.RowHeadersVisible = false;
            this.dgvRealTimeAllEvent.RowTemplate.Height = 25;
            this.dgvRealTimeAllEvent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRealTimeAllEvent.Size = new System.Drawing.Size(492, 253);
            this.dgvRealTimeAllEvent.TabIndex = 0;
            // 
            // FacePath
            // 
            this.FacePath.HeaderText = "FacePath";
            this.FacePath.Name = "FacePath";
            this.FacePath.ReadOnly = true;
            this.FacePath.Visible = false;
            this.FacePath.Width = 61;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "ID";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 43;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Time";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 58;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Device Type";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 94;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Device Name";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 102;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "UserID";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Width = 66;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Event Type";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Width = 88;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "Event Status";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.Width = 96;
            // 
            // tabCardEvent
            // 
            this.tabCardEvent.Controls.Add(this.dgvRealtimeCardEvent);
            this.tabCardEvent.ImageIndex = 1;
            this.tabCardEvent.Location = new System.Drawing.Point(4, 24);
            this.tabCardEvent.Name = "tabCardEvent";
            this.tabCardEvent.Padding = new System.Windows.Forms.Padding(3);
            this.tabCardEvent.Size = new System.Drawing.Size(492, 253);
            this.tabCardEvent.TabIndex = 0;
            this.tabCardEvent.Text = "CARD";
            this.tabCardEvent.UseVisualStyleBackColor = true;
            // 
            // dgvRealtimeCardEvent
            // 
            this.dgvRealtimeCardEvent.AllowUserToAddRows = false;
            this.dgvRealtimeCardEvent.AllowUserToDeleteRows = false;
            this.dgvRealtimeCardEvent.AllowUserToResizeColumns = false;
            this.dgvRealtimeCardEvent.AllowUserToResizeRows = false;
            this.dgvRealtimeCardEvent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvRealtimeCardEvent.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvRealtimeCardEvent.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvRealtimeCardEvent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRealtimeCardEvent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.FacePath_CardEvent,
            this.Column1,
            this.Column6,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dgvRealtimeCardEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRealtimeCardEvent.Location = new System.Drawing.Point(3, 3);
            this.dgvRealtimeCardEvent.Name = "dgvRealtimeCardEvent";
            this.dgvRealtimeCardEvent.ReadOnly = true;
            this.dgvRealtimeCardEvent.RowHeadersVisible = false;
            this.dgvRealtimeCardEvent.RowTemplate.Height = 25;
            this.dgvRealtimeCardEvent.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRealtimeCardEvent.Size = new System.Drawing.Size(486, 247);
            this.dgvRealtimeCardEvent.TabIndex = 0;
            // 
            // FacePath_CardEvent
            // 
            this.FacePath_CardEvent.HeaderText = "FacePath";
            this.FacePath_CardEvent.Name = "FacePath_CardEvent";
            this.FacePath_CardEvent.ReadOnly = true;
            this.FacePath_CardEvent.Visible = false;
            this.FacePath_CardEvent.Width = 61;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 43;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Time";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 58;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Controller";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 85;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Reader";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 68;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Card Number";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 104;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Event Status";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 96;
            // 
            // tabFingerEvent
            // 
            this.tabFingerEvent.Controls.Add(this.dgvRealtimeFingerEvent);
            this.tabFingerEvent.ImageIndex = 3;
            this.tabFingerEvent.Location = new System.Drawing.Point(4, 24);
            this.tabFingerEvent.Name = "tabFingerEvent";
            this.tabFingerEvent.Padding = new System.Windows.Forms.Padding(3);
            this.tabFingerEvent.Size = new System.Drawing.Size(492, 253);
            this.tabFingerEvent.TabIndex = 1;
            this.tabFingerEvent.Text = "FINGER";
            this.tabFingerEvent.UseVisualStyleBackColor = true;
            // 
            // dgvRealtimeFingerEvent
            // 
            this.dgvRealtimeFingerEvent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRealtimeFingerEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRealtimeFingerEvent.Location = new System.Drawing.Point(3, 3);
            this.dgvRealtimeFingerEvent.Name = "dgvRealtimeFingerEvent";
            this.dgvRealtimeFingerEvent.RowTemplate.Height = 25;
            this.dgvRealtimeFingerEvent.Size = new System.Drawing.Size(486, 247);
            this.dgvRealtimeFingerEvent.TabIndex = 0;
            // 
            // tabFaceEvent
            // 
            this.tabFaceEvent.Controls.Add(this.dgvRealTimeFaceEvent);
            this.tabFaceEvent.ImageIndex = 2;
            this.tabFaceEvent.Location = new System.Drawing.Point(4, 24);
            this.tabFaceEvent.Name = "tabFaceEvent";
            this.tabFaceEvent.Size = new System.Drawing.Size(492, 253);
            this.tabFaceEvent.TabIndex = 2;
            this.tabFaceEvent.Text = "FACE";
            this.tabFaceEvent.UseVisualStyleBackColor = true;
            // 
            // dgvRealTimeFaceEvent
            // 
            this.dgvRealTimeFaceEvent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRealTimeFaceEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRealTimeFaceEvent.Location = new System.Drawing.Point(0, 0);
            this.dgvRealTimeFaceEvent.Name = "dgvRealTimeFaceEvent";
            this.dgvRealTimeFaceEvent.RowTemplate.Height = 25;
            this.dgvRealTimeFaceEvent.Size = new System.Drawing.Size(492, 253);
            this.dgvRealTimeFaceEvent.TabIndex = 0;
            // 
            // EventImageList
            // 
            this.EventImageList.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.EventImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("EventImageList.ImageStream")));
            this.EventImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.EventImageList.Images.SetKeyName(0, "ALL.png");
            this.EventImageList.Images.SetKeyName(1, "Card.png");
            this.EventImageList.Images.SetKeyName(2, "face.png");
            this.EventImageList.Images.SetKeyName(3, "Finger.png");
            // 
            // panelEvent
            // 
            this.panelEvent.Controls.Add(this.panelRealtimeEvent);
            this.panelEvent.Controls.Add(this.panelCustomerInfor);
            this.panelEvent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEvent.Location = new System.Drawing.Point(300, 24);
            this.panelEvent.Name = "panelEvent";
            this.panelEvent.Size = new System.Drawing.Size(500, 404);
            this.panelEvent.TabIndex = 2;
            // 
            // timerRefreshStatus
            // 
            this.timerRefreshStatus.Enabled = true;
            this.timerRefreshStatus.Interval = 1000;
            // 
            // btnMenu
            // 
            this.btnMenu.IconChar = FontAwesome.Sharp.IconChar.AlignLeft;
            this.btnMenu.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnMenu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnMenu.IconSize = 32;
            this.btnMenu.Location = new System.Drawing.Point(258, 24);
            this.btnMenu.Name = "btnMenu";
            this.btnMenu.Size = new System.Drawing.Size(42, 34);
            this.btnMenu.TabIndex = 7;
            this.btnMenu.UseVisualStyleBackColor = true;
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(318, 49);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 7;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnMenu);
            this.Controls.Add(this.panelEvent);
            this.Controls.Add(this.controller_treeView);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.panelCustomerInfor.ResumeLayout(false);
            this.panelCustomerInfor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCustomerFace)).EndInit();
            this.panelRealtimeEvent.ResumeLayout(false);
            this.RealTimeEventTabControl.ResumeLayout(false);
            this.tabAllEvent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRealTimeAllEvent)).EndInit();
            this.tabCardEvent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRealtimeCardEvent)).EndInit();
            this.tabFingerEvent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRealtimeFingerEvent)).EndInit();
            this.tabFaceEvent.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRealTimeFaceEvent)).EndInit();
            this.panelEvent.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem systemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmSetting;
        private System.Windows.Forms.ToolStripMenuItem tsmLanguage;
        private System.Windows.Forms.ToolStripMenuItem tsmExit;
        private System.Windows.Forms.ToolStripMenuItem tsmVietNamese;
        private System.Windows.Forms.ToolStripMenuItem tsmEnglish;
        private System.Windows.Forms.TreeView controller_treeView;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Panel panelCustomerInfor;
        private System.Windows.Forms.Label lblEventCustomerTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblEventCustomerDepartment;
        private System.Windows.Forms.Label lblEventCustomerName;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label lblCustomerName;
        private System.Windows.Forms.PictureBox picCustomerFace;
        private System.Windows.Forms.Panel panelRealtimeEvent;
        private System.Windows.Forms.Panel panelEvent;
        private System.Windows.Forms.TabControl RealTimeEventTabControl;
        private System.Windows.Forms.TabPage tabAllEvent;
        private System.Windows.Forms.DataGridView dgvRealTimeAllEvent;
        private System.Windows.Forms.TabPage tabCardEvent;
        private System.Windows.Forms.DataGridView dgvRealtimeCardEvent;
        private System.Windows.Forms.TabPage tabFingerEvent;
        private System.Windows.Forms.DataGridView dgvRealtimeFingerEvent;
        private System.Windows.Forms.TabPage tabFaceEvent;
        private System.Windows.Forms.DataGridView dgvRealTimeFaceEvent;
        private System.Windows.Forms.ImageList EventImageList;
        private System.Windows.Forms.Timer timerRefreshStatus;
        private FontAwesome.Sharp.IconButton btnMenu;
        private System.Windows.Forms.DataGridViewTextBoxColumn FacePath;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn FacePath_CardEvent;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmControllerSetting;
        private System.Windows.Forms.ToolStripMenuItem tsmDownloadUser;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.TextBox textBox1;
    }
}