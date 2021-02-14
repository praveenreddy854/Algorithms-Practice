using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.ArrayProblems
{
    class SingleNumberClass
    {
        public static int SingleNumber(int[] nums)
        {
            int result = 0;
            foreach(int num in nums)
            {
                result ^= num;
            }
            return result;
        }
    }
}
