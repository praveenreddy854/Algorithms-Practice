using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.ArrayProblems
{
    class LongestIncreasingSubsequence
    {
        public static int GetLongestIncreasingSubsequence(int n, int[] a)
        {
            int[] dp = new int[n];

            for(int k = 0; k<n; k++)
            {
                dp[k] = 1;
            }
            int max = 1;
            for(int i=1;i<n;i++)
            {
                for(int j=0;j<i;j++)
                {
                    if(a[i] > a[j])
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                    }
                }
                if (dp[i] > max)
                {
                    max = dp[i];
                }
            }
            return max;
        }
        public static void Test()
        {
            Test1();
            Test2();
        }
        private static void Test1()
        {
            int expected = 3;
            int actual = GetLongestIncreasingSubsequence(6, new int[] { 5, 8, 3, 7, 9, 1 });
            Console.WriteLine(actual == expected);  
        }
        private static void Test2()
        {
            int expected = 6;
            int actual = GetLongestIncreasingSubsequence(16, new int[] { 0,8,4,12,2,10,6,14,1,9,5,13,3,11,7,15 });
            Console.WriteLine(actual == expected);
        }
    }
}
