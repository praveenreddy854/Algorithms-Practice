using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.ArrayProblems
{
    /// <summary>
    /// You may assume k is always valid, 1 ≤ k ≤ number of unique elements.
    //Your algorithm's time complexity must be better than O(n log n), where n is the array's size.
    //It's guaranteed that the answer is unique, in other words the set of the top k frequent elements is unique.
    //You can return the answer in any order.
    /// </summary>
    class TopKFrequentElements
    {
        public static int[] TopKFrequent(int[] nums, int k)
        {
            Dictionary<int, int> dict = new Dictionary<int, int>();
            KeyValuePair<int,int>[] heap = new KeyValuePair<int, int>[nums.Length];
            int[] result = new int[k];
            TopKFrequentElements obj = new TopKFrequentElements();
            for (int i=0;i<nums.Length;i++)
            {
                if(dict.ContainsKey(nums[i]))
                {
                    dict[nums[i]]++;
                }
                else
                {
                    dict[nums[i]] = 1;
                }
            }
            int index = 0;
            foreach(KeyValuePair<int,int> kp in dict)
            {
                heap[index] = kp;
                index++;
            }

            obj.BuildHeap(heap);

            for(int i=0;i<k;i++)
            {
                result[i] = obj.DeleteRootFromHeap(heap, heap.Length - i).Key;
            }
            return result;
        }

        private void BuildHeap(KeyValuePair<int, int>[] a)
        {
            for (int i = 0; i < a.Length; i++)
            {
                Heapify(i, a);
            }
        }

        private KeyValuePair<int, int> DeleteRootFromHeap(KeyValuePair<int, int>[] a, int heapSize)
        {
            int lastIndex = heapSize - 1;
            KeyValuePair<int, int> temp = a[0];
            a[0] = a[lastIndex];
            a[lastIndex] = temp;

            DeleteHeapify(0, a, lastIndex);
            return temp;
        }
        private void Heapify(int i, KeyValuePair<int, int>[] a)
        {
            int parentIndex = (i - 1) / 2;

            if (a[i].Value > a[parentIndex].Value)
            {
                KeyValuePair<int,int> temp = a[i];
                a[i] = a[parentIndex];
                a[parentIndex] = temp;

                Heapify(parentIndex, a);
            }
        }

        private void DeleteHeapify(int i, KeyValuePair<int, int>[] a, int heapSize)
        {
            int leftIndex = 2 * i + 1;
            int rightIndex = 2 * i + 2;
            int largestIndex = i;

            if (leftIndex < heapSize && a[leftIndex].Value > a[largestIndex].Value)
            {
                largestIndex = leftIndex;
            }
            if (rightIndex < heapSize && a[rightIndex].Value > a[largestIndex].Value)
            {
                largestIndex = rightIndex;
            }

            if (largestIndex != i)
            {
                KeyValuePair<int, int> temp = a[i];
                a[i] = a[largestIndex];
                a[largestIndex] = temp;

                DeleteHeapify(largestIndex, a, heapSize);
            }

        }
    }
}
