namespace Algorithms_Practice.TreeProblems
{
    using System.Collections.Generic;
    //https://leetcode.com/problems/construct-binary-tree-from-preorder-and-inorder-traversal/solution/
    public class ConstructBST
    {
        private Dictionary<int, int>  dict = new Dictionary<int, int>();
        private int preOrderIndex = 0;
         public TreeNode BuildTree(int[] preorder, int[] inorder) {
             for(int i =0; i < inorder.Length; i++)
             {
                 dict[inorder[i]] = i;
             }
             return BuildTreeHelper(preorder, 0, preorder.Length - 1);
        }
        private TreeNode BuildTreeHelper(int[] preorder,int left, int right)
        {
            if(left > right)
            {
                return null;
            }
            int rootValue = preorder[preOrderIndex++];
            TreeNode root = new TreeNode(rootValue);

            root.left = BuildTreeHelper(preorder, left, dict[rootValue] - 1);
            root.right = BuildTreeHelper(preorder, dict[rootValue] + 1, right);
            return root;
        }
    }
}