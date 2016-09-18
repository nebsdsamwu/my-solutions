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

            BuildBST();
            Console.ReadKey();
        }

        public static void BuildBST()
        {
/*
 *                 11
 *                /  \ 
                 7   12
               /  \    \
               4   8    13
             /  \   \    \
            2    5   9    14
          /  \    \   \        
         1    3    6   10   
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
            int[] src = {1,2,3,4,5,6,7,8,9,10};

            Node[] nds = new Node[10];
            for (int i = 0; i < src.Length; i++ )
            {
                nds[i] = new Node(src[i]);
            }

            foreach (Node nd in nds)
            {
                Console.WriteLine(nd.value);
            }

            Node root = new Node(src[0]);
            RootIndex(src);
        }

        public static int RootIndex(int[] numbs)
        {
            int idx = 0;
            int sum = 0;
            int n = 0;
            while (sum <= numbs.Length)
            {
                n += 1;
                sum = n * (n + 1) / 2;     
            }
            Console.WriteLine(sum);

            return idx;
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
