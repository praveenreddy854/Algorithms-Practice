namespace Algorithms_Practice.LinkedListProblems
{
    using System.Collections.Generic;
    using System.Linq;
    public class MergeKSortedLists
    {
        //https://leetcode.com/problems/merge-k-sorted-lists/
        public ListNode MergeKLists(ListNode[] lists) {
            SortedDictionary<int, int> dict = new SortedDictionary<int, int>();
            ListNode result = new ListNode(0);

            for(int i = 0; i < lists.Length; i++)
            {
                ListNode root = lists[i];

                while(root != null)
                {
                    if(dict.ContainsKey(root.val))
                    {
                        dict[root.val]++;
                    }
                    else
                    {
                        dict.Add(root.val, 1);
                    }
                    root = root.next;
                }
            }

            ListNode temp = result;
            foreach(var kv in dict)
            {
                for(int i = 0; i < kv.Value; i++)
                {
                    temp.next = new ListNode(kv.Key);
                    temp = temp.next;
                }
            }
            return result.next;
        }
    }
}