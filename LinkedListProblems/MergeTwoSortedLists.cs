namespace Algorithms_Practice.LinkedListProblems
{
    using System;
    //https://leetcode.com/problems/merge-two-sorted-lists/submissions/
    public class MergeTwoSortedLists
    {
        private ListNode l3;
    public ListNode MergeTwoLists(ListNode l1, ListNode l2, ListNode l3) {
       if(l1 == null && l2 == null)
            {
                return null;
            }
            

            if((l1 == null) || l2 != null && l1.val > l2.val)
            {
                l3 = new ListNode(l2.val, null);
                l2 = l2.next;
            }
           else if(l1 != null)
            {
                l3 = new ListNode(l1.val, null);
                l1 = l1.next;
            }
            l3.next = MergeTwoLists(l1, l2, l3.next);
            return l3;     
    }
        public static void Test()
        {
            MergeTwoSortedLists obj = new MergeTwoSortedLists();
            ListNode l1 = new ListNode(1);
            l1.next = new ListNode(2);
            l1.next.next = new ListNode(3);

            ListNode l2 = new ListNode(1);
            l2.next = new ListNode(3);
            l2.next.next = new ListNode(4);

            ListNode l3 = obj.MergeTwoLists(l1, l2, null);

            while(l3 != null)
            {
                System.Console.WriteLine(l3.val);
                l3 = l3.next;
            }

        }
    }

    public class ListNode 
    {
        public int val;
        public ListNode next;
        public ListNode(int val=0, ListNode next=null) {
            this.val = val;
            this.next = next;
        }

    }   
}