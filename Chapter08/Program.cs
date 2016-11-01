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
            Console.WriteLine(FibonaciiMemo(10));

            Console.ReadLine();
        }

        static int Fibonacii(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            else return Fibonacii(n - 1) + Fibonacii(n - 2);
        }

        static int FibonaciiMemo(int n)
        {
            return FibonaciiMemo(n, new int[n + 1]);
        }

        static int FibonaciiMemo(int i, int[] memo)
        {
            if (i == 0 || i == 1)
            {
                return i;
            }

            if (memo[i] == 0)
            {
                memo[i] = FibonaciiMemo(i - 1, memo) + FibonaciiMemo(i - 2, memo);
            }
            return memo[i];
        }
    }
}
