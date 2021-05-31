namespace Algorithms_Practice.BackTracking
{
    //https://leetcode.com/problems/palindrome-partitioning/
    using System.Collections.Generic;
    using System;
    public class PalindromePartitioning
    {
        IList<IList<string>> result = new List<IList<string>>();
    HashSet<string> palindromes = new HashSet<string>();
        public IList<IList<string>> Partition(string s) {
            Helper(s, 0, new List<string>());
            return result;
        }
        private void Helper(string s, int index, IList<string> list)
        {
            for(int i = index; i < s.Length; i++)
            {
                string subStr = s.Substring(index, i + 1 - index);

               if(IsPalindrome(subStr, 0, i - index))
                {
                    list.Add(subStr);
                    palindromes.Add(subStr);
                }
                else
                {
                    continue;
                }
                Helper(s, i + 1, list);
                if(i == s.Length - 1)
            {            
                result.Add(new List<string>(list));
            }
                if(list.Count > 0)
                {
                    list.RemoveAt(list.Count - 1);
                }
                
            }
        }
         private bool IsPalindrome(string s, int start, int end)
        {
            if(s[start] == s[end] && (s.Length <= 2 || palindromes.Contains(s.Substring(start + 1, end - 1))))
            {
                return true;
            }
            return false;
        }
        public static void Test()
        {
            PalindromePartitioning obj = new PalindromePartitioning();
            obj.Partition("aab");
        }
    }
}