using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.StringProblems
{
    class LongestSubString
    {
        public static int LengthOfLongestSubstring(string s)
        {
            int n = s.Length, ans = 0;
            int[] index = new int[128]; // current index of character
                                        // try to extend the range [i, j]
            for (int j = 0, i = 0; j < n; j++)
            {
                i = Math.Max(index[s[j]], i);
                ans = Math.Max(ans, j - i + 1);
                index[s[j]] = j + 1;
            }
            return ans;
        }

        public static void Test()
        {
            string a = "abcadbceb";
            int res = LengthOfLongestSubstring(a);
            System.Console.WriteLine("answer for string "+ a + " " +res);

            a = "abcb";
            res = LengthOfLongestSubstring(a);
            System.Console.WriteLine("answer for string "+ a + " " +res);

        }
    }
}
