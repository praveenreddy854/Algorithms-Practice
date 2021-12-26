namespace Algorithms_Practice.BackTracking
{
    //https://leetcode.com/problems/letter-case-permutation/
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LetterCasePermutations
    {
        IList<string> result;
        public IList<string> LetterCasePermutation(string s) {
            result = new List<string>();
            LetterCasePermutationHelper(s, 0, new StringBuilder());

            return result;
        }

        private void LetterCasePermutationHelper(string s, int index, StringBuilder transformedString) {

            if(index == s.Length) {
                result.Add(new String(transformedString.ToString()));
                return;
            }
            char currentLetter = s[index];
            LetterCasePermutationHelper(s, index + 1, transformedString.Append(currentLetter));
            transformedString.Remove(transformedString.Length - 1, 1);
            
            if(!int.TryParse(currentLetter.ToString(), out int temp))
            {
                LetterCasePermutationHelper(s, index + 1, transformedString.Append(TransformCase(currentLetter.ToString())));
                transformedString.Remove(transformedString.Length - 1, 1);
            }
            
        }
        private string TransformCase(string input)
        {
            if(!input.Equals(input.ToUpper()))
            {
                return input.ToUpper();
            }
            return input.ToLower();
        }
    }
}