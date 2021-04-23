namespace Algorithms_Practice.TreeProblems
{
    using System.Collections.Generic;
    public class BinaryTreeToLinkedList
    {
        Stack<TreeNode> rightStack = new Stack<TreeNode>();
        public void Flatten(TreeNode root) {
            TreeNode temp  = root;
            FlattenHelper(temp);
        }
        private void FlattenHelper(TreeNode root)
        {
            while(root?.left != null)
            {
                rightStack.Push(root.right);
                root.right = root.left;
                root.left = null;
                root = root.right;
            }
            rightStack.Push(root?.right);
            while(rightStack.Count != 0)
            {
                TreeNode node = rightStack.Pop();
                if(node == null)
                {
                    continue;
                }
                root.right = node;
                FlattenHelper(node);
            }
        }
        public static void Test()
        {
            BinaryTreeToLinkedList obj = new BinaryTreeToLinkedList();

            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(5);

            root.left.left = new TreeNode(3);
            root.left.right = new TreeNode(4);

            root.right.right = new TreeNode(6);

            obj.Flatten(root);
        }
    }
}