// 
//    Binary Genetic Algorithm for find minimum fitness F1(x) = |x| + Cos(x)
//    Class FormBGA.Designer for (Graphical form)
//
namespace AI_BGA
{
    partial class FormBGA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBGA));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtMinRange = new System.Windows.Forms.TextBox();
            this.txtMaxRange = new System.Windows.Forms.TextBox();
            this.txtResulatInt = new System.Windows.Forms.TextBox();
            this.txtNpop = new System.Windows.Forms.TextBox();
            this.txtResulatMan = new System.Windows.Forms.TextBox();
            this.cmboFunction = new System.Windows.Forms.ComboBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.lblBestFitness = new System.Windows.Forms.Label();
            this.lblElitValue = new System.Windows.Forms.Label();
            this.lblRepeatLoop = new System.Windows.Forms.Label();
            this.btnAbout = new System.Windows.Forms.Button();
            this.lblCostfcn = new System.Windows.Forms.Label();
            this.checkboxMutation = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Minimum Range X:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Maximum Range X:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 160);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(101, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Crossover Function:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Population Size:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 70);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Resulation Integer X:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Resulation Mantissa X:";
            // 
            // txtMinRange
            // 
            this.txtMinRange.ForeColor = System.Drawing.Color.Gray;
            this.txtMinRange.Location = new System.Drawing.Point(133, 7);
            this.txtMinRange.MaxLength = 20;
            this.txtMinRange.Name = "txtMinRange";
            this.txtMinRange.Size = new System.Drawing.Size(179, 20);
            this.txtMinRange.TabIndex = 0;
            this.txtMinRange.Text = "Default -99999.99";
            this.txtMinRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMinRange.TextChanged += new System.EventHandler(this.txtMinRange_TextChanged);
            this.txtMinRange.MouseLeave += new System.EventHandler(this.txtMinRange_MouseLeave);
            this.txtMinRange.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMinRange_KeyDown);
            this.txtMinRange.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtMinRange_KeyUp);
            this.txtMinRange.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtMinRange_MouseClick);
            this.txtMinRange.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMinRange_KeyPress);
            // 
            // txtMaxRange
            // 
            this.txtMaxRange.ForeColor = System.Drawing.Color.Gray;
            this.txtMaxRange.Location = new System.Drawing.Point(133, 37);
            this.txtMaxRange.MaxLength = 20;
            this.txtMaxRange.Name = "txtMaxRange";
            this.txtMaxRange.Size = new System.Drawing.Size(179, 20);
            this.txtMaxRange.TabIndex = 1;
            this.txtMaxRange.Text = "Default +99999.99";
            this.txtMaxRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMaxRange.TextChanged += new System.EventHandler(this.txtMaxRange_TextChanged);
            this.txtMaxRange.MouseLeave += new System.EventHandler(this.txtMaxRange_MouseLeave);
            this.txtMaxRange.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMaxRange_KeyDown);
            this.txtMaxRange.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtMaxRange_KeyUp);
            this.txtMaxRange.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtMaxRange_MouseClick);
            this.txtMaxRange.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMaxRange_KeyPress);
            // 
            // txtResulatInt
            // 
            this.txtResulatInt.ForeColor = System.Drawing.Color.Gray;
            this.txtResulatInt.Location = new System.Drawing.Point(133, 67);
            this.txtResulatInt.MaxLength = 20;
            this.txtResulatInt.Name = "txtResulatInt";
            this.txtResulatInt.Size = new System.Drawing.Size(179, 20);
            this.txtResulatInt.TabIndex = 2;
            this.txtResulatInt.Text = "Default 5";
            this.txtResulatInt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtResulatInt.TextChanged += new System.EventHandler(this.txtResulatInt_TextChanged);
            this.txtResulatInt.MouseLeave += new System.EventHandler(this.txtResulatInt_MouseLeave);
            this.txtResulatInt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtResulatInt_KeyDown);
            this.txtResulatInt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtResulatInt_KeyUp);
            this.txtResulatInt.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtResulatInt_MouseClick);
            this.txtResulatInt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtResulatInt_KeyPress);
            // 
            // txtNpop
            // 
            this.txtNpop.ForeColor = System.Drawing.Color.Gray;
            this.txtNpop.Location = new System.Drawing.Point(133, 127);
            this.txtNpop.MaxLength = 20;
            this.txtNpop.Name = "txtNpop";
            this.txtNpop.Size = new System.Drawing.Size(179, 20);
            this.txtNpop.TabIndex = 4;
            this.txtNpop.Text = "Default 20";
            this.txtNpop.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtNpop.TextChanged += new System.EventHandler(this.txtNpop_TextChanged);
            this.txtNpop.MouseLeave += new System.EventHandler(this.txtNpop_MouseLeave);
            this.txtNpop.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNpop_KeyDown);
            this.txtNpop.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtNpop_KeyUp);
            this.txtNpop.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtNpop_MouseClick);
            this.txtNpop.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtNpop_KeyPress);
            // 
            // txtResulatMan
            // 
            this.txtResulatMan.ForeColor = System.Drawing.Color.Gray;
            this.txtResulatMan.Location = new System.Drawing.Point(133, 97);
            this.txtResulatMan.MaxLength = 20;
            this.txtResulatMan.Name = "txtResulatMan";
            this.txtResulatMan.Size = new System.Drawing.Size(179, 20);
            this.txtResulatMan.TabIndex = 3;
            this.txtResulatMan.Text = "Default 2";
            this.txtResulatMan.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtResulatMan.TextChanged += new System.EventHandler(this.txtResulatMan_TextChanged);
            this.txtResulatMan.MouseLeave += new System.EventHandler(this.txtResulatMan_MouseLeave);
            this.txtResulatMan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtResulatMan_KeyDown);
            this.txtResulatMan.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtResulatMan_KeyUp);
            this.txtResulatMan.MouseClick += new System.Windows.Forms.MouseEventHandler(this.txtResulatMan_MouseClick);
            this.txtResulatMan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtResulatMan_KeyPress);
            // 
            // cmboFunction
            // 
            this.cmboFunction.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmboFunction.DisplayMember = "3";
            this.cmboFunction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmboFunction.ItemHeight = 13;
            this.cmboFunction.Items.AddRange(new object[] {
            "SinglePoint",
            "TwoPoint",
            "Uniform"});
            this.cmboFunction.Location = new System.Drawing.Point(133, 157);
            this.cmboFunction.MaxDropDownItems = 4;
            this.cmboFunction.Name = "cmboFunction";
            this.cmboFunction.Size = new System.Drawing.Size(179, 21);
            this.cmboFunction.TabIndex = 5;
            this.cmboFunction.Text = "Uniform";
            this.cmboFunction.SelectedIndexChanged += new System.EventHandler(this.cmboFunction_SelectedIndexChanged);
            this.cmboFunction.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmboFunction_KeyPress);
            // 
            // btnStart
            // 
            this.btnStart.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStart.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnStart.ForeColor = System.Drawing.Color.OrangeRed;
            this.btnStart.Location = new System.Drawing.Point(89, 232);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(146, 40);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "&Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // lblBestFitness
            // 
            this.lblBestFitness.AutoSize = true;
            this.lblBestFitness.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblBestFitness.ForeColor = System.Drawing.Color.Indigo;
            this.lblBestFitness.Location = new System.Drawing.Point(10, 316);
            this.lblBestFitness.Name = "lblBestFitness";
            this.lblBestFitness.Size = new System.Drawing.Size(102, 20);
            this.lblBestFitness.TabIndex = 7;
            this.lblBestFitness.Text = "Best Fitness:";
            // 
            // lblElitValue
            // 
            this.lblElitValue.AutoSize = true;
            this.lblElitValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblElitValue.ForeColor = System.Drawing.Color.Indigo;
            this.lblElitValue.Location = new System.Drawing.Point(10, 283);
            this.lblElitValue.Name = "lblElitValue";
            this.lblElitValue.Size = new System.Drawing.Size(188, 20);
            this.lblElitValue.TabIndex = 8;
            this.lblElitValue.Text = "Elite Chromosome Value:";
            // 
            // lblRepeatLoop
            // 
            this.lblRepeatLoop.AutoSize = true;
            this.lblRepeatLoop.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblRepeatLoop.ForeColor = System.Drawing.Color.Indigo;
            this.lblRepeatLoop.Location = new System.Drawing.Point(10, 349);
            this.lblRepeatLoop.Name = "lblRepeatLoop";
            this.lblRepeatLoop.Size = new System.Drawing.Size(201, 20);
            this.lblRepeatLoop.TabIndex = 7;
            this.lblRepeatLoop.Text = "Loop repeated counter =  0";
            // 
            // btnAbout
            // 
            this.btnAbout.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnAbout.BackgroundImage")));
            this.btnAbout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAbout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAbout.Location = new System.Drawing.Point(15, 232);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(44, 40);
            this.btnAbout.TabIndex = 9;
            this.btnAbout.UseVisualStyleBackColor = true;
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // lblCostfcn
            // 
            this.lblCostfcn.AutoSize = true;
            this.lblCostfcn.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lblCostfcn.ForeColor = System.Drawing.Color.Indigo;
            this.lblCostfcn.Location = new System.Drawing.Point(11, 383);
            this.lblCostfcn.Name = "lblCostfcn";
            this.lblCostfcn.Size = new System.Drawing.Size(284, 20);
            this.lblCostfcn.TabIndex = 7;
            this.lblCostfcn.Text = "Cost Function:          F1(x) = |x| + Cos(x)";
            // 
            // checkboxMutation
            // 
            this.checkboxMutation.AutoSize = true;
            this.checkboxMutation.Checked = true;
            this.checkboxMutation.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkboxMutation.Enabled = false;
            this.checkboxMutation.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.checkboxMutation.Location = new System.Drawing.Point(15, 196);
            this.checkboxMutation.Name = "checkboxMutation";
            this.checkboxMutation.Size = new System.Drawing.Size(153, 17);
            this.checkboxMutation.TabIndex = 10;
            this.checkboxMutation.Text = "doing Mutation (UNIFORM)";
            this.checkboxMutation.UseVisualStyleBackColor = true;
            // 
            // FormBGA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 416);
            this.Controls.Add(this.checkboxMutation);
            this.Controls.Add(this.btnAbout);
            this.Controls.Add(this.lblElitValue);
            this.Controls.Add(this.lblCostfcn);
            this.Controls.Add(this.lblRepeatLoop);
            this.Controls.Add(this.lblBestFitness);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.cmboFunction);
            this.Controls.Add(this.txtResulatMan);
            this.Controls.Add(this.txtNpop);
            this.Controls.Add(this.txtResulatInt);
            this.Controls.Add(this.txtMaxRange);
            this.Controls.Add(this.txtMinRange);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormBGA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Binary Genetic Algorithm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtMinRange;
        private System.Windows.Forms.TextBox txtMaxRange;
        private System.Windows.Forms.TextBox txtResulatInt;
        private System.Windows.Forms.TextBox txtNpop;
        private System.Windows.Forms.TextBox txtResulatMan;
        private System.Windows.Forms.ComboBox cmboFunction;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label lblBestFitness;
        private System.Windows.Forms.Label lblElitValue;
        private System.Windows.Forms.Label lblRepeatLoop;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.Label lblCostfcn;
        public System.Windows.Forms.CheckBox checkboxMutation;
    }
}

