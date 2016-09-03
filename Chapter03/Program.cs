﻿using System;
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
            StackPlate<int> plate = new StackPlate<int>();
            plate.Push(13);
            plate.Push(12);
            plate.Push(11);
            plate.Push(10);
            plate.Push(9);
            plate.Push(8);
            plate.Push(7);
            plate.Push(6);
            plate.Push(5);
            plate.Push(4);
            plate.Push(3);
            plate.Push(2);
            plate.Push(1);
            plate.Push(0);

            Console.WriteLine(plate.PopAtIndex(1));
            Console.WriteLine(plate.PopAtIndex(0));
            //while (!plate.IsEmpty())
            //{
            //    Console.WriteLine(plate.Pop());
            //}
            //Test();
            //TestTriStack();
            Console.ReadKey();
        }
        static void TestTriStack()
        {
            //StackNodeArray<int> ary = new StackNodeArray<int>();
            //ary.Push(0, 1);
            //ary.Push(0, 2);
            //ary.Push(1, 3);
            //ary.Push(2, 4);
            //ary.Push(2, 5);
            //ary.Push(1, 9);
            //Console.WriteLine(ary.Pop(0));
            //Console.WriteLine(ary.Pop(2));
            //Console.WriteLine(ary.Pop(1));
            //ary.Pop(1);
            //ary.Pop(1);
            //ary.Pop(1);
            //ary.Pop(1);
            //ary.Push(1, 1);
            //ary.Push(1, 2);
            //ary.Push(1, 3);
            //ary.Push(1, 4);
            //ary.Push(1, 5);
            //ary.Push(1, 9);
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

    public class StackPlate<T>
    {
        private int threshold = 5;
        public int Threshold
        {
            get
            {
                 return threshold;
            }
            set
            {
                threshold = value;
            }
        }

        private int sn = 0;
        public int SN
        {
            get
            {
                return sn;
            }
            set
            {
                sn = value;
            }
        }

        private Dictionary<int, MyStack<T>> plate;
        private int curSize;
        MyStack<T> s1 = new MyStack<T>();

        public StackPlate()
        {
            plate = new Dictionary<int, MyStack<T>>();
            SN = 1;
            plate.Add(SN, new MyStack<T>());
            curSize = 0;
        }

        public void Push(T item)
        {
            if (curSize == Threshold)
            {
                MyStack<T> nStk = new MyStack<T>();
                SN += 1;
                nStk.Push(item);
                plate.Add(SN, nStk);
                curSize = 1;
            }
            else
            {
                MyStack<T> stk = null; 
                plate.TryGetValue(SN, out stk);
                stk.Push(item);
                plate[SN] = stk;
                curSize += 1;
            }
        }

        public T Pop()
        {
            MyStack<T> stk = null;
            plate.TryGetValue(SN, out stk);
            T item = stk.Pop();
            curSize -= 1;
            if (curSize == 0)
            {
                plate.Remove(SN);
                SN -= 1;
                curSize = Threshold;
            }
            return item;
        }

        public T PopAtIndex(int idx)
        {
            if(idx == SN)
            {
                return this.Pop();
            }

            StackPlate<T> tplate = new StackPlate<T>();

            while (SN > idx)
            {
                MyStack<T> stk = null;
                plate.TryGetValue(SN, out stk);
                while(! stk.IsEmpty())
                {
                    tplate.Push(stk.Pop());
                }
                plate.Remove(SN);
                SN -= 1;
            }

            T item = this.Pop();

            while(! tplate.IsEmpty())
            {
                this.Push(tplate.Pop());
            }

            return item;
        }

        public T Peak()
        {
            MyStack<T> stk = null;
            plate.TryGetValue(SN, out stk);
            T item = stk.Peak();
            return item;
        }

        public bool IsEmpty()
        {
            return SN == 0;
        }
    }


    public class StackNodeArray<T>
    {
        private static int totalsize = 18;
        private static int oneSize = totalsize / 3;
        public int TotalSize 
        {
            get
            {
                return TotalSize;
            }

            set
            {
                totalsize = value;
            }
        }

        public StackNode<T>[] nodes;
        int[] tops;
        int[] lengths;

        public StackNodeArray()
        {
            nodes = new StackNode<T>[totalsize];
            tops = new int[] { 0, oneSize, oneSize * 2 };
            lengths = new int[] { 0, 0, 0 };
        }

        public void Push(int stkNo, T data)
        {
            if (lengths[stkNo] == oneSize) throw new Exception("Stack " + stkNo + " is full.");
            if (lengths[stkNo] > 0)
            {
                tops[stkNo] += 1;
            }
            nodes[tops[stkNo]] = new StackNode<T>(data);
            lengths[stkNo] += 1;
        }

        public T Pop(int stkNo)
        {
            if (lengths[stkNo] == 0) throw new Exception("Stack " + stkNo + " is empty.");
            T data = nodes[tops[stkNo]].data;
            nodes[tops[stkNo]] = null;
            tops[stkNo] -= 1;
            lengths[stkNo] -= 1;
            return data;
        }

        public T Peak(int stkNo)
        {
            if (lengths[stkNo] == 0) throw new Exception("Stack " + stkNo + " is empty.");
            T data = nodes[tops[stkNo]].data;
            return data;
        }
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
