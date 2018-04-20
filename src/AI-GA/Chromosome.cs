// 
//    Binary Genetic Algorithm for find minimum fitness F1(x) = |x| + Cos(x)
//    Class Chromosome 
//
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace AI_BGA
{
    class Chromosome
    {
        #region Define Varibale
        //
        // Default chromosome = |_|_|_|_|_|.|_|_|
        //
        // Default Nbit Decimal = 7
        //
        public static int resulation_Integer = 5;   // Gene Integer  |_|_|_|_|_|. ---
        public static int resulation_Mantissa = 2;  // Gene Mantissa        --- .|_|_|
        //
        // Default Rate[No.Integer, No.Mantissa] = [6.2]
        //
        public static double min_Rate = -99999.99;  // -∞ in rate[5, 2] = -99999.99
        public static double max_Rate = 99999.99;   // +∞ in rate[5, 2] = +99999.99
        //
        // chromosome = Gene Integer + Gene Mantissa
        //
        private bool negative = false; // if Rondom Number for chromosome<0 then negative = true
        public bool Negative
        {
            get { return negative; }
            set { negative = value; }
        } // get or set +/- No.chromosome

        private int integer_Dec; // Decimal Integer Gene
        public int Integer_Dec
        {
            get { return integer_Dec; }
            set { integer_Dec = value; }
        }
        
        private int mantissa_Dec; // Decimal Mantissa Gene
        public int Mantissa_Dec
        {
            get { return mantissa_Dec; }
            set { mantissa_Dec = value; }
        }

        private string integer_Bin; // Binary Integer Gene
        public string Integer_Bin
        {
            get { return integer_Bin; }
            set { integer_Bin = value; }
        }

        private string mantissa_Bin; // Binary Mantissa Gene
        public string Mantissa_Bin
        {
            get { return mantissa_Bin; }
            set { mantissa_Bin = value; }
        }

        public double Fitness;
        //
        // Double Number chromosome
        //
        public double IM_Chromosome;
        #endregion Define Varibale
        //
        // Convert Two Gene Integer & Mantissa to double Chromosome
        private double ConvertTo_Double(int integer, int mantissa)
        {
            // Example: integer = 12  ,  mantissa = 233  ,  negative = true
            //    then: double_Value = -12.233
            string No = integer.ToString() + "." + mantissa.ToString();
            double double_Value = Convert.ToDouble(No);
            if (negative) double_Value *= (-1); // if negative == true then double_Value < 0
            return double_Value;
        }

        // Constructor by Default Resulation(6, 2, -99999.99, 99999.99)
        public Chromosome() 
        {
            negative = false;
            Fitness = 0.0;
            IM_Chromosome = 0.0;
            integer_Bin = "0";
            mantissa_Bin = "0";
            integer_Dec = 0;
            mantissa_Dec = 0;
        }

        // Constructor by parameter (Resulation, Rate)
        public Chromosome(int no_Integer, int no_Mantissa, double min, double max, Random two_Gene) 
        {
            resulation_Integer = no_Integer;
            resulation_Mantissa = no_Mantissa;
            min_Rate = min;
            max_Rate = max;
            negative = false;
            Fitness = 0.0;
            IM_Chromosome = 0.0;
            // create Randoming Gene
            //
            //            First Gene (Integer Gene)
            //
            int buffer = two_Gene.Next(Convert.ToInt32(Math.Truncate(min_Rate)),
                                         Convert.ToInt32(Math.Truncate(max_Rate)));
            //
            // if Random chromosome is < 0 then negative = true
            if (buffer < 0)
            {
                negative = true;
                integer_Dec = Math.Abs(buffer); // clean '-' and Save gene Integer 
            }
            else
            {
                negative = false;
                integer_Dec = buffer;
            }
            //
            //            Second Gene (Mantissa Gene)
            //
            // if Rate isn't Double number so haven't mantissa and is Integer No.
            if (resulation_Mantissa == 0) mantissa_Dec = 0;
            else // if Rate is Double number so have mantissa
            {
                // Example: min = 12.05 , max = 12.54 Then mantissa_Dec is a Number between 5~54
                if (Convert.ToInt32(Math.Truncate(min_Rate)) == Convert.ToInt32(Math.Truncate(max_Rate)))
                {
                    // create gene Mantissa
                    mantissa_Dec = two_Gene.Next(breakMantissa(min_Rate), breakMantissa(max_Rate));
                }
                // Example: min = -12.5 , max = 12.54 Then mantissa_Dec is a Number between 0~99
                else
                {
                    // create gene Mantissa between 0 ~ maxDigit9
                    mantissa_Dec = two_Gene.Next(0, craeteMax(resulation_Mantissa));
                }
            }
            //
            // Calculator
            //
            enCoder(); // enCoder to binary chromosome
            Evaluate(); // calculat Fitness of this chromosome in cost function
        }

        private int craeteMax(int NumberDigit) // Example: if(NumberDigit == 4) then return 9999
        {
            // Example: if(NumberDigit == 4)
            // mission-0: (0*10)   + 9 = 9
            // mission-1: (9*10)   + 9 = 99
            // mission-2: (99*10)  + 9 = 999
            // mission-3: (999*10) + 9 = 9999
            //
            int mantissaDigit = 0;
            for (int i = 0; i < NumberDigit; i++)
                mantissaDigit = (mantissaDigit * 10) + 9; 
            return mantissaDigit; // Maximum of Mantisa Number at chromosome
        }

        // get a double number (Example: -12.345) and give Mantissa part of number (Example: 345)
        private int breakMantissa(double no)
        {
            char[] NO = no.ToString().ToCharArray();
            // Example: -12.345
            //             ^
            //           (Dot)
            bool find_Dot = false;
            string strMantissa = "";
            for (int i = 0; i < NO.Length; i++)
                if (NO[i] != '.' && find_Dot)
                    strMantissa += NO[i].ToString();
                else if (NO[i] == '.')
                    find_Dot = true;
                else continue;
            return Convert.ToInt32(strMantissa); // in Example: return 345           
        }

        // Enter Fitness Function in front of Fitness and Receipt chromosome Cost double number  
        public void Evaluate()
        {
            deCoder();
            // Marge Integer_Dec+Mantissa_Dec and give both Decimal No. in one double number
            IM_Chromosome = ConvertTo_Double(integer_Dec, mantissa_Dec);
            // Convert Radians(IM_Chromosome) to Degrees
            double degrees = IM_Chromosome * (Math.PI / 180);
            // Fitness Function: f1(x) = |x| + cos(x)
            Fitness = (Math.Abs(IM_Chromosome) + Math.Cos(degrees)); 
        }
        
        // Encoder Decimal Chromosome to Binary Chromosome
        public void enCoder()
        {
            try
            {
                // Convert long integer_Dec to string Binary 
                integer_Bin = Convert.ToString(integer_Dec, 2);
            }
            catch
            {
                MessageBox.Show("Can not Convert Integer_Dec Number to binary", "Convert Error",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            try
            {
                // Convert long mantissa_Dec to string Binary 
                mantissa_Bin = Convert.ToString(mantissa_Dec, 2);
            }
            catch
            {
                MessageBox.Show("Can not Convert Mantissa_Dec Number to binary", "Convert Error",
                     MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // deCoder Binary Chromosome to Decimal Chromosome
        private void deCoder()
        {
            try
            {
                // Convert string integer_Bin & mantissa_Bin to long integer_Dec & mantissa_Dec 
                integer_Dec = Convert.ToInt32(integer_Bin, 2);
                mantissa_Dec = Convert.ToInt32(mantissa_Bin, 2);
            }
            catch
            {
                MessageBox.Show("Can not Convert Binary chromosome to Decimal chromosome",
                    "deCoder Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
