// 
//    Binary Genetic Algorithm for find minimum fitness F1(x) = |x| + Cos(x)
//    Class DNA
//
using System;
using System.Collections.Generic;
using System.Text;

namespace AI_BGA
{
    class DNA
    {
        #region Define Varible
        
        public static int population_Size = 20; // Default Npop = 20 
        public static Chromosome[] DNA_Array; // Population Chromosome
        public static double[] Pn; // for save chromosome Possibilty  
        public  static int N_keep; // Defined Number of beter chromosomes (Npop - xRate)
        //
        // for send information to Crossover Function Name
        private static string strAlgorithm = "Uniform"; 

        #endregion 

        // Constructor without parameter
        public DNA()
        {
            DNA_Array = new Chromosome[population_Size];
            // create First Randoming Population (matris Npop × Nbit)
            for (int i = 0; i < population_Size; i++)
                DNA_Array[i] = new Chromosome(); 
        }

        // Constructor by (Npop, no_Integer, no_Mantissa, min, max) parameters
        public DNA(int Npop, int no_Integer, int no_Mantissa, double min,
                            double max, string Algorithm, Random two_Gene)
        {
            strAlgorithm = Algorithm;
            population_Size = Npop;
            DNA_Array = new Chromosome[population_Size];
            for (int i = 0; i < population_Size; i++)
                // create First Randoming Population (matris Npop × Nbit)
                DNA_Array[i] = new Chromosome(no_Integer, no_Mantissa, min, max, two_Gene); 
        }

        // Descending Sort All Chromosome by fitness feature
        // sort way is QuickSort Method
        public void QuickSort()
        {
            // Example: buffer, B , A (change A & B place) 
            Chromosome buffer;
            for (int i = DNA_Array.Length - 1; i > 0; i--) // Defined number of row (line-No.) |
                for (int j = 1; j <= i; j++) // Defined number of column (Shift-No.) --
            //
            // Place1 (B , A) ==> if ( B > A ) then change place B <-- A and Place2 (A , B)
            //
                    if (DNA_Array[j - 1].Fitness > DNA_Array[j].Fitness)  
                    {
                        buffer = DNA_Array[j - 1];        // B --> buffer             Place(B, A)
                        DNA_Array[j - 1] = DNA_Array[j];  // B <-- A                  Place(A, A)
                        DNA_Array[j] = buffer;            // buffer --> A             Place(A, B)
                    }
        }

        // Select any worst chromosome for clear and ...
        public void Selection()
        {
            x_Rate();
            if (N_keep == 0) return; // because End Of App
            // craete buffer cache chromosome array to save Temporarily 
            Chromosome[] buffer = new Chromosome[N_keep];
            for (int i = 0; i < N_keep; i++)
                buffer[i] = DNA_Array[i];

            // delete worst chromosomes by start at N_keep
            // for (int i = N_keep; i < population_Size; i++) 
            // {
            //     DNA_Array[i].Negative = false;
            //     DNA_Array[i].Integer_Bin = "0";
            //     DNA_Array[i].Integer_Dec = 0;
            //     DNA_Array[i].Mantissa_Bin = "0";
            //     DNA_Array[i].Mantissa_Dec = 0;
            //     DNA_Array[i].IM_Chromosome = 0.0;
            //     DNA_Array[i].Fitness = 0.0;
            // }

            // Craete New Array to save population chromosomes
            DNA_Array = new Chromosome[population_Size];
            //
            // Rebulding Chromosome Array 
            for (int i = 0; i < N_keep; i++)
                DNA_Array[i] = buffer[i];
        }

        //find percent of All chromosome rate for delete Amiss(xRate) or Useful(Nkeep) chromosome
        //x_Rate Accourding by chromosome fitness Average 
        private void x_Rate()
        {
            // calculate Addition of all fitness
            double sumFitness = 0;
            for (int i = 0; i < population_Size; i++)
                sumFitness += DNA_Array[i].Fitness;
            // calculate Average of All chromosome fitness 
            double aveFitness = sumFitness / population_Size; //Average of all chromosome fitness
            N_keep = 0; // N_keep start at 0 till Average fitness chromosome
            for (int i = 0; i < population_Size; i++) 
                if (aveFitness < DNA_Array[i].Fitness)
                {
                    N_keep = i; // counter as 0 ~ fitness Average + 1
                    break;
                }
        }

