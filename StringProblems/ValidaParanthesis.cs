using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.StringProblems
{
    class ValidaParanthesis
    {
        public static bool IsValid(string s)
        {
            Stack<char> stack = new Stack<char>();
            Dictionary<char, char> dict = new Dictionary<char, char>();
            dict.Add(')', '(');
            dict.Add(']', '[');
            dict.Add('}', '{');
            // dummies
            dict.Add('(', 'a');
            dict.Add('[', 'b');
            dict.Add('{', 'c');

            stack.Push('d');
            for (int i=0; i<s.Length;i++)
            {
                if(stack.Peek() == dict[s[i]])
                {
                    stack.Pop();
                }
                else
                {
                    stack.Push(s[i]);
                }
            }

            return stack.Peek() == 'd' ? true : false;
        }
    }
}
