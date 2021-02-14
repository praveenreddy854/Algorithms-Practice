using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.NumberProblems
{
    //https://leetcode.com/problems/power-of-three/
    class PowerOfThree
    {
        public bool IsPowerOfThree(int n)
        {
            if (n == 1) return true;
            while(n != 0)
            {
                if(n == 3)
                {
                    return true;
                }
                if (n % 3 != 0)
                {
                    return false;
                }
                n = n / 3;
            }
            
            return false;
        }
    }
}
