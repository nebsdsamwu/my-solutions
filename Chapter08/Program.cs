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

            // 8.1
            //Console.WriteLine(CountStep(25));

            // 8.2
            // oooxox
            // oxooxo  
            // ooooox
            // oxxxoo
            // oooooo

            //bool[][] mazz = new bool[5][];
            //mazz[0] = new bool[] { true, true, true, false, true, false };
            //mazz[1] = new bool[] { true, false, true, true, false, true };
            //mazz[2] = new bool[] { true, true, true, true, true, false };
            //mazz[3] = new bool[] { true, false, false, false, true, true };
            //mazz[4] = new bool[] { true, true, true, true, true, true }; 

            //List<Tuple<int, int>> path = GetPath(mazz);
            //foreach (var p in path)
            //{
            //    Console.WriteLine(p.Item1 + ", " + p.Item2);
            //}

            // 8.3
            int[] array = { -10, -5, -3, -2, -1, 1, 2, 3, 4, 5, 6, 11, 13, 15, 16, 20 };
            Console.WriteLine(MagicFast(array));

            Console.ReadLine();
        }

        // 8.3
        static int MagicFast(int[] array)
        {
            return MagicFast(array, 0, array.Length - 1);
        }

        // 8.3
        static int MagicFast(int[] array, int start, int end)
        {
            if (end < start)
            {
                return -1;
            }

            int mid = (start + end) / 2;

            if (array[mid] == mid)
            {
                return mid;
            }
            else if (array[mid] > mid)
            {
                return MagicFast(array, start, mid - 1);
            }
            else
            {
                return MagicFast(array, mid + 1, end);
            }
        }

        // 8.3
        static int MagicSlow(int[] array)
        {
            for (int i = 0; i < array.Length; i++ )
            {
                if (array[i] == i)
                {
                    return i;
                }
            }
            return -1;
        }

        // 8.2
        static List<Tuple<int, int>> GetPath(bool[][] mazz)
        {
            if (mazz == null || mazz.Length == 0) return null;
            List<Tuple<int, int>> path = new List<Tuple<int, int>>();
            HashSet<Tuple<int, int>> failedPoints = new HashSet<Tuple<int, int>>();
            if (GetPath(mazz, mazz.Length -1, mazz[0].Length - 1, path, failedPoints))
            {
                return path;
            }
            return null;
        }

        static bool GetPath(bool[][] mazz, int row, int col, List<Tuple<int, int>> path, HashSet<Tuple<int, int>> failedPoints)
        {
            if (col < 0 || row < 0 || ! mazz[row][col])
            {
                return false;
            }

            Tuple<int, int> point = new Tuple<int, int>(row, col);

            if (failedPoints.Contains(point))
            {
                return false;
            }

            bool isAtOrigin = (row == 0 && col == 0);

            if (isAtOrigin
                || GetPath(mazz, row, col - 1, path, failedPoints)
                || GetPath(mazz, row - 1, col, path, failedPoints))
            {
                //Tuple<int, int> point = new Tuple<int, int>(row, col);
                path.Add(point);
                return true;
            }
            failedPoints.Add(point);
            return false;
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
