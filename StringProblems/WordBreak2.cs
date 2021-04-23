namespace Algorithms_Practice.StringProblems
{
    using System.Text;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class WordBreak2
    {
        IList<string> ans = new List<string>();
        public IList<string> WordBreak(string s, IList<string> wordDict) {
            HashSet<string> h = new HashSet<string>(wordDict);
            s = s + "$";
            WordBreakHelper(s, h, "");
            return ans;
        }

        private void WordBreakHelper(string s, HashSet<string> wordDict, String sb)
        {
            for(int i = 0; i < s.Length; i++)
            {
                string subStr = s.Substring(0, i + 1);
                if(wordDict.Contains(subStr))
                {
                    WordBreakHelper(s.Substring(i + 1), wordDict, sb + subStr+ " ");
                }
                else if(subStr == "$")
                {
                    ans.Add(sb.TrimEnd());
                    return;
                }
            }
        }
        public static void Test()
        {
            WordBreak2 obj = new WordBreak2();
            string s = "aaaaaaa";
            IList<string> wordDict = new List<string>(){"aaaa","aa","a"};
            obj.WordBreak(s, wordDict);
        }
    }
}