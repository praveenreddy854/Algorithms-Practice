namespace Algorithms_Practice.NumberProblems
{
    public class FindDuplicateClass
    {
        public int FindDuplicate(int[] nums) {
            bool[] dp = new bool[nums.Length - 1];
            foreach(int num in nums)
            {
                if(dp[num - 1])
                {
                    return num;
                }
                dp[num - 1] = true;
            }
            return 0;
        }
    }
}