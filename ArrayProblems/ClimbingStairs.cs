using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.ArrayProblems
{
    class ClimbingStairs
    {
        public static int ClimbStairs(int n)
        {
           if(n<3)
            {
                return n;
            }

            int last = 2;
            int lastButOne = 1;
            int i = 3;
            while (i<=n)
            {
                int temp = last;
                last = last + lastButOne;
                lastButOne = temp;
                i++;
            }
            return last;
        }
    }
}
