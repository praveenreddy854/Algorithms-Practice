namespace Algorithms_Practice.DynamicsProgrammingProblems
{
    //https://leetcode.com/problems/unique-paths-iii/
    public class UniquePaths3
    {
        private int rowsCount = 0;
        private int colsCount = 0;
        private Reachability3[][] reachableLookUp;
        private int maxCounter = 0;
        private int ans = 0;
        public int UniquePathsIII(int[][] grid) {
            rowsCount = grid.Length;
            colsCount = grid[0].Length;
            reachableLookUp = new Reachability3[rowsCount][];

            for(int i = 0; i < rowsCount; i++)
            {
                reachableLookUp[i] = new Reachability3[colsCount];
            }
            
            int startRowIndex = 0, startColIndex = 0;
            for(int i = 0; i < rowsCount; i++)
            {
                for(int j = 0; j < colsCount; j++)
                {
                    if(grid[i][j] == 1)
                    {
                        startRowIndex = i;
                        startColIndex = j;
                    }
                    if(grid[i][j] >= 0)
                    {
                        maxCounter++;
                    }
                }
            }
            System.Console.WriteLine("max counter "+ maxCounter);
            UniquePathsIIIHelper(startRowIndex, startColIndex, grid, maxCounter);
            return ans;
        }
        private void UniquePathsIIIHelper(int row, int col, int[][] grid, int maxCounter)
        {
            if(row >= rowsCount || col >= colsCount || row < 0 || col < 0)
            {
                return;
            }
            if(reachableLookUp[row][col] == Reachability3.Visited || grid[row][col] == -1)
            {
                return;
            }
            maxCounter--;

            if(grid[row][col] == 2)
            {
                if(maxCounter == 0)
                {
                    ans++;
                }
                return;
            }
            
            reachableLookUp[row][col] = Reachability3.Visited;
            
            UniquePathsIIIHelper(row, col - 1, grid, maxCounter);
            UniquePathsIIIHelper(row + 1, col, grid, maxCounter);
            UniquePathsIIIHelper(row, col + 1, grid, maxCounter);
            UniquePathsIIIHelper(row - 1, col, grid, maxCounter);
            reachableLookUp[row][col] = Reachability3.NotVisited;
        }

        public static void Test()
        {
            UniquePaths3 obj = new UniquePaths3();
            int[][] a = new int[3][];
            a[0] = new int[4] {1,0,0,0};
            a[1] = new int[4] {0,0,0,0};
            a[2] = new int[4] {0,0,2,-1};
            int r = obj.UniquePathsIII(a);
            System.Console.WriteLine(r);
        }
    }
    public enum Reachability3
    {
        NotVisited,
        Visited
    }
}