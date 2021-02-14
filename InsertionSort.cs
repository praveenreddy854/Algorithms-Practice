﻿using System;
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

            for(int i=1;i<a.Length-1;i++)
            {
                int temp = a[i];
                bool inserted = false;
                for(int j=i-1;j>=0;j--)
                {
                    if(temp < a[j])
                    {
                        a[j+1] = a[j];
                    }
                    else
                    {
                        a[j + 1] = temp;
                        inserted = true;
                        break;
                    }
                }
                if(!inserted)
                {
                    a[0] = temp;
                }
            }

            for (int i = 0; i < a.Length-1; i++)
            {
                Console.WriteLine(a[i]);
            }
        }
    }
}
