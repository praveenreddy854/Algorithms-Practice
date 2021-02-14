using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.ArrayProblems
{
    class MaxLengthzofPaitChain
    {

        public static int FindLongestChain(int[][] pairs)
        {
            Array.Sort(pairs, (a,b) => a[0] - b[0]);
            int maxLen = 1;
            int i = 1;
            int j = 0;
            while(i < pairs.Length)
            {
                while (pairs[i][0] > pairs[j][1])
                {
                    maxLen++;
                    j = i;
                }
                i++;
            }
            
            return maxLen;
        }
    }
}
