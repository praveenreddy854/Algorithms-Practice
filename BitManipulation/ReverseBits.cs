using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.BitManipulation
{
    //https://leetcode.com/problems/reverse-bits/
    class ReverseBits
    {
        public static uint ReverseBitsWithShift(uint n)
        {
            uint ret = 0;
            int i = 0;
            while(i<32)
            {
                ret += (n & 1) << 31 - i;
                n = n >> 1;
                i++;
            }
            return ret;
        }
    }
}
