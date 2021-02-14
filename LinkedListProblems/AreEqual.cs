namespace ConsoleApp1.LinkedListProblems
{
    public class AreEqual
    {
        public static bool CheckEquality(ListNode l1, ListNode l2)
        {
            while(l1 != null && l2 != null)
            {
                if(l1.val != l2.val)
                {
                    return false;
                }
                l1 = l1.next;
                l2 = l2.next;
            }
            if(l1 == null && l2 == null)
            {
                return true;
            }
            return false;
        }
    }
}