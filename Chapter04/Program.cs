using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Chapter03;

namespace Chapter04
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestTree();
            //TestGraph();

            // 4.6
            //Node root = BuildMinHeightBST_V1();
            //Node pre = new Node(8);
            //Console.WriteLine(FindNext(root, pre, null).value);
            //Console.WriteLine(CheckBST(root));
            //List<LinkedList<Node>> levels = LevelNodes(root);
            //Console.WriteLine(IsBalance(root));

            #region // 4.7
            List<Node> prjs = new List<Node>();
            string[] names = { "a","b","c","d","e","f"};
            Node a = new Node("a");
            Node b = new Node("b");
            Node c = new Node("c");
            Node d = new Node("d");
            Node e = new Node("e");
            Node f = new Node("f");

            foreach (string name in names)
            {
                Node nd = null;
                switch (name)
                {
                    case "a":
                        a.parent = f;
                        f.kids.Add(a);
                        break;

                    case "b": 
                        b.parent = f;
                        f.kids.Add(b);
                        break;

                    case "c": 
                        c.parent = d;
                        d.kids.Add(c);
                        break;

                    case "d":
                        d.parent = b;
                        b.kids.Add(d);
                        break;

                    case "e": 
                        e.parent = null;
                        e.kids = null;
                        break;

                    case "f": 
                        f.parent = null;
                        f.kids.Add(b);
                        f.kids.Add(a);
                        break;

                    default: nd = new Node("empty");
                        break;             
                }
            }
            prjs.Add(a);
            prjs.Add(b);
            prjs.Add(c);
            prjs.Add(d);
            prjs.Add(e);
            prjs.Add(f);

            //List<string> result = FindOrder(prjs);
            #endregion

            #region dpns
            //List<Node[]> dps = new List<Node[]>();
            //Node[] d1 = { new Node("a"), new Node("d") };
            //Node[] d2 = { new Node("f"), new Node("b") };
            //Node[] d3 = { new Node("b"), new Node("d") };
            //Node[] d4 = { new Node("f"), new Node("a") };
            //Node[] d5 = { new Node("d"), new Node("c") };
            //dps.Add(d1);
            //dps.Add(d2);
            //dps.Add(d3);
            //dps.Add(d4);
            //dps.Add(d5);
            #endregion

            // 4.8
            Node[] nds = BuildBSTAndGetNodes();
            //InOrderTraverse(nds[0]);
            //Node cmn = FindCommon(nds[1], nds[2]);

            // 4.9;
            Node root = BuildMinHeightBST_V1();
            FindSequence(root);
            Console.ReadKey();
        }

        // 4.9
        public static void FindSequence(Node root)
        {
            List<Node> ds = BFSFillNull(root);
            Node[] ndry = ds.ToArray<Node>();
            Node[] toPrint = null;

            for (int i = 0; i < ndry.Length; i++)
            {
                toPrint = new Node[ndry.Length];
                toPrint[0] = ndry[0];
                
                for (int j = 1; j < ndry.Length; j++)
                {
                    toPrint[j] = ndry[j];
                }
                PrintNodes(toPrint);
                int k = i + 1;
                Node tmp = toPrint[k];
                toPrint[k] = toPrint[k + 1];
                toPrint[k + 1] = tmp;
                PrintNodes(toPrint);
            }

            Console.WriteLine(ds.Count);
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
            Console.Write("}" );
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
                Console.WriteLine(d.value);
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

        // 4.8
        public static Node FindCommon(Node d1, Node d2)
        {
            if (d1.ValEqual(d2)) return d1;

            Node nd1 = d1.parent;
            Node nd2 = d2.parent;
            while (nd1 != null)
            {
                Console.WriteLine(nd1.value);
                while(nd2 != null)
                {
                    if (nd2.ValEqual(nd1))
                    {
                        return nd2;
                    }
                    nd2 = nd2.parent;
                }
                nd2 = d2.parent;
                nd1 = nd1.parent;
            }

            return null;
        }

        public static Node[] BuildBSTAndGetNodes()
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
            int[] src = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 , 11, 12, 13, 14, 15, 16, 17, 18, 19};//, 20 };
            Node[] nodes = new Node[3];

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
                    root.parent = nd;
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
                    nd.parent = cur;
                    cur = cur.right;
                }

                if (i == 3)
                {
                    nodes[1] = nd;
                }

                if (i == 13)
                {
                    nodes[2] = nd;
                }
            }
            nodes[0] = root;
            return nodes;
        }

        // 4.7 
        public static List<string> FindOrder(List<Node> prjs)
        {
            // find starts
            List<Node> starts = new List<Node>();
            foreach (Node nd in prjs)
            {
                if (nd.parent == null)
                {
                    starts.Add(nd);
                }
            }

            List<string> order = new List<string>();

            foreach (Node nd in starts)
            {
                DFSOrder(nd, order);
            }

            return order;
        }

        public static void DFSOrder(Node root, List<string> order)
        {
            if (root == null) return;

            Console.WriteLine(root.name);
            if (!root.visited)
            {
                order.Add(root.name);
                root.visited = true;
            }

            if (root.kids != null)
            {
                foreach (Node nd in root.kids)
                {
                    DFSOrder(nd, order);
                }
            }
        }

        // 4.6
        public static Node FindNext(Node root, Node pre, Node result)
        {
            if (result != null) return result;

            if (root != null)
            {
                result = FindNext(root.left, pre, result);
                //Console.WriteLine(root.value);
                if (root.parent!= null && root.parent.ValEqual(pre))
                {
                    return root;
                }
                result = FindNext(root.right, pre, result);
            }
            return result;
        }

        // 4.5
        public static bool CheckBST(Node root)
        {
            int pre = -99999;
            bool isBST = true;
            return IsBST(root, pre, isBST);
        }

        public static bool IsBST(Node root, int pre, bool isBST)
        {
            if (root != null)
            {
                isBST = IsBST(root.left, pre, isBST);

                if (!isBST) return false;

                Console.WriteLine(root.value);
                if (root.value >= pre)
                {
                    pre = root.value;
                }
                else 
                {
                    return false;
                }

                isBST = IsBST(root.right, pre, isBST);
            }
            return isBST;
        }

        // 4.4
        public static bool IsBalance(Node root)
        {
            Queue<Node> nds = new Queue<Node>();
            root.marked = true;
            nds.Enqueue(root);
            int capacity = 1;
            int capacityBak = capacity;
            int lvlcnt = 0;
            int emptyCnt = 0;
            int unbalanceCnt = 0;

            while (nds.Count > 0)
            {
                Node nd = nds.Dequeue();
                Console.WriteLine("Vist:" + nd.value);

                if (nd.name == "empty")
                {
                    emptyCnt += 1;
                }

                if (emptyCnt == capacityBak)
                {
                    break;
                }

                if (capacity == 0)
                {
                    if (emptyCnt > 0) 
                    {
                        unbalanceCnt += 1;
                        if (unbalanceCnt > 1)
                        {
                            return false;
                        }
                    }
                    lvlcnt += 1;
                    emptyCnt = 0;
                    capacity = (int)(Math.Pow(2, lvlcnt));
                    capacityBak = capacity;
                }

                if (nd.left != null)
                {
                    nd.left.marked = true;
                    nds.Enqueue(nd.left);
                }
                else
                {
                    Node empty = new Node("empty");
                    empty.left = new Node("empty");
                    empty.right = new Node("empty"); ;
                    nds.Enqueue(empty);
                }

                if (nd.right != null && nd.name != "empty")
                {
                    nd.right.marked = true;
                    nds.Enqueue(nd.right);
                }
                else
                {
                    Node empty = new Node("empty");
                    empty.left = new Node("empty");
                    empty.right = new Node("empty"); ;
                    nds.Enqueue(empty);
                }

                capacity -= 1;
            }
            return true;
        }

        // 4.3 
        public static List<LinkedList<Node>> LevelNodes(Node root)
        {
            List<LinkedList<Node>> levels = new List<LinkedList<Node>>();

            Queue<Node> nds = new Queue<Node>();
            root.marked = true;
            nds.Enqueue(root);
            int capacity = 1;
            int capacityBak = capacity;
            int lvlcnt = 0;
            int emptyCnt = 0;
            LinkedList<Node> list = new LinkedList<Node>();

            while (nds.Count > 0)
            {
                Node nd = nds.Dequeue();
                Console.WriteLine("Vist:" + nd.value);

                if (nd.name == "empty")
                {
                    emptyCnt += 1;
                }

                if (emptyCnt == capacityBak)
                {
                    break;
                }

                if (capacity == 0)
                {
                    levels.Add(list);
                    list = new LinkedList<Node>();
                    lvlcnt += 1;
                    emptyCnt = 0;
                    capacity = (int)(Math.Pow(2, lvlcnt));
                    capacityBak = capacity;
                }

                if (nd.name != "empty")
                {
                    list.AddLast(nd);
                }

                if (nd.left != null)
                {
                    nd.left.marked = true;
                    nds.Enqueue(nd.left);
                }
                else
                {
                    Node empty = new Node("empty");
                    empty.left = new Node("empty");
                    empty.right = new Node("empty"); ;
                    nds.Enqueue(empty);
                }

                if (nd.right != null && nd.name != "empty")
                {
                    nd.right.marked = true;
                    nds.Enqueue(nd.right);
                }
                else
                {
                    Node empty = new Node("empty");
                    empty.left = new Node("empty");
                    empty.right = new Node("empty"); ;
                    nds.Enqueue(empty);
                }

                capacity -= 1;

                if (nds.Count == 0)
                {
                    levels.Add(list);
                }
            }
            return levels;
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
            int[] src = { 1, 2, 3, 4, 5};//, 6, 7, 8, 9, 10};//, 11, 12, 13, 14, 15, 16, 17, 18, 19 };//, 20 };

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

            //InOrderTraverse(root);
            //PreOrderTraverse(root);
            //Console.WriteLine(idxs.Count);

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

        public static void InsertToBST(Node root, Node node)
        {
            if (node.value <= root.value)
            {
                if (root.left == null)
                {
                    root.left = node;
                }
                else
                {
                    InsertToBST(root.left, node);
                }
            }
            else
            {
                if (root.right == null)
                {
                    root.right = node;
                }
                else
                {
                    InsertToBST(root.right, node);
                }
            }
        }

        public static int RootIndex(int[] numbs)
        {
            int rootIdx = 0;
            int fullLength = 0;
            int preLength = 0;
            int n = 0;

            while (fullLength <= numbs.Length)
            {
                preLength = fullLength;
                n += 1;
                fullLength = n * (n + 1) / 2;          
            }

            if (numbs.Length > preLength)
            {
                rootIdx = preLength + 1;
            }
            else // (numbs.Length <= preLength)
            {
                rootIdx =  1 + (n - 1) * (n - 2) / 2;
            }

            Console.WriteLine(rootIdx);

            return rootIdx;
        }

        public static void TestGraph()
        {
            /*
             *  0 -> 1 <- 2
             *  | \  | \  ^
             *  V  V V  V |
             *  5   4 <- 3
             */
            Node nd00 = new Node(0);
            Node nd01 = new Node(1);
            Node nd02 = new Node(2);
            Node nd03 = new Node(3);
            Node nd04 = new Node(4);
            Node nd05 = new Node(5);

            nd00.children = new Node[] { nd01, nd04, nd05 };
            nd01.children = new Node[] { nd03, nd04 };
            nd02.children = new Node[] { nd01 };
            nd03.children = new Node[] { nd02, nd04 };
            nd04.children = new Node[] { };
            nd05.children = new Node[] { };

            //BFSearch(nd00);
            Console.WriteLine(HasRoute(nd03, nd00));
        }

        public static bool HasRoute(Node a, Node b)
        {
            MyQueue<Node> que = new MyQueue<Node>();
            a.marked = true;
            que.Enqueue(a);

            while (! que.IsEmpty())
            {
                Node r = que.Dequeue();
                Console.WriteLine(r.value);
                if (r.value == b.value)
                {
                    return true;
                }
                foreach (Node nd in r.children)
                {
                    if (! nd.marked)
                    {
                        nd.marked = true;
                        que.Enqueue(nd);
                    }
                }
            }
            return false;
        }

        public static void TestTree()
        {
            /*        10     
                  5        20
                9   18   3     7
             */
            Node root = new Node(10);
            root.left = new Node(5);
            root.right = new Node(20);
            root.left.left = new Node(9);
            root.left.right = new Node(18);
            root.right.left = new Node(3);
            root.right.right = new Node(7);
            Console.WriteLine(CheckBST(root));
            //PostOrderTraverse(root);
        }

        // BreadthFirstSearch
        public static void BFSearch(Node root)
        {
            MyQueue<Node> queue = new MyQueue<Node>();
            root.marked = true;
            queue.Enqueue(root);

            while(! queue.IsEmpty())
            {
                Node nd = queue.Dequeue();
                Console.WriteLine("visit: " + nd.value);
                foreach(Node n in nd.children)
                {
                    if (! n.marked)
                    {
                        n.marked = true;
                        queue.Enqueue(n);
                    }
                }
            }
        }

        // DepthFirstSearch
        public static void DFSearch(Node root)
        {
            if (root == null) return;
            
            Console.WriteLine(root.value);
            root.visited = true;
            foreach (Node nd in root.children)
            {
                if (nd.visited == false)
                {
                    DFSearch(nd);
                }
            }
        }

        public static void InOrderTraverse(Node nd)
        {
            if (nd != null)
            {
                InOrderTraverse(nd.left);
                Console.WriteLine(nd.value);
                InOrderTraverse(nd.right);
            }
        }

        public static void PreOrderTraverse(Node nd)
        {
            if (nd != null)
            {
                Console.WriteLine(nd.value);
                PreOrderTraverse(nd.left);
                PreOrderTraverse(nd.right);
            }
        }

        public static void PostOrderTraverse(Node nd)
        {
            if (nd != null)
            {
                PostOrderTraverse(nd.left);
                PostOrderTraverse(nd.right);
                Console.WriteLine(nd.value);
            }
        }
    }

    public class Graph
    {
        public Node[] nodes { get; set; }
    }

    public class Node
    {
        public string name { get; set; }
        public int value { get; set; }
        public bool visited { get; set; }
        public Node left { get; set; }
        public Node right { get; set; }
        public Node parent { get; set; }
        public Node[] children { get; set; }
        public List<Node> kids { get; set; }
        public bool marked { get; set; }

        public Node(string s)
        {
            name = s;
            visited = false;
            marked = false;
            kids = new List<Node>();
        }

        public Node(int val)
        {
            value = val;
            visited = false;
            marked = false;
            kids = new List<Node>();
        }

        public Node(string s, int val)
        {
            name = s;
            value = val;
            visited = false;
            marked = false;
            kids = new List<Node>();
        }

        public Node(Node[] c)
        {
            children = c;
            visited = false;
            marked = false;
            kids = new List<Node>();
        }

        public bool ValEqual(Node cur)
        {
            return this.value == cur.value;
        }

        public bool NameEqual(Node cur)
        {
            return this.name == cur.name;
        }
    }
}
