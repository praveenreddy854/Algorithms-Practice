using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.TreeProblems
{
    class SortedArrayToBSTClass
    {
        public static TreeNode SortedArrayToBST(int[] nums)
        {
            return SortedArrayToBSTUtils(nums, 0, nums.Length - 1);
        }

        private static TreeNode SortedArrayToBSTUtils(int[] nums, int start, int end)
        {
            if(start > end)
            {
                return null;
            }
            int middle = (start + end) / 2;
            TreeNode root = new TreeNode(nums[middle]);
            root.left = SortedArrayToBSTUtils(nums, start, middle-1);
            root.right = SortedArrayToBSTUtils(nums, middle+1, end);
            return root;
        }
        
    }
}

