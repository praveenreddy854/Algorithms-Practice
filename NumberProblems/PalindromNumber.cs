using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.NumberProblems
{
    class PalindromNumber
    {
        public static bool IsPolidrom(int x)
        {
            int temp = x;
            int rem = 0;
            long rev = 0;
            bool isNegative = x < 0 ? true : false;
            if (isNegative)
            {
                return false;
            }

            try
            {
                while (x > 0)
                {
                    rem = x % 10;
                    rev = rev * 10 + rem;
                    x = x / 10;

                    if (rev >= int.MaxValue)
                    {
                        throw new Exception();
                    }
                }
            }
            catch
            {
                return false;
            }
            
            return temp == rev;
        }
    }
}
