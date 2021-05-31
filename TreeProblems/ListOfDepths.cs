namespace Algorithms_Practice.TreeProblems
{
    using System.Collections.Generic;
    using System.Linq;
    using System;
    // Given a BT design an algorithm which creates a list of nodes at each depth
    public class ListOfDepths
    {
        IList<IList<TreeNode>> result;
        public void GetListOfDepths(TreeNode root)
        {
            result = new List<IList<TreeNode>>();
            List<TreeNode> listNodes = new List<TreeNode>();
            listNodes.Add(root);
            GetListOfDepthsHelper(listNodes);

            foreach(var list in result)
            {
                foreach(TreeNode node in list)
                {
                    System.Console.Write(node.val + " ");
                }
                System.Console.WriteLine();
            }

        }
        private void GetListOfDepthsHelper(IList<TreeNode> list)
        {
            if(list.FirstOrDefault() == null)
            {
                return;
            }
            result.Add(list);
            List<TreeNode> newList = new List<TreeNode>();
            foreach(TreeNode node in list)
            {
                if(node.left != null)
                {
                    newList.Add(node.left);
                }
                if(node.right != null)
                {
                    newList.Add(node.right);
                }
            }
            GetListOfDepthsHelper(newList);
        }
        public static void Test()
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);
            root.left.left.left = new TreeNode(4);

            ListOfDepths listOfDepths = new ListOfDepths();
            listOfDepths.GetListOfDepths(root);

            Console.ReadKey();
        }
    }
}