namespace ConsoleApp1.ArrayProblems
{
    using System;
    // https://leetcode.com/problems/search-in-rotated-sorted-array/submissions/
    public class SearchRotatedSortedArray
    {
        public int Search(int[] nums, int target) {

            int pivot = FindPivot(nums);
            Console.WriteLine("Pivot "+pivot);
            return SearchHelper(nums, pivot, target);
        }

        private int FindPivot(int[] nums)
        {
            int start = 0, end = nums.Length - 1;

            while(start < end - 1)
            {
                int middle = (start + end) / 2;
                if(nums[middle] > nums[end] )
                {
                    start = middle;
                }
                else
                {
                    end = middle;
                }
            }
            if(nums[start] > nums[end])
            {
                return end;
            }
            return nums.Length - 1;
        }
        private int SearchHelper(int[] nums, int pivot, int target)
        {
            if(target >= nums[0])
            {
                return BinarySearch(nums, 0, pivot, target);
            }
            return BinarySearch(nums, pivot, nums.Length - 1, target);
        }

        private int BinarySearch(int[] nums, int start, int end, int target)
        {
            while(start < end - 1)
            {
                Console.WriteLine("Inside while");
                int middle = (start + end) / 2;
                if(nums[middle] == target)
                {
                    return middle;
                }
                if(target > nums[middle])
                {
                    start = middle;
                }
                else
                {
                    end = middle;
                }
            }
            Console.WriteLine("end "+end);
            Console.WriteLine("start "+start);
            if(nums[end] == target)
            {
                return end;
            }
            if(nums[start] == target)
            {
                return start;
            }
            return -1;
        }
    }
}