namespace Algorithms_Practice.ArrayProblems
{
    //https://leetcode.com/problems/sort-colors/
    public class SortColorsClass
    {
        public void SortColors(int[] nums) {
            int[] dp = new int[3];

            foreach(int num in nums)
            {
                dp[num]++;
            }
            
            int j = 0;
            for(int i =0; i < 3; i++)
            {
                while(dp[i] != 0)
                {
                    nums[j] = i;
                    dp[i]--;
                    j++;
                }
            }
        }
    }
}