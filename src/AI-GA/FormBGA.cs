// 
//    Binary Genetic Algorithm for find minimum fitness F1(x) = |x| + Cos(x)
//    Class FormBGA that is sub class of Form C#
//
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace AI_BGA
{
    public partial class FormBGA : Form
    {
        public FormBGA()
        {
            InitializeComponent();
        }

        public static bool checkedMutation = false;
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (checkboxMutation.Checked) checkedMutation = true;
            else checkedMutation = false;
            this.Cursor = System.Windows.Forms.Cursors.WaitCursor;
            double MinimumRange = -99999.99;
            double MaximumRange = 99999.99;
            int Resulation_Int = 5;
            int Resulation_Man = 2;
            int Npop = 20;
            string strCrossoverFcn = "Uniform";
            try
            {
                if (txtMinRange.Text != "Default -99999.99")
                    MinimumRange = Convert.ToDouble(txtMinRange.Text.Trim());

                if (txtMaxRange.Text != "Default +99999.99")
                    MaximumRange = Convert.ToDouble(txtMaxRange.Text.Trim());

                if (txtResulatInt.Text != "Default 5")
                    Resulation_Int = Convert.ToInt32(txtResulatInt.Text.Trim());

                if (txtResulatMan.Text != "Default 2")
                    Resulation_Man = Convert.ToInt32(txtResulatMan.Text.Trim());

                if (txtNpop.Text != "Default 20")
                    Npop = Convert.ToInt32(txtNpop.Text.Trim());
            }
            catch
            {
                MessageBox.Show("TextBox Information is Incorrect Entered!\nPlease Correction it"
                    , "Input Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            switch (cmboFunction.Text.Trim())
            {
                case "SinglePoint": strCrossoverFcn = "SinglePoint";
                    break;
                case "TwoPoint": strCrossoverFcn = "TwoPoint";
                    break;
                case "Uniform": strCrossoverFcn = "Uniform";
                    break;
                default: MessageBox.Show("Please Change Crossover Function to Correct Funnction"
                    , "ComboBox.Item Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }
            Random two_Gene = new Random();
            DNA StartAlgorithm = new DNA(Npop, Resulation_Int, Resulation_Man, MinimumRange
                                            , MaximumRange, strCrossoverFcn, two_Gene);
            int counter = 1;
            do
            {
                StartAlgorithm.QuickSort();
                StartAlgorithm.Selection();
                if (DNA.N_keep == 0) break;
                StartAlgorithm.Reproduction(two_Gene);
                lblRepeatLoop.Text = "Loop repeated counter =  " + counter.ToString();
            } // End do-While when All chromosome Like them
            while (StartAlgorithm.Isotropy_Evaluatuon() && counter++ < 10000); 

            lblBestFitness.Text = "Best Fitness:  " + DNA.DNA_Array[0].Fitness.ToString();
            lblElitValue.Text = "Elite Chromosome Value: " + DNA.DNA_Array[0].IM_Chromosome.ToString();
            Cursor = Cursors.Default;
        }        

        //
        // Boolean flag used to determine when a character other than a number is entered.
        private bool nonNumberEntered = false;

        // Boolean flag used to determine when a character other than a Minus is entered.
        public bool OemMinusOne = false;

        #region txtMinRange Events
        private void txtMinRange_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift == true && txtMinRange.Text == "Default -99999.99") 
            {
                txtMinRange.Text = string.Empty;
                txtMinRange.ForeColor = Color.Black;
            }
            // Initialize the flag to false.
            nonNumberEntered = false;
            // Determine whether the keystroke is a number from the top of the keyboard.
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                // Determine whether the keystroke is a number from the keypad.
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    // Determine whether the keystroke is a backspace.
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.Subtract && e.KeyCode != Keys.OemMinus && e.KeyCode != Keys.OemPeriod)
                    {
                        // A non-numerical keystroke was pressed.
                        // Set the flag to true and evaluate in KeyPress event.
                        nonNumberEntered = true;
                    }
                    else if (e.KeyCode == Keys.OemMinus || e.KeyCode == Keys.Subtract || e.KeyCode == Keys.OemPeriod) // OemPeriod == '.'
                    {
                        if (OemMinusOne == false)
                        {
                            OemMinusOne = true;
                        }
                        else if (OemMinusOne == true)
                        {
                            nonNumberEntered = true;
                        }
                    }
                    else OemMinusOne = false;
                }
                else OemMinusOne = false;
            }
            else OemMinusOne = false;
            if (e.KeyCode == Keys.Delete)
            {
                if (txtMinRange.Text == "Default -99999.99")
                {
                    txtMinRange.Text = string.Empty;
                    txtMinRange.ForeColor = Color.Black;
                }
            }
        }

        private void txtMinRange_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtMinRange.Text == "Default -99999.99")
            {
                txtMinRange.Text = string.Empty;
                txtMinRange.ForeColor = Color.Black;
            }
        }

        private void txtMinRange_MouseLeave(object sender, EventArgs e)
        {
            if (txtMinRange.Text == "")
            {
                txtMinRange.ForeColor = Color.Gray;
                txtMinRange.Text = "Default -99999.99";
            }
        }

        private void txtMinRange_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMinRange.Text == "")
            {
                txtMinRange.ForeColor = Color.Gray;
                txtMinRange.Text = "Default -99999.99";
            }
        }

        private void txtMinRange_TextChanged(object sender, EventArgs e)
        {
            if (txtMinRange.Text != "Default -99999.99" && txtMinRange.Text != "")
            {
                char[] Spil = txtMinRange.Text.ToCharArray();
                for (int i = 0; i < Spil.Length; i++)
                {
                    if (Spil[i] == '0' || Spil[i] == '1' || Spil[i] == '2' || Spil[i] == '3' || Spil[i] == '4' || Spil[i] == '5' ||
                        Spil[i] == '6' || Spil[i] == '7' || Spil[i] == '8' || Spil[i] == '9' || Spil[i] == '-' || Spil[i] == '.')
                        continue;
                    else
                    {
                        MessageBox.Show("Please Enter Just Number or (-). This TextBox don't Accept Other Key!" +
                            "\nلطفاً فقط عدد و علامت تفریق را وارد کنید. این فیلد کلید دیگری را قبول نمی کند ", "Enter InCorrect Key"
                            , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        try
                        {
                            TextBox objTextBox = (TextBox)this.ActiveControl;
                            // Undo the last operation
                            objTextBox.Undo();
                        }
                        catch
                        {
                            txtMinRange.Text = "";
                        }
                        break;
                    }
                }
                return;
            }
        }

        private void txtMinRange_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
            // clear TextBox Fill "Default -99999.99"
            if (nonNumberEntered == false)
            {
                if (txtMinRange.Text == "Default -99999.99")
                {
                    txtMinRange.Text = string.Empty;
                    txtMinRange.ForeColor = Color.Black;
                }
            }
        }
        #endregion

        #region txtMaxRange Events
        private void txtMaxRange_MouseLeave(object sender, EventArgs e)
        {
            if (txtMaxRange.Text == "")
            {
                txtMaxRange.ForeColor = Color.Gray;
                txtMaxRange.Text = "Default +99999.99";
            }
        }

        private void txtMaxRange_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtMaxRange.Text == "Default +99999.99")
            {
                txtMaxRange.Text = string.Empty;
                txtMaxRange.ForeColor = Color.Black;
            }
        }

        private void txtMaxRange_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift == true && txtMaxRange.Text == "Default +99999.99")
            {
                txtMaxRange.Text = string.Empty;
                txtMaxRange.ForeColor = Color.Black;
            }
            // Initialize the flag to false.
            nonNumberEntered = false;
            // Determine whether the keystroke is a number from the top of the keyboard.
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                // Determine whether the keystroke is a number from the keypad.
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    // Determine whether the keystroke is a backspace.
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.Subtract && e.KeyCode != Keys.OemMinus && e.KeyCode != Keys.OemPeriod)
                    {
                        // A non-numerical keystroke was pressed.
                        // Set the flag to true and evaluate in KeyPress event.
                        nonNumberEntered = true;
                    }
                    else if (e.KeyCode == Keys.OemMinus || e.KeyCode == Keys.Subtract || e.KeyCode == Keys.OemPeriod)
                    {
                        if (OemMinusOne == false)
                        {
                            OemMinusOne = true;
                        }
                        else if (OemMinusOne == true)
                        {
                            nonNumberEntered = true;
                        }
                    }
                    else OemMinusOne = false;
                }
                else OemMinusOne = false;
            }
            else OemMinusOne = false;
            if (e.KeyCode == Keys.Delete)
            {
                if (txtMaxRange.Text == "Default +99999.99")
                {
                    txtMaxRange.Text = string.Empty;
                    txtMaxRange.ForeColor = Color.Black;
                }
            }
        }

        private void txtMaxRange_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
            // clear TextBox Fill "Default +99999.99"
            if (nonNumberEntered == false)
            {
                if (txtMaxRange.Text == "Default +99999.99")
                {
                    txtMaxRange.Text = string.Empty;
                    txtMaxRange.ForeColor = Color.Black;
                }
            }
        }

        private void txtMaxRange_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtMaxRange.Text == "")
            {
                txtMaxRange.ForeColor = Color.Gray;
                txtMaxRange.Text = "Default +99999.99";
            }
        }

        private void txtMaxRange_TextChanged(object sender, EventArgs e)
        {
            if (txtMaxRange.Text != "Default +99999.99" && txtMaxRange.Text != "")
            {
                char[] Spil = txtMaxRange.Text.ToCharArray();
                for (int i = 0; i < Spil.Length; i++)
                {
                    if (Spil[i] == '0' || Spil[i] == '1' || Spil[i] == '2' || Spil[i] == '3' || Spil[i] == '4' || Spil[i] == '5' ||
                        Spil[i] == '6' || Spil[i] == '7' || Spil[i] == '8' || Spil[i] == '9' || Spil[i] == '-' || Spil[i] == '.' || Spil[i] == '.')
                        continue;
                    else
                    {
                        MessageBox.Show("Please Enter Just Number or (-). This TextBox don't Accept Other Key!" +
                            "\nلطفاً فقط عدد و علامت تفریق را وارد کنید. این فیلد کلید دیگری را قبول نمی کند ", "Enter InCorrect Key"
                            , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        try
                        {
                            TextBox objTextBox = (TextBox)this.ActiveControl;
                            // Undo the last operation
                            objTextBox.Undo();
                        }
                        catch
                        {
                            txtMaxRange.Text = "";
                        }
                        break;
                    }
                }
                return;
            }
        }
        #endregion
       
        #region txtResulatInt Events
        private void txtResulatInt_TextChanged(object sender, EventArgs e)
        {
            if (txtResulatInt.Text != "Default 5" && txtResulatInt.Text != "")
            {
                char[] Spil = txtResulatInt.Text.ToCharArray();
                for (int i = 0; i < Spil.Length; i++)
                {
                    if (Spil[i] == '0' || Spil[i] == '1' || Spil[i] == '2' || Spil[i] == '3' || Spil[i] == '4' || Spil[i] == '5' ||
                        Spil[i] == '6' || Spil[i] == '7' || Spil[i] == '8' || Spil[i] == '9' || Spil[i] == '-' || Spil[i] == 'x' || Spil[i] == 'X')
                        continue;
                    else
                    {
                        MessageBox.Show("Please Enter Just Number or (-). This TextBox don't Accept Other Key!" +
                            "\nلطفاً فقط عدد و علامت تفریق را وارد کنید. این فیلد کلید دیگری را قبول نمی کند ", "Enter InCorrect Key"
                            , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        try
                        {
                            TextBox objTextBox = (TextBox)this.ActiveControl;
                            // Undo the last operation
                            objTextBox.Undo();
                        }
                        catch
                        {
                            txtResulatInt.Text = "";
                        }
                        break;
                    }
                }
                return;
            }
        }

        private void txtResulatInt_MouseLeave(object sender, EventArgs e)
        {
            if (txtResulatInt.Text == "")
            {
                txtResulatInt.ForeColor = Color.Gray;
                txtResulatInt.Text = "Default 5";
            }
        }

        private void txtResulatInt_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtResulatInt.Text == "Default 5")
            {
                txtResulatInt.Text = string.Empty;
                txtResulatInt.ForeColor = Color.Black;
            }
        }

        private void txtResulatInt_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtResulatInt.Text == "")
            {
                txtResulatInt.ForeColor = Color.Gray;
                txtResulatInt.Text = "Default 5";
            }
        }

        private void txtResulatInt_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
            // clear TextBox Fill "Default 5"
            if (nonNumberEntered == false)
            {
                if (txtResulatInt.Text == "Default 5")
                {
                    txtResulatInt.Text = string.Empty;
                    txtResulatInt.ForeColor = Color.Black;
                }
            }
        }

        private void txtResulatInt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift == true && txtResulatInt.Text == "Default 5")
            {
                txtResulatInt.Text = string.Empty;
                txtResulatInt.ForeColor = Color.Black;
            }
            // Initialize the flag to false.
            nonNumberEntered = false;
            // Determine whether the keystroke is a number from the top of the keyboard.
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                // Determine whether the keystroke is a number from the keypad.
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    // Determine whether the keystroke is a backspace.
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.Subtract && e.KeyCode != Keys.OemMinus && e.KeyCode != Keys.X)
                    {
                        // A non-numerical keystroke was pressed.
                        // Set the flag to true and evaluate in KeyPress event.
                        nonNumberEntered = true;
                    }
                    else if (e.KeyCode == Keys.OemMinus || e.KeyCode == Keys.Subtract)
                    {
                        if (OemMinusOne == false)
                        {
                            OemMinusOne = true;
                        }
                        else if (OemMinusOne == true)
                        {
                            nonNumberEntered = true;
                        }
                    }
                    else OemMinusOne = false;
                }
                else OemMinusOne = false;
            }
            else OemMinusOne = false;
            if (e.KeyCode == Keys.Delete)
            {
                if (txtResulatInt.Text == "Default 5")
                {
                    txtResulatInt.Text = string.Empty;
                    txtResulatInt.ForeColor = Color.Black;
                }
            }
        }
        #endregion

        #region txtResulatMan Events
        private void txtResulatMan_TextChanged(object sender, EventArgs e)
        {
            if (txtResulatMan.Text != "Default 2" && txtResulatMan.Text != "")
            {
                char[] Spil = txtResulatMan.Text.ToCharArray();
                for (int i = 0; i < Spil.Length; i++)
                {
                    if (Spil[i] == '0' || Spil[i] == '1' || Spil[i] == '2' || Spil[i] == '3' || Spil[i] == '4' || Spil[i] == '5' ||
                        Spil[i] == '6' || Spil[i] == '7' || Spil[i] == '8' || Spil[i] == '9' || Spil[i] == '-' || Spil[i] == 'x' || Spil[i] == 'X')
                        continue;
                    else
                    {
                        MessageBox.Show("Please Enter Just Number or (-). This TextBox don't Accept Other Key!" +
                            "\nلطفاً فقط عدد و علامت تفریق را وارد کنید. این فیلد کلید دیگری را قبول نمی کند ", "Enter InCorrect Key"
                            , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        try
                        {
                            TextBox objTextBox = (TextBox)this.ActiveControl;
                            // Undo the last operation
                            objTextBox.Undo();
                        }
                        catch
                        {
                            txtResulatMan.Text = "";
                        }
                        break;
                    }
                }
                return;
            }
        }

        private void txtResulatMan_MouseLeave(object sender, EventArgs e)
        {
            if (txtResulatMan.Text == "")
            {
                txtResulatMan.ForeColor = Color.Gray;
                txtResulatMan.Text = "Default 2";
            }
        }

        private void txtResulatMan_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtResulatMan.Text == "Default 2")
            {
                txtResulatMan.Text = string.Empty;
                txtResulatMan.ForeColor = Color.Black;
            }
        }

        private void txtResulatMan_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtResulatMan.Text == "")
            {
                txtResulatMan.ForeColor = Color.Gray;
                txtResulatMan.Text = "Default 2";
            }
        }

        private void txtResulatMan_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
            // clear TextBox Fill "Default 5"
            if (nonNumberEntered == false)
            {
                if (txtResulatMan.Text == "Default 2")
                {
                    txtResulatMan.Text = string.Empty;
                    txtResulatMan.ForeColor = Color.Black;
                }
            }
        }

        private void txtResulatMan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift == true && txtResulatMan.Text == "Default 2")
            {
                txtResulatMan.Text = string.Empty;
                txtResulatMan.ForeColor = Color.Black;
            }
            // Initialize the flag to false.
            nonNumberEntered = false;
            // Determine whether the keystroke is a number from the top of the keyboard.
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                // Determine whether the keystroke is a number from the keypad.
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    // Determine whether the keystroke is a backspace.
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.Subtract && e.KeyCode != Keys.OemMinus && e.KeyCode != Keys.X)
                    {
                        // A non-numerical keystroke was pressed.
                        // Set the flag to true and evaluate in KeyPress event.
                        nonNumberEntered = true;
                    }
                    else if (e.KeyCode == Keys.OemMinus || e.KeyCode == Keys.Subtract)
                    {
                        if (OemMinusOne == false)
                        {
                            OemMinusOne = true;
                        }
                        else if (OemMinusOne == true)
                        {
                            nonNumberEntered = true;
                        }
                    }
                    else OemMinusOne = false;
                }
                else OemMinusOne = false;
            }
            else OemMinusOne = false;
            if (e.KeyCode == Keys.Delete)
            {
                if (txtResulatMan.Text == "Default 2")
                {
                    txtResulatMan.Text = string.Empty;
                    txtResulatMan.ForeColor = Color.Black;
                }
            }
        }
        #endregion

        #region txtNpop Events
        private void txtNpop_TextChanged(object sender, EventArgs e)
        {
            if (txtNpop.Text != "Default 20" && txtNpop.Text != "")
            {
                char[] Spil = txtNpop.Text.ToCharArray();
                for (int i = 0; i < Spil.Length; i++)
                {
                    if (Spil[i] == '0' || Spil[i] == '1' || Spil[i] == '2' || Spil[i] == '3' || Spil[i] == '4' || Spil[i] == '5' ||
                        Spil[i] == '6' || Spil[i] == '7' || Spil[i] == '8' || Spil[i] == '9' || Spil[i] == '-' || Spil[i] == 'x' || Spil[i] == 'X')
                        continue;
                    else
                    {
                        MessageBox.Show("Please Enter Just Number or (-). This TextBox don't Accept Other Key!" +
                            "\nلطفاً فقط عدد و علامت تفریق را وارد کنید. این فیلد کلید دیگری را قبول نمی کند ", "Enter InCorrect Key"
                            , MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        try
                        {
                            TextBox objTextBox = (TextBox)this.ActiveControl;
                            // Undo the last operation
                            objTextBox.Undo();
                        }
                        catch
                        {
                            txtNpop.Text = "";
                        }
                        break;
                    }
                }
                return;
            }
        }

        private void txtNpop_MouseLeave(object sender, EventArgs e)
        {
            if (txtNpop.Text == "")
            {
                txtNpop.ForeColor = Color.Gray;
                txtNpop.Text = "Default 20";
            }
        }

        private void txtNpop_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtNpop.Text == "Default 20")
            {
                txtNpop.Text = string.Empty;
                txtNpop.ForeColor = Color.Black;
            }
        }

        private void txtNpop_KeyUp(object sender, KeyEventArgs e)
        {
            if (txtNpop.Text == "")
            {
                txtNpop.ForeColor = Color.Gray;
                txtNpop.Text = "Default 20";
            }
        }

        private void txtNpop_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Check for the flag being set in the KeyDown event.
            if (nonNumberEntered == true)
            {
                // Stop the character from being entered into the control since it is non-numerical.
                e.Handled = true;
            }
            // clear TextBox Fill "Default 5"
            if (nonNumberEntered == false)
            {
                if (txtNpop.Text == "Default 20")
                {
                    txtNpop.Text = string.Empty;
                    txtNpop.ForeColor = Color.Black;
                }
            }
        }

        private void txtNpop_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift == true && txtNpop.Text == "Default 20")
            {
                txtNpop.Text = string.Empty;
                txtNpop.ForeColor = Color.Black;
            }
            // Initialize the flag to false.
            nonNumberEntered = false;
            // Determine whether the keystroke is a number from the top of the keyboard.
            if (e.KeyCode < Keys.D0 || e.KeyCode > Keys.D9)
            {
                // Determine whether the keystroke is a number from the keypad.
                if (e.KeyCode < Keys.NumPad0 || e.KeyCode > Keys.NumPad9)
                {
                    // Determine whether the keystroke is a backspace.
                    if (e.KeyCode != Keys.Back && e.KeyCode != Keys.Subtract && e.KeyCode != Keys.OemMinus && e.KeyCode != Keys.X)
                    {
                        // A non-numerical keystroke was pressed.
                        // Set the flag to true and evaluate in KeyPress event.
                        nonNumberEntered = true;
                    }
                    else if (e.KeyCode == Keys.OemMinus || e.KeyCode == Keys.Subtract)
                    {
                        if (OemMinusOne == false)
                        {
                            OemMinusOne = true;
                        }
                        else if (OemMinusOne == true)
                        {
                            nonNumberEntered = true;
                        }
                    }
                    else OemMinusOne = false;
                }
                else OemMinusOne = false;
            }
            else OemMinusOne = false;
            if (e.KeyCode == Keys.Delete)
            {
                if (txtNpop.Text == "Default 20")
                {
                    txtNpop.Text = string.Empty;
                    txtNpop.ForeColor = Color.Black;
                }
            }
        }
        #endregion

        #region cmboFunction Events
        private void cmboFunction_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        #endregion

        private void btnAbout_Click(object sender, EventArgs e)
        {
            FormAbout About = new FormAbout();
            About.ShowDialog();
        }

        private void cmboFunction_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmboFunction.Text == "Uniform")
            {
                checkboxMutation.Checked = true;
                checkboxMutation.Enabled = false;
            }
            else
                checkboxMutation.Enabled = true;
        }

    }
}
