using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.StringProblems
{
    class LongestPalidromicSubString
    {
        public static string LongestPalindrome(string s)
        {
            int maxLength = 1;
            int startIndex = 0;
            for (int i = 0; i < s.Length; i++)
            {
                int counter = 0;
                int k = i;
                int j = s.Length - 1;
                for (; j > k; j--)
                {
                    if (s[k] == s[j])
                    {
                        k++;
                        counter = counter + 2;
                    }
                    
                }
                if (maxLength <= counter)
                {
                    if(k == j)
                    {
                        counter++;
                    }
                    maxLength = counter;
                    startIndex = i;
                    System.Console.WriteLine("i is"+i);
                }
            }
            Console.WriteLine("Start index "+ startIndex);
            Console.WriteLine("Start max "+ maxLength);
            return s.Substring(startIndex, maxLength);
        }
    }
}
