using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class BinarySearchTree
    {
        public Node Root { get; set; }
        public BinarySearchTree()
        {
            Root = null;
        }
        public BinarySearchTree(int data)
        {
            Root = new Node(data);
        }

        public Node InsertToBST(Node root, int data)
        {
            if(root == null)
            {
                root = new Node(data);
                return root;
            }

            if(data <= root.Data)
            {
                root.Left = InsertToBST(root.Left, data);
            }
            else
            {
                root.Right = InsertToBST(root.Right, data);
            }
            return root;
        }

        public void InorderTraversal(Node root)
        {
            if(root == null)
            {
                return;
            }

            InorderTraversal(root.Left);
            Console.Write(" " + root.Data);
            InorderTraversal(root.Right);
        }

        public void PreOrderTraversal(Node root)
        {
            if (root == null)
            {
                return;
            }

            Console.Write(" "+root.Data);
            PreOrderTraversal(root.Left);
            PreOrderTraversal(root.Right);
        }

        public void PostOrderTraversal(Node root)
        {
            if (root == null)
            {
                return;
            }

            PostOrderTraversal(root.Left);
            PostOrderTraversal(root.Right);
            Console.Write(" " + root.Data);
        }

        private bool CheckIfTheTreeIsBst(Node root, int minKey, int maxKey)
        {
            if(root == null)
            {
                return true;
            }
            if(root.Data < minKey || root.Data > maxKey)
            {
                return false;
            }
            return CheckIfTheTreeIsBst(root.Left, minKey, root.Data) & CheckIfTheTreeIsBst(root.Right, root.Data, maxKey);
        }

        public static void CreateBST()
        {
            int[] a = new int[] { 8, 3, 10, 14,14, 13, 1, 6, 4, 7 };
            BinarySearchTree bst = new BinarySearchTree();

            for(int i=0;i<a.Length;i++)
            {
                bst.Root = bst.InsertToBST(bst.Root, a[i]);
            }
            Console.WriteLine("InOrder : ");
            bst.InorderTraversal(bst.Root);
            Console.WriteLine("PreOrder : ");
            bst.PreOrderTraversal(bst.Root);
            Console.WriteLine("PostOrder : ");
            bst.PostOrderTraversal(bst.Root);
            bool isBst = bst.CheckIfTheTreeIsBst(bst.Root, int.MinValue, int.MaxValue);
        }
    }
    class Node
    {
        public int Data { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node(int data)
        {
            Data = data;
        }
    }
}
