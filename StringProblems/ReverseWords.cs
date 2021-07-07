namespace Algorithms_Practice.StringProblems
{
    //https://leetcode.com/problems/reverse-words-in-a-string/
    using System.Collections.Generic;
    using System.Text;

    public class ReverseWordsClass
    {
        public string ReverseWords(string s) {
            Stack<string> stack = new Stack<string>();

            StringBuilder singleWord = new StringBuilder();
            for(int i = 0; i < s.Length; i++){
                // if not a space, add to sb
                if(s[i] != ' ')
                {
                    singleWord.Append(s[i]);
                }
                // End of string or end of word, add to stack
                if((s[i] == ' ' || i == s.Length - 1) && singleWord.Length > 0){
                    stack.Push(singleWord.ToString());
                    singleWord = new StringBuilder();
                }
            }
            StringBuilder result = new StringBuilder();
            while(stack.Count > 0){
                result.Append(stack.Pop() + " ");
            }
            // Remove the space at the end
            return result.ToString().Substring(0, result.Length - 1);
        }
    }
}