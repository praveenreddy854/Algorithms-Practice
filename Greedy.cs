using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class ActivitySelction
    {
        public static void GetMostNumberOfActivities()
        {
            int[] startOfActivities = { 1, 3, 0, 5, 8, 5 };
            int[] endOfActivities =   { 2, 4, 6, 7, 9, 9 };
            int j = 0;

            Console.WriteLine(j);
            for(int i=1; i<endOfActivities.Length; i++)
            {
                if(endOfActivities[j] <= startOfActivities[i])
                {
                    Console.Write(i+" ");
                    j = i;
                }
            }
            Console.Read();

        }
        public static void GetLeastChangeInLeastCoins()
        {
            int[] a = { 5, 2, 1 };
            int target = 13;
            int prevSum = 0;
            int sum = 0;
            int i = 0;
            int counter = 0;
            do
            {
                if (target > sum)
                {
                    sum += a[i];
                }
                if (target < sum)
                {
                    sum = prevSum;
                    i++;
                    continue;
                }
                
                counter++;

                if (target == sum)
                {
                    Console.WriteLine(counter);
                    break;
                }
                prevSum = sum;
            } while (1 == 1);

        }
    }
}
