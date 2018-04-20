// 
//    Binary Genetic Algorithm for find minimum fitness F1(x) = |x| + Cos(x)
//    Class Crossover 
//
using System;
using System.Collections.Generic;
using System.Text;

namespace AI_BGA
{
    class Crossover
    {
        #region Defined Variable
        private Chromosome chromosome_Child_1;
        private Chromosome chromosome_Child_2;

        // Defined Children Chromosom to ReadOnly Property
        public Chromosome Chromosome_Child_1
        {
            get
            {
                return chromosome_Child_1;
            }
        }
        public Chromosome Chromosome_Child_2
        {
            get
            {
                return chromosome_Child_2;
            }
        }

        #endregion

        // Constructor Function for Crossover between 2 Chromosome's
        // Father and Mather for product Children Chromosome
        // Change Crossover function Algorithm by user
        public Crossover(Chromosome chromosome_Father, Chromosome chromosome_Mather
                        , string Algorithm, Random two_Gene)
        {
            // Set Unit Length for both of chromosome (Father & Mather)
            chromosome_Father = setLength(chromosome_Father,
                chromosome_Father.Integer_Bin.Length, chromosome_Mather.Integer_Bin.Length,
                chromosome_Father.Mantissa_Bin.Length, chromosome_Mather.Mantissa_Bin.Length);
            //
            // Set Unit Length for both of chromosome (Father & Mather)
            chromosome_Mather = setLength(chromosome_Mather,
                chromosome_Father.Integer_Bin.Length, chromosome_Mather.Integer_Bin.Length,
                chromosome_Father.Mantissa_Bin.Length, chromosome_Mather.Mantissa_Bin.Length);

            // choose Algorithm for crossover function
            switch (Algorithm) // Defined the Crossover Algorithm by User
            {
                case "SinglePoint": SinglePoint(chromosome_Father, chromosome_Mather, two_Gene);
                    break;
                case "TwoPoint": TwoPoint(chromosome_Father, chromosome_Mather, two_Gene);
                    break;
                case "Uniform": Uniform(chromosome_Father, chromosome_Mather, two_Gene);
                    break;
                // Defual Algorithm for Crossover is Uniform
                default: Uniform(chromosome_Father, chromosome_Mather, two_Gene);
                    break;
            }
            //
            // get children chromosome fitness
            chromosome_Child_1.Evaluate();
            chromosome_Child_2.Evaluate();
        }

        // set Maximum Range for chromosome as self Father & Mather Chromosome Range
        private Chromosome setLength(Chromosome chromosome_FM, int intLength_f,
                                int intLenght_m, int manLength_f, int manLength_m)
        {
            int maxInteger = Math.Max(intLength_f, intLenght_m);
            int maxMantissa = Math.Max(manLength_f, manLength_m);
            //set chromosome_FM.Integer_Binary.Length = Maximum Integer Length (Father & Mather)
            if (chromosome_FM.Integer_Bin.Length < maxInteger)
                while (chromosome_FM.Integer_Bin.Length != maxInteger)
                    // add number zero 0 before chromosome Example: "0" added to "123" ==> "0123"
                    chromosome_FM.Integer_Bin = "0" + chromosome_FM.Integer_Bin;
            //set chromosome_FM.Mantissa_Binary.Length = Maximum Mantissa Length(Father & Mather)
            if (chromosome_FM.Mantissa_Bin.Length < maxMantissa)
                while (chromosome_FM.Mantissa_Bin.Length != maxMantissa)
                    // add number zero 0 before chromosome Example: "0" added to "123" ==> "0123"
                    chromosome_FM.Mantissa_Bin = "0" + chromosome_FM.Mantissa_Bin;
            return chromosome_FM;
        }
        
