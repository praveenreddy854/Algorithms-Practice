using System;
using System.Collections.Generic;

namespace ConsoleApp1.StringProblems
{
    public class StringPurmutations
    {
        public static void GetPermitations(string input)
        {
            Dictionary<char, int> dictionary = new Dictionary<char,int>();
            foreach(char c in input)
            {
                if(dictionary.ContainsKey(c))
                {
                    dictionary[c]++;
                    continue;
                }
                dictionary.Add(c,1);
            }
            char[] output = new char[input.Length];
        }

        private static void GetPermutationsUtil(string input, Dictionary<char,int> dictionary, char[] output, int depth)
        {
            int breakCounter = 0;
            KeyValuePair<char,int> firstNonZero = new KeyValuePair<char, int>();
            foreach(var kp in dictionary)
            {
                if(kp.Value == 0)
                {
                    if(breakCounter == dictionary.Count)
                    {
                        return;
                    }
                }
                 if(kp.Value != 0)
                {
                    if(firstNonZero.Equals( new KeyValuePair<char, int>()))
                    {
                        firstNonZero = kp;
                    }
                }
            }
            
            dictionary[firstNonZero.Key]--;
            output[depth] = firstNonZero.Key;
            GetPermutationsUtil(input, dictionary, output, depth++);

            foreach(char o in output)
            {
                Console.Write(o + " ");
            }
            System.Console.WriteLine();
        }
    }
}