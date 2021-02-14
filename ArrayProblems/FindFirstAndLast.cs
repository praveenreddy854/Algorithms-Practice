namespace ConsoleApp1.ArrayProblems
{
    //https://leetcode.com/problems/find-first-and-last-position-of-element-in-sorted-array/
    public class FindFirstAndLast
    {
        int first{get;set;}
        int last {get;set;}
        public int[] SearchRange(int[] nums, int target) {
            first = -1; last = -1;
            SearchRangeUntil(nums, 0, nums.Length - 1 , target, true);
            
            if(last != - 1)
            {
                SearchRangeUntil(nums, last, nums.Length - 1 , target, false);
            }
            else
            {
                SearchRangeUntil(nums, 0, nums.Length - 1 , target, false);
            }
            return new int[]{first, last};
        }
        private void SearchRangeUntil(int[] nums, int start, int end, int target, bool findFirst) 
        {
            if(start > end || end >= nums.Length)
            {
                return;
            }

            int mid = (start +  end) / 2;
            if(nums[mid] == target)
            {
                if(first == -1 || mid < first )
                {
                    first = mid;
                }
                if(last == -1 || mid > last )
                {
                    last = mid;
                }
            }
            if(start == mid)
            {
                return;
            }
            if((findFirst && nums[mid] >= target) || (!findFirst && nums[mid] > target))
            {
                SearchRangeUntil(nums, start, mid - 1, target, findFirst);
            }
            else{
                SearchRangeUntil(nums, mid + 1, end, target, findFirst);
            }
        }
        private void GetFirstAndLastOccurances(int[] nums, int start, int end, int target, bool findFirst)
        {
            int mid = (start +  end) / 2;
            if(nums[mid] == target)
            {
                if(first == -1 || mid < first )
                {
                    first = mid;
                }
                if(last == -1 || mid > last )
                {
                    last = mid;
                }
            }

            if(start == mid)
            {
                return;
            }
            if((findFirst && nums[mid] >= target) || (!findFirst && nums[mid] > target))
            {
                GetFirstAndLastOccurances(nums, start, mid - 1, target, findFirst);
            }
            else{
                GetFirstAndLastOccurances(nums, mid + 1, end, target, findFirst);
            }
        }
    }
}