        // Crossover Function single-point
        private void SinglePoint(Chromosome chromosome_Father, Chromosome chromosome_Mather, Random two_Gene)
        {
            chromosome_Child_1 = new Chromosome();
            chromosome_Child_2 = new Chromosome();
            int select_point;
            //
            // save binary string to char[]
            //
            // convert string Integer-Chromosome to char[]
            // × × ×
            char[] sp_father_int_CharArray = chromosome_Father.Integer_Bin.ToCharArray();
            // + + +
            char[] sp_mather_int_CharArray = chromosome_Mather.Integer_Bin.ToCharArray();
            //
            // convert string Mantissa-Chromosome to char[]
            char[] sp_father_double_CharArray = chromosome_Father.Mantissa_Bin.ToCharArray();
            char[] sp_mather_double_CharArray = chromosome_Mather.Mantissa_Bin.ToCharArray();
            //
            // Create Chromosome_Child_1  &  Chromosome_Child_2
            //
            // select_point is a Random number that:
            // select division point between Integer
            // if(Random Number == 4) then Select :
            //                                           <---×
            //                                      |_|_|_|_|_|_|_|_ . . .
            //                                       0 1 2 3 4 5 6 7 . . .
            //
            // if(chromosome_Father.Integer_Bin.Length == 8) then
            //    Random Selection Number is betwwen [0~6] because:
            //                      <---×
            // Length 8 == |_|_|_|_|_|_|_|_|
            //              0 1 2 3 4 5 6 7 
            // End Select is cell(0~6) for singlePoint by cell(7)
            //
            // Therefore selection number Apply between 0~chromosome_Father.Integer_Bin.Length-2
            //
            // define variable
            // Integer SinglePoint Variable
            //
            string sp_father_intPart1 = "";  // for save Left-Part of Father integer Chromosome
            string sp_father_intPart2 = "";  // for save Right-Part of Father integer Chromosome
            string sp_mather_intPart1 = "";  // for save Left-Part of Mather integer Chromosome
            string sp_mather_intPart2 = "";  // for save Right-Part of Mather integer chromosome
            //
            // Mantissa SinglePoint Variable
            //
            string sp_father_doublePart1 = ""; // save Left-Part of Father mantissa Chromosome
            string sp_father_doublePart2 = ""; // save Right-Part of Father mantissa Chromosome
            string sp_mather_doublePart1 = ""; // save Left-Part of Mather mantissa Chromosome
            string sp_mather_doublePart2 = ""; // save Right-Part of Mather mantissa chromosome
            //
            //  save char[].Partition to string
            //
            if (chromosome_Father.Integer_Bin.Length > 1)
            {
                //   selecttion point for select between Integer Binary Partition
                select_point = two_Gene.Next(0, chromosome_Father.Integer_Bin.Length - 2);
                // Part 1 Integer
                for (int i = 0; i <= select_point; i++)
                {
                    sp_father_intPart1 += sp_father_int_CharArray[i].ToString(); // × × ×
                    sp_mather_intPart1 += sp_mather_int_CharArray[i].ToString(); // + + +
                }
                // Part 2 Integer
                for (int j = select_point + 1; j < chromosome_Father.Integer_Bin.Length; j++)
                {
                    sp_father_intPart2 += sp_father_int_CharArray[j].ToString(); // × × ×
                    sp_mather_intPart2 += sp_mather_int_CharArray[j].ToString(); // + + +
                }
            }
            // if( mantissa decimal number not exist)
            if (chromosome_Father.Mantissa_Bin.Length > 1)
            {
                //   selecttion point for select between Mantissa Binary Partition
                select_point = two_Gene.Next(0, chromosome_Father.Mantissa_Bin.Length - 2);
                // Part 1 Mantissa
                for (int i = 0; i <= select_point; i++)
                {
                    sp_father_doublePart1 += sp_father_double_CharArray[i].ToString();
                    sp_mather_doublePart1 += sp_mather_double_CharArray[i].ToString();
                }
                //
                // Part 2 Mantissa
                for (int j = select_point + 1; j < chromosome_Father.Mantissa_Bin.Length; j++)
                {
                    sp_father_doublePart2 += sp_father_double_CharArray[j].ToString();
                    sp_mather_doublePart2 += sp_mather_double_CharArray[j].ToString();
                }
            }
            //
            //     CROSSOVER SINGLE-POINT RUN
            //
            // if(Selection Point == 5) 
            // then:
            //                          × × × × × × + +                        × × × × × × × ×
            // chromosome Father:      |_|_|_|_|_|_|_|_|          (Child_1)   |_|_|_|_|_|_|_|_|
            //                          0 1 2 3 4 5 6 7                        0 1 2 3 4 5 6 7
            //                                            :(Create Child)==>  
            //                          + + + + + + × ×                        + + + + + + + +
            // chromosome Mather:      |_|_|_|_|_|_|_|_|          (Child_2)   |_|_|_|_|_|_|_|_|
            //                          0 1 2 3 4 5 6 7                        0 1 2 3 4 5 6 7
            //
            // child-1 Integer crossover
            chromosome_Child_1.Integer_Bin = sp_father_intPart1 + sp_mather_intPart2;  
            //
            // child-1 Mantissa crossover
            chromosome_Child_1.Mantissa_Bin = sp_father_doublePart1 + sp_mather_doublePart2; 
            //
            // child-2 Integer crossover
            chromosome_Child_2.Integer_Bin = sp_mather_intPart1 + sp_father_intPart2; 
            //
            // child-2 Mantissa crossoevr
            chromosome_Child_2.Mantissa_Bin = sp_mather_doublePart1 + sp_father_doublePart2; 
            if (chromosome_Father.Integer_Bin.Length <= 1)
            {
                chromosome_Child_1.Integer_Bin = chromosome_Father.Integer_Bin;
                chromosome_Child_2.Integer_Bin = chromosome_Mather.Integer_Bin;
            }
            if (chromosome_Father.Mantissa_Bin.Length <= 1)
            {
                chromosome_Child_1.Mantissa_Bin = chromosome_Mather.Mantissa_Bin;
                chromosome_Child_2.Mantissa_Bin = chromosome_Father.Mantissa_Bin;
            }
            //
            // choose Negative for child_1 chromosome
            int int_negativeMark = two_Gene.Next(0, 1);
            if (int_negativeMark == 0) // choose negative as chromosome_father
                chromosome_Child_1.Negative = chromosome_Father.Negative;
            // choose negative as chromosome_mather
            else chromosome_Child_1.Negative = chromosome_Mather.Negative;
            //
            // choose Negative for child_2 chromosome
            int_negativeMark = two_Gene.Next(0, 1);
            if (int_negativeMark == 0) // choose negative as chromosome_father
                chromosome_Child_2.Negative = chromosome_Father.Negative;
            // choose negative as chromosome_mather
            else chromosome_Child_2.Negative = chromosome_Mather.Negative;
        }

