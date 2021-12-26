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

            for(int i = 0, l = 0, k = nums.Length - 1; l < k;)
            {
                if(nums[l] == 1)
                {
                    l++;
                }
                else if(nums[l] == 0)
                {
                    int temp = nums[i];
                    nums[i] = nums[l];
                    nums[l] = temp;
                    l++;i++;
                }
                else
                {
                    int temp = nums[k];
                    nums[l] = nums[k];
                    nums[k] = temp;
                }
            }
        }


        
    }
}