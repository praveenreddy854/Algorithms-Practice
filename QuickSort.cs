using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class QuickSort
    {
        public static void QuickSortFunc()
        {
            //int[] a = { 2, 5, 3, 1, 8, 9 };
            int[] a = {-1, 2, 5, 3, 1, 8, 9, 0 };
            QuickSortUtils(a, 0, a.Length - 1);
            for (int i=0;i<a.Length;i++)
            {
                Console.Write(a[i]+ " ");
            }

        }

        private static void QuickSortUtils(int[] a, int low, int high)
        {
            if (high - low <= 0)
                return;
            int p = QuickSort.Partition(a, low, high);
            QuickSort.QuickSortUtils(a, low, p - 1);
            QuickSort.QuickSortUtils(a, p + 1, high);
        }
        private static int Partition(int[] a, int low, int high)
        {
            int pivot = a[low];
            int pivotIndex = low;
            while(low < high)
            {
                while(low <= high & a[low] <= pivot)
                {
                    low++;
                }
                while(low <= high & a[high] > pivot)
                {
                    high--;
                }
                if(low<high)
                {
                    int temp1 = a[low];
                    a[low] = a[high];
                    a[high] = temp1;
                }
            }
            int temp2 = pivot;
            a[pivotIndex] = a[high];
            a[high] = pivot;
            return high;
        }
    }
}
