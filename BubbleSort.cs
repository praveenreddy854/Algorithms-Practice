using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class BubbleSort
    {
        public static void BubbleSortFunc()
        {
            int[] a = new int[] { 2, 8, 5, 9, 4, 3 };
            int temp = -1;
            for(int i= a.Length-1; i > 0; i--)
            {
                for(int j=0; j<i;j++)
                {
                    if(a[j] > a[i])
                    {
                        temp = a[j];
                        a[j] = a[i];
                        a[i] = temp;
                    }
                }
            }

            for(int i=0;i<a.Length;i++)
            {
                Console.WriteLine(a[i]);
            }
        }
    }
}
