using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.ArrayProblems
{
    //https://leetcode.com/problems/best-time-to-buy-and-sell-stock-ii/
    class BestTimeToBuyAndSellStocks
    {
        //https://leetcode.com/problems/best-time-to-buy-and-sell-stock/
        public int MaxProfit(int[] prices)
        {
            int min = int.MaxValue;
            int maxProfit = 0;
            for (int i = 0; i < prices.Length; i++)
            {
                min = Math.Min(prices[i], min);
                maxProfit = Math.Max(maxProfit, prices[i] - min);
            }
            return maxProfit;
        }

        public static int MaxProfit2(int[] prices)
        {
            return MaxProfit2Utils(prices, 0, prices.Length - 1);
        }

        private static int MaxProfit2Utils(int[] prices, int start, int end)
        {
            if(start >= end - 1)
            {
                int diff = prices[end] - prices[start];
                return diff > 0 ? diff : 0;
            }

            int middle = (end + start) / 2;

            int result = MaxProfit2Utils(prices, start, middle) + MaxProfit2Utils(prices, middle, end);
            return result;
        }
    }
}
