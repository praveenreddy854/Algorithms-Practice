using System;

namespace Algorithms_Practice.DynamicsProgrammingProblems
{
    //https://leetcode.com/problems/house-robber-iii/
    public class HouseRobber3
    {
        public int Rob(TreeNode root) {
            int[] result = RobHelper(root);
            return Math.Max(result[0], result[1]);
        }

        private int[] RobHelper(TreeNode root)
        {
            if (root == null)
            {
                return new int[2];
            }

            int[] l = RobHelper(root.left);
            int[] r = RobHelper(root.right);

            int[] result =  new int[2];

            result[0] = l[1] + r[1] + root.val;
            result[1] = Math.Max(l[0], l[1]) + Math.Max(r[0], r[1]);
            return result;
        }
    }
    public class TreeNode {
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}
}