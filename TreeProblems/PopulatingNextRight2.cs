using System;
using System.Collections.Generic;

namespace Algorithms_Practice.TreeProblems2
{
    //https://leetcode.com/problems/populating-next-right-pointers-in-each-node-ii/
    public class PopulateNextRight2
    {
        public Node Connect(Node root) {
            if(root == null)
            {
                return root;
            }
            Queue<Node> q = new Queue<Node>();

            q.Enqueue(root);
            //ConnectHelper(root, q, 0, 0);

            while(q.Count > 0)
            {
                int count = q.Count;

                for(int i = 1; i <= count; i++)
                {
                    Node node = q.Dequeue();
                    if(i < count)
                    {
                        node.next = q.Peek();
                    }
                    if(node.left != null)
                    {
                        q.Enqueue(node.left);
                    }
                    if(node.right != null)
                    {
                        q.Enqueue(node.right);
                    }
                }
            }
            return root;
        }

        private void ConnectHelper(Node root, Queue<NextRightEntity> q, int position, int height) {
            q.Dequeue();
            if(q.Count > 0 && q.Peek().Level == height)
            {
                NextRightEntity nre = q.Peek();
                root.next = nre.Node;
            }
            if(root.left != null)
                q.Enqueue(new NextRightEntity(root.left, false , height + 1));
            int newHeight = height;
            
            bool isLevelTerminator = false;
            if(Math.Pow(2, height + 1) == position + 2)
            {
                isLevelTerminator = true;
            }
            if(root.right != null)
                q.Enqueue(new NextRightEntity(root.right, isLevelTerminator, height + 1));
            if(Math.Pow(2, height + 1) <= position + 2)
            {
                newHeight++;
            }

            if(q.Count != 0)
            {
                ConnectHelper(q.Peek().Node, q, position + 1, newHeight);
            }
        }
        public static void Test()
        {
            PopulateNextRight2 populateNextRight = new PopulateNextRight2();
            Node root = new Node(1);
            root.left = new Node(2);
            root.right = new Node(3);
            root.left.left = new Node(4);
            root.left.right = new Node(5);
            root.right.left = null;
            root.right.right = new Node(7);
            populateNextRight.Connect(root);
        }
    }
}