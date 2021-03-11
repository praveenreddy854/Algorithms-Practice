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
            int[] a = { 4, 3, 1, 8, 9, 15, 20, 2, 5, 6, 30, 70,
60,80,0,9,67,54,51,52,24,54,7 };
            int[] tempArray = new int[a.Length];
            for(int i = 0; i < a.Length; i++)
            {
                tempArray[i] = a[i];
            }
            SortUtil(a, tempArray, 0, a.Length - 1);
            Print(a);
        }

        private static void SortUtil(int[] a, int[] tempArray, int l, int h)
        {
            if(l < h)
            {
                int m = (l + h) / 2;

                SortUtil(a, tempArray, l, m);

                SortUtil(a, tempArray, m + 1, h);

                Merge(a, tempArray, l, h);
            }
        }
        private static void Merge(int[] a, int[] tempArray, int l, int h)
        {
            int leftEnd = (l + h) / 2;
            int rightStart = leftEnd + 1;

            int lIndex = l;
            int rIndex = rightStart;

            for(int i = l; i <= h; i++)
            {
                if(rIndex <= h && a[lIndex] > a[rIndex])
                {
                    tempArray[i] = a[rIndex++];
                }
                else if(lIndex <= leftEnd)
                {
                    tempArray[i] = a[lIndex++];
                }
                else{
                    tempArray[i] = a[rIndex++];
                }
            }

            for(int i = l; i <= h; i++)
            {
                a[i] = tempArray[i];
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
