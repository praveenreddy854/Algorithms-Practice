namespace ConsoleApp1.ArrayProblems
{
    using System;
    public class NumberOfPairs
    {
        public static void CountPairs(int[] x, int[] y, int m, int n)
        {

        }

        class BST{
            public Node Root { get; set; }
            public void Create(int[] a)
            {
                foreach(int i in a)
                {
                    InsertToBST(i, Root);
                }
            }
            private Node InsertToBST(int data, Node root)
            {
                if(root == null)
                {
                    root = new Node(data);
                    return root;
                }
                if(data <= root.Data)
                {
                    root.Left = InsertToBST(data, root.Left);
                }
                else
                {
                    root.Right = InsertToBST(data, root.Right);
                }
                return root;
            }
        }

        class Node
        {
            public Node(int data)
            {
                Data = data;
            }
            public int Data { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
        }
    }
    
}