namespace Algorithms_Practice.StringProblems
{
    using System.Collections.Generic;
    public class RegexMatching
    {
        Dictionary<string, bool> dict = new Dictionary<string, bool>();
        public bool IsMatch(string s, string p) {
            
            if((string.IsNullOrEmpty(s) && string.IsNullOrEmpty(p)) || s == p || p == ".*" | (s.Length == 1 && p == "."))
            {
                return true;
            }
            if((string.IsNullOrEmpty(s) || string.IsNullOrEmpty(p)) && !MatchStarsAndCharsCount(p))
            {
                return false;
            }
            
            int j = 0, k = 1;

            bool[] result = new bool[s.Length];

           string pToMatch = p[j].ToString();
           if(k < p.Length && p[k] == '*')
           {
               j++;
               pToMatch += p[k];
           }
            if(dict.ContainsKey(s))
            {
                return dict[s];
            }
           IList<string> matches = GetMatches(s, pToMatch);
        bool ans = false;
           foreach(string match in matches)
           {
               string temp = p.Length > 1 ? p.Substring(j + 1, p.Length - (j + 1)) : string.Empty;
               ans |= IsMatch(match, temp);
                if(!dict.ContainsKey(match))
                {
                    dict.Add(match, ans);
                }
                else if(!dict[match])
                {
                    dict[match] = ans;
                }
           }
           return ans;
        }
        private List<string> GetMatches(string s, string p)
        {
            List<string> matches = new List<string>();
            if(p.Length > 0 && p[p.Length - 1] == '*')
            {
                string temp = " " + s;

                do
                {
                    temp = temp.Length > 1 ? temp.Substring(1, temp.Length - 1) : string.Empty;
                    matches.Add(temp);
                } while((temp.StartsWith(p[0]) || p.StartsWith('.')) && !string.IsNullOrEmpty(temp));
            }
            else if(s.StartsWith(p) || p.StartsWith('.'))
            {
                string temp = s.Length > 1 ? s.Substring(1, s.Length - 1) : string.Empty;
                matches.Add(temp);
            }
            
            return matches;
        }

        private bool MatchStarsAndCharsCount(string p)
        {
            if(string.IsNullOrEmpty(p) || p.Length % 2 != 0)
            {
                return false;
            }
            int starCount = 0;
            int charCount = 0;

            foreach(char c in p)
            {
                if(c == '*')
                {
                    starCount++;
                }
                else
                {
                    charCount++;
                }
            }
            return starCount == charCount;
        }

        public static void Test()
        {
            RegexMatching obj = new RegexMatching();
            bool res = obj.IsMatch("aaa", "ab*a*c*a");
            System.Console.WriteLine(res);
            
        }
    }
}