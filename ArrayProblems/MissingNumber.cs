namespace ConsoleApp1.ArrayProblems
{
    //https://practice.geeksforgeeks.org/problems/missing-number-in-array1416/1
    public class MissingNumber
    {
        public int GetMissingNumber(int[] array, int n)
        {
            int targetSum = n * (n + 1)/2;
            int sum = 0;
            foreach(int i in array)
            {
                sum += i;
            }
            return targetSum - sum;
        }
    }
}