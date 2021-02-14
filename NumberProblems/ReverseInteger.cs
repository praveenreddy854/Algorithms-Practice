using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.NumberProblems
{
    class ReverseInteger
    {
        //https://leetcode.com/problems/reverse-integer/
        public static int Reverse(int x)
        {
            int rem = 0;
            long rev = 0;
            bool isNegative = x < 0 ? true : false;
            if (isNegative)
            {
                x = -1 * x;
            }

            try
            {
                while (x > 0)
                {
                    rem = x % 10;
                    rev = rev * 10 + rem;
                    x = x / 10;

                    if(rev >= int.MaxValue)
                    {
                        throw new Exception();
                    }
                }
            }
            catch
            {
                return 0;
            }

            if(isNegative)
            {
                rev = -1 * rev;
            }
            return (int)rev;
        }
    }
}
