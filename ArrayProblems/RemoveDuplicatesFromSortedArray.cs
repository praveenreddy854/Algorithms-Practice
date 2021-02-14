using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.ArrayProblems
{
    class RemoveDuplicatesFromSortedArray
    {
        //https://leetcode.com/problems/remove-duplicates-from-sorted-array/
        public static int RemoveDuplicates(int[] nums)
        {
            if(nums.Length < 2)
            {
                return nums.Length;
            }

            int i = 0;
            for(int j=0;j<nums.Length;j++)
            {
                if(nums[i] != nums[j])
                {
                    i++;
                    nums[i] = nums[j];
                }
            }
            return i + 1;
        }
    }
}
