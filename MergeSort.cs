using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class MergeSort
    {
        public static void MergeSortFunc()
        {
            int[] a = { 2, 5, 3, 1, 8, 9 };
            SortUtil(a);
            Print(a);
        }

        public static int[] MergeSortFunc(int[] a)
        {
            return SortUtil(a);
        }

        private static int[] SortUtil(int[] a)
        {
            if(a.Length <2)
            {
                return a;
            }
            int n = a.Length;
            int[] left = new int[(int)Math.Floor((double)n / 2)];
            int[] right = new int[(int)Math.Ceiling((double)n / 2)];
            for(int i=0, j=0, k= 0; i<a.Length; i++)
            {
                if(i< (int)Math.Floor((double)n / 2))
                {
                    left[j] = a[i];
                    j++;
                }
                else
                {
                    right[k] = a[i];
                    k++;
                }
            }
            int[] leftSplit = SortUtil(left);
            int[] rightSplit = SortUtil(right);
            Merge(a, leftSplit, rightSplit);
            return a;
        }
        private static void Merge(int[] a, int[] left, int[] right)
        {
            
            for (int i = 0, j = 0, k = 0; i < a.Length; i++)
            {
                if (j < left.Length && ( k >= right.Length || left[j] < right[k]))
                {
                    a[i] = left[j];
                    j++;
                }
                else
                {
                    a[i] = right[k];
                    k++;
                }
            }
        }

        private static void Print(int[] a)
        {
            for(int i =0;i<a.Length;i++)
            {
                Console.WriteLine(a[i]);
            }
        }
    }
}
