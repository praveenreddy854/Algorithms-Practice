using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Amazon
{
    /// <summary>
    /// https://leetcode.com/discuss/interview-question/762546/
    /// </summary>
    class FindFruitCombos
    {
        public static int WinPrize(List<List<string>> cl, List<string> cart)
        {
            int cartPointer = 0;
            foreach (List<string> code in cl)
            {
                foreach(string item in code)
                {
                    if(cartPointer >= cart.Count)
                    {
                        return 0;
                    }
                    if(item == cart[cartPointer] || item == "anything")
                    {
                        cartPointer++;
                    }
                    else
                    {
                        return 0;
                    }
                }
            }
            return cartPointer == cart.Count ? 1 : 0;
        }
        public static void TestWinPrize()
        {
            // Not a winner
            List<List<string>> cl1 = new List<List<string>>()
            { new List<string>(){ "apple", "apple" }, new List<string>() { "banana", "anything", "banana" } };
            List<string> cart1 = new List<string>()
            { "orange", "apple", "apple", "banana", "orange", "banana" };

            // Not a winner
            List<List<string>> cl2 = new List<List<string>>()
            { new List<string>(){ "apple", "apple" }, new List<string>() { "banana", "anything", "banana" } };
            List<string> cart2 = new List<string>()
            { "apple", "apple", "apple", "banana", "orange", "banana" };

            // Not a winner
            List<List<string>> cl3 = new List<List<string>>()
            { new List<string>(){ "apple", "apple" }, new List<string>() { "banana", "anything", "banana" } };
            List<string> cart3 = new List<string>()
            { "apple", "apple", "banana", "banana", "orange", "banana" };

            // Winner
            List<List<string>> cl4 = new List<List<string>>()
            { new List<string>(){ "apple", "apple" }, new List<string>() { "banana", "anything", "banana" } };
            List<string> cart4 = new List<string>()
            { "apple", "apple", "banana", "orange", "banana" };

            TestInternal(cl1, cart1, 0);
            TestInternal(cl2, cart2, 0);
            TestInternal(cl3, cart3, 0);
            TestInternal(cl4, cart4, 1);
        }
        private static void TestInternal(List<List<string>> cl, List<string> cart, int expected)
        {
            Console.WriteLine(WinPrize(cl,cart) == expected);
        }
    }
}
