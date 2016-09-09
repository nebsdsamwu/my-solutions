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
            Node root = new Node(10);
            root.left = new Node(5);
            root.right = new Node(20);
            root.left.left = new Node(9);
            root.left.right = new Node(18);
            root.right.left = new Node(3);
            root.right.right = new Node(7);
            Console.ReadKey();
        }
    }

    public class Node
    {
        public string name { get; set; }
        public int value { get; set; }
        public Node left { get; set; }
        public Node right { get; set; }
        public Node[] children { get; set; }

        public Node(string s)
        {
            name = s;
        }

        public Node(int val)
        {
            value = val;
        }

        public Node(string s, int val)
        {
            name = s;
            value = val;
        }

        public Node(Node[] c)
        {
            children = c;
        }
    }
}
