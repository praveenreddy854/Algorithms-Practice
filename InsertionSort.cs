using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class InsertionSort
    {
        public static void InsertionSortFunc()
        {
            int[] a = { 2, 5, 3, 1, 8, 9, int.MaxValue };

            for (int i = 1; i < a.Length - 1; i++)
            {
                int temp = a[i];
                int j = i - 1;
                while (j >= 0 && temp < a[j])
                {
                    a[j + 1] = a[j--];
                }
                a[j + 1] = temp;
            }

            for (int i = 0; i < a.Length - 1; i++)
            {
                Console.WriteLine(a[i]);
            }
        }
    }
}
