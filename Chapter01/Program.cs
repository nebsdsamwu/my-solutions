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
            Console.WriteLine(IsOneEditAway("bake", "bakeee"));
            //string s1 = "Rats live on no evil star";
            //string s2 = "Taco cat yyoo vvv";
            //Console.WriteLine(IsPalindrome(s1));
            //Console.WriteLine(IsPermutationNSqr("abcfe", "ceabf"));
            //Console.WriteLine(IsUniqueNSqr("aobcdfgep"));
            Console.ReadKey();
        }

        // 1.5.1
        static bool IsOneEditAway(string s1, string s2)
        {
            if (Math.Abs(s1.Length - s2.Length) > 1)
            {
                return false;
            }

            if (s1.Length >= s2.Length)
                return CheckOneEditAway(s1, s2);
            else
                return CheckOneEditAway(s2, s1);
        }

        static bool CheckOneEditAway(string lng, string shrt)
        {
            char[] chsL = lng.ToCharArray();
            int[] chArchive = new int[256];
            for (int i = 0; i < chsL.Length; i++)
            {
                chArchive[(int)chsL[i]] += 1;
            }

            char[] chsS = shrt.ToCharArray();
            for (int i = 0; i < chsS.Length; i++)
            {
                if (chArchive[chsS[i]] > 0)
                {
                    chArchive[chsS[i]] -= 1;
                }
            }
 
            int cnt = 0;
            foreach(int n in chArchive)
            {
                if (n > 0)
                {
                    cnt += 1;
                }
            }

            if (cnt > 1)
            {
                return false;
            }
            return true;;
        }

        // 1.4.1
        static bool IsPalindrome(string s)
        {
            char[] chs = s.ToCharArray();
            var charCnt = new Dictionary<char, int?>();

            for (int i = 0; i < chs.Length; i++)
            {
                if (chs[i] == ' ')
                {
                    continue;
                }
                else
                {
                    if (chs[i] < 'a')
                    {
                        int cht = (int)chs[i] + 32;
                        chs[i] = (char)(cht);
                    }
                }

                int? cnt = 0;
                if (charCnt.TryGetValue(chs[i], out cnt))
                {
                    cnt += 1;
                    charCnt[chs[i]] = cnt;
                }
                else
                {
                    charCnt.Add(chs[i], 1);
                }
            }
              
            int oddCnt = 0;
            foreach(var kvp in charCnt)
            {
                if (kvp.Value % 2 == 0)
                    continue;

                if (kvp.Value % 2 == 1)
                {
                    oddCnt += 1;
                    if (oddCnt > 1)
                        return false;
                }
            }
            return true; ;
        }

        // 1.2.2
        static bool IsPermutationDict(string str1, string str2)
        {
            char[] chs1 = str1.ToCharArray();
            char[] chs2 = str2.ToCharArray();
            Dictionary<char, int?> chDict = new Dictionary<char, int?>();

            foreach (char ch2 in chs2)
            {
                int? cnt = 0;
                if (chDict.TryGetValue(ch2, out cnt))
                {
                    cnt += 1;
                    chDict[ch2] = cnt;
                }
                else
                {
                    chDict.Add(ch2, 1);
                }
            }

            foreach (char ch1 in chs1)
            {
                //foreach (char ch2 in chDict.Keys)
                //{
                //    if (ch1 == ch2)
                //    {
                //        int cnt = chDict[ch2].Value;
                //        chDict[ch2] = cnt - 1;
                //        break;
                //    }

                //    if (ch2 == chs2.Last())
                //        return false;
                //}
            }
            return true;
        }

        // 1.2.2
        static bool IsPermutationHash(string str1, string str2)
        {
            char[] chs1 = str1.ToCharArray();
            char[] chs2 = str2.ToCharArray();
            HashSet<char> chSet = new HashSet<char>();

            foreach(char ch2 in chs2)
            {
                chSet.Add(ch2);
            }

            foreach (char ch1 in chs1)
            {
                foreach (char ch2 in chSet)
                {
                    if (ch1 == ch2)
                        break;

                    if (ch2 == chs2.Last())
                        return false;
                }
            }
            return true;
        }

        // 1.2.1
        static bool IsPermutationNSqr(string str1, string str2)
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


        // 1.1.2
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

        // 1.1.1
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
