namespace Algorithms_Practice.LinkedListProblems
{
    //https://leetcode.com/problems/reorder-list/
    using System.Collections.Generic;
    using System;
    public class ReOrderList
    {
        public void ReorderList(ListNode head) {
            Stack<ListNode> stack = new Stack<ListNode>();

            ListNode temp = head;
            int size = 0;

            while(temp != null) {
                stack.Push(temp);
                temp = temp.next;
                size++;
            }

            temp = head;
            int halfSize = (int)Math.Floor((double)size);
            int counter = 0;
            while(counter < halfSize && temp != null) {
                ListNode originalNext = temp.next;
                temp.next = stack.Pop();
                temp.next.next = originalNext == temp.next ? null : originalNext;
                temp = temp.next.next;
                Console.WriteLine(temp?.val);
                counter++;
            }

            if(temp != null)
            {
                temp.next = null;
            }
        }
    }
}