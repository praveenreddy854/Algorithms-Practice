namespace Algorithms_Practice.ArrayProblems
{
    public class SearchMatrix2
    {
        // https://leetcode.com/problems/search-a-2d-matrix-ii/
        public bool SearchMatrix(int[][] matrix, int target) {
            int rows = matrix.Length;
            int cols = matrix[0].Length;

            int row = 0;
            int col = cols - 1;

            while (row < rows && col >= 0) {
                if(matrix[row][col] == target)
                {
                    return true;
                }
                if(matrix[row][col] > target)
                {
                    col--;
                }
                else
                {
                    row++;
                }
            }
            return false;
        }

        public static void Test()
        {
            int[][] matrix1 = new int[5][]
            {
                new int[5]{1,4,7,11,15},
                new int[5] {2,5,8,12,19},
                new int[5]{3,6,9,16,22},
                new int[5] {10,13,14,17,24},
                new int[5]{18,21,23,26,30}
            };
            int[][] matrix2 = new int[1][]
            {
                new int[2]{1, 1}
            };

            SearchMatrix2 searchMatrix = new SearchMatrix2();
            System.Console.WriteLine(searchMatrix.SearchMatrix(matrix2, 0));
        }
    }
}