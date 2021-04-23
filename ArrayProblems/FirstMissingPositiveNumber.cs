namespace Algorithms_Practice.ArrayProblems
{
    using System.Collections.Generic;
    using System;
    public class FirstMissingPositiveNumberClass
    {
        public int FirstMissingPositive(int[] nums) {
            HashSet<long> set = new HashSet<long>();
            int max = 0;

            for(int i = 0; i < nums.Length; i++)
            {
               set.Add(nums[i]);
               max = Math.Max(max, nums[i]);
            }
            max = Math.Max(max, nums.Length + 1);

            for(int i = 1; i < set.Count; i++)
            {
                if(!set.Contains(i))
                {
                    return i;
                }
            }

            return max + 1;
        }
        
    }
}