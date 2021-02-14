using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.NumberProblems
{
    class HappyNumbers
    {
        public bool IsHappy(int n)
        {
            int sum = 0;
            do
            {
                while(n != 0)
                {
                    int rem = n % 10;
                    sum += rem * rem;
                    n = (n / 10);
                }
                n = sum;
                sum = 0;
            } while (n >= 10);
            if (n == 1 || n == 7) return true;
            return false;
        }
    }
}
