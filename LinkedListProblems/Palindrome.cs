using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.LinkedListProblems
{
    class Palindrome
    {
        public static bool IsPalindrome(ListNode head)
        {
            if (head == null) return false;
            bool isPalindrome;
            PalindromeChecker(head, head, out isPalindrome);
            return isPalindrome;
        }

        public static bool TestIsPalindrome()
        {
            ListNode node = new ListNode(1);
            node.next = new ListNode(2);
            node.next.next = new ListNode(1);
            return IsPalindrome(node);
        }
        private static ListNode PalindromeChecker(ListNode head1, ListNode head2, out bool isPalindrome)
        {
            if(head2.next == null)
            {
                isPalindrome = true;
                if (head1.val != head2.val)
                {
                    isPalindrome &= false;
                }
                isPalindrome &= true;
                return head1.next;
            }

            head1 = PalindromeChecker(head1, head2.next, out isPalindrome);
            if (head1.val != head2.val)
            {
               isPalindrome &= false;
            }

            isPalindrome &= true;
            return head1.next;
        }
    }
}
