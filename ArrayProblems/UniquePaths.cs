namespace Algorithms_Practice.ArrayProblems
{
    //https://leetcode.com/problems/unique-paths/
    public class UniquePathsClass
    {
        int[,] dp;
         public int UniquePaths(int m, int n) {
             dp = new int[m,n];

             for(int i = 0; i < m; i++)
             {
                 for(int j = 0; j < n; j++)
                 {
                     dp[i,j] = -1;
                 }
             }
             dp[m - 1, n - 1] = 1;
             return UniquePathsHelper(0, 0, m, n);
        }
        private int UniquePathsHelper(int rowIndex, int columnIndex, int m, int n)
        {
            if(rowIndex >= m || columnIndex >= n)
            {
                return 0;
            }
            if(dp[rowIndex, columnIndex] != -1)
            {
                return dp[rowIndex, columnIndex];
            }

            int res = UniquePathsHelper(rowIndex + 1, columnIndex, m , n) + UniquePathsHelper(rowIndex, columnIndex + 1, m , n);
            dp[rowIndex, columnIndex] = res;
            return res;
        }
    }
}