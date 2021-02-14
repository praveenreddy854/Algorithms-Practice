namespace ConsoleApp1.ArrayProblems
{
    using System.Collections.Generic;
    using System.Linq;
    using System;
    using System.Text;

    // https://leetcode.com/problems/group-anagrams/
    public class GroupAnagramsClass
    {
        public IList<IList<string>> GroupAnagrams(string[] strs) {
            int startIndexDiff = 97;

            IDictionary<string, IList<string>> dict = new Dictionary<string, IList<string>>();

            for(int i = 0; i < strs.Length; i++)
            {
                int[] count = new int[26];
                 foreach(char c in strs[i])
                 {
                     count[(int)c - startIndexDiff]++;
                 }
                
                StringBuilder sb = new StringBuilder();
                 for(int j =0; j < count.Length; j++)
                 {
                     sb.Append(count[j]);
                 }
                
                string key = sb.ToString();
                 if(dict.ContainsKey(key))
                 {
                     dict[key].Add(strs[i]);
                 }
                 else
                 {
                     IList<string> newEntry = new List<string>();
                     newEntry.Add(strs[i]);
                     dict.Add(key, newEntry);
                 }
                
                
            }

            return dict.Values.ToList();
        }

        public static void Test()
        {
            GroupAnagramsClass obj = new GroupAnagramsClass();
            string[] strs = {"",""};
            obj.GroupAnagrams(strs);
        }
    }
}