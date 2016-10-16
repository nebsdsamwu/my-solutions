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
            // 5.1
            //string n = "10000000000";
            //string m = "10011";
            //Insert(n, m);

            // 5.2
            //BinToString(0.72);
            //FlipToWin(1775); // 11011101111
            //5.3
            FindNext("11011001111100"); // 13948
            //FindMax(1775); // 11011101111

            // 5.4
            //Conversion(1775, 29);

            // 5.5
            // Swap("10101010");


            Console.ReadLine();   
        }

        // 5.5
        static void Swap(string s)
        {
            int input = Convert.ToInt32(s, 2);
            Console.WriteLine(input);
            string mask = "10101010";
                       // "10101010"
                       //  010101010
            int a = Convert.ToInt32(mask, 2);
            a = a & input;
            Console.WriteLine(a);
            Console.WriteLine(Convert.ToString(a,2));
            //"01010101"
            //"10101010"
            //"00000000"

            //"01010101"
            // 00000000
            // 01010101

        }

        // 5.4
        static void Conversion(int a, int b)
        {
            // 11101, 1111
            Console.WriteLine(Convert.ToString(a, 2));
            Console.WriteLine(Convert.ToString(b, 2));
            int c = a ^ b;
            Console.WriteLine(Convert.ToString(c, 2));
            int cnt = 0;
            for (int d = a ^ b; d != 0; d = d & (d-1))
            {
                cnt += 1;
            }
            Console.WriteLine(cnt);
        }

        // 5.4  -- HARD- Study
        static void FindNext(string bits)
        {
            //bits = "11011001111001";

            Console.WriteLine(Convert.ToInt32(bits, 2));
            // 11011001111100
            int n = Convert.ToInt32(bits, 2);
            Console.WriteLine(Convert.ToString(n, 2));
            int c = n;
            int c0 = 0;
            int c1 = 0;

            // 110110011111100  c
            // 000000000000001  1
            while ((c & 1) == 0 && (c != 0))
            {
                c0 += 1;
                c >>= 1;
            }

            while ((c & 1) == 1)
            {
                c1 += 1;
                c >>= 1;
            }
            //Console.WriteLine(c0);
            //Console.WriteLine(c1);

            if (c0 + c1 == 31 || c0 + c1 == 0) 
                throw new Exception("No bigger number exists");

            int p = c0 + c1;

            n |= (1 << p);
            Console.WriteLine(Convert.ToString(n, 2));
            n &= ~((1 << p) - 1);
            Console.WriteLine(Convert.ToString(n, 2));
            n |= (1 << (c1 - 1)) - 1;
            Console.WriteLine(Convert.ToString(n, 2));
        }
        
        static void FindPrev(int n)
        {

        }

        // 5.3 
        /*  
         * 11011101111
         * [1,2]  [0,1]  [1,3]  [0,1]  [1,4]
         */
        public static int FlipToWin(int n)
        {
            string bits = Convert.ToString(n, 2);
            Tuple<char, int>[] rec = CountBits(bits).ToArray();
            int maxLen = 0;
            int curLen = 0;

            for (int i = 0; i < rec.Length - 1; i++)
            {
                if (rec[i].Item1 == '1')
                {
                    if (rec[i + 1].Item2 == 1)
                    {
                        curLen = rec[i].Item2 + rec[i + 2].Item2 + 1;
                        if (curLen > maxLen)
                        {
                            maxLen = curLen;
                        }
                        i = i + 1;
                    }
                    else if (rec[i + 1].Item2 > 1)
                    {
                        curLen = rec[i].Item2 + 1;
                        if (curLen > maxLen)
                        {
                            maxLen = curLen;
                        }
                    }
                    curLen = 0;
                }
                else if (rec[i].Item1 == '0')
                {
                    Console.WriteLine("[" + i + "]");
                }
            }
            return maxLen;
        }

        // 11011101111
        public static List<Tuple<char, int>> CountBits(string bits)
        {
            List<Tuple<char, int>> rec = new List<Tuple<char, int>>();         
            char[] bry = bits.ToCharArray();
            int tcnt = 0;
            int fcnt = 0;
            for (int i = 0; i < bry.Length; i++)
            {
                if (bry[i] == '1')
                {
                    tcnt += 1;
                    if ((i + 1 < bry.Length && bry[i + 1] == '0') || i + 1 == bry.Length)
                    {
                        Tuple<char, int> tp = new Tuple<char, int>('1', tcnt);
                        rec.Add(tp);
                        tcnt = 0;
                    }
                }
                else  
                {
                    fcnt += 1;
                    if ((i + 1 < bry.Length && bry[i + 1] == '1') || i + 1 == bry.Length)
                    {
                        Tuple<char, int> tp = new Tuple<char, int>('0', fcnt);
                        rec.Add(tp);
                        fcnt = 0;
                    }
                }
            }
            return rec;
        }
 
        // 5.2
        public static void BinToString(double r)
        {
            //0.75 = 0.5 + 0.25

            int cnt = 0;
            List<string> bits = new List<string>();
            while (r > 0 && cnt <= 32)
            {
                r = r * 2;
                string bit = r - 1 >= 0 ? "1" : "0";
                bits.Add(bit);
                if (r > 1)
                {
                    r -= 1;
                }
                cnt += 1; 
            }
            if (bits.Count > 32)
            {
                Console.WriteLine("ERROR");
            }
            else
            {
                foreach (string s in bits)
                {
                    Console.Write(s);
                }
            }
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
