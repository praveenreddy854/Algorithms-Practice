using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class DynamicsProgramming
    {
        /// <summary>
        /// 0/1 knapsack problem
        /// Select items to get max profit. Max weight allowed is 8
        /// </summary>
        public static void SelectItemsForMaxProfit()
        {
            int[] weights = { 0, 5, 3, 4, 2 };
            int[] profits = { 0, 60, 50, 70, 30 };
            int maxWeight = 8;
            int[,] matrix = new int[weights.Length, maxWeight + 1];
            for(int i=1; i< weights.Length; i++)
            {
                for(int j=1; j<= maxWeight; j++)
                {
                    int ignoringThis = matrix[i - 1, j];
                    if (j - weights[i] >= 0)
                    {
                        int consideringThis = matrix[i - 1, j - weights[i]] + profits[i];
                        
                        matrix[i, j] = Math.Max(consideringThis, ignoringThis);
                    }
                    else
                    {
                        matrix[i, j] = ignoringThis;
                    }
                    
                }    
            }
            Console.WriteLine(matrix[weights.Length-1, maxWeight]);
        }
    }
}
