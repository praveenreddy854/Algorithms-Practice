using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.LinkedListProblems
{
    /// <summary>
    /// https://leetcode.com/problems/add-two-numbers/
    /// </summary>
    class AddTwoNumberClass
    {
        public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            AddTrailingZeros(l1, l2);
            return AddTwoNumbersUtils(l1, l2);
        }
        private ListNode AddTwoNumbersUtils(ListNode l1, ListNode l2)
        {
            int carry = 0;
            ListNode l1Temp = l1;
            ListNode prev = null;
            while (l1Temp != null)
            {
                int sum = l1Temp.val + l2.val + carry;
                int rem = sum % 10;
                l1Temp.val = rem;
                carry = sum / 10;
                prev = l1Temp;
                l1Temp = l1Temp.next;
                l2 = l2.next;
            }
            if(carry != 0)
            {
                prev.next = new ListNode(carry);
            }
            return l1;
        }
        private void AddTrailingZeros(ListNode l1, ListNode l2)
        {
            int l1Legth = 0;
            ListNode l1Temp = l1;
            while(l1Temp != null)
            {
                l1Temp = l1Temp.next;
                l1Legth++;
            }

            int l2Legth = 0;
            ListNode l2Temp = l2;
            while (l2Temp != null)
            {
                l2Temp = l2Temp.next;
                l2Legth++;
            }

            if(l1Legth > l2Legth)
            {
                int diff = l1Legth - l2Legth;
                l2 = AddTrailingZerosUtils(l2, diff);
            }
            else if(l2Legth > l1Legth)
            {
                int diff = l2Legth - l1Legth;
                l1 = AddTrailingZerosUtils(l1, diff);
            }
        }

        private ListNode AddTrailingZerosUtils(ListNode node, int diff)
        {
            if(node == null)
            {
                int counter = 1;
                node = new ListNode(0);
                ListNode temp = node;
                while (counter < diff)
                {
                    temp.next = new ListNode(0);
                    temp = temp.next;
                    counter++;
                }
                return node;
            }
            node.next = AddTrailingZerosUtils(node.next, diff);
            return node;
        }

    }
}
