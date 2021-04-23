namespace Algorithms_Practice.StringProblems
{
    using System.Collections.Generic;
    using System;
    //https://leetcode.com/problems/longest-valid-parentheses/
    public class LongestValidaParanthesesClass
    {
        public int LongestValidParentheses(string s)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(-1);
            int maxLen = 0;
            int len = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(')
                {
                    stack.Push(i);
                    continue;
                }
                else
                {
                    stack.Pop();
                    if (stack.Count == 0)
                    {
                        stack.Push(i);
                    }
                    else
                    {
                        len = i - stack.Peek();
                        maxLen = Math.Max(maxLen, len);
                    }
                }


            }
            return maxLen;
        }
    }
}