namespace ConsoleApp1.ArrayProblems
{
    // https://leetcode.com/problems/word-search/
    public class WordSearch
    {
        private char[][] board;
        private string word;
        public bool Exist(char[][] board, string word) {
            this.board = board;
            this.word = word;
            
            int maxRows =  board.Length;
            int maxColumns =  board[0].Length;
            for(int i = 0; i < maxRows; i++)
            {
                for(int j = 0; j < maxColumns; j++)
                {
                     if(word[0] == board[i][j] && WordSearchUtil(i, j, 0, maxRows, maxColumns))
                     {
                        return true;
                     }
                }
            }
            return false;
        }

        private bool WordSearchUtil(int row, int column, int wordIndex, int maxRows, int maxColumns)
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
                         WordSearchUtil(row - 1, column, wordIndex + 1, maxRows, maxColumns) || 
                         WordSearchUtil(row, column - 1, wordIndex + 1, maxRows, maxColumns) || 
                         WordSearchUtil(row + 1, column, wordIndex + 1, maxRows, maxColumns) ||
                         WordSearchUtil(row, column + 1, wordIndex + 1, maxRows, maxColumns);
            board[row][column] = temp;           
            return result;
        }

        public static void Test()
        {
            WordSearch obj = new WordSearch();
            char[][] board = new char[][]{new char[]{'A','B','C','E'},new char[]{'S','F','C','S'},new char[]{'A','D','E','E'}};
            obj.Exist(board, "ABCC");
        }
    }
}