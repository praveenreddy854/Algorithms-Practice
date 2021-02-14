namespace ConsoleApp1.ArrayProblems
{
    //https://practice.geeksforgeeks.org/problems/-rearrange-array-alternately-1587115620/1
    public class ReArrangeElementsAlt
    {
        public static void ReArrange(int[] arr, int n)
        {
            int mid = arr[(n-1) / 2];
            int leftIndex = (n - 2) / 2;
             int rightIndex = leftIndex + 1;
             int targetIndex = n - 1;

             
            if(n % 2 != 0)
            {
                mid = arr[n / 2];
                targetIndex--;
                rightIndex++;
            }

             ReArrangeUtils(arr, arr[leftIndex], arr[rightIndex], leftIndex, rightIndex, targetIndex);

             arr[n - 1] = mid;
        }
        private static void ReArrangeUtils(int[] arr, int left, int right, int leftIndex, int rightIndex, int targetIndex)
        {
            leftIndex--;
            rightIndex++;
            if(leftIndex > -1)
            {
                ReArrangeUtils(arr, arr[leftIndex], arr[rightIndex], leftIndex, rightIndex, targetIndex - 2);
            }

            arr[targetIndex - 1] = right;
            arr[targetIndex] = left;
        }

        public static void Test()
        {
            int[] a1 = new int[] {1, 2, 3, 4, 5, 6};
            int n1 = 6;

            ReArrange(a1, n1);
            int[] a1Expected = new int[] {6, 1, 5, 2, 4, 3};

            for(int i=0; i<n1; i++)
            {
                if(a1[i] != a1Expected[i])
                {
                    System.Console.WriteLine("Invalid answer");
                    break;
                }
            }
            System.Console.WriteLine("Valid.");


            int[] a2 = new int[] {1, 2, 3, 4, 5};
            int n2 = 5;

            ReArrange(a2, n2);
            int[] a2Expected = new int[] {5, 1, 4, 2, 3};

            for(int i=0; i<n2; i++)
            {
                if(a2[i] != a2Expected[i])
                {
                    System.Console.WriteLine("Invalid answer");
                    break;
                }
            }
            System.Console.WriteLine("Valid.");
        }
    }
}