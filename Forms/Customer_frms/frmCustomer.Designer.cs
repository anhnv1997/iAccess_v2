
namespace iAccess.Forms.Customer_frms
{
    partial class frmCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomer));
            this.panelAction = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panelCardGroupInfor = new System.Windows.Forms.Panel();
            this.cbMainCard = new System.Windows.Forms.ComboBox();
            this.cbSecondaryCard = new System.Windows.Forms.ComboBox();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblID = new System.Windows.Forms.Label();
            this.lblSecondaryCard = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblMainCard = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblAddr = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtAddr = new System.Windows.Forms.TextBox();
            this.cbDepartment = new System.Windows.Forms.ComboBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPhoto = new System.Windows.Forms.Label();
            this.picFace = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.PanelPhoto = new System.Windows.Forms.Panel();
            this.panelFinger = new System.Windows.Forms.Panel();
            this.dgvFingerDatas = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbEditByFile = new System.Windows.Forms.ToolStripButton();
            this.tsbEditByDevice = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panelAction.SuspendLayout();
            this.panelCardGroupInfor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFace)).BeginInit();
            this.PanelPhoto.SuspendLayout();
            this.panelFinger.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFingerDatas)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelAction
            // 
            this.panelAction.Controls.Add(this.btnCancel);
            this.panelAction.Controls.Add(this.btnSave);
            this.panelAction.Location = new System.Drawing.Point(8, 367);
            this.panelAction.Name = "panelAction";
            this.panelAction.Size = new System.Drawing.Size(745, 53);
            this.panelAction.TabIndex = 8;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(640, 10);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 40);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(539, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 40);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panelCardGroupInfor
            // 
            this.panelCardGroupInfor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelCardGroupInfor.Controls.Add(this.cbMainCard);
            this.panelCardGroupInfor.Controls.Add(this.cbSecondaryCard);
            this.panelCardGroupInfor.Controls.Add(this.lblDepartment);
            this.panelCardGroupInfor.Controls.Add(this.lblID);
            this.panelCardGroupInfor.Controls.Add(this.lblSecondaryCard);
            this.panelCardGroupInfor.Controls.Add(this.lblPhone);
            this.panelCardGroupInfor.Controls.Add(this.lblCode);
            this.panelCardGroupInfor.Controls.Add(this.lblMainCard);
            this.panelCardGroupInfor.Controls.Add(this.lblEmail);
            this.panelCardGroupInfor.Controls.Add(this.lblName);
            this.panelCardGroupInfor.Controls.Add(this.lblAddr);
            this.panelCardGroupInfor.Controls.Add(this.lblDescription);
            this.panelCardGroupInfor.Controls.Add(this.txtAddr);
            this.panelCardGroupInfor.Controls.Add(this.cbDepartment);
            this.panelCardGroupInfor.Controls.Add(this.txtID);
            this.panelCardGroupInfor.Controls.Add(this.txtName);
            this.panelCardGroupInfor.Controls.Add(this.txtCode);
            this.panelCardGroupInfor.Controls.Add(this.txtDescription);
            this.panelCardGroupInfor.Controls.Add(this.txtEmail);
            this.panelCardGroupInfor.Controls.Add(this.txtPhone);
            this.panelCardGroupInfor.Location = new System.Drawing.Point(426, 12);
            this.panelCardGroupInfor.Name = "panelCardGroupInfor";
            this.panelCardGroupInfor.Size = new System.Drawing.Size(327, 349);
            this.panelCardGroupInfor.TabIndex = 9;
            // 
            // cbMainCard
            // 
            this.cbMainCard.FormattingEnabled = true;
            this.cbMainCard.Location = new System.Drawing.Point(119, 126);
            this.cbMainCard.Name = "cbMainCard";
            this.cbMainCard.Size = new System.Drawing.Size(197, 23);
            this.cbMainCard.TabIndex = 14;
            this.cbMainCard.Visible = false;
            // 
            // cbSecondaryCard
            // 
            this.cbSecondaryCard.FormattingEnabled = true;
            this.cbSecondaryCard.Location = new System.Drawing.Point(119, 155);
            this.cbSecondaryCard.Name = "cbSecondaryCard";
            this.cbSecondaryCard.Size = new System.Drawing.Size(197, 23);
            this.cbSecondaryCard.TabIndex = 15;
            this.cbSecondaryCard.Visible = false;
            // 
            // lblDepartment
            // 
            this.lblDepartment.AutoSize = true;
            this.lblDepartment.Location = new System.Drawing.Point(23, 275);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(70, 15);
            this.lblDepartment.TabIndex = 13;
            this.lblDepartment.Text = "Department";
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(23, 12);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(18, 15);
            this.lblID.TabIndex = 0;
            this.lblID.Text = "ID";
            // 
            // lblSecondaryCard
            // 
            this.lblSecondaryCard.AutoSize = true;
            this.lblSecondaryCard.Location = new System.Drawing.Point(23, 158);
            this.lblSecondaryCard.Name = "lblSecondaryCard";
            this.lblSecondaryCard.Size = new System.Drawing.Size(90, 15);
            this.lblSecondaryCard.TabIndex = 11;
            this.lblSecondaryCard.Text = "Secondary Card";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(23, 217);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(41, 15);
            this.lblPhone.TabIndex = 0;
            this.lblPhone.Text = "Phone";
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(23, 70);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(35, 15);
            this.lblCode.TabIndex = 0;
            this.lblCode.Text = "Code";
            // 
            // lblMainCard
            // 
            this.lblMainCard.AutoSize = true;
            this.lblMainCard.Location = new System.Drawing.Point(23, 129);
            this.lblMainCard.Name = "lblMainCard";
            this.lblMainCard.Size = new System.Drawing.Size(62, 15);
            this.lblMainCard.TabIndex = 9;
            this.lblMainCard.Text = "Main Card";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(23, 188);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(36, 15);
            this.lblEmail.TabIndex = 0;
            this.lblEmail.Text = "Email";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(23, 41);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(39, 15);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // lblAddr
            // 
            this.lblAddr.AutoSize = true;
            this.lblAddr.Location = new System.Drawing.Point(23, 246);
            this.lblAddr.Name = "lblAddr";
            this.lblAddr.Size = new System.Drawing.Size(49, 15);
            this.lblAddr.TabIndex = 0;
            this.lblAddr.Text = "Address";
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(23, 99);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(67, 15);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Description";
            // 
            // txtAddr
            // 
            this.txtAddr.Location = new System.Drawing.Point(119, 243);
            this.txtAddr.Name = "txtAddr";
            this.txtAddr.Size = new System.Drawing.Size(197, 23);
            this.txtAddr.TabIndex = 7;
            // 
            // cbDepartment
            // 
            this.cbDepartment.FormattingEnabled = true;
            this.cbDepartment.Location = new System.Drawing.Point(119, 272);
            this.cbDepartment.Name = "cbDepartment";
            this.cbDepartment.Size = new System.Drawing.Size(197, 23);
            this.cbDepartment.TabIndex = 12;
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(119, 9);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(197, 23);
            this.txtID.TabIndex = 1;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(119, 38);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(197, 23);
            this.txtName.TabIndex = 2;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(119, 67);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(197, 23);
            this.txtCode.TabIndex = 3;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(119, 96);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(197, 23);
            this.txtDescription.TabIndex = 4;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(119, 185);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(197, 23);
            this.txtEmail.TabIndex = 5;
            // 
            // txtPhone
            // 
            this.txtPhone.Location = new System.Drawing.Point(119, 214);
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(197, 23);
            this.txtPhone.TabIndex = 6;
            // 
            // lblPhoto
            // 
            this.lblPhoto.AutoSize = true;
            this.lblPhoto.Location = new System.Drawing.Point(3, -1);
            this.lblPhoto.Name = "lblPhoto";
            this.lblPhoto.Size = new System.Drawing.Size(39, 15);
            this.lblPhoto.TabIndex = 10;
            this.lblPhoto.Text = "Photo";
            // 
            // picFace
            // 
            this.picFace.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.picFace.Location = new System.Drawing.Point(3, 17);
            this.picFace.Name = "picFace";
            this.picFace.Size = new System.Drawing.Size(251, 129);
            this.picFace.TabIndex = 11;
            this.picFace.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(260, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 23);
            this.button1.TabIndex = 12;
            this.button1.Text = "Load From File";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnLoadPhotoFromFile);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(260, 46);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 23);
            this.button2.TabIndex = 12;
            this.button2.Text = "Load From Device";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnLoadPhotoFromDevice);
            // 
            // PanelPhoto
            // 
            this.PanelPhoto.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanelPhoto.Controls.Add(this.picFace);
            this.PanelPhoto.Controls.Add(this.button2);
            this.PanelPhoto.Controls.Add(this.lblPhoto);
            this.PanelPhoto.Controls.Add(this.button1);
            this.PanelPhoto.Location = new System.Drawing.Point(8, 12);
            this.PanelPhoto.Name = "PanelPhoto";
            this.PanelPhoto.Size = new System.Drawing.Size(412, 150);
            this.PanelPhoto.TabIndex = 13;
            // 
            // panelFinger
            // 
            this.panelFinger.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panelFinger.Controls.Add(this.dgvFingerDatas);
            this.panelFinger.Controls.Add(this.toolStrip1);
            this.panelFinger.Controls.Add(this.label1);
            this.panelFinger.Location = new System.Drawing.Point(8, 168);
            this.panelFinger.Name = "panelFinger";
            this.panelFinger.Size = new System.Drawing.Size(414, 193);
            this.panelFinger.TabIndex = 14;
            // 
            // dgvFingerDatas
            // 
            this.dgvFingerDatas.AllowUserToAddRows = false;
            this.dgvFingerDatas.AllowUserToDeleteRows = false;
            this.dgvFingerDatas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvFingerDatas.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvFingerDatas.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvFingerDatas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFingerDatas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3});
            this.dgvFingerDatas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFingerDatas.Location = new System.Drawing.Point(0, 40);
            this.dgvFingerDatas.Name = "dgvFingerDatas";
            this.dgvFingerDatas.ReadOnly = true;
            this.dgvFingerDatas.RowHeadersVisible = false;
            this.dgvFingerDatas.RowTemplate.Height = 25;
            this.dgvFingerDatas.Size = new System.Drawing.Size(410, 149);
            this.dgvFingerDatas.TabIndex = 1;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "STT";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 50;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Thông Tin";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 85;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbEditByFile,
            this.tsbEditByDevice,
            this.tsbDelete});
            this.toolStrip1.Location = new System.Drawing.Point(0, 15);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(410, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbEditByFile
            // 
            this.tsbEditByFile.Image = ((System.Drawing.Image)(resources.GetObject("tsbEditByFile.Image")));
            this.tsbEditByFile.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditByFile.Name = "tsbEditByFile";
            this.tsbEditByFile.Size = new System.Drawing.Size(99, 22);
            this.tsbEditByFile.Text = "Edit From File";
            this.tsbEditByFile.Click += new System.EventHandler(this.tsbEditByFile_Click);
            // 
            // tsbEditByDevice
            // 
            this.tsbEditByDevice.Image = ((System.Drawing.Image)(resources.GetObject("tsbEditByDevice.Image")));
            this.tsbEditByDevice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEditByDevice.Name = "tsbEditByDevice";
            this.tsbEditByDevice.Size = new System.Drawing.Size(116, 22);
            this.tsbEditByDevice.Text = "Edit From Device";
            this.tsbEditByDevice.Click += new System.EventHandler(this.tsbEditByDevice_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.Image = global::iAccess.Properties.Resources.delete;
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(60, 22);
            this.tsbDelete.Text = "Delete";
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Fingers";
            // 
            // frmCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(755, 444);
            this.Controls.Add(this.panelFinger);
            this.Controls.Add(this.PanelPhoto);
            this.Controls.Add(this.panelCardGroupInfor);
            this.Controls.Add(this.panelAction);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCustomer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCustomer";
            this.Load += new System.EventHandler(this.frmCustomer_Load);
            this.panelAction.ResumeLayout(false);
            this.panelCardGroupInfor.ResumeLayout(false);
            this.panelCardGroupInfor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFace)).EndInit();
            this.PanelPhoto.ResumeLayout(false);
            this.PanelPhoto.PerformLayout();
            this.panelFinger.ResumeLayout(false);
            this.panelFinger.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFingerDatas)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelAction;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panelCardGroupInfor;
        private System.Windows.Forms.ComboBox cbDepartment;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label lblSecondaryCard;
        private System.Windows.Forms.Label lblMainCard;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtAddr;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblAddr;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.ComboBox cbSecondaryCard;
        private System.Windows.Forms.ComboBox cbMainCard;
        private System.Windows.Forms.Label lblPhoto;
        private System.Windows.Forms.PictureBox picFace;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel PanelPhoto;
        private System.Windows.Forms.Panel panelFinger;
        private System.Windows.Forms.DataGridView dgvFingerDatas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbEditByFile;
        private System.Windows.Forms.ToolStripButton tsbEditByDevice;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.Label label1;
    }
}