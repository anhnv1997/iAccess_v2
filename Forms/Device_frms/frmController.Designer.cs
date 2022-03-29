
namespace iAccess.Forms.Device_frms
{
    partial class frmController
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmController));
            this.chbInUse = new System.Windows.Forms.CheckBox();
            this.cbDisplayMode = new System.Windows.Forms.ComboBox();
            this.cbControllerGroup = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbCommunicationType = new System.Windows.Forms.ComboBox();
            this.cbControllerType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.lblIP = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.lblPort = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panelAction = new System.Windows.Forms.Panel();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.panelCardGroupInfor = new System.Windows.Forms.Panel();
            this.panelAction.SuspendLayout();
            this.panelCardGroupInfor.SuspendLayout();
            this.SuspendLayout();
            // 
            // chbInUse
            // 
            this.chbInUse.AutoSize = true;
            this.chbInUse.Location = new System.Drawing.Point(145, 328);
            this.chbInUse.Name = "chbInUse";
            this.chbInUse.Size = new System.Drawing.Size(58, 19);
            this.chbInUse.TabIndex = 12;
            this.chbInUse.Text = "In Use";
            this.chbInUse.UseVisualStyleBackColor = true;
            // 
            // cbDisplayMode
            // 
            this.cbDisplayMode.FormattingEnabled = true;
            this.cbDisplayMode.ItemHeight = 15;
            this.cbDisplayMode.Location = new System.Drawing.Point(145, 299);
            this.cbDisplayMode.Name = "cbDisplayMode";
            this.cbDisplayMode.Size = new System.Drawing.Size(207, 23);
            this.cbDisplayMode.TabIndex = 11;
            // 
            // cbControllerGroup
            // 
            this.cbControllerGroup.FormattingEnabled = true;
            this.cbControllerGroup.ItemHeight = 15;
            this.cbControllerGroup.Location = new System.Drawing.Point(145, 270);
            this.cbControllerGroup.Name = "cbControllerGroup";
            this.cbControllerGroup.Size = new System.Drawing.Size(207, 23);
            this.cbControllerGroup.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(23, 273);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(96, 15);
            this.label9.TabIndex = 23;
            this.label9.Text = "Controller Group";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 302);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 15);
            this.label10.TabIndex = 24;
            this.label10.Text = "Display Mode";
            // 
            // cbCommunicationType
            // 
            this.cbCommunicationType.FormattingEnabled = true;
            this.cbCommunicationType.ItemHeight = 15;
            this.cbCommunicationType.Location = new System.Drawing.Point(145, 241);
            this.cbCommunicationType.Name = "cbCommunicationType";
            this.cbCommunicationType.Size = new System.Drawing.Size(207, 23);
            this.cbCommunicationType.TabIndex = 9;
            // 
            // cbControllerType
            // 
            this.cbControllerType.FormattingEnabled = true;
            this.cbControllerType.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.cbControllerType.ItemHeight = 15;
            this.cbControllerType.Location = new System.Drawing.Point(145, 212);
            this.cbControllerType.Name = "cbControllerType";
            this.cbControllerType.Size = new System.Drawing.Size(207, 23);
            this.cbControllerType.TabIndex = 8;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(23, 186);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(57, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "Password";
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(145, 183);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(207, 23);
            this.txtPassword.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(23, 215);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 15);
            this.label6.TabIndex = 14;
            this.label6.Text = "Controller Type";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(23, 244);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(121, 15);
            this.label8.TabIndex = 16;
            this.label8.Text = "Communication Type";
            // 
            // lblIP
            // 
            this.lblIP.AutoSize = true;
            this.lblIP.Location = new System.Drawing.Point(23, 99);
            this.lblIP.Name = "lblIP";
            this.lblIP.Size = new System.Drawing.Size(17, 15);
            this.lblIP.TabIndex = 5;
            this.lblIP.Text = "IP";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(145, 96);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(207, 23);
            this.txtIP.TabIndex = 4;
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(23, 128);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(29, 15);
            this.lblPort.TabIndex = 7;
            this.lblPort.Text = "Port";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 157);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Username";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(145, 125);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(207, 23);
            this.txtPort.TabIndex = 5;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(256, 3);
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
            this.btnSave.Location = new System.Drawing.Point(161, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 40);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panelAction
            // 
            this.panelAction.Controls.Add(this.btnCancel);
            this.panelAction.Controls.Add(this.btnSave);
            this.panelAction.Location = new System.Drawing.Point(2, 356);
            this.panelAction.Name = "panelAction";
            this.panelAction.Size = new System.Drawing.Size(374, 48);
            this.panelAction.TabIndex = 11;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(145, 154);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(207, 23);
            this.txtUsername.TabIndex = 6;
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
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(145, 9);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(207, 23);
            this.txtID.TabIndex = 1;
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
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(145, 67);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(207, 23);
            this.txtCode.TabIndex = 3;
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
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(145, 38);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(207, 23);
            this.txtName.TabIndex = 2;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // panelCardGroupInfor
            // 
            this.panelCardGroupInfor.Controls.Add(this.chbInUse);
            this.panelCardGroupInfor.Controls.Add(this.cbDisplayMode);
            this.panelCardGroupInfor.Controls.Add(this.cbControllerGroup);
            this.panelCardGroupInfor.Controls.Add(this.label9);
            this.panelCardGroupInfor.Controls.Add(this.label10);
            this.panelCardGroupInfor.Controls.Add(this.cbCommunicationType);
            this.panelCardGroupInfor.Controls.Add(this.cbControllerType);
            this.panelCardGroupInfor.Controls.Add(this.label5);
            this.panelCardGroupInfor.Controls.Add(this.txtPassword);
            this.panelCardGroupInfor.Controls.Add(this.label6);
            this.panelCardGroupInfor.Controls.Add(this.label8);
            this.panelCardGroupInfor.Controls.Add(this.lblIP);
            this.panelCardGroupInfor.Controls.Add(this.txtIP);
            this.panelCardGroupInfor.Controls.Add(this.lblPort);
            this.panelCardGroupInfor.Controls.Add(this.txtUsername);
            this.panelCardGroupInfor.Controls.Add(this.label4);
            this.panelCardGroupInfor.Controls.Add(this.txtPort);
            this.panelCardGroupInfor.Controls.Add(this.lblID);
            this.panelCardGroupInfor.Controls.Add(this.txtID);
            this.panelCardGroupInfor.Controls.Add(this.lblCode);
            this.panelCardGroupInfor.Controls.Add(this.txtCode);
            this.panelCardGroupInfor.Controls.Add(this.lblName);
            this.panelCardGroupInfor.Controls.Add(this.txtName);
            this.panelCardGroupInfor.Location = new System.Drawing.Point(2, 3);
            this.panelCardGroupInfor.Name = "panelCardGroupInfor";
            this.panelCardGroupInfor.Size = new System.Drawing.Size(374, 348);
            this.panelCardGroupInfor.TabIndex = 12;
            // 
            // frmController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 408);
            this.Controls.Add(this.panelAction);
            this.Controls.Add(this.panelCardGroupInfor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmController";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Controller";
            this.Load += new System.EventHandler(this.frmController_Load);
            this.panelAction.ResumeLayout(false);
            this.panelCardGroupInfor.ResumeLayout(false);
            this.panelCardGroupInfor.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chbInUse;
        private System.Windows.Forms.ComboBox cbDisplayMode;
        private System.Windows.Forms.ComboBox cbControllerGroup;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cbCommunicationType;
        private System.Windows.Forms.ComboBox cbControllerType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label lblIP;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panelAction;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Panel panelCardGroupInfor;
    }
}