        // Crossover Function two-point
        private void TwoPoint(Chromosome chromosome_Father, Chromosome chromosome_Mather, Random two_Gene)
        {
            chromosome_Child_1 = new Chromosome();
            chromosome_Child_2 = new Chromosome();
            //
            // save Random number for cut integer Left-Part
            int select_point_i1 = 0; 
            //
            // save Random number for cut integer Right-Part
            int select_point_i2 = chromosome_Father.Integer_Bin.Length - 1;
            //
            // save Random number for cut mantissa Left-Part
            int select_point_m1 = 0; 
            //
            // save Random number for cut mantissa Right-Part
            int select_point_m2 = chromosome_Father.Mantissa_Bin.Length - 1; 
            //
            // save binary string to char[]
            //
            // convert string Integer-Chromosome to char[]
            // × × ×
            char[] sp_father_int_CharArray = chromosome_Father.Integer_Bin.ToCharArray();
            // + + +
            char[] sp_mather_int_CharArray = chromosome_Mather.Integer_Bin.ToCharArray();
            //
            // convert string Mantissa-Chromosome to char[]
            char[] sp_father_double_CharArray = chromosome_Father.Mantissa_Bin.ToCharArray();
            char[] sp_mather_double_CharArray = chromosome_Mather.Mantissa_Bin.ToCharArray();
            // Create Chromosom_Child_1  &  Chromosom_Child_2
            //
            // select_point_1 is a Random number that:
            // select division point between 0 ~ Half-Integer
            // if(Random Number == 2) then Select :
            //                                       (p1)×  |(Second Half-Integer)
            //                                      |_|_|_|_|_|_|_|_| 
            //                                       0 1 2 3 4 5 6 7 
            //
            // select_point_2 is a Random number that:
            // select division point between Half-Integer ~ Integer.Length
            // if(Random Number == 5) then Select :
            //                          (First Half-Integer)|  ×(p2)
            //                                      |_|_|_|_|_|_|_|_| 
            //                                       0 1 2 3 4 5 6 7 
            //
            // if(chromosome_Father.Integer_Bin.Length == 8) then 
            //    Random Selection Number is betwwen [0~7] because:
            // *Half-Point1 = between 3-4 == [0~3]
            // *Half-Point2 = between 3-4 == (3~7]==[4~7]
            //
            //                ×-----×        *(p1=1 & p2=4)* 
            // Length 8 == |_|_|_|_|_|_|_|_|                 
            //              0 1 2 3 4 5 6 7 
            //
            // End Select is cell(0~7) for two-Point by cell(8)
            //
            // Therefore selection number Apply between 0~chromosome_Father.Integer_Bin.Length-1
            //
            // define variable
            // Integer TwoPoint Variable
            //
            string sp_father_intPart = "";    // save Center-Part of Father integer Chromosome
            string sp_mather_intPart = "";    // save Center-Part of Mather integer Chromosome
            //
            // Mantissa TwoPoint Variable
            //
            string sp_father_doublePart = ""; // save Left-Part of Father mantissa Chromosome
            string sp_mather_doublePart = ""; // save Left-Part of Mather mantissa Chromosome
            //
            //  save char[].Partition to string
            //
            // Part center Integer
            // Clause for Integer crossover is: Minimum Integer.Length == 2
            if (chromosome_Father.Integer_Bin.Length > 1) 
            {
                //   selecttion point for select between Integer Binary Partition
                // for save half as Integer_bin.length
                int half_integerLenght = (chromosome_Father.Integer_Bin.Length / 2) - 1; 

                select_point_i1 = two_Gene.Next(0, half_integerLenght); // p1
                //
                select_point_i2 = two_Gene.Next((half_integerLenght + 1),
                    (chromosome_Father.Integer_Bin.Length - 1)); // p2
                
                for (int i = select_point_i1; i <= select_point_i2; i++)
                {
                    sp_father_intPart += sp_father_int_CharArray[i].ToString(); // × × ×
                    sp_mather_intPart += sp_mather_int_CharArray[i].ToString(); // + + +
                }
            }
            // if( mantissa decimal number not exist or less than 2)
            // Clause for Mantissa crossover is: Minimum Mantisssa.Length == 2
            if (chromosome_Father.Mantissa_Bin.Length > 1) 
            {
                // selection two-point for select between Mantissa Binary Partition
                // for save half as Mantissa_bin.length
                int half_mantissaLenght = (chromosome_Father.Mantissa_Bin.Length / 2) - 1;
                //
                // p1 (one integer Random num between 0 ~ Half-Mantissa)
                select_point_m1 = two_Gene.Next(0, half_mantissaLenght); // p1
                //
                select_point_m2 = two_Gene.Next((half_mantissaLenght + 1)
                    , (chromosome_Father.Mantissa_Bin.Length - 1)); // p2
                //
                // Part center Mantissa
                for (int i = select_point_m1; i <= select_point_m2; i++)
                {
                    sp_father_doublePart += sp_father_double_CharArray[i].ToString();
                    sp_mather_doublePart += sp_mather_double_CharArray[i].ToString();
                }
            }
            //
            //                            CROSSOVER TWO-POINT RUN
            //
            // Example: if(Selection Point == 2 & 5) then
            //                         # # × × × × # #                        # # + + + + # #
            // chromosome Father:     |_|_|_|_|_|_|_|_|          (Child_1)   |_|_|_|_|_|_|_|_|  
            //                         0 1 2 3 4 5 6 7                        0 1 2 3 4 5 6 7
            //                                           :(Create Child)==>  
            //                         ~ ~ + + + + ~ ~                        ~ ~ × × × × ~ ~
            // chromosome Mather:     |_|_|_|_|_|_|_|_|          (Child_2)   |_|_|_|_|_|_|_|_|
            //                         0 1 2 3 4 5 6 7                        0 1 2 3 4 5 6 7
            //
            //       Clear children chromosome information
            chromosome_Child_1.Integer_Bin = "";
            chromosome_Child_1.Mantissa_Bin = "";
            chromosome_Child_2.Integer_Bin = "";
            chromosome_Child_2.Mantissa_Bin = "";
            //
            //        Create Integer Chromosom Children
            //
            if (chromosome_Father.Integer_Bin.Length > 1)
            {
                // save string as 0 ~ select_point_integer_Left 
                for (int i = 0; i < select_point_i1; i++) 
                {
                    // child-1 Integer crossover
                    chromosome_Child_1.Integer_Bin += sp_father_int_CharArray[i].ToString();
                    // child-2 Integer crossover
                    chromosome_Child_2.Integer_Bin += sp_mather_int_CharArray[i].ToString(); 
                }
                // save string select_point_integer_Center
                chromosome_Child_1.Integer_Bin += sp_mather_intPart;
                // save string select_point_integer_Center
                Chromosome_Child_2.Integer_Bin += sp_father_intPart; 
                //
                // save string as select_point_Right ~ end
                for (int i = select_point_i2 + 1; i < chromosome_Father.Integer_Bin.Length; i++) 
                {
                    // child-1 Integer crossover
                    chromosome_Child_1.Integer_Bin += sp_father_int_CharArray[i].ToString();
                    // child-2 Integer crossover
                    chromosome_Child_2.Integer_Bin += sp_mather_int_CharArray[i].ToString();
                }
            }
            else
            {
                chromosome_Child_1.Integer_Bin = "0";
                chromosome_Child_2.Integer_Bin = "0";
            }
            //
            //        Create Mantissa Chromosom Children
            //
            if (chromosome_Father.Mantissa_Bin.Length > 1)
            {
                // save string as 0 ~ select_point_integer_Left
                for (int i = 0; i < select_point_m1; i++) 
                {
                    // child-1 Mantissa crossover
                    chromosome_Child_1.Mantissa_Bin += sp_father_double_CharArray[i].ToString();
                    // child-2 Mantissa crossover
                    chromosome_Child_2.Mantissa_Bin += sp_mather_double_CharArray[i].ToString();
                }
                // save string select_point_Mantissa_Center
                chromosome_Child_1.Mantissa_Bin += sp_mather_doublePart;
                // save string select_point_Mantissa_Center
                Chromosome_Child_2.Mantissa_Bin += sp_father_doublePart;
                //
                // save string as select_point_Right ~ end
                for (int i = select_point_m2 + 1; i < chromosome_Father.Mantissa_Bin.Length; i++)
                {
                    // child-1 Integer crossover
                    chromosome_Child_1.Mantissa_Bin += sp_father_double_CharArray[i].ToString();
                    // child-2 Integer crossover
                    chromosome_Child_2.Mantissa_Bin += sp_mather_double_CharArray[i].ToString();
                }
            }
            else
            {
                chromosome_Child_1.Mantissa_Bin = "0";
                chromosome_Child_2.Mantissa_Bin = "0";
            }
            //
            // choose Negative for child_1 chromosome
            int int_negativeMark = two_Gene.Next(0, 1);
            if (int_negativeMark == 0) // choose negative as chromosome_father
                chromosome_Child_1.Negative = chromosome_Father.Negative;
            // choose negative as chromosome_mather
            else chromosome_Child_1.Negative = chromosome_Mather.Negative;
            //
            // choose Negative for child_2 chromosome
            int_negativeMark = two_Gene.Next(0, 1);
            if (int_negativeMark == 0) // choose negative as chromosome_father
                chromosome_Child_2.Negative = chromosome_Father.Negative;
            // choose negative as chromosome_mather
            else chromosome_Child_2.Negative = chromosome_Mather.Negative;
        }

