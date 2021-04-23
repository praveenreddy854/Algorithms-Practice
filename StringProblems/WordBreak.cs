namespace Algorithms_Practice.StringProblems
{
    //https://leetcode.com/problems/word-break/
    using System;
    using System.Collections.Generic;
    using System.Collections;
    using System.Linq;

    public class WordBreakClass
    {
        private int len;
        private Dictionary<String, bool> dp = new Dictionary<String, bool>();
        public bool WordBreak(string s, IList<string> wordDict) {
            len = s.Length;
            HashSet<string> h = new HashSet<string>(wordDict);
            return WordBreakHelper(s, h);
        }

        private bool WordBreakHelper(string s, HashSet<string> wordDict)
        {
            if(wordDict.Contains(s))
            {
                return true;
            }
            if(dp.ContainsKey(s))
            {
               return dp[s];
            }
            for(int i = 1; i < s.Length; i++)
            {
                string subStr = s.Substring(0, i);
                
                if(wordDict.Contains(subStr) && WordBreakHelper(s.Substring(i), wordDict))
                {
                    if(!dp.ContainsKey(s))
                    {
                        dp.Add(s, true);
                    }
                    return true;
                }
            }
            if(!dp.ContainsKey(s))
            {
                dp.Add(s, false);
            }
            return false;
        }
        public static void Test()
        {
            WordBreakClass obj = new WordBreakClass();
            obj.WordBreak("acb", new List<string>{"ab", "ac"});
        }
    }
}