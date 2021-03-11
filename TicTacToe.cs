using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp1
{
    using System;
    class TicTacToe
    {
        private static int size = 3;
        public static void PrintBoard(char[][] board)
        {
            Console.WriteLine("\n\n"); 
      
            Console.WriteLine("\t\t\t  %c | %c  | %c  \n", board[0][0], 
                             board[0][1], board[0][2]); 
            Console.WriteLine("\t\t\t--------------\n"); 
            Console.WriteLine("\t\t\t  %c | %c  | %c  \n", board[1][0], 
                             board[1][1], board[1][2]); 
            Console.WriteLine("\t\t\t--------------\n"); 
            Console.WriteLine("\t\t\t  %c | %c  | %c  \n\n", board[2][0], 
                             board[2][1], board[2][2]); 
   
    return; 
            
        }
    }
}
