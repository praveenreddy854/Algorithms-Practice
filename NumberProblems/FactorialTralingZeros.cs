using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.NumberProblems
{
    class FactorialTralingZeros
    {
        public int TrailingZeroes(int n)
        {
            int count = 0;
            while(n >= 0)
            {
                n = n / 5;
                count+= n;
            }
            return count;
        }
    }
}
