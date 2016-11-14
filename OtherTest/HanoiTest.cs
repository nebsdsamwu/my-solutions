using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtherTest
{
    class HanoiTest
    {
        private int towerCnt = 3;
        private int diskCnt = 0;
        Stack<int>[] towers;

        public HanoiTest(int d)
        {
            if (d < 1)
            {
                Console.WriteLine("Invalid disk quantity.");
            }
            else
            {
                diskCnt = d;
                towers = new Stack<int>[towerCnt];
                for (int i = 0; i < towers.Length; i++ )
                {
                    towers[i] = new Stack<int>();
                }

                for (int i = diskCnt - 1; i >= 0; i--)
                {
                    towers[0].Push(i);
                }
            }
        }

        public void Run()
        {
            Console.WriteLine(towers[0].Count);
        }

    }
}
