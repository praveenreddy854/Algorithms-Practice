using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class SinglyLinkedList
    {
        Node Head { get; set; }
        Node Last { get; set; }
        public SinglyLinkedList()
        {
            Head = Last = null;
        }
        public SinglyLinkedList(int data)
        {
            Head = new Node(data);
            Last = Head;
        }
        class Node
        {
            public Node(int data)
            {
                Data = data;
            }
            public int Data { get; set; }
            public Node Next { get; set; }
        }

        private Node Insert(Node head, int data)
        {
            if (head == null)
            {
                head = new Node(data);
                return head;
            }

            head.Next = Insert(head.Next, data);
            return head;
        }

        private Node InsertAtEnd(Node last, int data)
        {
            if(last == null)
            {
                Head = Last = new Node(data);
                return Last;
            }
            last.Next = new Node(data);
            last = last.Next;
            return last;
        }
        public static void Create()
        {
            int[] a = { 10, 12, 1, 5, 6 };
            SinglyLinkedList list = new SinglyLinkedList();
            //for(int i=0;i<a.Length;i++)
            //{
            //    list.Head = list.Insert(list.Head, a[i]);
            //}

            for (int i = 0; i < a.Length; i++)
            {
                list.Last = list.InsertAtEnd(list.Last, a[i]);
            }
        }
    }

    class DoublyLinkedList
    {
        Node Head { get; set; }
        Node Last { get; set; }
        public DoublyLinkedList()
        {
            Head = null;
        }
        public DoublyLinkedList(int data)
        {
            Head = new Node(data);
        }
        class Node
        {
            public Node(int data)
            {
                Data = data;
            }
            public int Data { get; set; }
            public Node Next { get; set; }
            public Node Previous { get; set; }
        }

        private Node InsertAtEnd(Node last, int data)
        {
            if(last == null)
            {
                Head = Last = new Node(data);
                return Last;
            }
            last.Next = new Node(data);
            var temp = last;
            last = last.Next;
            last.Previous = temp;
            return last;
        }

        public static void Create()
        {
            int[] a = { 10, 12, 1, 5, 6 };
            DoublyLinkedList dl = new DoublyLinkedList();
            for(int i=0;i<a.Length;i++)
            {
                dl.Last = dl.InsertAtEnd(dl.Last, a[i]);
            }
        }
    }
    class CircularLinkedList
    {
        Node Head { get; set; }
        public CircularLinkedList()
        {
            Head = null;
        }
        public CircularLinkedList(int data)
        {
            Head = new Node(data);
        }
        class Node
        {
            public Node(int data)
            {
                Data = data;
            }
            public int Data { get; set; }
            public Node Next { get; set; }
        }
        private Node InsertAtEnd(Node head, int data)
        {
            if (head == null)
            {
                head = new Node(data);
                head.Next = head;
                return head;
            }
            var temp = head.Next;
            head.Next = new Node(data);
            head.Next.Next = temp;
            head = head.Next;
            return head;
        }

        public static void Create()
        {
            int[] a = { 10, 12, 1, 5, 6 };
            CircularLinkedList dl = new CircularLinkedList();
            for (int i = 0; i < a.Length; i++)
            {
                dl.Head = dl.InsertAtEnd(dl.Head, a[i]);
            }
        }
    }
}
