using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter08
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FibonacciBU(10));

            Console.ReadLine();
        }

        static int FibonacciBU(int n)
        {
            if (n == 0) return 0;

            int a = 0;
            int b = 1;

            for (int i = 2; i < n; i++)
            {
                int c = a + b;
                a = b;
                b = c;
            }
            return a + b;
        }

        static int FibonacciBU0(int n)
        {
            if (n == 0) return 0;
            else if (n == 1) return 1;

            int[] memo = new int[n];
            memo[0] = 0;
            memo[1] = 1;

            for (int i = 2; i < n; i++)
            {
                memo[i] = memo[i - 1] + memo[i - 2];
            }

            return memo[n - 1] + memo[n - 2];
        }

        static int Fibonacii(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            else return Fibonacii(n - 1) + Fibonacii(n - 2);
        }

        static int FibonacciMemo(int n)
        {
            return FibonacciMemo(n, new int[n + 1]);
        }

        static int FibonacciMemo(int i, int[] memo)
        {
            if (i == 0 || i == 1)
            {
                return i;
            }

            if (memo[i] == 0)
            {
                memo[i] = FibonacciMemo(i - 1, memo) + FibonacciMemo(i - 2, memo);
            }
            return memo[i];
        }
    }
}
