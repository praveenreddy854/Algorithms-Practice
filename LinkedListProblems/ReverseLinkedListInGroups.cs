using System;

namespace ConsoleApp1.LinkedListProblems
{
    public class ReverseLinkedListInGroups
    {
        public ListNode ReverseInGroups(ListNode head, int groups)
        {
            ListNode current = head;
            
            ListNode prevGroupEnd = current, lastPrevGroupEnd = current;
            int counter = 0;


            while(current != null)
            {
                ListNode prev = null, next = null;
                while(current != null)
                {
                    next = current.next;
                    current.next = prev;
                    prev = current;
                    
                    counter++;
                    if(counter <= groups)
                    {
                        head = current;
                    }
                    current = next;
                    if(counter % groups == 0)
                    {
                        break;
                    }
                }
                if(prev != head)
                {
                    lastPrevGroupEnd.next = prev;
                }
                lastPrevGroupEnd = prevGroupEnd;
                
                prevGroupEnd.next = current;
                prevGroupEnd = current;
            }
            
            return head;
        }

        public static void Test()
        {
            ListNode l1 = new ListNode(1);
            l1.next = new ListNode(2);
            l1.next.next = new ListNode(3);
            l1.next.next.next = new ListNode(4);
            l1.next.next.next.next = new ListNode(5);
            l1.next.next.next.next.next = new ListNode(6);
            l1.next.next.next.next.next.next = new ListNode(7);


            ListNode expectedNode = new ListNode(3);
            expectedNode.next = new ListNode(2);
            expectedNode.next.next = new ListNode(1);
            expectedNode.next.next.next = new ListNode(6);
            expectedNode.next.next.next.next = new ListNode(5);
            expectedNode.next.next.next.next.next = new ListNode(4);
            expectedNode.next.next.next.next.next.next = new ListNode(7);

            ReverseLinkedListInGroups obj = new ReverseLinkedListInGroups();
            ListNode actualNode = obj.ReverseInGroups(l1,3);

            Console.WriteLine(AreEqual.CheckEquality(expectedNode, actualNode));
        }
    }
}