namespace iAccess.Forms.Customer_frms
{
    partial class frmFingerprintFromDevice
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
            this.cbDevice = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtFingerData = new System.Windows.Forms.RichTextBox();
            this.lblFingerIndex = new System.Windows.Forms.Label();
            this.btnLoadFinger = new FontAwesome.Sharp.IconButton();
            this.SuspendLayout();
            // 
            // cbDevice
            // 
            this.cbDevice.FormattingEnabled = true;
            this.cbDevice.Location = new System.Drawing.Point(98, 22);
            this.cbDevice.Name = "cbDevice";
            this.cbDevice.Size = new System.Drawing.Size(258, 23);
            this.cbDevice.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Device";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Finger Index";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 15);
            this.label3.TabIndex = 3;
            this.label3.Text = "Finger Data";
            // 
            // txtFingerData
            // 
            this.txtFingerData.Location = new System.Drawing.Point(98, 129);
            this.txtFingerData.Name = "txtFingerData";
            this.txtFingerData.Size = new System.Drawing.Size(258, 146);
            this.txtFingerData.TabIndex = 4;
            this.txtFingerData.Text = "";
            // 
            // lblFingerIndex
            // 
            this.lblFingerIndex.AutoSize = true;
            this.lblFingerIndex.Location = new System.Drawing.Point(98, 92);
            this.lblFingerIndex.Name = "lblFingerIndex";
            this.lblFingerIndex.Size = new System.Drawing.Size(38, 15);
            this.lblFingerIndex.TabIndex = 6;
            this.lblFingerIndex.Text = "label4";
            // 
            // btnLoadFinger
            // 
            this.btnLoadFinger.IconChar = FontAwesome.Sharp.IconChar.Download;
            this.btnLoadFinger.IconColor = System.Drawing.Color.DarkGreen;
            this.btnLoadFinger.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnLoadFinger.IconSize = 32;
            this.btnLoadFinger.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLoadFinger.Location = new System.Drawing.Point(375, 22);
            this.btnLoadFinger.Name = "btnLoadFinger";
            this.btnLoadFinger.Size = new System.Drawing.Size(138, 35);
            this.btnLoadFinger.TabIndex = 7;
            this.btnLoadFinger.Text = "Load Finger Data";
            this.btnLoadFinger.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btnLoadFinger.UseVisualStyleBackColor = true;
            this.btnLoadFinger.Click += new System.EventHandler(this.btnLoadFinger_Click);
            // 
            // frmFingerprintFromDevice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnLoadFinger);
            this.Controls.Add(this.lblFingerIndex);
            this.Controls.Add(this.txtFingerData);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbDevice);
            this.Name = "frmFingerprintFromDevice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Load Finger From Device";
            this.Load += new System.EventHandler(this.frmFingerprintFromDevice_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbDevice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox txtFingerData;
        private System.Windows.Forms.Label lblFingerIndex;
        private FontAwesome.Sharp.IconButton btnLoadFinger;
    }
}