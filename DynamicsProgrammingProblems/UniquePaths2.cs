namespace Algorithms_Practice.DynamicsProgrammingProblems
{
    //https://leetcode.com/problems/unique-paths-ii/
    public class UniquePaths2
    {
        int maxRows = 0;
        int maxCols = 0;
        Reachability[][] lookUp;
        int[][] counter;
        public int UniquePathsWithObstacles(int[][] obstacleGrid) {
            maxCols = obstacleGrid[0].Length;
            maxRows = obstacleGrid.Length;
            System.Console.WriteLine("rows "+ maxRows);
            System.Console.WriteLine("cols "+ maxCols);
            lookUp = new Reachability[maxRows][];
            counter = new int[maxRows][];

            for(int i = 0; i < maxRows; i++)
            {
                lookUp[i] = new Reachability[maxCols];
                counter[i] = new int[maxCols];
            }
            lookUp[maxRows - 1][maxCols - 1] = obstacleGrid[maxRows - 1][maxCols - 1] == 0 ? Reachability.Reachable : Reachability.Unrechable;
            counter[maxRows - 1][maxCols - 1] = obstacleGrid[maxRows - 1][maxCols - 1] == 0 ? 1 : 0;
            return UniquePathsWithObstaclesHelper(0, 0, obstacleGrid);
        }

        private int UniquePathsWithObstaclesHelper(int row, int col, int[][] obstacleGrid)  
        {
            if(row >= maxRows || col >= maxCols)
            {
                return 0;
            }
            if(lookUp[row][col] == Reachability.Reachable && obstacleGrid[row][col] == 0)
            {
                lookUp[row][col] = Reachability.Reachable;
                return counter[row][col] + 1;
            }
            else if(lookUp[row][col] == Reachability.Unrechable || obstacleGrid[row][col] == 1)
            {
                lookUp[row][col] = Reachability.Unrechable;
                return 0;
            }

            int result = UniquePathsWithObstaclesHelper(row, col + 1, obstacleGrid) + UniquePathsWithObstaclesHelper(row + 1, col, obstacleGrid);

            if(result > 0)
            {
                lookUp[row][col] = Reachability.Reachable;
                counter[row][col] = result;
            }
            else
            {
                lookUp[row][col] = Reachability.Unrechable;
            }
            return result;
        }

        public static void Test()
        {
            UniquePaths2 obj = new UniquePaths2();
            int[][] a = new int[4][];
            a[0] = new int[5] {0,0,0,0,0};
            a[1] = new int[5] {0,0,0,0,1};
            a[2] = new int[5] {0,0,0,1,0};
            a[3] = new int[5] {0,0,0,0,0};
            int r = obj.UniquePathsWithObstacles(a);
            System.Console.WriteLine(r);
        }
    }
    public enum Reachability
    {
        UnKnown,
        Reachable,
        Unrechable
        
    }
}