namespace ConsoleApp1.ArrayProblems
{
    //https://practice.geeksforgeeks.org/problems/-rearrange-array-alternately-1587115620/1
    public class ReArrangeElementsAlt
    {
        public static void ReArrange(int[] arr, int n)
        {
            int m = arr[n - 1] + 1;
            int right = n - 1;
            int left = 0;

            for(int i = 0; i < n; i++) {
                if(i % 2 == 0) {
                    arr[i] = (arr[right] % m ) / m + arr[i];
                    right--;
                }
                else
                {
                    arr[i] = (arr[left] % m) / m + arr[i];
                    left++;
                }
            }

            for(int i = 0; i < n; i++)
            {
                arr[i] = (arr[i])/ m;
            }
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