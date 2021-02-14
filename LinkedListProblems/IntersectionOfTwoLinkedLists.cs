using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.LinkedListProblems
{
    class IntersectionOfTwoLinkedLists
    {
        public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
        {
            ListNode head1 = headA;
            ListNode head2 = headB;
            while(head1 != head2)
            {
                if(head1 == null)
                {
                    head1 = headB;
                }
                if (head2 == null)
                {
                    head2 = headA;
                }
                head1 = head1.next;
                head2 = head2.next;
            }
            return head1;
        }
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int x) { val = x; }
        }
    }
}
