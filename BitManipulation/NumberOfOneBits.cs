using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.BitManipulation
{
    public class NumberOfOneBits
    {
        public int HammingWeight(uint n)
        {
            uint res = 0;
            int count = 0;
            while(n != 0)
            {
                res = n & 1;
                if(res == 1)
                {
                    count++;
                }
                n = n >> 1;
            }
            return count;
        }
    }
}
