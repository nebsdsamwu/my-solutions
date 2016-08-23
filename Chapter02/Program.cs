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
            SingleLinkedList sList = new SingleLinkedList();

            foreach (int n in t)
            {
                sList.AppendToTail(n);
            }

            Node nd = sList.head;
            while(nd != null)
            {
                Console.WriteLine(nd.data);
                nd = nd.next;
            }

            // 2.1
            //RemoveDups(sList);
            //nd = sList.head;
            
            // 2.2
            SingleLinkedList result = GetKthToLast(sList, 13);
            nd = result.head;

            Console.WriteLine();

            while (nd != null)
            {
                Console.WriteLine(nd.data);
                nd = nd.next;
            }

            Console.ReadKey();
        }

        // 2.2
        static SingleLinkedList GetKthToLast(SingleLinkedList sList, int k)
        {
            SingleLinkedList result = new SingleLinkedList();
            if (k < 1)
            {
                return result;
            }
            else if (k == 1)
            {
                return sList;
            }

            Node nd = sList.head;

            while (nd != null && k > 0)
            {
                if (k > 1)
                {
                    k -= 1;
                    nd = nd.next;
                }
                else
                {
                    result = new SingleLinkedList(nd);
                    break;
                }           
            }
            return result;
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
                        // else skip this node
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

        public SingleLinkedList()
        {
            head = null;
        }

        public SingleLinkedList(Node h)
        {
            head = h;
        }

        public void AppendToTail(int n)
        {
            Node end = new Node(n);
            if (this.head == null)
            {
                this.head = end;
            }
            else
            {
                Node nd = this.head;
                while (nd.next != null)
                {
                    nd = nd.next;
                }
                nd.next = end;
            }
        }

        public void AppendToTail(Node end)
        {
            if (this.head == null)
            {
                this.head = end;
            }
            else
            {
                Node nd = this.head;
                while (nd.next != null)
                {
                    nd = nd.next;
                }
                nd.next = end;
            }
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
