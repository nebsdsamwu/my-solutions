using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanoiTower
{
    class Tower
    {
        private Stack<int> disks;
        private int index;
        public Tower(int i)
        {
            disks = new Stack<int>();
            index = i;
        }

        public int Index
        {
            get { return index; }
            set { index = value; }
        }

        public void Add(int d)
        {
            if (!(disks.Count == 0) && disks.Peek() <= d)
            {
                Console.WriteLine("Error pacing disk " + d);
            }
            else
            {
                disks.Push(d);
            }
        }

        public void MoveTopTo(Tower t)
        {
            int top = disks.Pop();
            t.Add(top);
        }

        public void MoveDisks(int index, Tower destination, Tower buffer)
        {
            if (index > 0)
            {
                MoveDisks(index - 1, buffer, destination);
                MoveTopTo(destination);
                buffer.MoveDisks(index - 1, destination, this);
            }
        }
    }
}
