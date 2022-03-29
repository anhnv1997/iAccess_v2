
namespace iAccess.Forms.Customer_frms
{
    partial class frmCardPrivilege
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCardPrivilege));
            this.chlbSelected = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSelect = new FontAwesome.Sharp.IconButton();
            this.btnSelectAll = new FontAwesome.Sharp.IconButton();
            this.btnUnSelectAll = new FontAwesome.Sharp.IconButton();
            this.btnUnSelect = new FontAwesome.Sharp.IconButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.panelAction = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.chlbUnSelected = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.cbTimezone = new System.Windows.Forms.ComboBox();
            this.panelAction.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // chlbSelected
            // 
            this.chlbSelected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chlbSelected.FormattingEnabled = true;
            this.chlbSelected.Location = new System.Drawing.Point(0, 15);
            this.chlbSelected.Name = "chlbSelected";
            this.chlbSelected.Size = new System.Drawing.Size(170, 138);
            this.chlbSelected.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "Selected Output";
            // 
            // btnSelect
            // 
            this.btnSelect.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSelect.IconChar = FontAwesome.Sharp.IconChar.AngleRight;
            this.btnSelect.IconColor = System.Drawing.Color.Green;
            this.btnSelect.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSelect.IconSize = 38;
            this.btnSelect.Location = new System.Drawing.Point(0, 0);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(136, 38);
            this.btnSelect.TabIndex = 4;
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSelectAll.IconChar = FontAwesome.Sharp.IconChar.AngleDoubleRight;
            this.btnSelectAll.IconColor = System.Drawing.Color.Green;
            this.btnSelectAll.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSelectAll.IconSize = 38;
            this.btnSelectAll.Location = new System.Drawing.Point(0, 38);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(136, 38);
            this.btnSelectAll.TabIndex = 5;
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnUnSelectAll
            // 
            this.btnUnSelectAll.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUnSelectAll.IconChar = FontAwesome.Sharp.IconChar.AngleDoubleLeft;
            this.btnUnSelectAll.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnUnSelectAll.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnUnSelectAll.IconSize = 32;
            this.btnUnSelectAll.Location = new System.Drawing.Point(0, 114);
            this.btnUnSelectAll.Name = "btnUnSelectAll";
            this.btnUnSelectAll.Size = new System.Drawing.Size(136, 38);
            this.btnUnSelectAll.TabIndex = 7;
            this.btnUnSelectAll.UseVisualStyleBackColor = true;
            this.btnUnSelectAll.Click += new System.EventHandler(this.btnUnSelectAll_Click);
            // 
            // btnUnSelect
            // 
            this.btnUnSelect.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnUnSelect.IconChar = FontAwesome.Sharp.IconChar.AngleLeft;
            this.btnUnSelect.IconColor = System.Drawing.Color.Firebrick;
            this.btnUnSelect.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnUnSelect.IconSize = 38;
            this.btnUnSelect.Location = new System.Drawing.Point(0, 76);
            this.btnUnSelect.Name = "btnUnSelect";
            this.btnUnSelect.Size = new System.Drawing.Size(136, 38);
            this.btnUnSelect.TabIndex = 6;
            this.btnUnSelect.UseVisualStyleBackColor = true;
            this.btnUnSelect.Click += new System.EventHandler(this.btnUnSelect_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 38);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Code";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(39, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 72);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 8;
            this.label6.Text = "Description";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(76, 6);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(403, 23);
            this.txtName.TabIndex = 1;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(76, 35);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(403, 23);
            this.txtCode.TabIndex = 2;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(76, 64);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(403, 23);
            this.txtDescription.TabIndex = 3;
            // 
            // panelAction
            // 
            this.panelAction.Controls.Add(this.btnCancel);
            this.panelAction.Controls.Add(this.btnSave);
            this.panelAction.Location = new System.Drawing.Point(4, 296);
            this.panelAction.Name = "panelAction";
            this.panelAction.Size = new System.Drawing.Size(476, 46);
            this.panelAction.TabIndex = 12;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(380, 3);
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
            this.btnSave.Location = new System.Drawing.Point(285, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(89, 40);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "Save";
            this.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(4, 138);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(476, 153);
            this.panel1.TabIndex = 13;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.btnUnSelectAll);
            this.panel3.Controls.Add(this.btnUnSelect);
            this.panel3.Controls.Add(this.btnSelectAll);
            this.panel3.Controls.Add(this.btnSelect);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(170, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(136, 153);
            this.panel3.TabIndex = 15;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.chlbUnSelected);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(170, 153);
            this.panel4.TabIndex = 15;
            // 
            // chlbUnSelected
            // 
            this.chlbUnSelected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chlbUnSelected.FormattingEnabled = true;
            this.chlbUnSelected.Location = new System.Drawing.Point(0, 15);
            this.chlbUnSelected.Name = "chlbUnSelected";
            this.chlbUnSelected.Size = new System.Drawing.Size(170, 138);
            this.chlbUnSelected.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "UnSelected Output";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chlbSelected);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(306, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(170, 153);
            this.panel2.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 15);
            this.label3.TabIndex = 14;
            this.label3.Text = "Timezone";
            // 
            // cbTimezone
            // 
            this.cbTimezone.FormattingEnabled = true;
            this.cbTimezone.Location = new System.Drawing.Point(72, 93);
            this.cbTimezone.Name = "cbTimezone";
            this.cbTimezone.Size = new System.Drawing.Size(121, 23);
            this.cbTimezone.TabIndex = 15;
            // 
            // frmCardPrivilege
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 392);
            this.Controls.Add(this.cbTimezone);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelAction);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCardPrivilege";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Card Privilege";
            this.Load += new System.EventHandler(this.frmCardPrivilege_Load);
            this.panelAction.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckedListBox chlbSelected;
        private System.Windows.Forms.Label label2;
        private FontAwesome.Sharp.IconButton btnSelect;
        private FontAwesome.Sharp.IconButton btnSelectAll;
        private FontAwesome.Sharp.IconButton btnUnSelectAll;
        private FontAwesome.Sharp.IconButton btnUnSelect;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Panel panelAction;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.CheckedListBox chlbUnSelected;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbTimezone;
    }
}