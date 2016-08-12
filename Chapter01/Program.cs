using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(IsApermutationNSqr("abcde", "cedba"));
            //Console.WriteLine(IsUniqueNSqr("aobcdfgep"));
            Console.ReadKey();
        }

        // 1.2
        static bool IsApermutationNSqr(string str1, string str2)
        {
            char[] chs1 = str1.ToCharArray();
            char[] chs2 = str2.ToCharArray();

            foreach (char ch1 in chs1)
            {
                foreach (char ch2 in chs2)
                {
                    if (ch1 == ch2)
                        break;

                    if (ch2 == chs2.Last())
                        return false;
                }
            }
            return true;
        }


        // 1.1
        static bool IsUnique(string str)
        {
            char[] chs = str.ToCharArray();
            int[] chArchive = new int[128];

            for (int i = 0; i < chs.Length; i++)
            {
                if (chArchive[(int)chs[i]] == 0)
                {
                    chArchive[(int)chs[i]] = 1;
                }
                else if (chArchive[(int)chs[i]] == 1)
                {
                    return false;
                }
            }
            return true;
        }

        static bool IsUniqueNSqr(string str)
        {
            char[] chs = str.ToCharArray();

            for (int i = 0; i < chs.Length; i++)
            {
                for (int j=i + 1; j< chs.Length; j++)
                {
                    if (chs[i] == chs[j])
                        return false;
                }
            }
            return true;
        }
    }
}
