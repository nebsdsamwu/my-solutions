using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtherTest
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] a = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            FindMedian(a.Length, a);

            Console.ReadKey();
        }

        static void FindMedian(int n, int[] a)
        {
            //Console.WriteLine(n);
            List<int> list = new List<int>();

            for (int i = 0; i < a.Length; i++)
            {
                list.Add(a[i]);
                FindMedian(list);
            }
        }

        static void FindMedian(List<int> list)
        {
            int cnt = list.Count();
            if (cnt == 1)
            {
                Console.WriteLine(((double)list.First()).ToString("F1"));
                return;
            }
            list.Sort();
            double result = -1;
            int mid0 = cnt / 2;
            if (cnt % 2 == 0)
            {      
                result = ((double)list.ElementAt(mid0) + (double)list.ElementAt(mid0 - 1)) / 2;
                Console.WriteLine(result.ToString("F1"));

            }
            else
            {
                result = ((double)list.ElementAt(mid0));
                Console.WriteLine(result.ToString("F1"));
            }
        }
    }
}
