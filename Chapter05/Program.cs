using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter05
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(SetBit(9, 2));

            Console.ReadLine();
        }

        public static bool GetBit(int num, int i)
        {
            // 1001
            // 0100

            return ((num & 1 << i) != 0);
        }

        public static int SetBit(int num, int i)
        {
            // 1001
            // 0100
            // 1101
            return num | (1 << i);
        }
    }
}
