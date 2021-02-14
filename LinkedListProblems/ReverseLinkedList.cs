using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.LinkedListProblems
{
    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x, ListNode next = null)
        {
            val = x;
            next = null;
        }
    }
    class ReverseLinkedList
    {
        public ListNode ReverseList(ListNode head)
        {
            ListNode prev = null;
            ListNode current = head;

            while(current != null)
            {
                ListNode next = current.next;
                current.next = prev;
                prev = current;
                current = next;
            }
            return prev;
        }
    }
}
