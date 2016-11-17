using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OtherTest
{
    class HanoiTest
    {
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
                towers = new Stack<int>[3];
                for (int i = 0; i < towers.Length; i++ )
                {
                    towers[i] = new Stack<int>();
                }

                for (int i = diskCnt; i > 0; i--)
                {
                    towers[0].Push(i);
                }
            }
        }

        public void Run()
        {
            // Console.WriteLine(towers[0].Count);
            MoveDisks(diskCnt, towers[0], towers[1], towers[2]);
        }

        private void MoveDisks(int n, Stack<int> fromTwr, Stack<int> buffTwr, Stack<int> toTwr)
        {
            if (n > 0)
            {
                MoveDisks(n - 1, fromTwr, toTwr, buffTwr);
                int top = fromTwr.Pop();
                toTwr.Push(top);
                MoveDisks(n - 1, buffTwr, fromTwr, toTwr);
            }
        }

        private void Move2Disks(Stack<int> fromTwr, Stack<int> buffTwr, Stack<int> toTwr, int index)
        {
            if (fromTwr.Count == 2)
            {
                int pickedDisk = fromTwr.Pop();
                buffTwr.Push(pickedDisk);
                pickedDisk = fromTwr.Pop();
                toTwr.Push(pickedDisk);
                pickedDisk = buffTwr.Pop();
                toTwr.Push(pickedDisk);
            }
            else Console.WriteLine("Invalid disk quantity.");
        }
    }
}
