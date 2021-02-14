using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp1
{
    class TicTacToe
    {
        private static int size = 3;
        public static void PrintBoard()
        {
            for(int i=0; i<size;i++)
            {
                Console.Write("\n");
                for (int j=0;j<size;j++)
                {
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.Write("\t\t\t");
                    Console.BufferHeight = 1;
                    Console.BufferWidth = 1;
                }
                Console.BackgroundColor = ConsoleColor.Black;
            }
            
        }
    }
}
