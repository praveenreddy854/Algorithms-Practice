using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.TreeProblems
{
    //https://www.geeksforgeeks.org/level-order-tree-traversal/
    class LevelOrderTraversal
    {
        private static void PrintLevelOrder(TreeNode node)
        {
            if(node == null)
            {
                return;
            }

            Queue<TreeNode> treeQuee = new Queue<TreeNode>();
            treeQuee.Enqueue(node);

            while(treeQuee.Count != 0)
            {
                TreeNode tempNode = treeQuee.Dequeue();
                Console.WriteLine(tempNode.val + " ");

                if(tempNode.left != null)
                {
                    treeQuee.Enqueue(tempNode.left);
                }
                if(tempNode.right != null)
                {
                    treeQuee.Enqueue(tempNode.right);
                }
            }
        }
        public static void Test()
        {
            TreeNode root = new TreeNode(1);
            root.left = new TreeNode(2);
            root.right = new TreeNode(3);
            root.left.left = new TreeNode(4);
            root.left.right = new TreeNode(5);

            PrintLevelOrder(root);
            Console.ReadKey();
        }
    }
}
