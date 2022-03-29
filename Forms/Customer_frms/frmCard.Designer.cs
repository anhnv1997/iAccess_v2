
namespace iAccess.Forms.Customer_frms
{
    partial class frmCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCard));
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblCardNumber = new System.Windows.Forms.Label();
            this.txtCardNumber = new System.Windows.Forms.TextBox();
            this.lblCardCode = new System.Windows.Forms.Label();
            this.txtCardCode = new System.Windows.Forms.TextBox();
            this.lblStartTime = new System.Windows.Forms.Label();
            this.lblCardType = new System.Windows.Forms.Label();
            this.lblEndTime = new System.Windows.Forms.Label();
            this.lblCardGroup = new System.Windows.Forms.Label();
            this.lblCardPrivilege = new System.Windows.Forms.Label();
            this.chbInUse = new System.Windows.Forms.CheckBox();
            this.dtpStartTime = new System.Windows.Forms.DateTimePicker();
            this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
            this.cbCardType = new System.Windows.Forms.ComboBox();
            this.cbCardGroup = new System.Windows.Forms.ComboBox();
            this.cbCardPrivilege = new System.Windows.Forms.ComboBox();
            this.panelCardInfor = new System.Windows.Forms.Panel();
            this.panelAction = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.picCard = new System.Windows.Forms.PictureBox();
            this.panelCardInfor.SuspendLayout();
            this.panelAction.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCard)).BeginInit();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(23, 12);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(39, 15);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(116, 9);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(200, 23);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(23, 41);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(67, 15);
            this.lblDescription.TabIndex = 0;
            this.lblDescription.Text = "Description";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(116, 38);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(200, 23);
            this.txtDescription.TabIndex = 2;
            // 
            // lblCardNumber
            // 
            this.lblCardNumber.AutoSize = true;
            this.lblCardNumber.Location = new System.Drawing.Point(22, 70);
            this.lblCardNumber.Name = "lblCardNumber";
            this.lblCardNumber.Size = new System.Drawing.Size(79, 15);
            this.lblCardNumber.TabIndex = 0;
            this.lblCardNumber.Text = "Card Number";
            // 
            // txtCardNumber
            // 
            this.txtCardNumber.Location = new System.Drawing.Point(116, 67);
            this.txtCardNumber.Name = "txtCardNumber";
            this.txtCardNumber.Size = new System.Drawing.Size(200, 23);
            this.txtCardNumber.TabIndex = 3;
            this.txtCardNumber.TextChanged += new System.EventHandler(this.txtCardNumber_TextChanged);
            // 
            // lblCardCode
            // 
            this.lblCardCode.AutoSize = true;
            this.lblCardCode.Location = new System.Drawing.Point(23, 104);
            this.lblCardCode.Name = "lblCardCode";
            this.lblCardCode.Size = new System.Drawing.Size(63, 15);
            this.lblCardCode.TabIndex = 0;
            this.lblCardCode.Text = "Card Code";
            // 
            // txtCardCode
            // 
            this.txtCardCode.Location = new System.Drawing.Point(116, 96);
            this.txtCardCode.Name = "txtCardCode";
            this.txtCardCode.Size = new System.Drawing.Size(200, 23);
            this.txtCardCode.TabIndex = 4;
            this.txtCardCode.TextChanged += new System.EventHandler(this.txtCardCode_TextChanged);
            // 
            // lblStartTime
            // 
            this.lblStartTime.AutoSize = true;
            this.lblStartTime.Location = new System.Drawing.Point(23, 132);
            this.lblStartTime.Name = "lblStartTime";
            this.lblStartTime.Size = new System.Drawing.Size(60, 15);
            this.lblStartTime.TabIndex = 0;
            this.lblStartTime.Text = "Start Time";
            // 
            // lblCardType
            // 
            this.lblCardType.AutoSize = true;
            this.lblCardType.Location = new System.Drawing.Point(22, 188);
            this.lblCardType.Name = "lblCardType";
            this.lblCardType.Size = new System.Drawing.Size(59, 15);
            this.lblCardType.TabIndex = 0;
            this.lblCardType.Text = "Card Type";
            // 
            // lblEndTime
            // 
            this.lblEndTime.AutoSize = true;
            this.lblEndTime.Location = new System.Drawing.Point(23, 161);
            this.lblEndTime.Name = "lblEndTime";
            this.lblEndTime.Size = new System.Drawing.Size(56, 15);
            this.lblEndTime.TabIndex = 0;
            this.lblEndTime.Text = "End Time";
            // 
            // lblCardGroup
            // 
            this.lblCardGroup.AutoSize = true;
            this.lblCardGroup.Location = new System.Drawing.Point(23, 217);
            this.lblCardGroup.Name = "lblCardGroup";
            this.lblCardGroup.Size = new System.Drawing.Size(68, 15);
            this.lblCardGroup.TabIndex = 0;
            this.lblCardGroup.Text = "Card Group";
            // 
            // lblCardPrivilege
            // 
            this.lblCardPrivilege.AutoSize = true;
            this.lblCardPrivilege.Location = new System.Drawing.Point(23, 246);
            this.lblCardPrivilege.Name = "lblCardPrivilege";
            this.lblCardPrivilege.Size = new System.Drawing.Size(80, 15);
            this.lblCardPrivilege.TabIndex = 0;
            this.lblCardPrivilege.Text = "Card Privilege";
            // 
            // chbInUse
            // 
            this.chbInUse.AutoSize = true;
            this.chbInUse.Location = new System.Drawing.Point(116, 271);
            this.chbInUse.Name = "chbInUse";
            this.chbInUse.Size = new System.Drawing.Size(58, 19);
            this.chbInUse.TabIndex = 10;
            this.chbInUse.Text = "In Use";
            this.chbInUse.UseVisualStyleBackColor = true;
            // 
            // dtpStartTime
            // 
            this.dtpStartTime.Location = new System.Drawing.Point(116, 126);
            this.dtpStartTime.Name = "dtpStartTime";
            this.dtpStartTime.Size = new System.Drawing.Size(200, 23);
            this.dtpStartTime.TabIndex = 5;
            // 
            // dtpEndTime
            // 
            this.dtpEndTime.Location = new System.Drawing.Point(116, 155);
            this.dtpEndTime.Name = "dtpEndTime";
            this.dtpEndTime.Size = new System.Drawing.Size(200, 23);
            this.dtpEndTime.TabIndex = 6;
            // 
            // cbCardType
            // 
            this.cbCardType.FormattingEnabled = true;
            this.cbCardType.Location = new System.Drawing.Point(116, 185);
            this.cbCardType.Name = "cbCardType";
            this.cbCardType.Size = new System.Drawing.Size(200, 23);
            this.cbCardType.TabIndex = 7;
            // 
            // cbCardGroup
            // 
            this.cbCardGroup.FormattingEnabled = true;
            this.cbCardGroup.Location = new System.Drawing.Point(116, 214);
            this.cbCardGroup.Name = "cbCardGroup";
            this.cbCardGroup.Size = new System.Drawing.Size(200, 23);
            this.cbCardGroup.TabIndex = 8;
            // 
            // cbCardPrivilege
            // 
            this.cbCardPrivilege.FormattingEnabled = true;
            this.cbCardPrivilege.Location = new System.Drawing.Point(116, 243);
            this.cbCardPrivilege.Name = "cbCardPrivilege";
            this.cbCardPrivilege.Size = new System.Drawing.Size(200, 23);
            this.cbCardPrivilege.TabIndex = 9;
            // 
            // panelCardInfor
            // 
            this.panelCardInfor.Controls.Add(this.lblName);
            this.panelCardInfor.Controls.Add(this.cbCardPrivilege);
            this.panelCardInfor.Controls.Add(this.txtName);
            this.panelCardInfor.Controls.Add(this.cbCardGroup);
            this.panelCardInfor.Controls.Add(this.lblStartTime);
            this.panelCardInfor.Controls.Add(this.cbCardType);
            this.panelCardInfor.Controls.Add(this.lblCardNumber);
            this.panelCardInfor.Controls.Add(this.dtpEndTime);
            this.panelCardInfor.Controls.Add(this.lblCardType);
            this.panelCardInfor.Controls.Add(this.dtpStartTime);
            this.panelCardInfor.Controls.Add(this.txtCardNumber);
            this.panelCardInfor.Controls.Add(this.chbInUse);
            this.panelCardInfor.Controls.Add(this.lblDescription);
            this.panelCardInfor.Controls.Add(this.txtCardCode);
            this.panelCardInfor.Controls.Add(this.lblEndTime);
            this.panelCardInfor.Controls.Add(this.lblCardPrivilege);
            this.panelCardInfor.Controls.Add(this.lblCardCode);
            this.panelCardInfor.Controls.Add(this.txtDescription);
            this.panelCardInfor.Controls.Add(this.lblCardGroup);
            this.panelCardInfor.Location = new System.Drawing.Point(12, 12);
            this.panelCardInfor.Name = "panelCardInfor";
            this.panelCardInfor.Size = new System.Drawing.Size(331, 296);
            this.panelCardInfor.TabIndex = 5;
            // 
            // panelAction
            // 
            this.panelAction.Controls.Add(this.btnCancel);
            this.panelAction.Controls.Add(this.btnSave);
            this.panelAction.Location = new System.Drawing.Point(12, 308);
            this.panelAction.Name = "panelAction";
            this.panelAction.Size = new System.Drawing.Size(634, 53);
            this.panelAction.TabIndex = 6;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(337, 6);
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
            this.btnSave.Location = new System.Drawing.Point(242, 6);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 40);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // picCard
            // 
            this.picCard.Image = ((System.Drawing.Image)(resources.GetObject("picCard.Image")));
            this.picCard.Location = new System.Drawing.Point(350, 13);
            this.picCard.Name = "picCard";
            this.picCard.Size = new System.Drawing.Size(296, 295);
            this.picCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picCard.TabIndex = 7;
            this.picCard.TabStop = false;
            // 
            // frmCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 363);
            this.Controls.Add(this.picCard);
            this.Controls.Add(this.panelAction);
            this.Controls.Add(this.panelCardInfor);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Card";
            this.Load += new System.EventHandler(this.frmCard_Load);
            this.panelCardInfor.ResumeLayout(false);
            this.panelCardInfor.PerformLayout();
            this.panelAction.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblCardNumber;
        private System.Windows.Forms.TextBox txtCardNumber;
        private System.Windows.Forms.Label lblCardCode;
        private System.Windows.Forms.TextBox txtCardCode;
        private System.Windows.Forms.Label lblStartTime;
        private System.Windows.Forms.Label lblCardType;
        private System.Windows.Forms.Label lblEndTime;
        private System.Windows.Forms.Label lblCardGroup;
        private System.Windows.Forms.Label lblCardPrivilege;
        private System.Windows.Forms.CheckBox chbInUse;
        private System.Windows.Forms.DateTimePicker dtpStartTime;
        private System.Windows.Forms.DateTimePicker dtpEndTime;
        private System.Windows.Forms.ComboBox cbCardType;
        private System.Windows.Forms.ComboBox cbCardGroup;
        private System.Windows.Forms.ComboBox cbCardPrivilege;
        private System.Windows.Forms.Panel panelCardInfor;
        private System.Windows.Forms.Panel panelAction;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.PictureBox picCard;
    }
}