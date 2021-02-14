namespace ConsoleApp1.ArrayProblems
{
    using System;
    public class ContiguousSubArraySum
    {
            public static void MaxSum(int[] a)
            {
                    
                int sum = (int)(-1* Math.Pow(10,7));
                int max = sum;

                for(int i=0; i<a.Length; i++)
                {
                    int temp = sum + a[i];
                    if(a[i] > temp)
                    {
                        sum = a[i];
                    }
                    else
                    {
                        sum = temp;
                    }

                    if(sum > max)
                    {
                        max = sum;
                    }
                }
                System.Console.WriteLine("The max sum is "+max);
            }

            public static void Test()
            {
                int[] a1 = new int[]{1,2,3};
                MaxSum(a1);

                int[] a2 = new int[]{-1,1,2,3};
                MaxSum(a2);

                int[] a3 = new int[]{1,2,-5,3};
                MaxSum(a3);

                int[] a4 = new int[]{1,2,-2,3};
                MaxSum(a4);

                int[] a5 = new int[]{1,2,-2,3,-4};
                MaxSum(a5);




            }
    }
}