using System;
using System.Text;

namespace Algorithms_Practice.ArrayProblems
{
    using System.Collections.Generic;
    using System.Linq;
    //https://leetcode.com/problems/remove-k-digits/
    public class RemoveKDigits
    {
        public string RemoveKdigits(string num, int k) {
            string zero = "0";
            char zeroChar = '0';
            if(k == num.Length)
            {
                return zero;
            }
            
            Stack<char> stack = new Stack<char>();

            for(int i = 0; i < num.Length; i++)
            {
                if(stack.Count == 0){
                    stack.Push(num[i]);
                }
                else
                {
                    while(stack.Count > 0 && k > 0 && stack.Peek() > num[i])
                    {
                        stack.Pop();
                        k--;
                    }
                    stack.Push(num[i]);
                }
            }

            StringBuilder sb = new StringBuilder();
            while(k > 0 && stack.Count > 0)
            {
                stack.Pop();
                k--;
            }
            while(stack.Count > 0)
            {
                sb.Append(stack.Pop());
            }

            string result = sb.ToString();
            result = (new String(result.Reverse().ToArray())).TrimStart(zeroChar);
            if(String.IsNullOrWhiteSpace(result))
            {
                return zero;
            }
            return result;
        }
        private string GetMin(string num)
        {
            if(num.Length == 1)
            {
                return "0";
            }
            string min = string.Empty;
            for(int i = 0; i < num.Length; i++)
            {
                string strAfterRemoval = num.Remove(i, 1);
                if(min == string.Empty)
                {
                    min = strAfterRemoval;
                    continue;
                }
                
                for(int j = 0; j < strAfterRemoval.Length; j++)
                {
                    if(min[j] > strAfterRemoval[j])
                    {
                        min = strAfterRemoval;
                        break;
                    }
                    else if(min[j] < strAfterRemoval[j])
                    {
                        break;
                    }
                }
            }
            return min;
        }
        public static void Test()
        {
            RemoveKDigits removeKDigits = new RemoveKDigits();
            removeKDigits.RemoveKdigits("1432219", 3);
        }
    }
}