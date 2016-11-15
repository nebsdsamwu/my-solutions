using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HanoiTower
{
    class Program
    {
        static void Main(string[] args)
        {
            Tower[] towers = new Tower[3];
            for (int i=0; i < 3; i++)
            {
                towers[i] = new Tower(i);
            }

            int diskCnt = 8;
            for (int i = diskCnt - 1; i >= 0; i--)
            {
                towers[0].Add(i);
            }

            towers[0].MoveDisks(diskCnt, towers[2], towers[1]);

            Console.ReadKey();
        }
    }


}
