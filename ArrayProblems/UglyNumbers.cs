using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.ArrayProblems
{
    class UglyNumbers
    {
        public static int NthUglyNumber(int n)
        {
            int i2 = 0;
            int i3 = 0;
            int i5 = 0;

            int nexti2 = 2;
            int nexti3 = 3;
            int nexti5 = 5;

            int[] ugly = new int[n];
            int nextUgly = 1;

            ugly[0] = 1;

            for(int i=1;i<n;i++)
            {
                nextUgly = Math.Min(nexti2, Math.Min(nexti3, nexti5));

                ugly[i] = nextUgly;

                if(nextUgly == nexti2)
                {
                    i2++;
                    nexti2 = ugly[i2] * 2;
                }
                if (nextUgly == nexti3)
                {
                    i3++;
                    nexti3 = ugly[i3] * 3;
                }
                if (nextUgly == nexti5)
                {
                    i5++;
                    nexti5 = ugly[i5] * 5;
                }
            }
            return nextUgly;
        }
    }
}
