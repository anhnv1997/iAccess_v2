namespace iAccess.Forms.Device_frms
{
    partial class frmController_Door
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmController_Door));
            this.panelAction = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panelCardGroupInfor = new System.Windows.Forms.Panel();
            this.numReaderIndex = new System.Windows.Forms.NumericUpDown();
            this.cbDoor = new System.Windows.Forms.ComboBox();
            this.cbController = new System.Windows.Forms.ComboBox();
            this.lblID = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblReaderIndex = new System.Windows.Forms.Label();
            this.lblDoor = new System.Windows.Forms.Label();
            this.lblController = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.panelAction.SuspendLayout();
            this.panelCardGroupInfor.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numReaderIndex)).BeginInit();
            this.SuspendLayout();
            // 
            // panelAction
            // 
            this.panelAction.Controls.Add(this.btnCancel);
            this.panelAction.Controls.Add(this.btnSave);
            this.panelAction.Location = new System.Drawing.Point(3, 215);
            this.panelAction.Name = "panelAction";
            this.panelAction.Size = new System.Drawing.Size(325, 48);
            this.panelAction.TabIndex = 10;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(220, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 40);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(125, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 40);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panelCardGroupInfor
            // 
            this.panelCardGroupInfor.Controls.Add(this.numReaderIndex);
            this.panelCardGroupInfor.Controls.Add(this.cbDoor);
            this.panelCardGroupInfor.Controls.Add(this.cbController);
            this.panelCardGroupInfor.Controls.Add(this.lblID);
            this.panelCardGroupInfor.Controls.Add(this.txtID);
            this.panelCardGroupInfor.Controls.Add(this.lblCode);
            this.panelCardGroupInfor.Controls.Add(this.txtCode);
            this.panelCardGroupInfor.Controls.Add(this.lblName);
            this.panelCardGroupInfor.Controls.Add(this.txtDescription);
            this.panelCardGroupInfor.Controls.Add(this.lblReaderIndex);
            this.panelCardGroupInfor.Controls.Add(this.lblDoor);
            this.panelCardGroupInfor.Controls.Add(this.lblController);
            this.panelCardGroupInfor.Controls.Add(this.lblDescription);
            this.panelCardGroupInfor.Controls.Add(this.txtName);
            this.panelCardGroupInfor.Location = new System.Drawing.Point(3, 3);
            this.panelCardGroupInfor.Name = "panelCardGroupInfor";
            this.panelCardGroupInfor.Size = new System.Drawing.Size(325, 209);
            this.panelCardGroupInfor.TabIndex = 11;
            this.panelCardGroupInfor.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCardGroupInfor_Paint);
            // 
            // numReaderIndex
            // 
            this.numReaderIndex.Location = new System.Drawing.Point(104, 183);
            this.numReaderIndex.Maximum = new decimal(new int[] {
            32,
            0,
            0,
            0});
            this.numReaderIndex.Name = "numReaderIndex";
            this.numReaderIndex.Size = new System.Drawing.Size(212, 23);
            this.numReaderIndex.TabIndex = 7;
            // 
            // cbDoor
            // 
            this.cbDoor.FormattingEnabled = true;
            this.cbDoor.Location = new System.Drawing.Point(104, 154);
            this.cbDoor.Name = "cbDoor";
            this.cbDoor.Size = new System.Drawing.Size(212, 23);
            this.cbDoor.TabIndex = 6;
            // 
            // cbController
            // 
            this.cbController.FormattingEnabled = true;
            this.cbController.Location = new System.Drawing.Point(104, 125);
            this.cbController.Name = "cbController";
            this.cbController.Size = new System.Drawing.Size(212, 23);
            this.cbController.TabIndex = 5;
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
            this.txtID.Location = new System.Drawing.Point(104, 9);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(212, 23);
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
            this.txtCode.Location = new System.Drawing.Point(104, 67);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(212, 23);
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
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(104, 96);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(212, 23);
            this.txtDescription.TabIndex = 4;
            // 
            // lblReaderIndex
            // 
            this.lblReaderIndex.AutoSize = true;
            this.lblReaderIndex.Location = new System.Drawing.Point(23, 188);
            this.lblReaderIndex.Name = "lblReaderIndex";
            this.lblReaderIndex.Size = new System.Drawing.Size(75, 15);
            this.lblReaderIndex.TabIndex = 0;
            this.lblReaderIndex.Text = "Reader Index";
            // 
            // lblDoor
            // 
            this.lblDoor.AutoSize = true;
            this.lblDoor.Location = new System.Drawing.Point(23, 157);
            this.lblDoor.Name = "lblDoor";
            this.lblDoor.Size = new System.Drawing.Size(33, 15);
            this.lblDoor.TabIndex = 0;
            this.lblDoor.Text = "Door";
            // 
            // lblController
            // 
            this.lblController.AutoSize = true;
            this.lblController.Location = new System.Drawing.Point(23, 128);
            this.lblController.Name = "lblController";
            this.lblController.Size = new System.Drawing.Size(60, 15);
            this.lblController.TabIndex = 0;
            this.lblController.Text = "Controller";
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
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(104, 38);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(212, 23);
            this.txtName.TabIndex = 2;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // frmController_Door
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 270);
            this.Controls.Add(this.panelCardGroupInfor);
            this.Controls.Add(this.panelAction);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmController_Door";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Controller_Door";
            this.Load += new System.EventHandler(this.frmController_Door_Load);
            this.panelAction.ResumeLayout(false);
            this.panelCardGroupInfor.ResumeLayout(false);
            this.panelCardGroupInfor.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numReaderIndex)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelAction;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panelCardGroupInfor;
        private System.Windows.Forms.NumericUpDown numReaderIndex;
        private System.Windows.Forms.ComboBox cbDoor;
        private System.Windows.Forms.ComboBox cbController;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblReaderIndex;
        private System.Windows.Forms.Label lblDoor;
        private System.Windows.Forms.Label lblController;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtName;
    }
}