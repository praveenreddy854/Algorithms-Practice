namespace ConsoleApp1.LinkedListProblems
{
    public class RemoveNthNode
    {
        //https://leetcode.com/problems/remove-nth-node-from-end-of-list/

         public ListNode RemoveNthFromEnd(ListNode head, int n) {
             int target;
             return RemoveNthFromEndHelper(head, n, out target, 1);
        }
        private ListNode RemoveNthFromEndHelper(ListNode head, int n, out int target, int index)
        {
            if(head == null)
            {
                target = index - n;
                return null;
            }
            head = RemoveNthFromEndHelper(head.next, n, out target, index + 1);

            System.Console.WriteLine("target"+ target);

            if(target == index + 1)
            {
                head.next = head.next.next;
            }
            else if(target <= index)
            {
                return null;
            }
            return head;
        }
    }
}