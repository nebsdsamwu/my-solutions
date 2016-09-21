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

            Node root = BuildMinHeightBST();
            List<LinkedList<Node>> levels = LevelNodes(root);

            Console.ReadKey();
        }

        public static List<LinkedList<Node>> LevelNodes(Node root)
        {
            List<LinkedList<Node>> levels = new List<LinkedList<Node>>();

            Queue<Node> nds = new Queue<Node>();
            root.marked = true;
            //LinkedList<Node> rootLvl = new LinkedList<Node>();
            //rootLvl.AddLast(root);
            //levels.Add(rootLvl);
            nds.Enqueue(root);
            int capacity = 1;
            int lvlcnt = 0;
            LinkedList<Node> list = new LinkedList<Node>(); ;

            while(nds.Count > 0)
            {
                Node nd = nds.Dequeue();
                Console.WriteLine("Vist:" + nd.value);
                //if (capacity != 0)
                //{
                //    list.AddLast(nd);
                //    capacity -= 1;
                //}
                if (capacity == 0)
                {
                    levels.Add(list);
                    list = new LinkedList<Node>();  
                    lvlcnt += 1;
                    capacity = 2 ^ lvlcnt;
                }

                list.AddLast(nd);
                capacity -= 1;

                if (nd.left != null)
                {
                    nd.left.marked = true;
                    nds.Enqueue(nd.left);
                }

                if (nd.right != null)
                {
                    nd.right.marked = true;
                    nds.Enqueue(nd.right);
                }
            }

            return levels;
        }

        public static Node BuildMinHeightBST()
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
                     1    3    6   10   15   21
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
            int[] src = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19 };
           
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

            PostOrderTraverse(root);
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
        public Node[] children { get; set; }
        public bool marked { get; set; }

        public Node(string s)
        {
            name = s;
            visited = false;
            marked = false;
        }

        public Node(int val)
        {
            value = val;
            visited = false;
            marked = false;
        }

        public Node(string s, int val)
        {
            name = s;
            value = val;
            visited = false;
            marked = false;
        }

        public Node(Node[] c)
        {
            children = c;
            visited = false;
            marked = false;
        }
    }
}
