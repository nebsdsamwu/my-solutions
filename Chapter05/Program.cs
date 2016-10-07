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
            string n = "10000000000";
            string m = "10011";
            Insert(n, m);

            Console.ReadLine();
        }

        // 5.2
        public static void BinToString(double r)
        {

        }

        // 5.1
        public static void Insert(string n, string m)
        {
            int i = 2;
            int j = 6;
            int bn = Convert.ToInt32(n, 2);
            int bm = Convert.ToInt32(m, 2);
            bm <<= i;
            int r = bn | bm;
            Console.WriteLine(Convert.ToString(r, 2));
        }

        public static void TestBitOpt()
        {
            Console.WriteLine(GetBit(13, 2));
            Console.WriteLine(SetBit(13, 1));
            Console.WriteLine(ClearBit(13, 2));
            Console.WriteLine(ClearBitFromI(13, 2));
            Console.WriteLine(ClearBitToI(13, 2));
            Console.WriteLine(UpdateBit(13, 1, true));
        }

        public static bool GetBit(int num, int i)
        {
            // 1101
            // 0100

            return ((num & 1 << i) != 0);
        }

        public static int SetBit(int num, int i)
        {
            // 1101
            // 0110
            // 1111
            return num | (1 << i);
        }

        public static int ClearBit(int num, int i)
        {
            // 1101
            // 0010
            int mask = ~(1 << i);
            return num & mask;
        }

        public static int ClearBitFromI(int num, int i)
        {
            // 1101
            // 0011
            int mask = (1 << i) - 1;
            return num & mask;
        }

        public static int ClearBitToI(int num, int i)
        {
            // 1101
            // 1000
            int mask = (-1 << (i + 1));
            return num & mask;
        }

        public static int UpdateBit(int num, int i, bool is1)
        {
            // 1101
            // 1011  

            // 1001
            // 0000
            int value = is1 ? 1 : 0;
            int mask = ~(1 << i);
            return (num & mask) | (value << i);
        }
    }
}
