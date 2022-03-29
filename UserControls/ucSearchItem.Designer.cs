namespace iAccess.UserControls
{
    partial class ucSearchItem
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
            this.txtSearchItem = new System.Windows.Forms.TextBox();
            this.lvResult = new System.Windows.Forms.ListView();
            this.columnHeader1_Name = new System.Windows.Forms.ColumnHeader();
            this.columnHeader_CardCode = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1_CardNumber = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1_Description = new System.Windows.Forms.ColumnHeader();
            this.ID = new System.Windows.Forms.ColumnHeader();
            this.iconButton1 = new FontAwesome.Sharp.IconButton();
            this.panelSearchItem = new System.Windows.Forms.Panel();
            this.panelSearchContent = new System.Windows.Forms.TableLayoutPanel();
            this.btnSelectedItem = new FontAwesome.Sharp.IconButton();
            this.panelSearchItem.SuspendLayout();
            this.panelSearchContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSearchItem
            // 
            this.txtSearchItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSearchItem.Location = new System.Drawing.Point(0, 0);
            this.txtSearchItem.Margin = new System.Windows.Forms.Padding(0);
            this.txtSearchItem.Name = "txtSearchItem";
            this.txtSearchItem.PlaceholderText = "Name, Card Code or Card Number";
            this.txtSearchItem.Size = new System.Drawing.Size(308, 23);
            this.txtSearchItem.TabIndex = 0;
            this.txtSearchItem.TextChanged += new System.EventHandler(this.txtSearchItem_TextChanged);
            // 
            // lvResult
            // 
            this.lvResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1_Name,
            this.columnHeader_CardCode,
            this.columnHeader1_CardNumber,
            this.columnHeader1_Description,
            this.ID});
            this.lvResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvResult.FullRowSelect = true;
            this.lvResult.GridLines = true;
            this.lvResult.HideSelection = false;
            this.lvResult.Location = new System.Drawing.Point(0, 25);
            this.lvResult.MultiSelect = false;
            this.lvResult.Name = "lvResult";
            this.lvResult.Size = new System.Drawing.Size(338, 233);
            this.lvResult.TabIndex = 1;
            this.lvResult.UseCompatibleStateImageBehavior = false;
            this.lvResult.View = System.Windows.Forms.View.Details;
            this.lvResult.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvResult_ItemSelectionChanged);
            // 
            // columnHeader1_Name
            // 
            this.columnHeader1_Name.Text = "Name";
            // 
            // columnHeader_CardCode
            // 
            this.columnHeader_CardCode.Text = "Card Code";
            this.columnHeader_CardCode.Width = 90;
            // 
            // columnHeader1_CardNumber
            // 
            this.columnHeader1_CardNumber.Text = "Card Number";
            this.columnHeader1_CardNumber.Width = 90;
            // 
            // columnHeader1_Description
            // 
            this.columnHeader1_Description.Text = "Description";
            this.columnHeader1_Description.Width = 90;
            // 
            // ID
            // 
            this.ID.Width = 0;
            // 
            // iconButton1
            // 
            this.iconButton1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.iconButton1.IconChar = FontAwesome.Sharp.IconChar.Search;
            this.iconButton1.IconColor = System.Drawing.Color.Black;
            this.iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconButton1.IconSize = 16;
            this.iconButton1.Location = new System.Drawing.Point(308, 0);
            this.iconButton1.Margin = new System.Windows.Forms.Padding(0);
            this.iconButton1.Name = "iconButton1";
            this.iconButton1.Size = new System.Drawing.Size(30, 25);
            this.iconButton1.TabIndex = 2;
            this.iconButton1.UseVisualStyleBackColor = true;
            // 
            // panelSearchItem
            // 
            this.panelSearchItem.Controls.Add(this.lvResult);
            this.panelSearchItem.Controls.Add(this.panelSearchContent);
            this.panelSearchItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelSearchItem.Location = new System.Drawing.Point(0, 23);
            this.panelSearchItem.Name = "panelSearchItem";
            this.panelSearchItem.Size = new System.Drawing.Size(338, 258);
            this.panelSearchItem.TabIndex = 4;
            // 
            // panelSearchContent
            // 
            this.panelSearchContent.ColumnCount = 2;
            this.panelSearchContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelSearchContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.panelSearchContent.Controls.Add(this.txtSearchItem, 0, 0);
            this.panelSearchContent.Controls.Add(this.iconButton1, 1, 0);
            this.panelSearchContent.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSearchContent.Location = new System.Drawing.Point(0, 0);
            this.panelSearchContent.Name = "panelSearchContent";
            this.panelSearchContent.RowCount = 1;
            this.panelSearchContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelSearchContent.Size = new System.Drawing.Size(338, 25);
            this.panelSearchContent.TabIndex = 3;
            // 
            // btnSelectedItem
            // 
            this.btnSelectedItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSelectedItem.IconChar = FontAwesome.Sharp.IconChar.AngleDown;
            this.btnSelectedItem.IconColor = System.Drawing.Color.Black;
            this.btnSelectedItem.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSelectedItem.IconSize = 26;
            this.btnSelectedItem.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSelectedItem.Location = new System.Drawing.Point(0, 0);
            this.btnSelectedItem.Name = "btnSelectedItem";
            this.btnSelectedItem.Size = new System.Drawing.Size(338, 23);
            this.btnSelectedItem.TabIndex = 5;
            this.btnSelectedItem.Text = "Select Item";
            this.btnSelectedItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSelectedItem.UseVisualStyleBackColor = true;
            this.btnSelectedItem.Click += new System.EventHandler(this.btnSelectedItem_Click);
            // 
            // ucSearchItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panelSearchItem);
            this.Controls.Add(this.btnSelectedItem);
            this.Name = "ucSearchItem";
            this.Size = new System.Drawing.Size(338, 281);
            this.panelSearchItem.ResumeLayout(false);
            this.panelSearchContent.ResumeLayout(false);
            this.panelSearchContent.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtSearchItem;
        private System.Windows.Forms.ListView lvResult;
        private FontAwesome.Sharp.IconButton iconButton1;
        private System.Windows.Forms.Panel panelSearchItem;
        private System.Windows.Forms.TableLayoutPanel panelSearchContent;
        private System.Windows.Forms.ColumnHeader columnHeader1_Name;
        private System.Windows.Forms.ColumnHeader columnHeader_CardCode;
        private System.Windows.Forms.ColumnHeader columnHeader1_CardNumber;
        private FontAwesome.Sharp.IconButton btnSelectedItem;
        private System.Windows.Forms.ColumnHeader columnHeader1_Description;
        private System.Windows.Forms.ColumnHeader ID;
    }
}
