namespace Algorithms_Practice.ArrayProblems
{
    //https://leetcode.com/problems/find-peak-element/
    public class FindPeak
    {
        public int FindPeakElement(int[] nums) {
            return FindPeakElementHelper(nums, 0, nums.Length - 1);
        }
        private int FindPeakElementHelper(int[] nums, int low, int high){

            if(low == high)
            {
                return low;
            }
            int mid = (low + high) / 2;

            if(nums[mid] > nums[mid + 1])
            {
                return FindPeakElementHelper(nums, low, mid - 1);
            }
            return FindPeakElementHelper(nums, mid + 1, high);
        }
    }
}