namespace AI_BGA
{
    partial class FormAbout
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAbout));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblDefine = new System.Windows.Forms.Label();
            this.toolTipDispose = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(148, 117);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.toolTipDispose.SetToolTip(this.pictureBox1, "Click to Close Window");
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lblDefine
            // 
            this.lblDefine.AutoSize = true;
            this.lblDefine.Location = new System.Drawing.Point(157, 11);
            this.lblDefine.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDefine.Name = "lblDefine";
            this.lblDefine.Size = new System.Drawing.Size(339, 68);
            this.lblDefine.TabIndex = 2;
            this.lblDefine.Text = "BGA Version 2.0\r\nCopyright © 2009 Behzad.kh\r\nPlatform: C#.Net \r\nAll program parts" +
    " created by Mr. Behzad Khosravifar\r\n";
            this.toolTipDispose.SetToolTip(this.lblDefine, "Click to Close Window");
            this.lblDefine.Click += new System.EventHandler(this.lblDefine_Click);
            // 
            // toolTipDispose
            // 
            this.toolTipDispose.ShowAlways = true;
            // 
            // FormAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 116);
            this.ControlBox = false;
            this.Controls.Add(this.lblDefine);
            this.Controls.Add(this.pictureBox1);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormAbout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.toolTipDispose.SetToolTip(this, "Click to Close Window");
            this.TopMost = true;
            this.Click += new System.EventHandler(this.FormAbout_Click);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblDefine;
        private System.Windows.Forms.ToolTip toolTipDispose;
    }
}