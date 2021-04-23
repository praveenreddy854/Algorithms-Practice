using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.ArrayProblems
{
    class UglyNumbers
    {
        public int NthUglyNumber(int n)
        {
            List<int> uglies = new List<int>();

            int twoPointer = 0;
            int threePointer = 0;
            int fivePointer = 0;
            uglies.Add(1);

            while(uglies.Count <= n)
            {
               int nextUgly = Math.Min(uglies[twoPointer] * 2, Math.Min(uglies[threePointer] * 3, uglies[fivePointer] * 5));

               uglies.Add(nextUgly);
            
                if(uglies.Count == n)
                {
                    return nextUgly;
                }
               if(nextUgly == uglies[twoPointer] * 2)
               {
                   twoPointer++;
               }
               else if(nextUgly == uglies[threePointer] * 3)
               {
                   threePointer++;
               }
               else if(nextUgly == uglies[fivePointer] * 5)
               {
                   fivePointer++;
               }
            }
            return uglies[n];
        }
    }
}
