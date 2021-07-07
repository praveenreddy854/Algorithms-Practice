namespace Algorithms_Practice.LinkedListProblems
{
    //https://leetcode.com/problems/copy-list-with-random-pointer/
    using System.Collections.Generic;
    public class DeepCloneLinkedList
    {
        public Node CopyRandomList(Node head) {
            Node deepCloneHead =  new Node(int.MaxValue);
            Node temp = head;
            Node tempDeepCloneHead = deepCloneHead;
            Dictionary<Node, Node> deepCloneNodeDict = new Dictionary<Node, Node>();

            while (temp != null)
            {
                deepCloneHead.next = new Node(temp.val);
                deepCloneHead = deepCloneHead.next;
                deepCloneNodeDict.Add(temp, deepCloneHead);
                temp = temp.next;
            }
            tempDeepCloneHead = tempDeepCloneHead.next;
            deepCloneHead = tempDeepCloneHead;
            temp = head;
            while(temp != null)
            {
                deepCloneNodeDict[temp].random = temp.random == null ? null :  deepCloneNodeDict[temp.random];
                temp = temp.next;
            }
            return deepCloneHead;
        }
        
    }
    public class Node {
    public int val;
    public Node next;
    public Node random;
    
    public Node(int _val) {
        val = _val;
        next = null;
        random = null;
    }
}
}