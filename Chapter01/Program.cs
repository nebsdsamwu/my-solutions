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

            Rotate9Dots();

            //string[,] mFour = new string[2,2];
            //mFour[0, 1] = "A";
            //mFour[1, 1] = "B";
            //mFour[0, 0] = "C";
            //mFour[1, 0] = "D";

            //for (int i = 0; i < mFour.GetLongLength(0); i++)
            //{
            //    for(int j=0;j<mFour.GetLongLength(1); j++)
            //    {
            //        Console.WriteLine(mFour[i,j]);
            //    }
            //}
                //Console.WriteLine(CompressString("aabcccccaaa"));
                //Console.WriteLine(IsOneAway("bake", "bakeee"));
                //string s1 = "Rats live on no evil star";
                //string s2 = "Taco cat yyoo vvv";
                //Console.WriteLine(IsPalindrome(s1));
                //Console.WriteLine(IsPermutationNSqr("abcfe", "ceabf"));
                //Console.WriteLine(IsUniqueNSqr("aobcdfgep"));
                Console.ReadKey();
        }

        // Ranson
        static bool CheckNote(string[] source, string[] notes)
        {
            Dictionary<string, int> pool = new Dictionary<string, int>();
            foreach (string s in source)
            {
                int cnt = -1;
                if (pool.TryGetValue(s, out cnt))
                {
                    cnt += 1;
                    pool[s] = cnt;
                }
                else
                {
                    pool.Add(s, 1);
                }
            }

            foreach (var kvp in pool)
            {
                //Console.WriteLine(kvp.Key +":"+kvp.Value);
            }

            foreach (string s in notes)
            {
                int cnt = -1;
                if (pool.TryGetValue(s, out cnt))
                {
                    cnt -= 1;
                    if (cnt > 0)
                    {
                        pool[s] = cnt;
                    }
                    else
                    {
                        pool.Remove(s);
                    }
                }
                else
                {
                    Console.WriteLine("No");
                    return false; ;
                }
            }
            Console.WriteLine("Yes");
            return true;
        }

        // 1.7.1 - test
        static void Rotate9Dots()
        {
            /*
             *  c f i       a b c 
             *  b e h   =>  d e f
             *  a d g       g h i 
             *  
             *  [ g d a h e b i f c ]
             *  
             *  current:
             *  a f c
             *  b e h
             *  d d h
             */
            string[,] mm = new string[3, 3];
            mm[0, 0] = "a";
            mm[0, 1] = "b";
            mm[0, 2] = "c";
            mm[1, 0] = "d";
            mm[1, 1] = "e";
            mm[1, 2] = "f";
            mm[2, 0] = "g";
            mm[2, 1] = "h";
            mm[2, 2] = "i";

            int len = mm.GetLength(0);
            double csum = 0;
            for (int i = 0; i < len; i++)
            {
                csum += i;
            }

            double cntr = csum / len;

            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    Console.WriteLine(mm[i, j]);
                }
            }


            string t1 = "";
            string t2 = "";
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    if (i < cntr && j < cntr)
                    {
                        t1 = mm[i, j];
                        mm[i, j] = mm[i + 1, j];
                    }
                    else if (i < cntr && j == cntr)
                    {
                        t2 = mm[i, j];
                        mm[i, j] = t1;
                    }
                    else if (i < cntr && j > cntr)
                    {
                        t2 = mm[i, j];
                        mm[i, j] = t1;
                    }
                    else if (i > cntr && j < cntr)
                    {
                        mm[i, j] = mm[i, j + 1];
                    }
                    else if (i > cntr && j > cntr)
                    {
                        mm[i, j] = t2;
                    }
                }
            }
            Console.WriteLine("");

            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    Console.WriteLine(mm[i, j]);
                }
            }
            Console.WriteLine("");
        }

        static void Rotate4Dots()
        {
            string[,] mm = new string[2, 2];

            mm[0, 0] = "a";
            mm[0, 1] = "b";
            mm[1, 0] = "c";
            mm[1, 1] = "d";

            int len = mm.GetLength(0);
            double csum = 0;
            for (int i = 0; i < len; i++ )
            {
                csum += i;
            }

            double ctr = csum / len;
 
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    Console.WriteLine(mm[i, j]);
                }
            }


            string t1 = "";
            string t2 = "";
            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    if (i < ctr && j < ctr)
                    {
                        t1 = mm[i, j];
                        mm[i, j] = mm[i + 1, j];
                    }
                    else if (i < ctr && j > ctr)
                    {
                        t2 = mm[i, j];
                        mm[i, j] = t1;
                    }
                    else if (i > ctr && j < ctr)
                    {
                        mm[i, j] = mm[i, j + 1];
                    }
                    else if (i > ctr && j > ctr)
                    {
                        mm[i, j] = t2;
                    }
                }
            }
            Console.WriteLine("");

            for (int i = 0; i < len; i++)
            {
                for (int j = 0; j < len; j++)
                {
                    Console.WriteLine(mm[i, j]);
                }
            }
            Console.WriteLine("");
            Console.ReadKey();
        }

        // 1.7.1
        static void RotateMatrix(string[,] m)
        {
            float c = (float)(m.GetLength(0) / 2);

            for (int i = 0; i < m.GetLongLength(0); i++)
            {
                for (int j = 0; j < m.GetLongLength(1); j++)
                {
                    Console.WriteLine(m[i, j]);
                    if (i > c && j>c) 
                    {

                    }
                }
            }            
        }

        // 1.6.1
        static string CompressString(string inStr)
        {
            string outStr = "";
            char[] chs = inStr.ToCharArray();
            Queue<string> strQue = new Queue<string>();

            int start = 0;
            int cnt = 0;
            for (int i = 0; i < chs.Length; i++)
            {
                start = i;
                cnt = 1;
                while(chs[i+1]==chs[start])
                {
                    cnt += 1;
                    i += 1;
                    if (i == chs.Length - 1)
                    { 
                        break; 
                    }
                }
                strQue.Enqueue(chs[start].ToString());
                strQue.Enqueue(cnt.ToString());
            }

            if (strQue.Count >= chs.Length)
            {
                return inStr;
            }
            else
            {
                while (strQue.Count > 0)
                {
                    outStr += strQue.Dequeue();
                }
                return outStr;
            }
        }

        // 1.5.1
        static bool IsOneAway(string s1, string s2)
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
