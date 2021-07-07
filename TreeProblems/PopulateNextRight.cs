namespace Algorithms_Practice.TreeProblems2
{
    using System;
    using System.Collections.Generic;
    //https://leetcode.com/problems/populating-next-right-pointers-in-each-node/
    public class PopulateNextRight
    {
        public Node Connect(Node root) {
            Queue<NextRightEntity> q = new Queue<NextRightEntity>();

            q.Enqueue(new NextRightEntity(root, true, 0));
            ConnectHelper(root, q, 0, 0);
            return root;
        }

        private void ConnectHelper(Node root, Queue<NextRightEntity> q, int position, int height) 
        {
            var nextRightEntity = q.Dequeue();
            if(!nextRightEntity.IsLevelTerminator)
            {
                root.next = q.Peek().Node;
            }
            if(root.left != null)
                q.Enqueue(new NextRightEntity(root.left, false));
            int newHeight = height;
            
            bool isLevelTerminator = false;
            if(Math.Pow(2, height + 1) == position + 2)
            {
                isLevelTerminator = true;
            }
            if(root.right != null)
                q.Enqueue(new NextRightEntity(root.right, isLevelTerminator));
            if(Math.Pow(2, height + 1) < position + 2)
            {
                newHeight++;
            }

            if(q.Count != 0)
            {
                ConnectHelper(q?.Peek()?.Node, q, position + 1, newHeight);
            }
        }
        public static void Test()
        {
            PopulateNextRight populateNextRight = new PopulateNextRight();
            Node root = new Node(1);
            root.left = new Node(2);
            root.right = new Node(3);
            root.left.left = new Node(4);
            root.left.right = new Node(5);
            root.right.left = new Node(6);
            root.right.right = new Node(7);
            populateNextRight.Connect(root);
        }
    }
    public class NextRightEntity
    {
        public Node Node { get; set; }
        public bool IsLevelTerminator { get; set; }
        public int Level { get; set; }
        public int Position { get; set; }

        public NextRightEntity(Node node, bool isLevelTerminator, int level = 0, int pos = 0)
        {
            this.Node = node;
            this.IsLevelTerminator = isLevelTerminator;
            this.Level = level;
            this.Position = pos;
        }
    }
    public class Node 
    {
        public int val;
        public Node left;
        public Node right;
        public Node next;

        public Node() {}

        public Node(int _val) {
            val = _val;
        }

        public Node(int _val, Node _left, Node _right, Node _next) {
            val = _val;
            left = _left;
            right = _right;
            next = _next;
        }
    }
}