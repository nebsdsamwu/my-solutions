using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter04
{
    class Program
    {
        static void Main(string[] args)
        {
            //TestTree();
            TestGraph();
            Console.ReadKey();
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

            DFSearch(nd00);
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

        public Node(string s)
        {
            name = s;
            visited = false;
        }

        public Node(int val)
        {
            value = val;
            visited = false;
        }

        public Node(string s, int val)
        {
            name = s;
            value = val;
            visited = false;
        }

        public Node(Node[] c)
        {
            children = c;
            visited = false;
        }
    }
}
