
namespace iAccess.UserControls
{
    partial class ucUser
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvUser = new System.Windows.Forms.DataGridView();
            this.tsbEXPORT = new System.Windows.Forms.ToolStripButton();
            this.tsbIMPORT = new System.Windows.Forms.ToolStripButton();
            this.tsbREFRESH = new System.Windows.Forms.ToolStripButton();
            this.tsbDELETE = new System.Windows.Forms.ToolStripButton();
            this.tsbEDIT = new System.Windows.Forms.ToolStripButton();
            this.tsbADD = new System.Windows.Forms.ToolStripButton();
            this.tsbActions = new System.Windows.Forms.ToolStrip();
            this._ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).BeginInit();
            this.tsbActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvUser
            // 
            this.dgvUser.AllowUserToAddRows = false;
            this.dgvUser.AllowUserToDeleteRows = false;
            this.dgvUser.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvUser.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvUser.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._ID,
            this.Column1,
            this.Column4,
            this.Column2,
            this.Column3,
            this.Column10,
            this.Column11,
            this.Column14});
            this.dgvUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUser.Location = new System.Drawing.Point(0, 27);
            this.dgvUser.Name = "dgvUser";
            this.dgvUser.RowHeadersVisible = false;
            this.dgvUser.RowTemplate.Height = 25;
            this.dgvUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUser.Size = new System.Drawing.Size(629, 332);
            this.dgvUser.TabIndex = 3;
            // 
            // tsbEXPORT
            // 
            this.tsbEXPORT.Image = global::iAccess.Properties.Resources.Export_Icon_32;
            this.tsbEXPORT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEXPORT.Name = "tsbEXPORT";
            this.tsbEXPORT.Size = new System.Drawing.Size(86, 24);
            this.tsbEXPORT.Text = "EXPORT";
            this.tsbEXPORT.Click += new System.EventHandler(this.tsbEXPORT_Click);
            // 
            // tsbIMPORT
            // 
            this.tsbIMPORT.Image = global::iAccess.Properties.Resources.download;
            this.tsbIMPORT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbIMPORT.Name = "tsbIMPORT";
            this.tsbIMPORT.Size = new System.Drawing.Size(87, 24);
            this.tsbIMPORT.Text = "IMPORT";
            this.tsbIMPORT.Click += new System.EventHandler(this.tsbIMPORT_Click);
            // 
            // tsbREFRESH
            // 
            this.tsbREFRESH.Image = global::iAccess.Properties.Resources.Refresh;
            this.tsbREFRESH.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbREFRESH.Name = "tsbREFRESH";
            this.tsbREFRESH.Size = new System.Drawing.Size(92, 24);
            this.tsbREFRESH.Text = "REFRESH";
            this.tsbREFRESH.Click += new System.EventHandler(this.tsbREFRESH_Click);
            // 
            // tsbDELETE
            // 
            this.tsbDELETE.Image = global::iAccess.Properties.Resources.delete;
            this.tsbDELETE.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDELETE.Name = "tsbDELETE";
            this.tsbDELETE.Size = new System.Drawing.Size(81, 24);
            this.tsbDELETE.Text = "DELETE";
            this.tsbDELETE.Click += new System.EventHandler(this.tsbDELETE_Click);
            // 
            // tsbEDIT
            // 
            this.tsbEDIT.Image = global::iAccess.Properties.Resources.Edit1;
            this.tsbEDIT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEDIT.Name = "tsbEDIT";
            this.tsbEDIT.Size = new System.Drawing.Size(62, 24);
            this.tsbEDIT.Text = "EDIT";
            this.tsbEDIT.Click += new System.EventHandler(this.tsbEDIT_Click);
            // 
            // tsbADD
            // 
            this.tsbADD.Image = global::iAccess.Properties.Resources.Add1;
            this.tsbADD.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbADD.Name = "tsbADD";
            this.tsbADD.Size = new System.Drawing.Size(62, 24);
            this.tsbADD.Text = "ADD";
            this.tsbADD.Click += new System.EventHandler(this.tsbADD_Click);
            // 
            // tsbActions
            // 
            this.tsbActions.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tsbActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbADD,
            this.tsbEDIT,
            this.tsbDELETE,
            this.tsbREFRESH,
            this.tsbIMPORT,
            this.tsbEXPORT});
            this.tsbActions.Location = new System.Drawing.Point(0, 0);
            this.tsbActions.Name = "tsbActions";
            this.tsbActions.Size = new System.Drawing.Size(629, 27);
            this.tsbActions.TabIndex = 2;
            this.tsbActions.Text = "toolStrip1";
            // 
            // _ID
            // 
            this._ID.HeaderText = "ID";
            this._ID.Name = "_ID";
            this._ID.Visible = false;
            this._ID.Width = 29;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "    ";
            this.Column1.Name = "Column1";
            this.Column1.Width = 28;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "STT";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 58;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Name";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 74;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Code";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 69;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Username";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 101;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "Password";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Width = 98;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "In Use";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            this.Column14.Width = 55;
            // 
            // ucUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvUser);
            this.Controls.Add(this.tsbActions);
            this.Name = "ucUser";
            this.Size = new System.Drawing.Size(629, 359);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUser)).EndInit();
            this.tsbActions.ResumeLayout(false);
            this.tsbActions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvUser;
        private System.Windows.Forms.ToolStripButton tsbEXPORT;
        private System.Windows.Forms.ToolStripButton tsbIMPORT;
        private System.Windows.Forms.ToolStripButton tsbREFRESH;
        private System.Windows.Forms.ToolStripButton tsbDELETE;
        private System.Windows.Forms.ToolStripButton tsbEDIT;
        private System.Windows.Forms.ToolStripButton tsbADD;
        private System.Windows.Forms.ToolStrip tsbActions;
        private System.Windows.Forms.DataGridViewTextBoxColumn _ID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column14;
    }
}
