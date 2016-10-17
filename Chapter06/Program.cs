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
            Console.WriteLine(PrimeV1(11119111));
            Console.ReadKey();
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