        // Create New chromosome with Father & Mather Chromosome Instead of deleted chromosomes
        public void Reproduction(Random two_Gene)
        {
            // Definiton Probability Accourding by chromosome fitness 
            // create Pn[N_keep];
            Rank_Trim();

            Crossover father_mather;
            Mutation offspring = new Mutation();
            //
            // for send and check Father & Mather chromosome
            Chromosome Rank_Father;
            Chromosome Rank_Mather;
            for (int i = N_keep; i < population_Size; i += 2)
            {
                // have a problem (maybe Rank_1() == Rank_2()) then Father == Mather
                // Solve Problem by checker Loop
                do
                {
                    Rank_Father = Rank(two_Gene);
                    Rank_Mather = Rank(two_Gene);
                }
                while(Rank_Father == Rank_Mather);
                //
                father_mather = new Crossover(Rank_Father, Rank_Mather, strAlgorithm, two_Gene);
                //
                //  Crossover by Mutation
                //
                if (FormBGA.checkedMutation)
                {
                    //DNA_Array[i] = father_mather.Chromosome_Child_1;
                    DNA_Array[i] = offspring.uniform(father_mather.Chromosome_Child_1, two_Gene);
                    try
                    {
                        //DNA_Array[i + 1] = father_mather.Chromosome_Child_2;
                        DNA_Array[i + 1] = offspring.uniform(father_mather.Chromosome_Child_2
                                                                , two_Gene);
                    }
                    catch
                    {
                        break; // DNA_Array index Array is out of rang 
                    }
                }
                else
                {
                    //DNA_Array[i] = father_mather.Chromosome_Child_1;
                    DNA_Array[i] = father_mather.Chromosome_Child_1;
                    try
                    {
                        //DNA_Array[i + 1] = father_mather.Chromosome_Child_2;
                        DNA_Array[i + 1] = father_mather.Chromosome_Child_2;
                    }
                    catch
                    {
                        break; // DNA_Array index Array is out of rang 
                    }
                }
            }
        }

        // Definiton Probability Accourding by chromosome fitness 
        private void Rank_Trim()
        {
            // First Reserve Possibility Number for every Remnant chromosome 
            // chromosome Possibility Function is:
            // (1 + N_keep - No.chromosome) / ( ∑ No.chromosome) 
            // Where as at this program No.chromosome Of Array begin as Number 0
            // There for No.chromosome in Formula = No.chromosome + 1
            // then function is: if (n == N_keep)
            // Possibility[No.chromosome] = (n - No.chromosome) / (n(n+1) / 2)
            //
            Pn = new double[N_keep]; // Create chromosome possibilty Array Cell as N_keep
            double Sum = ((N_keep * (N_keep + 1)) / 2); // (∑ No.chromosome) == (n(n+1) / 2)
            Pn[0] = N_keep / Sum; // Father (Best - Elit) chromosome Possibility
            for (int i = 1; i < N_keep; i++)
            {
                // Example: if ( Pn[Elit] = 0.4  &  Pn[Elit +1] = 0.2  &  Pn[Elit +2]  = 0.1 )
                // Then Own:          0 <= R <= 0.4 ===> Select chromosome[Elit]
                //                  0.4 <  R <= 0.6 ===> Select chromosome[Elit +1] 
                //                  0.6 <  R <= 0.7 ===> Select chromosome[Elit +2]
                // etc ... 
                Pn[i] = ((N_keep - i) / Sum) + Pn[i - 1];
            } 
        }

        // Return Father and Mather chromosome with Probability of chromosome fitnes
        private Chromosome Rank(Random two_Gene)
        {
            double R = two_Gene.NextDouble();
            for (int i = 0; i < N_keep; i++)
            {
                // Example: if ( Pn[Elit] = 0.6  &  Pn[Elit+1] = 0.3  &  Pn[Elit+2]  = 0.1 )
                // Then Own:          0 <= R <= 0.6  ===> Select chromosome[Elit]
                //                  0.6 <  R <= 0.9  ===> Select chromosome[Elit +1] 
                //                  0.9 <  R <= 1    ===> Select chromosome[Elit +2]
                // 
                if (R <= Pn[i]) return DNA_Array[i];
                else continue;
            }
            return DNA_Array[0]; // if don't run Modality of 'for' then return Elit chromosome 
        }

        // Check the isotropy All REMNANT chromosome (N_keep)
        public bool Isotropy_Evaluatuon()
        {
            // Isotropy percent is 90% of All chromosome Fitness
            int per_Iso = Convert.ToInt32(Math.Truncate(Convert.ToDouble(90 * N_keep / 100)));
            int counter_Isotropy = 0;
            double BestFitness = DNA_Array[0].Fitness;
            //
            // i start at 1 because DNA_Array[0] is self BestFitness
            for (int i = 1; i < N_keep; i++) 
                if (BestFitness >= DNA_Array[i].Fitness) counter_Isotropy++;
            
            // G.A Algorithm did isotropy and app Stoped
            if (counter_Isotropy >= per_Iso) return false; 
            else return true; // G.A Algorithm didn't isotropy and app will continued
        }
    }
}