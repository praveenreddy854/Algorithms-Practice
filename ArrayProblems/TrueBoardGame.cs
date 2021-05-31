namespace Algorithms_Practice.ArrayProblems
{
    using System.Collections.Generic;
    public class TrueBoardGame
    {
        private int MaxRows { get; set; }
        private int MaxCols { get; set; }
        private Dictionary<Directions, KeyValuePair<int, int>> dict = new Dictionary<Directions, KeyValuePair<int, int>>();
        public enum Directions
        {
            W, SW, S, SE, E, NE, N, NW
        }

        public bool IsBoardSolved(bool[,] board, int targetMatches)
        {
            MaxCols = board.GetLength(0);
            MaxRows = board.GetLength(1);
            
            for(int i = 0; i < MaxRows; i++)
            {
                for(int j = 0; j < MaxCols; j++)
                {
                    if(!board[i, j])
                    {
                        continue;
                    }
                    foreach(var kv in dict)
                    {
                        if(IsBoardSolvedHelper(board, targetMatches, i, j, kv.Value, 1))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
        }
        private bool IsBoardSolvedHelper(bool[,] board, int targetMatches, int row, int col, KeyValuePair<int, int> dir, int matches)
        {
            if(row >= MaxRows || col >= MaxCols || row < 0 || col < 0 || matches > targetMatches)
            {
                return false;
            }
            if(board[row,col] == false)
            {
                return false;
            }
            if(matches == targetMatches)
            {
                return true;
            }
            
            if(IsBoardSolvedHelper(board, targetMatches, row + dir.Key, col + dir.Value, dir, matches + 1))
            {
                return true;
            }
            return false;
        }
        private void PopulateDirections()
        {
            dict.Add(Directions.W, new KeyValuePair<int, int>(0, -1));
            dict.Add(Directions.SW, new KeyValuePair<int, int>(1, -1));
            dict.Add(Directions.S, new KeyValuePair<int, int>(1, 0));
            dict.Add(Directions.SE, new KeyValuePair<int, int>(1, 1));
            dict.Add(Directions.E, new KeyValuePair<int, int>(0, 1));
            dict.Add(Directions.NE, new KeyValuePair<int, int>(-1, 1));
            dict.Add(Directions.N, new KeyValuePair<int, int>(-1, 0));
            dict.Add(Directions.NW, new KeyValuePair<int, int>(-1, -1));
        }

        public static void Test()
        {
            TrueBoardGame obj = new TrueBoardGame();
            obj.PopulateDirections();
            bool[,] board = new bool[1000,1000];

            board[0,1] = true;
            board[1,1] = true;
            board[2,1] = true;
            board[2,2] = true;
            board[3,1] = false;
            board[3,2] = true;
            board[1,1] = true;

            board[996,99] = true;
            board[997,99] = true;
            board[998,99] = true;
            board[999,99] = true;

            bool res = obj.IsBoardSolved(board, 4);
            System.Console.WriteLine(res);
        }
    }
}