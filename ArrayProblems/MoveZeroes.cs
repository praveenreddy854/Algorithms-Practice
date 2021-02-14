using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.ArrayProblems
{
    //https://leetcode.com/problems/move-zeroes/
    class MoveZeroesClass
    {
        public void MoveZeroes(int[] nums)
        {
            int i = 0, j = 1;
            while(j<nums.Length)
            {
                if(nums[i] != 0)
                {
                    i++;j++;
                    continue;
                }
                while(nums[j] == 0)
                {
                    j++;
                    if (j == nums.Length) return;
                }
                nums[i] = nums[j];
                nums[j] = 0;
                i++;j++;
            }
        }
    }
}
