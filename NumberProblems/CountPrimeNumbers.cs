using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.NumberProblems
{
    //https://leetcode.com/problems/count-primes/
    class CountPrimeNumbers
    {
        public int CountPrimes(int n)
        {
            int counter = 0;
            if (n < 2) return counter;
            bool[] nonPrime = new bool[n];
            for(int i=2;i<n;i++)
            {
                if (nonPrime[i]) continue;
                counter++;

                for(int j=2;i*j<n;j++)
                {
                    nonPrime[i*j] = true;
                }
            }
            return counter;
        }
        private bool IsPrimeNumber(int x, bool[] lookupArray)
        {
            bool isPrime = true;
            int m = x / 2;
            for(int i=2;i<=m;i++)
            {
                if(x%i==0)
                {
                    isPrime = false;
                    break;
                }
            }
            lookupArray[x] = isPrime;
            return isPrime;
        }
    }
}
