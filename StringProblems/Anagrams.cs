using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.StringProblems
{
    //https://leetcode.com/problems/valid-anagram/
    class Anagrams
    {
        public bool IsAnagram(string s, string t)
        {
            if(s.Length != t.Length)
            {
                return false;
            }
            int[] anagramArray = new int[26];
            foreach(char cs in s)
            {
                anagramArray[(int)cs - 97]++;
            }

            foreach(char ct in t)
            {
                if (anagramArray[(int)ct - 97] == 0)
                {
                    return false;
                }
                anagramArray[(int)ct - 97]--;
            }
            return true;
        }
    }
}
