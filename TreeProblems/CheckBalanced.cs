namespace Algorithms_Practice.TreeProblems
{
    using System;
    public class CheckBalanced
    {
        public int MaxDepth { get; set; }
        public int MinDepth { get; set; }
        public bool CheckIfBalanced(TreeNode root)
        {
            MaxDepth = 0;
            MinDepth = int.MaxValue;
            return CheckIfBalancedHelper(root, 0);
        }
        private bool CheckIfBalancedHelper(TreeNode root, int depth)
        {
            if(root == null)
            {
                MinDepth = Math.Min(depth, MinDepth);
                MaxDepth = Math.Max(depth, MaxDepth);
                if(MaxDepth - MinDepth > 1)
                {
                    return false;
                }
                return true;
            }
            int newDepth = depth + 1;
            return CheckIfBalancedHelper(root.left, newDepth) && CheckIfBalancedHelper(root.right, newDepth);
        }
        public static void Test()
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);
            root.left.left.left = new TreeNode(4);

            CheckBalanced checkBalanced = new CheckBalanced();
            System.Console.WriteLine(checkBalanced.CheckIfBalanced(root));

            Console.ReadKey();
        }
    }
}