using System;

namespace Algorithms_Practice.ArrayProblems
{
    public class ZerosAndOnesSegregation
    {
        /*
        Segregate 0s on left side and 1s on right side of the array. Traverse array only once.

        Input array   =  [0, 1, 0, 1, 0, 0, 1, 1, 1, 0]

        Output array =  [0, 0, 0, 0, 0, 1, 1, 1, 1, 1]
        */

        public static int[] SeparateZerosAndOnes(int[] a)
        {
            int i = 0; 
            int j = a.Length - 1;

            while(i < j)
            {
                while(i < a.Length - 1 && a[i] == 0)
                {
                    i++;
                }
                while(j > 0 && a[j] == 1)
                {
                    j--;
                }

                a[i++] = 0;
                a[j--] = 1;
            }

            return a;
        }

        public static void Test()
        {
            int[] a = new int[]{0,1,0,1,0,0,1,1,1,0};
            a = SeparateZerosAndOnes(a);
            foreach(int num in a)
            {
                System.Console.WriteLine(num + " ");
            }
        }
    }
}