namespace ConsoleApp1.StringProblems
{
    using System.Collections.Generic;
    using System.Linq;
    using System;
    public class GenerateParentheses
    {
        //https://leetcode.com/problems/generate-parentheses/

        private HashSet<string> list;
        public IList<string> GenerateParenthesis(int n) {
            list = new HashSet<string>();
            GenerateParenthesisUtils(n, 0, 0, "");
            return list.ToList();
        }
        private void GenerateParenthesisUtils(int n, int open, int close, string prev)
        {
            if(2 * n == prev.Length)
            {
                list.Add(prev);
            }

            if(open < n)
                GenerateParenthesisUtils(n, open + 1, close, prev + "(");
            if(close < open)
                 GenerateParenthesisUtils(n, open, close + 1, prev + ")");
        }
    }
}