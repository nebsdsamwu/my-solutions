using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter06
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine(PrimeNaive(111191));
            // Console.WriteLine(PrimeV1(111191));
            //Console.WriteLine(PrimeV1(11119111));

            Console.WriteLine(KidsRatioForFamilies(10000000).ToString("F3"));

            Console.ReadKey();
        }

        static double KidsRatioForFamilies(int n)
        {
            double r = 0;
            double g = 0;
            double b = 0;
            for (int i = 0; i < n; i++)
            {
                Tuple<int, int> ets = EstimateKidsNums();
                g += 1;
                b += ets.Item1;
            }

            r = (double)(g / (b + g));
            return r;
        }

        static Tuple<int, int> EstimateKidsNums()
        {
            int b = 0;
            Random rdm = new Random();
            bool isGirl = false;
            while(! isGirl)
            {
                isGirl = (rdm.Next(0, 2) == 1);
                if (isGirl)
                {
                    break;
                }
                else
                {
                    b += 1;
                }
            }
            return new Tuple<int, int>(b, 1);
        }

        static bool PrimeV1(int n)
        {
            if (n < 2) return false;

            int sqrn = (int) Math.Sqrt(n);

            for (int i = 2; i < sqrn; i++)
            {
                if (n % i == 0)
                {
                    Console.WriteLine(i);
                    return false;
                }
            }
            return true;
        }

        static bool PrimeNaive(int n)
        {
            if (n < 2)
            {
                return false;
            }

            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                {
                    Console.WriteLine(i);
                    return false;
                }
            }
            return true;
        }
    }
}
