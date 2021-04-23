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
        private string maxLengthPal = "";
        int maxLength = 0;
        public string LongestPalindrome(string s)
        {
            GetPalindrome(s, "");
            return maxLengthPal;
        }
        private void GetPalindrome(string s, string ps)
        {
            if(s.Length < maxLengthPal.Length)
            {
                return;
            }
            if(s.Length < 2)
            {
                ps = s;
                AssignMaxLength(ps);
                return;
            }
            if(s.Length == 2)
            {
                if(s[0] == s[1])
                {
                    ps = s;
                }
                else{
                    ps = s[0].ToString();
                }
                AssignMaxLength(ps);
                return;
            }
            int mid = s.Length / 2;
            int i = mid - 1, j = mid + 1;
            ps = s[mid].ToString();
            while(i >= 0 || j < s.Length)
            {
                if(i >= 0 && j < s.Length && s[i] == s[j])
                {
                    ps = s[i--] + ps + s[j++];
                }
                else if(i >= 0 && s[i] == ps[ps.Length - 1] && s[i] == ps[ps.Length / 2])
                {
                    ps = s[i--] + ps;
                }
                else if(j < s.Length && s[j] == ps[0] && s[j] == ps[ps.Length / 2])
                {
                    ps = ps + s[j++];
                }
                else
                {
                    break;
                }
            }
            
            AssignMaxLength(ps);
            GetPalindrome(s.Substring(0, mid + 1), "");
            GetPalindrome(s.Substring(mid, s.Length - mid), "");
        }
        private void AssignMaxLength(string ps)
        {
            maxLength = Math.Max(maxLength, ps.Length);
             if(ps.Length == maxLength)
             {
                 maxLengthPal = ps;
             }
        }

        public static void Test()
        {
            LongestPalidromicSubString obj = new LongestPalidromicSubString();
            obj.LongestPalindrome("cbbd");
        }
    }
}
