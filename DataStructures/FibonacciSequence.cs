using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public static class FibonacciSequence
    {
        /// <summary>
        /// Generate a given number of Fibonacci numbers
        /// </summary>
        /// <param name="n">Number to generate</param>
        public static void GetFibonacciNumber(int n)
        {
            int low = 0;
            int high = 1;
            Console.Write(high + " ");
            for (int i = 2; i <= n; i++)
            {
                int temp = low;
                low = high;
                high = temp + low;

                Console.Write(high + " ");
            }
        }

        public static int RecursionFibonacci(int n)
        {
            if (n <= 1)
            {
                return n;
            }
            return (RecursionFibonacci(n - 1) + RecursionFibonacci(n - 2));
        }
    }
}
