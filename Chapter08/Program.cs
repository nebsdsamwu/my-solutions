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
            // 8.0
            //Console.WriteLine(FibonacciBU(10));

            // 9.1
            Console.WriteLine(CountStep(30));
            Console.ReadLine();
        }

        // 8.1
        static int CountStep(int n)
        {
            int[] memo = new int[n + 1];
            for (int i = 0; i < memo.Length; i++)
            {
                memo[i] = -1;
            }
            return CountStep(n, memo);
        }

        static int CountStep(int n, int[] memo)
        {
            if (n < 0) return 0;
            else if (n == 0) return 1;
            else if (memo[n] > -1) return memo[n];
            else
            {
                memo[n] = CountStep(n - 1, memo) + CountStep(n - 2, memo) + CountStep(n - 3, memo);
                return memo[n];
            }
        }

        // 8.1
        static int CountStep0(int n)
        {
            if (n < 0) return 0;
            else if (n == 0) return 1;
            else
            {
                return CountStep(n - 1) + CountStep(n - 2) + CountStep(n - 3);
            }
        }


        // 8.0
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
