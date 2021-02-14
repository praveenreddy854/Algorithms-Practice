using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.LinkedListProblems
{
    public class MiddleOfLinkedList
    {
        public ListNode MiddleNode(ListNode head) 
        {
            ListNode temp = head;

            int counter1 = 1;

            while(temp.next != null)
            {
                counter1++;
                temp = temp.next;
            }

            int middleIndex = counter1/2;
            ListNode ans = head;
            int counter2 = 0;
            while(ans.next != null)
            {
                if(counter2 == middleIndex)
                {
                    return ans;
                }
                counter2++;
                temp = temp.next;
            }

            return ans;
        } 
    }
    
}