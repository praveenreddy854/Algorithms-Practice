namespace ConsoleApp1.ArrayProblems
{
    using System;
    using System.Collections.Generic;
    public class CountTriplets
    {
        public static void GetTriplets(int[] a)
        {
            Array.Sort(a);
            HashSet<int> set = new HashSet<int>();

            foreach(int i in a)
            {
                set.Add(i);
            }
            int counter = 0;
            int prev = int.MinValue;
            for(int i=0;i<a.Length;i++)
            {
                if(prev == a[i])
                {
                    continue;
                }
                int innerPrev = int.MinValue;
                for(int j=i+1; j<a.Length;j++)
                {
                    if(innerPrev == a[j])
                    {
                        continue;
                    }
                    innerPrev = a[j];
                    int third = a[i] + a[j];
                    if(set.Contains(third))
                    {
                        counter++;
                    }
                }
                prev = a[i];
            }
            System.Console.WriteLine("The number of triplets are "+counter);
        }

        public static void Test()
        {
            int[] a1 = {1,3,2};
            int[] a2 = {1,3,2,4,1};
            int[] a3 = {1,1,1,1,1,2};
            int[] a4 = {0,0,0};

            GetTriplets(a1);
            GetTriplets(a2);
            GetTriplets(a3);
            GetTriplets(a4);
        }
    }
}