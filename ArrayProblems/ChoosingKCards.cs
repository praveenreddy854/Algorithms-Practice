namespace Algorithms_Practice.ArrayProblems
{
    using System;
    //https://leetcode.com/problems/maximum-points-you-can-obtain-from-cards/
    public class ChoosingKCards
    {
        public int MaxScore(int[] cardPoints, int k) {
              int ans = 0;
            if(k >= cardPoints.Length)
            {
                foreach(int i in cardPoints)
                    ans += i;
                return ans;
            }
            int left = 0, right = 0;
            for(int i = 1; i <= k; i++)
            {
                right += cardPoints[cardPoints.Length - i];
            }

            ans = left + right;
            for(int i = 0; i < k; i++){
                left += cardPoints[i];
                right -= cardPoints[cardPoints.Length - 1 - (k - i)];
                ans = Math.Max(ans, left + right);
            }
            return ans;
        }
    }
}