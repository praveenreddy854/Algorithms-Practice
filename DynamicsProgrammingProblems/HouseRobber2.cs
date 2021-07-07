using System;

namespace Algorithms_Practice.DynamicsProgrammingProblems
{
    public class HouseRobber2
    {
        public int Rob(int[] nums) {

            int length = nums.Length;
            if(length == 1) {
                return nums[0];
            }
          
            if(length == 2)
            {
                return Math.Max(nums[0], nums[1]);
            }

            return Math.Max(RobeHelper(nums, 0, length - 1), RobeHelper(nums, 1, length));
        }
        private int RobeHelper(int[] nums, int start, int end)
        {
            int prev1 = 0;
            int prev2 = 0;

            for(int i = start; i < end; i++)
            {
                int temp = prev1;
                prev1 = Math.Max(prev1, prev2 + nums[i]);
                prev2 = temp;
            }
            return prev1;
        }
    }
}