using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.BitManipulation
{
    class MissingNumber
    {
        //https://leetcode.com/problems/missing-number/
        public int GetMissingNumber(int[] nums)
        {
            int targetSum = nums.Length * (nums.Length + 1) / 2;
            int sum = 0;
            foreach(int num in nums)
            {
                sum += num;
            }
            return targetSum - sum;
        }
    }
}
