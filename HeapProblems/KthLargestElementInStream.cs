using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.HeapProblems
{
    class KthLargestElementInStream
    {
        public int KthLargest { get; set; }
        public KthLargestElementInStream(int k, int[] a)
        {
            KthLargest = GetKthLargest(k, a);
        }

        private int GetKthLargest(int k, int[] a)
        {
            // Convert a[] to heap
            BuildHeap(a);

            int heapSize = a.Length;
            for (int i = 0; i != k - 1; i++, heapSize--)
            {
                DeleteRootFromHeap(a, heapSize);
            }

            return a[0];
        }

        private void BuildHeap(int[] a)
        {
            for(int i =0; i<a.Length; i++)
            {
                Heapify(i, a);
            }
        }
        
        private void DeleteRootFromHeap(int[] a, int heapSize)
        {
            int lastIndex = heapSize - 1;
            int temp = a[0];
            a[0] = a[lastIndex];
            a[lastIndex] = temp;

            DeleteHeapify(0, a, lastIndex);
        }
        private void Heapify(int i, int[] a)
        {
            int parentIndex = (i - 1) / 2;

            if(a[i] > a[parentIndex])
            {
                int temp = a[i];
                a[i] = a[parentIndex];
                a[parentIndex] = temp;

                Heapify(parentIndex, a);
            }
        }

        private void DeleteHeapify(int i, int[] a, int heapSize)
        {
            int leftIndex = 2 * i + 1;
            int rightIndex = 2 * i + 2;
            int largestIndex = i;

            if(leftIndex < heapSize && a[leftIndex] > a[largestIndex])
            {
                largestIndex = leftIndex;
            }
            if(rightIndex < heapSize && a[rightIndex] > a[largestIndex])
            {
                largestIndex = rightIndex;
            }

            if(largestIndex != i)
            {
                int temp = a[i];
                a[i] = a[largestIndex];
                a[largestIndex] = temp;

                DeleteHeapify(largestIndex, a, heapSize);
            }

        }
    }
}
