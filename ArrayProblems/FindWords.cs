namespace ConsoleApp1.ArrayProblems
{
    using System.Collections.Generic;
    using System.Linq;
    //https://leetcode.com/problems/word-search-ii/
    public class FindWordsClass
    {
        private char[][] board;
        private string[] words;
         public IList<string> FindWords(char[][] board, string[] words) {
             this.board = board;
            this.words = words;
            
            int maxRows =  board.Length;
            int maxColumns =  board[0].Length;
            IList<string> result = new List<string>();
            foreach(string word in words)
            {
                for(int i = 0; i < maxRows; i++)
                {
                    for(int j = 0; j < maxColumns; j++)
                    {
                         if(word[0] == board[i][j] && WordSearchUtil(i, j, 0, maxRows, maxColumns, word))
                         {
                            result.Add(word);
                         }
                    }
                }
            }
            
            return result.Distinct().ToList();
        }
        
        private bool WordSearchUtil(int row, int column, int wordIndex, int maxRows, int maxColumns, string word)
        {
            if(wordIndex == word.Length)
            {
                return true;
            }
            if(row < 0 || row >= maxRows || column < 0 || column >= maxColumns || board[row][column] != word[wordIndex])
            {
                return false;
            }
            
            char temp = board[row][column];
            board[row][column] = ' ';
            bool result = 
                         WordSearchUtil(row - 1, column, wordIndex + 1, maxRows, maxColumns, word) || 
                         WordSearchUtil(row, column - 1, wordIndex + 1, maxRows, maxColumns, word) || 
                         WordSearchUtil(row + 1, column, wordIndex + 1, maxRows, maxColumns, word) ||
                         WordSearchUtil(row, column + 1, wordIndex + 1, maxRows, maxColumns, word);
            board[row][column] = temp;           
            return result;
        }
    }
}