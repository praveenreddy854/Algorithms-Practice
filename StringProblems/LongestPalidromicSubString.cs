using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.StringProblems
{
    //https://leetcode.com/problems/longest-palindromic-substring/solution/
    class LongestPalidromicSubString
    {
        public string LongestPalindrome(string s) {
            if(s.Length == 0)
            {
                return string.Empty;
            }

            int maxLength = 1;
            int startIndex  = 0;
            HashSet<KeyValuePair<int, int>> palindromes = new HashSet<KeyValuePair<int, int>>();

            for(int i = 0; i < s.Length; i++)
            {
                palindromes.Add(new KeyValuePair<int, int>(i, i));
                if( i != 0 && s[i] == s[i - 1])
                {
                    startIndex = i - 1;
                    palindromes.Add(new KeyValuePair<int, int>(i - 1, i));
                    maxLength = 2;
                }
            }
            for(int k = 3; k <= s.Length; k++)
            {
                for(int i = 0; i <= s.Length - k; i++){
                    
                    int j = i + k - 1;
                    System.Console.WriteLine("i {0}, j {1}, k {2}", i, j, k);
                    if(s[i] == s[j] && palindromes.Contains(new KeyValuePair<int, int>(i + 1, j - 1)))
                    {
                        palindromes.Add(new KeyValuePair<int, int>(j ,i));
                        if(maxLength < k)
                        {
                            maxLength = k;
                            startIndex = i;
                        }
                    }
                }
            }
            return s.Substring(startIndex, maxLength);
    }

        public static void Test()
        {
            LongestPalidromicSubString obj = new LongestPalidromicSubString();
            obj.LongestPalindrome("aaaaa");
        }
    }
}
