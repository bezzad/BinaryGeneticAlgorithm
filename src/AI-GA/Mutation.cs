// 
//    Binary Genetic Algorithm for find minimum fitness F1(x) = |x| + Cos(x)
//    Class Mutation
//
using System;
using System.Collections.Generic;
using System.Text;

namespace AI_BGA
{
    class Mutation
    {
        // Function Uniform of class Mutation
        // change a bit of offspring chromosome for mutation
        public Chromosome uniform(Chromosome offspring, Random two_Gene)
        {
            // Random Number for choose a bit between 0 ~ (offspring.Length - 1)
            // if(offspring.Length == 8)
            //                           (0)×-------------×(offspring.Length-1)
            //                             |_|_|_|_|_|_|_|_|
            //                              0 1 2 3 4 5 6 7
            //
            //
            if (offspring.Integer_Bin.Length > 1) // Minimum offspring.Length for mutation is 2bit
            {
                // choose a point between 0 ~ offspring.Length - 1 
                int Integer_point = two_Gene.Next(0, offspring.Integer_Bin.Length - 1);
                // convert string to charArray for read a bit
                char[] charArrary_Integer_Bin = offspring.Integer_Bin.ToCharArray();
                //
                //             change a bit of selected point
                //
                // change by (NOT Bit) function   (0 --> 1)  or  (1 --> 0)
                if (charArrary_Integer_Bin[Integer_point] == '0') 
                    charArrary_Integer_Bin[Integer_point] = '1';
                
                else if (charArrary_Integer_Bin[Integer_point] == '1') 
                    charArrary_Integer_Bin[Integer_point] = '0';
                // convert charArray to string for save offspring chromosome 
                offspring.Integer_Bin = "";
                for (int i = 0; i < charArrary_Integer_Bin.Length; i++)
                    offspring.Integer_Bin += charArrary_Integer_Bin[i].ToString();
            }

            // Minimum offspring.Length for mutation is 2bit
            if (offspring.Mantissa_Bin.Length > 1) 
            {
                // choose a point between 0 ~ offspring.Length - 1 
                int Mantissa_point = two_Gene.Next(0, offspring.Mantissa_Bin.Length - 1);
                // convert string to charArray for read a bit
                char[] charArray_Mantissa_Bin = offspring.Mantissa_Bin.ToCharArray();
                //
                //             change a bit of selected point
                //
                // change by (NOT Bit) function   (0 --> 1)  or  (1 --> 0)
                if (charArray_Mantissa_Bin[Mantissa_point] == '0') 
                    charArray_Mantissa_Bin[Mantissa_point] = '1';
                
                else if (charArray_Mantissa_Bin[Mantissa_point] == '1') 
                    charArray_Mantissa_Bin[Mantissa_point] = '0';
                // convert charArray to string for save offspring chromosome 
                offspring.Mantissa_Bin = "";
                for (int i = 0; i < charArray_Mantissa_Bin.Length; i++)
                    offspring.Mantissa_Bin += charArray_Mantissa_Bin[i].ToString();
            }
            // deCoder & Evaluate Fitness & IM_Chromosome
            offspring.Evaluate();

            // return changed chromosome
            return offspring;
        }   
    }
}
