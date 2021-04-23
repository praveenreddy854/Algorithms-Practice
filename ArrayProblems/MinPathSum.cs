namespace Algorithms_Practice.ArrayProblems
{
    using System.Collections.Generic;
    using System;
    public class MinPathSumClass
    {
         public int MinPathSum(int[][] grid) {
             int columns = grid[0].Length;
             int rows = grid.GetLength(0);
             int[][] result = new int[rows][];
             bool[][] visited = new bool[rows][];

             for(int i = 0; i < rows; i++)
             {
                 result[i] = new int[columns];
                 visited[i] = new bool[columns];
             }

             for(int i = 0; i < rows; i++)
             {
                 for(int j = 0; j < columns; j++)
                 {
                     result[i][j] = int.MaxValue;
                 }
             }

             Queue<KeyValuePair<int, int>> q = new Queue<KeyValuePair<int, int>>();

             q.Enqueue(new KeyValuePair<int, int>(0, 0));

             while(q.Count > 0)
             {
                 KeyValuePair<int, int> indexKVP = q.Dequeue();

                 if(visited[indexKVP.Key][indexKVP.Value])
                 {
                     continue;
                 }

                 if(indexKVP.Key + 1 < rows)
                 {
                     q.Enqueue(new KeyValuePair<int, int>(indexKVP.Key + 1, indexKVP.Value));
                 }
                 if(indexKVP.Value + 1 < columns)
                 {
                     q.Enqueue(new KeyValuePair<int, int>(indexKVP.Key, indexKVP.Value + 1));
                 }

                 if(indexKVP.Key - 1 >= 0 && indexKVP.Value - 1 >= 0)
                 {
                     result[indexKVP.Key][indexKVP.Value] = Math.Min(result[indexKVP.Key - 1][indexKVP.Value], result[indexKVP.Key][indexKVP.Value - 1]) + grid[indexKVP.Key][indexKVP.Value];
                 }
                 else if(indexKVP.Key - 1 >= 0)
                 {
                     result[indexKVP.Key][indexKVP.Value] = result[indexKVP.Key - 1][indexKVP.Value] + grid[indexKVP.Key][indexKVP.Value];
                 }
                 else if(indexKVP.Value - 1 >= 0)
                 {
                     result[indexKVP.Key][indexKVP.Value] = result[indexKVP.Key][indexKVP.Value - 1] + grid[indexKVP.Key][indexKVP.Value];
                 }
                 else
                 {
                     result[indexKVP.Key][indexKVP.Value] = grid[indexKVP.Key][indexKVP.Value];
                 }
                 visited[indexKVP.Key][indexKVP.Value] = true;
             }
             return result[rows - 1][columns - 1];
        }

        public static void Test()
        {
            int[][] a = new int[][]
            {
                new int[]{1,2,3},
                new int[]{4,5,6}
            };

            MinPathSumClass obj = new MinPathSumClass();

            obj.MinPathSum(a);
        }
    }
}