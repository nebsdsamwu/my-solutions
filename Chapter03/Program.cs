using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter03
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();

            Console.ReadKey();
        }

        static void Test()
        {
            int[] nums = { 1, 2, 3, 4, 5 };
            MyStack<int> nStk = new MyStack<int>();
            MyQueue<int> nQue = new MyQueue<int>();

            foreach (int n in nums)
            {
                nStk.Push(n);
                nQue.Add(n);
            }

            while (!nStk.IsEmpty())
            {
                Console.WriteLine(nStk.Pop());
            }
            Console.WriteLine();
            while (!nQue.IsEmpty())
            {
                Console.WriteLine(nQue.Remove());
            }
        }
    }

    public class StackNode<T>
    {
        public T data { get; set; }
        public StackNode<T> next { get; set; }

        public StackNode(T data)
        {
            this.data = data;
        }
    }

    public class StackNodeArray<T>
    {
        StackNode<T>[] Nodes = new StackNode<T>[18];
    }

    public class OneStack<T>
    {
        private static int stkSize;
        public int length { get; set; }
        public int startIdx { get; set; }
        public int topIdx { get; set; }

        public OneStack(int index, int size)
        {
            stkSize = size;
            startIdx = index;
            topIdx = index;
            length = 0;
        }

        public void Push(int sn, T data)
        {
            if (length == stkSize) throw new Exception("Stack full");
            StackNode<T> nd = new StackNode<T>(data);
        }

        public bool IsFull()
        {
            return length == stkSize;
        }
    }

    public class OneTriStack<T>
    {
        private static int tSize = 18;
        public static StackNode<T>[] stackArray = new StackNode<T>[tSize];
    }

    public class MySimpleStack<T>
    {
        private class StackNode<T1>
        {
            public T1 data { get; set; }
            public StackNode<T1> next { get; set; }

            public StackNode(T1 data)
            {
                this.data = data;
            }
        }

        private StackNode<T> top;

        public T Pop()
        {
            if (top == null) throw new Exception("Stack empty");
            T item = top.data;
            top = top.next;
            return item;
        }

        public void Push(T item)
        {
            StackNode<T> t = new StackNode<T>(item);
            t.next = top;
            top = t;
        }

        public T Peak()
        {
            if (top == null) throw new Exception("stack empty");
            return top.data; 
        }

        public bool IsEmpty()
        {
            return top == null;
        }
    }
}