        // Crossover Function Uniform
        private void Uniform(Chromosome chromosome_Father, Chromosome chromosome_Mather, Random two_Gene)
        {
            // Define Children chromosome
            chromosome_Child_1 = new Chromosome();
            chromosome_Child_2 = new Chromosome();
            //
            // convert string chromosm to char[] Array
            //          
            //        chromosome Father works
            char[] char_Father_integer = chromosome_Father.Integer_Bin.ToCharArray();
            char[] char_Father_mantissa = chromosome_Father.Mantissa_Bin.ToCharArray();
            //
            //        chromosome Mather Works
            char[] char_Mather_integer = chromosome_Mather.Integer_Bin.ToCharArray();
            char[] char_Mather_mantissa = chromosome_Mather.Mantissa_Bin.ToCharArray();
            //
            // Random number for select between father & mather chromosome string

            //
            // at algorithm Flow exist:
            // Marge 2 chromosome by randoming bit and create 1 child
            //
            // if(chromosome.(Father & Mather).Length == 8) then    |_|_|_|_|_|_|_|_|
            //                                                       0 1 2 3 4 5 6 7
            // Random Number is between 0~1 (Example: 0.433)
            //  for i=0 --> i=7
            //   {
            //      if Random num > 0.5  then select at Father chromosome bit(i) 
            //      else if Random num <=0.5 then select at Mather chromosome bit(i)
            //   }
            // Example: (F & M length == 4)  
            // Random List:
            //             i=0 --> Random = 0.332           < 0.5
            //             i=1 --> Random = 0.564           > 0.5
            //             i=2 --> Random = 0.003           < 0.5
            //             i=3 --> Random = 0.499           < 0.5
            // Selection:           ×
            //           Father: |_|_|_|_|
            //                    0 1 2 3                  × × × ×
            //                    ×   × ×      ==> Child: |_|_|_|_|
            //           Mather: |_|_|_|_|                 0 1 2 3
            //                    0 1 2 3 
            //
            //        Create CHILD 1
            //
            chromosome_Child_1.Integer_Bin = ""; // for save child_1 chromosome_Integer
            chromosome_Child_1.Mantissa_Bin = ""; // for save child_1 chromosome_mantissa
            //
            // int i=0 ---->          chromosome Father or Mather Integer Length  
            //      |_|_|_|_|_|_|_|_|_ ...
            //   
            for (int i = 0; i < chromosome_Father.Integer_Bin.Length; i++)
            {
                // SelectionPoint is Random Number between 0~1
                //
                // Select & Add Father chromosome.Integer bit[i]
                if (two_Gene.NextDouble() > 0.5)
                    chromosome_Child_1.Integer_Bin += char_Father_integer[i].ToString();
                //
                // Select & Add Mather chromosome.Integer bit[i]
                else
                    chromosome_Child_1.Integer_Bin += char_Mather_integer[i].ToString();
            }
            //
            // int i=0 ---->          chromosome Father or Mather Mantissa Length  
            //      |_|_|_|_|_|_|_|_|_ ...
            //   
            for (int i = 0; i < chromosome_Father.Mantissa_Bin.Length; i++)
            {
                // SelectionPoint is Random Number between 0~1
                //
                // Select & Add Father chromosome.Mantissa bit[i]
                if (two_Gene.NextDouble() > 0.5)
                    chromosome_Child_1.Mantissa_Bin += char_Father_mantissa[i].ToString();
                //
                // Select & Add Mather chromosome.Mantissa bit[i]
                else
                    chromosome_Child_1.Mantissa_Bin += char_Mather_mantissa[i].ToString();
            }
            // 
            //   Select Negative Mark Child1
            //
            double Randoming01 = two_Gene.Next(); // one random number between 0~1
            if (Randoming01 > 0.5) chromosome_Child_1.Negative = chromosome_Father.Negative;
            else chromosome_Child_1.Negative = chromosome_Mather.Negative;

            //
            //        Create CHILD 2
            //

            chromosome_Child_2.Integer_Bin = ""; // for save child_2 chromosome_Integer
            chromosome_Child_2.Mantissa_Bin = ""; // for save child_2 chromosome_mantissa
            //
            // int i=0 ---->          chromosome Father or Mather Integer Length  
            //      |_|_|_|_|_|_|_|_|_ ...
            //   
            for (int i = 0; i < chromosome_Father.Integer_Bin.Length; i++)
            {
                // SelectionPoint is Random Number between 0~1
                //
                // Select & Add Father chromosome.Integer bit[i]
                if (two_Gene.NextDouble() > 0.5)
                    chromosome_Child_2.Integer_Bin += char_Father_integer[i].ToString();
                //
                // Select & Add Mather chromosome.Integer bit[i]
                else
                    chromosome_Child_2.Integer_Bin += char_Mather_integer[i].ToString();
            }
            //
            // int i=0 ---->          chromosome Father or Mather Mantissa Length  
            //      |_|_|_|_|_|_|_|_|_ ...
            //   
            for (int i = 0; i < chromosome_Father.Mantissa_Bin.Length; i++)
            {
                // SelectionPoint is Random Number between 0~1
                //
                // Select & Add Father chromosome.Mantissa bit[i]
                if (two_Gene.NextDouble() > 0.5)
                    chromosome_Child_2.Mantissa_Bin += char_Father_mantissa[i].ToString();
                //
                // Select & Add Mather chromosome.Mantissa bit[i]
                else
                    chromosome_Child_2.Mantissa_Bin += char_Mather_mantissa[i].ToString();
            }
            // 
            //   Select Negative Mark Child2
            //
            Randoming01 = two_Gene.Next(); // one random number between 0~1
            if (Randoming01 > 0.5) chromosome_Child_2.Negative = chromosome_Father.Negative;
            else chromosome_Child_2.Negative = chromosome_Mather.Negative;
        }
        //
        // this program do not used this function because the cpu time being Down Performs ...
        // check the IM_Chromosom in Chromosom_Child
        // and if double number be in Range return true, else return false
        private bool check_Range(string binary_Integer, string binary_Mantissa, bool negative)
        {
            // Convert Binary to Decimal (Integer.Mantissa_Binary ==> Integer.Mantissa_Decimal)
            long decimal_Integer = Convert.ToInt64(binary_Integer, 2);
            long decimal_Mantissa = 0;
            /* try // if (Mantiss == 0) return 0
            {
                decimal_Mantissa = Convert.ToInt32(binary_Mantissa, 2);
            }
            catch
            {
                decimal_Mantissa = 0;
            }
             */
            if (Chromosome.resulation_Mantissa > 0)
                decimal_Mantissa = Convert.ToInt64(binary_Mantissa, 2);
            //
            // Merge Integer_Dec + Mantissa_Dec and convert to string No(Integer.MAntissa_Decimal)
            string No = decimal_Integer.ToString() + "." + decimal_Mantissa.ToString();
            //
            // Convert string NO to double double_Value(Integer.Mantissa_Decimal)
            double double_Value = Convert.ToDouble(No);
            //
            // Apply Negative Sign on double_Value
            if (negative) double_Value *= (-1); // if (negative == true) then double_Value < 0
            //
            // Check double_Value Limited Area in Chromosom Range
            if (double_Value >= Chromosome.min_Rate && double_Value <= Chromosome.max_Rate)
                // Defual Range in Chromosom: max_Rate = 99999.99  &  min_Rate = -99999.99
                return true;
            else return false;
        }
    }
}