using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter04
{
    public class LookSequence
    {
        public static void FindSequence(Node root)
        {
            List<Node> ds = BFSFillNull(root);
            Node[] ndry = new Node[ds.Count];
            int i = 0;
            foreach(Node d in ds)
            {
                if (d.name != "null")
                {
                    ndry[i] = d;
                    i += 1;
                }
            }

            List<Node> list = new List<Node>();
            for (int h = 0; h < ndry.Length; h++ )
            {
                if (ndry[h] != null)
                {
                    list.Add(ndry[h]);
                }
            }

            GetPer(list);

            Console.WriteLine();
            foreach (Node n in list)
            {
                //Console.Write(n.value + " ");
            }
            Console.WriteLine();
        }

        public static bool IsInOrder(Node[] nds)
        {
            for (int i = 0; i < nds.Length; i++)
            {
                for (int j = i + 1; j < nds.Length; j++)
                {
                    if (nds[i].parent != null && nds[i].parent.ValEqual(nds[j]))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static void GetPer(List<Node> inlist)
        {
            Node[] list = inlist.ToArray();
            int endIdx = list.Length;
            GetPer(list, 0, endIdx);
        }

        public static void GetPer(Node[] list, int k, int m)
        {
            if (k == m)
            {
                if (IsInOrder(list))
                {
                    foreach (Node n in list)
                    {
                        Console.Write(n.value + " ");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                for (int i = k; i < m; i++)
                {
                    Swap(ref list[k], ref list[i]);
                    GetPer(list, k + 1, m);
                    Swap(ref list[k], ref list[i]);
                }
            }
        }

        public static void Swap(ref Node a, ref Node b)
        {
            if (a.ValEqual(b)) return;

            Node c = a;
            a = b;
            b = c;
        }

        public static void GetPer_Bak(List<int> inlist)
        {
            int[] list = inlist.ToArray();
            int endIdx = list.Length;
            GetPer_Bak(list, 0, endIdx);
        }

        public static void GetPer_Bak(int[] list, int k, int m)
        {
            if (k == m)
            {
                foreach (int n in list)
                {
                    Console.Write(n + " ");
                }
                Console.WriteLine();
            }
            else
            {
                for (int i = k; i < m; i++)
                {
                    Swap_Bak(ref list[k], ref list[i]);
                    GetPer_Bak(list, k + 1, m);
                    Swap_Bak(ref list[k], ref list[i]);
                }
            }
        }

        public static void Swap_Bak(ref int a, ref int b)
        {
            if (a == b) return;

            int c = a;
            a = b;
            b = c;
        }

        public static void PrintNodes(Node[] nds)
        {
            Console.Write("{");
            for (int i = 0; i < nds.Length; i++)
            {
                if (nds[i].name != "null")
                {
                    if (i < nds.Length - 1)
                    {
                        Console.Write(nds[i].value + ",");
                    }
                    else
                    {
                        Console.Write(nds[i].value);
                    }
                }
            }
            Console.Write("}");
            Console.Write("\n");
        }

        public static List<Node> BFSFillNull(Node root)
        {
            List<Node> nds = new List<Node>();
            Queue<Node> que = new Queue<Node>();
            que.Enqueue(root);
            root.marked = true;
            while (que.Count > 0)
            {
                Node d = que.Dequeue();
                nds.Add(d);
                //Console.WriteLine(d.value);
                d.visited = true;

                if (!(d.right == null && d.left == null))
                {
                    if (d.right != null && !d.right.marked)
                    {
                        que.Enqueue(d.right);
                        d.right.marked = true;
                    }
                    else
                    {
                        que.Enqueue(new Node("null"));
                    }

                    if (d.left != null && !d.left.marked)
                    {
                        que.Enqueue(d.left);
                        d.left.marked = true;
                    }
                    else
                    {
                        que.Enqueue(new Node("null"));
                    }
                }
            }
            return nds;
        }

        public static Node BuildMinHeightBST_V1()
        {
            /*       
             *                   16
             *                  /  \
             *                 11  17
             *                /  \   \
                             7   12   18
                           /  \    \    \
                          4    8    13   19
                         /  \   \    \    \
                        2    5   9    14   20 
                      /  \    \   \    \    \
                     1    3    6   10   15  [21]
             * 
             * 
             *            4
             *          2   5
             *        1  3  6 7
             *        
             *         3           4
             *        2 4        2   5
             *       1   5     1   3
             */
            int[] src = { 1, 2, 3, 4, 5 };//, 6, 7, 8, 9, 10};//, 11, 12, 13, 14, 15, 16, 17, 18, 19 };//, 20 };

            Queue<int> idxs = FindRootsIdx(src);

            int rootIdx = idxs.Dequeue();
            Node root = new Node(src[rootIdx]);
            Node cur = null;
            rootIdx = idxs.Dequeue();
            for (int i = 1; i < src.Length; i++)
            {
                Node nd = new Node(src[i]);
                if (i == rootIdx)
                {
                    nd.left = root;
                    root = nd;
                    cur = root;
                    if (idxs.Count > 0)
                    {
                        rootIdx = idxs.Dequeue();
                    }
                }
                else
                {
                    cur.right = nd;
                    cur = cur.right;
                }
            }

            return root;
            #region test InsetBST
            //Node[] nds = new Node[src.Length];
            //for (int i = 0; i < src.Length; i++)
            //{
            //    nds[i] = new Node(src[i]);
            //}

            //foreach (Node nd in nds)
            //{
            //    Console.WriteLine(nd.value);
            //}

            //Node root = new Node(src[0]);
            ////RootIndex(src);
            //Node root4 = new Node(4);
            //Node nd01 = new Node(1);

            //foreach (var nd in nds)
            //{
            //    InsertToBST(root4, nd);
            //}
            //Console.WriteLine("Inserted.");
            #endregion
        }

        public static Queue<int> FindRootsIdx(int[] numbs)
        {
            Queue<int> rootsIdx = new Queue<int>();
            int fullLength = 0;
            int preLength = 0;
            int n = 0;

            while (fullLength <= numbs.Length)
            {
                preLength = fullLength;
                n += 1;
                fullLength = n * (n + 1) / 2;
                rootsIdx.Enqueue(preLength);
            }

            return rootsIdx;
        }
    }
}
