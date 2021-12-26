namespace ConsoleApp1.StringProblems
{
    // https://leetcode.com/problems/letter-combinations-of-a-phone-number/
    using System.Collections.Generic;
    using System;
    using System.Text;

    public class LetterCombinations
    {
        IList<string> ans;
        public IList<string> GetLetterCombinations(string digits) {

            if(string.IsNullOrEmpty(digits))
            {
                return null;
            }
            Dictionary<char, IList<string>> dict = new Dictionary<char, IList<string>>();
            dict.Add('2', new List<string> {"a", "b", "c"});
            dict.Add('3', new List<string> {"d", "e", "f"});
            dict.Add('4', new List<string> {"g", "h", "i"});
            dict.Add('5', new List<string> {"j", "k", "l"});
            dict.Add('6', new List<string> {"m", "n", "o"});
            dict.Add('7', new List<string> {"p", "q", "r", "s"});
            dict.Add('8', new List<string> {"t", "u", "v"});
            dict.Add('9', new List<string> {"w", "x", "y", "z"});

            ans = new List<string>();

            return GetLetterCombinationsHelper2(digits, dict, new StringBuilder(), digits.Length);


        }
         private IList<string> GetLetterCombinationsHelper2(string digits, IDictionary<char, IList<string>> dict, StringBuilder combination, int length)
         {
             if(combination.Length == length)
             {
                 Console.WriteLine(combination);
                 ans.Add(new String(combination.ToString()));
                 return ans;
             }
             if(string.IsNullOrWhiteSpace(digits))
             {
                 return ans;
             }
             
             char digit = digits[0];

             string newDigits = digits.Substring(1, digits.Length - 1);
             System.Console.WriteLine("New digit" +newDigits);

             foreach(string aplhabet in dict[digit])
             {
                 combination.Append(aplhabet);
                 GetLetterCombinationsHelper2(newDigits, dict, combination, length);
                 combination.Remove(combination.Length - 1, 1);
             }
             return ans;
         }

         public IList<string> GetLetterCombinationsHelper(string digits, Dictionary<char, IList<string>> dict) {

             if(String.IsNullOrEmpty(digits))
             {
                 return null;
             }
             IList<string> result = GetLetterCombinationsHelper(digits.Substring(0, digits.Length - 1), dict);

             if(result == null)
             {
                  result = new List<string>();
                 foreach(string item in dict[digits[digits.Length - 1]])
                 {
                     result.Add(item);
                 }
                 return result;
             }

             IList<string> temp = new List<string>();
             foreach(string s in result)
             {
                  foreach(string item in dict[digits[digits.Length - 1]])
                 {
                     temp.Add(s+item);
                 }
             }
             return temp;

         }
    }
}