using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Heap
    {
        private static int lenght;
        public static void BuildHeap()
        {
            int[] a = new int[] { 10, 15, 14, 1, 9, 22, int.MinValue, int.MinValue, int.MinValue, int.MinValue };
            lenght = 6;
            int startIndex = lenght / 2 - 1;

            for(int i=startIndex;i>=0;i--)
            {
                Heapify(a,i, lenght);
            }
            
            InsertIntoHeap(16, a);


        }
        private static void Heapify(int[] a, int i, int n)
        {
            int largest = i;
            int l = 2 * i + 1;
            int r = 2 * i + 2;

            if (l < n && a[l] > a[largest])
            {
                largest = l;
            }
            if (r < n && a[r] > a[largest])
            {
                largest = r;
            }

            if (largest != i)
            {
                int temp = a[largest];
                a[largest] = a[i];
                a[i] = temp;

                Heapify(a, largest, n);
            }

            

        }


        private static void InsertHeapify(int[] a, int i)
        {
            int parent = (i - 1) / 2;

            if (a[parent] < a[i])
            {
                int temp = a[parent];
                a[parent] = a[i];
                a[i] = temp;

                InsertHeapify(a, parent);
            }
        }

        private static void InsertIntoHeap(int key, int[] a)
        {
            a[lenght] = key;

            lenght = lenght + 1;

            InsertHeapify(a, lenght - 1);
        }
    }
}
