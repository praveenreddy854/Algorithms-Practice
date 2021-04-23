namespace Algorithms_Practice.ArrayProblems
{
    public class RotateImage
    {
        //https://leetcode.com/problems/rotate-image/
        public void Rotate(int[][] matrix) {
            int n = matrix.Length;

            for(int i = 1, j = 0; j < n; j++, i--)
            {
                while(i < n)
                {
                    int tempI = i; int tempJ = j;
                    while(i > j)
                    {
                        int temp = matrix[i][j];
                        matrix[i][j] = matrix[j][i];
                        matrix[j][i] = temp;
                        i--;
                        j++;
                    }
                    i = tempI;
                    j = tempJ;
                    i++;
                }
            }

            for(int i =0; i < n; i++)
            {
                for(int j = 0, k = n; j < k; j++, k--)
                {
                    int temp = matrix[i][j];
                    matrix[i][j] = matrix[i][k];
                    matrix[i][k] = temp;
                }
            }
        }
    }
}