
namespace iAccess.UserControls.Device_ucs
{
    partial class ucCamera
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
            this.btnNextPage = new FontAwesome.Sharp.IconButton();
            this.txtCurrentPage = new System.Windows.Forms.TextBox();
            this.lblMaxPage = new System.Windows.Forms.TextBox();
            this.btnLastPage = new FontAwesome.Sharp.IconButton();
            this.btnPreviousPage = new FontAwesome.Sharp.IconButton();
            this.btnFirstPage = new FontAwesome.Sharp.IconButton();
            this.panelTool = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelMargin = new System.Windows.Forms.Panel();
            this.panelCardSearchByName = new System.Windows.Forms.Panel();
            this.txtNameSearch = new System.Windows.Forms.TextBox();
            this.ico_CardGroup = new FontAwesome.Sharp.IconPictureBox();
            this.tsbEXPORT = new System.Windows.Forms.ToolStripButton();
            this.tsbIMPORT = new System.Windows.Forms.ToolStripButton();
            this.panelSelectPage = new System.Windows.Forms.TableLayoutPanel();
            this.dgvCamera = new System.Windows.Forms.DataGridView();
            this._ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_Camera_Select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tsbREFRESH = new System.Windows.Forms.ToolStripButton();
            this.tsbDELETE = new System.Windows.Forms.ToolStripButton();
            this.tsbEDIT = new System.Windows.Forms.ToolStripButton();
            this.tsbADD = new System.Windows.Forms.ToolStripButton();
            this.tsbActions = new System.Windows.Forms.ToolStrip();
            this.chbSelectAll = new System.Windows.Forms.CheckBox();
            this.panelTool.SuspendLayout();
            this.panelCardSearchByName.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ico_CardGroup)).BeginInit();
            this.panelSelectPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCamera)).BeginInit();
            this.tsbActions.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNextPage
            // 
            this.btnNextPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNextPage.IconChar = FontAwesome.Sharp.IconChar.AngleRight;
            this.btnNextPage.IconColor = System.Drawing.Color.Black;
            this.btnNextPage.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnNextPage.IconSize = 32;
            this.btnNextPage.Location = new System.Drawing.Point(351, 0);
            this.btnNextPage.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.btnNextPage.Size = new System.Drawing.Size(37, 30);
            this.btnNextPage.TabIndex = 7;
            this.btnNextPage.UseVisualStyleBackColor = true;
            this.btnNextPage.Click += new System.EventHandler(this.btnNextPage_Click);
            // 
            // txtCurrentPage
            // 
            this.txtCurrentPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCurrentPage.Location = new System.Drawing.Point(268, 0);
            this.txtCurrentPage.Margin = new System.Windows.Forms.Padding(0);
            this.txtCurrentPage.Name = "txtCurrentPage";
            this.txtCurrentPage.Size = new System.Drawing.Size(40, 29);
            this.txtCurrentPage.TabIndex = 0;
            this.txtCurrentPage.TextChanged += new System.EventHandler(this.txtCurrentPage_TextChanged);
            this.txtCurrentPage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCurrentPage_KeyDown);
            // 
            // lblMaxPage
            // 
            this.lblMaxPage.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblMaxPage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblMaxPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMaxPage.Location = new System.Drawing.Point(311, 0);
            this.lblMaxPage.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblMaxPage.Name = "lblMaxPage";
            this.lblMaxPage.Size = new System.Drawing.Size(37, 29);
            this.lblMaxPage.TabIndex = 1;
            this.lblMaxPage.Text = "/100";
            // 
            // btnLastPage
            // 
            this.btnLastPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLastPage.IconChar = FontAwesome.Sharp.IconChar.AngleDoubleRight;
            this.btnLastPage.IconColor = System.Drawing.Color.Black;
            this.btnLastPage.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLastPage.IconSize = 32;
            this.btnLastPage.Location = new System.Drawing.Point(391, 0);
            this.btnLastPage.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.btnLastPage.Name = "btnLastPage";
            this.btnLastPage.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.btnLastPage.Size = new System.Drawing.Size(37, 30);
            this.btnLastPage.TabIndex = 2;
            this.btnLastPage.UseVisualStyleBackColor = true;
            this.btnLastPage.Click += new System.EventHandler(this.btnLastPage_Click);
            // 
            // btnPreviousPage
            // 
            this.btnPreviousPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPreviousPage.IconChar = FontAwesome.Sharp.IconChar.AngleLeft;
            this.btnPreviousPage.IconColor = System.Drawing.Color.Black;
            this.btnPreviousPage.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnPreviousPage.IconSize = 32;
            this.btnPreviousPage.Location = new System.Drawing.Point(228, 0);
            this.btnPreviousPage.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.btnPreviousPage.Name = "btnPreviousPage";
            this.btnPreviousPage.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.btnPreviousPage.Size = new System.Drawing.Size(37, 30);
            this.btnPreviousPage.TabIndex = 4;
            this.btnPreviousPage.UseVisualStyleBackColor = true;
            this.btnPreviousPage.Click += new System.EventHandler(this.btnPreviousPage_Click);
            // 
            // btnFirstPage
            // 
            this.btnFirstPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnFirstPage.IconChar = FontAwesome.Sharp.IconChar.AngleDoubleLeft;
            this.btnFirstPage.IconColor = System.Drawing.Color.Black;
            this.btnFirstPage.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnFirstPage.IconSize = 32;
            this.btnFirstPage.Location = new System.Drawing.Point(191, 0);
            this.btnFirstPage.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.btnFirstPage.Name = "btnFirstPage";
            this.btnFirstPage.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.btnFirstPage.Size = new System.Drawing.Size(37, 30);
            this.btnFirstPage.TabIndex = 5;
            this.btnFirstPage.UseVisualStyleBackColor = true;
            this.btnFirstPage.Click += new System.EventHandler(this.btnFirstPage_Click);
            // 
            // panelTool
            // 
            this.panelTool.AutoScroll = true;
            this.panelTool.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelTool.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelTool.Controls.Add(this.label1);
            this.panelTool.Controls.Add(this.panel1);
            this.panelTool.Controls.Add(this.panelMargin);
            this.panelTool.Controls.Add(this.panelCardSearchByName);
            this.panelTool.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTool.Location = new System.Drawing.Point(0, 25);
            this.panelTool.Name = "panelTool";
            this.panelTool.Size = new System.Drawing.Size(616, 33);
            this.panelTool.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(257, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(137, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Max Record Per Page: 50";
            // 
            // panel1
            // 
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(252, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(5, 31);
            this.panel1.TabIndex = 5;
            // 
            // panelMargin
            // 
            this.panelMargin.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMargin.Location = new System.Drawing.Point(247, 0);
            this.panelMargin.Name = "panelMargin";
            this.panelMargin.Size = new System.Drawing.Size(5, 31);
            this.panelMargin.TabIndex = 2;
            // 
            // panelCardSearchByName
            // 
            this.panelCardSearchByName.Controls.Add(this.txtNameSearch);
            this.panelCardSearchByName.Controls.Add(this.ico_CardGroup);
            this.panelCardSearchByName.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelCardSearchByName.Location = new System.Drawing.Point(0, 0);
            this.panelCardSearchByName.Name = "panelCardSearchByName";
            this.panelCardSearchByName.Size = new System.Drawing.Size(247, 31);
            this.panelCardSearchByName.TabIndex = 1;
            // 
            // txtNameSearch
            // 
            this.txtNameSearch.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.txtNameSearch.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.txtNameSearch.Location = new System.Drawing.Point(32, 3);
            this.txtNameSearch.Name = "txtNameSearch";
            this.txtNameSearch.PlaceholderText = "Name, Code or Description";
            this.txtNameSearch.Size = new System.Drawing.Size(215, 23);
            this.txtNameSearch.TabIndex = 0;
            // 
            // ico_CardGroup
            // 
            this.ico_CardGroup.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ico_CardGroup.Dock = System.Windows.Forms.DockStyle.Left;
            this.ico_CardGroup.ForeColor = System.Drawing.Color.DarkGreen;
            this.ico_CardGroup.IconChar = FontAwesome.Sharp.IconChar.AddressBook;
            this.ico_CardGroup.IconColor = System.Drawing.Color.DarkGreen;
            this.ico_CardGroup.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ico_CardGroup.IconSize = 31;
            this.ico_CardGroup.Location = new System.Drawing.Point(0, 0);
            this.ico_CardGroup.Name = "ico_CardGroup";
            this.ico_CardGroup.Size = new System.Drawing.Size(32, 31);
            this.ico_CardGroup.TabIndex = 0;
            this.ico_CardGroup.TabStop = false;
            // 
            // tsbEXPORT
            // 
            this.tsbEXPORT.Image = global::iAccess.Properties.Resources.Export_Icon_32;
            this.tsbEXPORT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEXPORT.Name = "tsbEXPORT";
            this.tsbEXPORT.Size = new System.Drawing.Size(72, 22);
            this.tsbEXPORT.Text = "EXPORT";
            this.tsbEXPORT.Click += new System.EventHandler(this.tsbEXPORT_Click);
            // 
            // tsbIMPORT
            // 
            this.tsbIMPORT.Image = global::iAccess.Properties.Resources.download;
            this.tsbIMPORT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbIMPORT.Name = "tsbIMPORT";
            this.tsbIMPORT.Size = new System.Drawing.Size(73, 22);
            this.tsbIMPORT.Text = "IMPORT";
            this.tsbIMPORT.Click += new System.EventHandler(this.tsbIMPORT_Click);
            // 
            // panelSelectPage
            // 
            this.panelSelectPage.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panelSelectPage.ColumnCount = 8;
            this.panelSelectPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelSelectPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.panelSelectPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.panelSelectPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.panelSelectPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.panelSelectPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.panelSelectPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.panelSelectPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.panelSelectPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelSelectPage.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.panelSelectPage.Controls.Add(this.btnNextPage, 5, 0);
            this.panelSelectPage.Controls.Add(this.txtCurrentPage, 3, 0);
            this.panelSelectPage.Controls.Add(this.lblMaxPage, 4, 0);
            this.panelSelectPage.Controls.Add(this.btnLastPage, 6, 0);
            this.panelSelectPage.Controls.Add(this.btnPreviousPage, 2, 0);
            this.panelSelectPage.Controls.Add(this.btnFirstPage, 1, 0);
            this.panelSelectPage.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelSelectPage.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.panelSelectPage.Location = new System.Drawing.Point(0, 293);
            this.panelSelectPage.Name = "panelSelectPage";
            this.panelSelectPage.RowCount = 1;
            this.panelSelectPage.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelSelectPage.Size = new System.Drawing.Size(616, 30);
            this.panelSelectPage.TabIndex = 20;
            // 
            // dgvCamera
            // 
            this.dgvCamera.AllowUserToAddRows = false;
            this.dgvCamera.AllowUserToDeleteRows = false;
            this.dgvCamera.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCamera.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvCamera.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvCamera.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvCamera.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCamera.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._ID,
            this.dgv_Camera_Select,
            this.Column11,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column1,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column12,
            this.Column13,
            this.Column14,
            this.Column15});
            this.dgvCamera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCamera.Location = new System.Drawing.Point(0, 58);
            this.dgvCamera.Name = "dgvCamera";
            this.dgvCamera.RowHeadersVisible = false;
            this.dgvCamera.RowTemplate.Height = 25;
            this.dgvCamera.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCamera.Size = new System.Drawing.Size(616, 235);
            this.dgvCamera.TabIndex = 18;
            this.dgvCamera.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvCamera_CellContentClick);
            // 
            // _ID
            // 
            this._ID.HeaderText = "ID";
            this._ID.Name = "_ID";
            this._ID.ReadOnly = true;
            this._ID.Visible = false;
            this._ID.Width = 26;
            // 
            // dgv_Camera_Select
            // 
            this.dgv_Camera_Select.HeaderText = "    ";
            this.dgv_Camera_Select.Name = "dgv_Camera_Select";
            this.dgv_Camera_Select.Width = 23;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "STT";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Width = 53;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Name";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 65;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Code";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 60;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Description";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Width = 96;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "IP";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 43;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Port";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 56;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Server Port";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 97;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Username";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Width = 89;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Password";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 84;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Channel";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 76;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Type";
            this.Column10.Name = "Column10";
            this.Column10.Width = 58;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "Stream Type";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Width = 102;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "Resolution";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.Width = 91;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "SDK";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            this.Column14.Width = 56;
            // 
            // Column15
            // 
            this.Column15.HeaderText = "In Use";
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            this.Column15.Width = 48;
            // 
            // tsbREFRESH
            // 
            this.tsbREFRESH.Image = global::iAccess.Properties.Resources.Refresh;
            this.tsbREFRESH.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbREFRESH.Name = "tsbREFRESH";
            this.tsbREFRESH.Size = new System.Drawing.Size(77, 22);
            this.tsbREFRESH.Text = "REFRESH";
            this.tsbREFRESH.Click += new System.EventHandler(this.tsbREFRESH_Click);
            // 
            // tsbDELETE
            // 
            this.tsbDELETE.Image = global::iAccess.Properties.Resources.delete;
            this.tsbDELETE.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDELETE.Name = "tsbDELETE";
            this.tsbDELETE.Size = new System.Drawing.Size(67, 22);
            this.tsbDELETE.Text = "DELETE";
            this.tsbDELETE.Click += new System.EventHandler(this.tsbDELETE_Click);
            // 
            // tsbEDIT
            // 
            this.tsbEDIT.Image = global::iAccess.Properties.Resources.Edit1;
            this.tsbEDIT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEDIT.Name = "tsbEDIT";
            this.tsbEDIT.Size = new System.Drawing.Size(53, 22);
            this.tsbEDIT.Text = "EDIT";
            this.tsbEDIT.Click += new System.EventHandler(this.tsbEDIT_Click);
            // 
            // tsbADD
            // 
            this.tsbADD.Image = global::iAccess.Properties.Resources.Add1;
            this.tsbADD.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbADD.Name = "tsbADD";
            this.tsbADD.Size = new System.Drawing.Size(53, 22);
            this.tsbADD.Text = "ADD";
            this.tsbADD.Click += new System.EventHandler(this.tsbADD_Click);
            // 
            // tsbActions
            // 
            this.tsbActions.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.tsbActions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbADD,
            this.tsbEDIT,
            this.tsbDELETE,
            this.tsbREFRESH,
            this.tsbIMPORT,
            this.tsbEXPORT});
            this.tsbActions.Location = new System.Drawing.Point(0, 0);
            this.tsbActions.Name = "tsbActions";
            this.tsbActions.Size = new System.Drawing.Size(616, 25);
            this.tsbActions.TabIndex = 17;
            this.tsbActions.Text = "toolStrip1";
            // 
            // chbSelectAll
            // 
            this.chbSelectAll.AutoSize = true;
            this.chbSelectAll.Location = new System.Drawing.Point(4, 64);
            this.chbSelectAll.Name = "chbSelectAll";
            this.chbSelectAll.Size = new System.Drawing.Size(15, 14);
            this.chbSelectAll.TabIndex = 21;
            this.chbSelectAll.UseVisualStyleBackColor = true;
            this.chbSelectAll.CheckedChanged += new System.EventHandler(this.chbSelectAll_CheckedChanged);
            // 
            // ucCamera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chbSelectAll);
            this.Controls.Add(this.dgvCamera);
            this.Controls.Add(this.panelTool);
            this.Controls.Add(this.panelSelectPage);
            this.Controls.Add(this.tsbActions);
            this.Name = "ucCamera";
            this.Size = new System.Drawing.Size(616, 323);
            this.panelTool.ResumeLayout(false);
            this.panelTool.PerformLayout();
            this.panelCardSearchByName.ResumeLayout(false);
            this.panelCardSearchByName.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ico_CardGroup)).EndInit();
            this.panelSelectPage.ResumeLayout(false);
            this.panelSelectPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCamera)).EndInit();
            this.tsbActions.ResumeLayout(false);
            this.tsbActions.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private FontAwesome.Sharp.IconButton btnNextPage;
        private System.Windows.Forms.TextBox txtCurrentPage;
        private System.Windows.Forms.TextBox lblMaxPage;
        private FontAwesome.Sharp.IconButton btnLastPage;
        private FontAwesome.Sharp.IconButton btnPreviousPage;
        private FontAwesome.Sharp.IconButton btnFirstPage;
        private System.Windows.Forms.Panel panelTool;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelMargin;
        private System.Windows.Forms.Panel panelCardSearchByName;
        private System.Windows.Forms.TextBox txtNameSearch;
        private FontAwesome.Sharp.IconPictureBox ico_CardGroup;
        private System.Windows.Forms.ToolStripButton tsbEXPORT;
        private System.Windows.Forms.ToolStripButton tsbIMPORT;
        private System.Windows.Forms.TableLayoutPanel panelSelectPage;
        private System.Windows.Forms.DataGridView dgvCamera;
        private System.Windows.Forms.DataGridViewTextBoxColumn _ID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dgv_Camera_Select;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Column15;
        private System.Windows.Forms.ToolStripButton tsbREFRESH;
        private System.Windows.Forms.ToolStripButton tsbDELETE;
        private System.Windows.Forms.ToolStripButton tsbEDIT;
        private System.Windows.Forms.ToolStripButton tsbADD;
        private System.Windows.Forms.ToolStrip tsbActions;
        private System.Windows.Forms.CheckBox chbSelectAll;
    }
}
