using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.ArrayProblems
{
    class MaximumSubArraySum
    {
        public static int MaxSubArray(int[] nums)
        {
            int sum = 0, maxSum = int.MinValue;
            int size = nums.Length;
            for (int k=0;k<size;k++)
            {
                if(sum >= 0)
                {
                    sum += nums[k];
                }
                else if(nums[k] > sum)
                {
                    sum = nums[k];
                }
                if(sum > maxSum)
                {
                    maxSum = sum;
                }
            }

            return maxSum;
        }

        public static int MaxSumUsingDivideAndConquer(int[] nums)
        {
            int n = nums.Length;
            int max_sum = maxSubArraySum(nums, 0, n - 1);

            Console.Write("Maximum contiguous sum is " +
                                                max_sum);
            return max_sum;
        }
        static int maxCrossingSum(int[] arr, int l,
                                int m, int h)
        {
            // Include elements on left of mid. 
            int sum = 0;
            int left_sum = int.MinValue;
            for (int i = m; i >= l; i--)
            {
                sum = sum + arr[i];
                if (sum > left_sum)
                    left_sum = sum;
            }

            // Include elements on right of mid 
            sum = 0;
            int right_sum = int.MinValue; ;
            for (int i = m + 1; i <= h; i++)
            {
                sum = sum + arr[i];
                if (sum > right_sum)
                    right_sum = sum;
            }

            // Return sum of elements on left 
            // and right of mid 
            // returning only left_sum + right_sum will fail for [-2, 1] 
            return Math.Max(left_sum + right_sum, Math.Max(left_sum, right_sum));
        }

        static int maxSubArraySum(int[] arr, int l,
                                        int h)
        {

            // Base Case: Only one element 
            if (l == h)
                return arr[l];

            // Find middle point 
            int m = (l + h) / 2;

            /* Return maximum of following three  
            possible cases: 
            a) Maximum subarray sum in left half 
            b) Maximum subarray sum in right half 
            c) Maximum subarray sum such that the  
            subarray crosses the midpoint */
            return Math.Max(Math.Max(maxSubArraySum(arr, l, m),
                                  maxSubArraySum(arr, m + 1, h)),
                                 maxCrossingSum(arr, l, m, h));
        }
    }
}
