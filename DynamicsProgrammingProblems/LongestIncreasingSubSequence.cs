namespace Algorithms_Practice.DynamicsProgrammingProblems
{
    using System;
    //https://leetcode.com/problems/longest-increasing-subsequence/submissions/
    public class LongestIncreasingSubSequence
    {
         public int LengthOfLIS(int[] nums) {
             if(nums.Length == 0) return 0;
        int[] dp = new int[nums.Length];
            dp[0] = 1;
            int ans = 1;
            for(int i = 1; i < nums.Length; i++)
            {
                int maxValue = 0;
                for(int j = 0; j < i; j++)
                {
                    if(nums[i] > nums[j])
                    {
                        maxValue = Math.Max(maxValue, dp[j]);
                    }
                }
                dp[i] = maxValue + 1;
                ans = Math.Max(ans, dp[i]);
            }
            return ans;
    }
        public static void Test()
        {
            LongestIncreasingSubSequence obj = new LongestIncreasingSubSequence();
            int r = obj.LengthOfLIS(new int[]{10, 9, 2, 5, 3, 7, 101, 18});
            System.Console.WriteLine(r);
        }
    }
}