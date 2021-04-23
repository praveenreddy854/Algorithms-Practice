namespace Algorithms_Practice.TreeProblems
{
    public class ValidateBST
    {
        public bool IsValidBST(TreeNode root) {
            return IsValidBSTHelper(root, long.MinValue, long.MaxValue);
        }
        private bool IsValidBSTHelper(TreeNode root, long min, long max)
        {
            if(root == null)
            {
                return true;
            }
            if(root.val <= min || root.val >= max)
            {
                return false;
            }
            return IsValidBSTHelper(root.left, min, root.val) && IsValidBSTHelper(root.right, root.val, max);
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