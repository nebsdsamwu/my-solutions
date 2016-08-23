using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter02
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] t = { 9, 4, 2, 5, 5, 5, 5, 7, 12, 4, 4, 4, 4, 43, 9, 2, 7 };
            Node head = new Node(0);
            SingleLinkedList sList = new SingleLinkedList(head);

            foreach (int n in t)
            {
                sList.AppendToTail(n);
            }

            Node nd = sList.head.next;
            while(nd.next != null)
            {
                Console.WriteLine(nd.data);
                nd = nd.next;
            }

            RemoveDups(sList);

            Console.WriteLine();
            nd = sList.head.next;
            while (nd != null)
            {
                Console.WriteLine(nd.data);
                nd = nd.next;
            }

            Console.ReadKey();
        }

        // 2.1
        static void RemoveDups(SingleLinkedList list)
        {
            Node nd = list.head;
            Node pre = null;
            HashSet<int> dSet = new HashSet<int>();
            while (nd != null)
            {
                if (dSet.Contains(nd.data)) 
                {
                    if (nd.next != null)
                    {
                        if (!dSet.Contains(nd.next.data)) // then connect nd's pre to nd's next.
                        {
                            pre.next = nd.next;
                            pre = nd;
                        }
                        //else
                        //{
                        //    // skip this node
                        //}
                    }
                    else if (nd.next == null)// nd is the end node, remove it.
                    {
                        pre.next = nd.next;
                    }
                }
                else 
                {
                    dSet.Add(nd.data);
                    pre = nd;
                }
                nd = nd.next;
            }
        }
    }

    public class SingleLinkedList
    {
        public Node head;

        public SingleLinkedList(Node h)
        {
            head = h;
        }

        public void AppendToTail(int n)
        {
            Node end = new Node(n);
            Node nd = this.head;
            while (nd.next != null)
            {
                nd = nd.next;
            }
            nd.next = end;
        }
    }

    public class Node
    {
        public Node next = null;
        public int data;

        public Node(int d)
        {
            data = d;
        }
    }
}
