using System;

namespace Algorithms_Practice.LinkedListProblems
{
    //https://leetcode.com/problems/add-two-numbers/
    public class AddTwoNumbersClass
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2) 
        {
            // Init the head to a value
            ListNode l3 = new ListNode(int.MaxValue);
            ListNode temp = l3;
            int carry = 0;

            while (l1 != null && l2 != null)
            {
                int sum = l1.val + l2.val + carry;
                int l3Val = sum % 10;
                carry = sum / 10;
                Console.Write(l3Val + " ");
                l3.next = new ListNode(l3Val);
                l3 = l3.next;
                l1 = l1.next;
                l2 = l2.next;
            }
            
            while(l1 != null){
                int sum = l1.val + carry;
                int l3Val = sum % 10;
                carry = sum / 10;
                l3.next = new ListNode(l3Val);
                l3 = l3.next;
                l1 = l1.next;
            }
            while(l2 != null){
                int sum = l2.val + carry;
                int l3Val = sum % 10;
                carry = sum / 10;
                l3.next = new ListNode(l3Val);
                l3 = l3.next;
                l2 = l2.next;
            }
            if(carry != 0)
            {
                l3.next = new ListNode(carry);
                l3 = l3.next;
            }

            // Skip the head to get the sum
            l3 = temp.next;

            return l3;
        }
    }
}