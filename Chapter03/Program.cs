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
            Random rdm = new Random();
            AnimalArranger arranger = new AnimalArranger();

            for (int i = 0; i < 20; i++)
            {
                Animal animal = rdm.Next(0, 2) == 0 ? new Animal("dog", i) : new Animal("cat", i);
                arranger.Enqueue(animal);
            }

            foreach(Animal a in arranger.animals)
            {
                Console.WriteLine(a.Type + ":" + a.SN.ToString());
            }

            Console.WriteLine();
            Animal ani = arranger.DequeueCat();
            Console.WriteLine(ani.Type + ":" + ani.SN);
            Console.WriteLine();

            Console.WriteLine();
            ani = arranger.DequeueDog();
            Console.WriteLine(ani.Type + ":" + ani.SN);
            Console.WriteLine();

            Console.WriteLine();
            ani = arranger.DequeueDog();
            Console.WriteLine(ani.Type + ":" + ani.SN);
            Console.WriteLine();

            Console.WriteLine();
            ani = arranger.DequeueCat();
            Console.WriteLine(ani.Type + ":" + ani.SN);
            Console.WriteLine();

            foreach (Animal a in arranger.animals)
            {
                Console.WriteLine(a.Type + ":" + a.SN.ToString());
            }
                // TestSort();
                // Test2StackQ();
                // TestStackPlate();
                // Test();
                // TestTriStack();
                Console.ReadKey();
        }

        static void TestSort()
        {
            MyStack<int> stk = new MyStack<int>();
            stk.Push(9);
            stk.Push(8);
            stk.Push(6);
            stk.Push(5);
            stk.Push(2);
            stk.Push(1);
            stk.Push(15);
            stk.Push(14);
            stk.Push(13);
            stk.Push(4);
            stk.Push(3);
            stk.Push(12);
            stk.Push(11);
            stk.Push(10);
            stk.Push(7);
            SortStack(stk);

            while (!stk.IsEmpty())
            {
                Console.WriteLine(stk.Pop());
            }
        }

        static void SortStack(MyStack<int> stk)
        {
            if (stk.IsEmpty()) throw new Exception("Stack is empty.");
            MyStack<int> tStk = new MyStack<int>();

            int m = stk.Peak();
            int t = 0;
            int cnt = 0;
            int allCnt = 0;

            while (! stk.IsEmpty())
            {
                t = stk.Pop();
                if (t < m) m = t;
                tStk.Push(t);
                cnt += 1;
            }
            allCnt = cnt;

            while (cnt > 0)
            {
                t = tStk.Pop();
                if (t != m)
                {
                    stk.Push(t);
                }
                cnt -= 1;
            }
            tStk.Push(m);
            allCnt -= 1;

            // n.
            while (allCnt > 0)
            {
                m = stk.Peak();
                while (!stk.IsEmpty())
                {
                    t = stk.Pop();
                    if (t < m) m = t; 
                    tStk.Push(t);
                }

                cnt = allCnt;
                while (cnt > 0)
                {
                    t = tStk.Pop();
                    if (t != m)
                    {
                        stk.Push(t);
                    }
                    cnt -= 1;
                }
                tStk.Push(m);
                allCnt -= 1;
            }

            while (!tStk.IsEmpty())
            {
                stk.Push(tStk.Pop());
            }
        }

        static void Test2StackQ()
        {
            TwoStacksQ<int> stkq = new TwoStacksQ<int>();
            stkq.Add(15);
            stkq.Add(14);
            stkq.Add(13);
            stkq.Add(12);
            stkq.Add(11);
            stkq.Add(10);
            Console.WriteLine(stkq.Remove());
            Console.WriteLine(stkq.Remove());
            Console.WriteLine(stkq.Remove());
            stkq.Add(9);
            stkq.Add(8);
            stkq.Add(7);
            stkq.Add(6);
            stkq.Add(5);
            stkq.Add(4);
            stkq.Add(3);
            stkq.Add(2);
            stkq.Add(1);

            while (!stkq.IsEmpty())
            {
                Console.WriteLine(stkq.Remove());
            }
        }

        static void TestStackPlate()
        {
            StackPlate<int> plate = new StackPlate<int>();
            plate.Push(15);
            plate.Push(14);
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

            Console.WriteLine(plate.PopAtIndex(2));
            Console.WriteLine(plate.PopAtIndex(1));
            Console.WriteLine(plate.PopAtIndex(3));


            //while (!plate.IsEmpty())
            //{
            //    Console.WriteLine(plate.Pop());
            //}
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

    public class AnimalArranger
    {
        public LinkedList<Animal> animals; 

        public AnimalArranger()
        {
            animals = new LinkedList<Animal>();
        }

        public void Enqueue(Animal animal)
        {
            animals.AddLast(animal);
        }

        public Animal DequeueAny()
        {
            Animal animal = animals.First();
            animals.RemoveFirst();
            return animal;
        }

        public Animal DequeueCat()
        {
            Animal animal = null;
            Animal adopted = null;
            AnimalArranger aa = new AnimalArranger();
            while (animals.Count > 0)
            {
                animal = animals.First();
                animals.RemoveFirst();
                if (adopted == null && animal.Type == "cat")
                {
                    adopted = animal;
                }
                else
                {
                    aa.Enqueue(animal);
                }
            }

            this.animals = aa.animals;
            return adopted;
        }

        public Animal DequeueDog()
        {
            Animal animal = null;
            Animal adopted = null;
            AnimalArranger aa = new AnimalArranger();
            while (animals.Count > 0)
            {
                animal = animals.First();
                animals.RemoveFirst();
                if (adopted == null && animal.Type == "dog")
                {
                    adopted = animal;
                }
                else
                {
                    aa.Enqueue(animal);
                }
            }
            this.animals = aa.animals;
            return adopted;
        }
    }

    public class Animal
    {
        public string Type { get; set; }
        public int SN { get; set; }

        public Animal(string t, int n)
        {
            Type = t;
            SN = n;
        }
    }

    public class TwoStacksQ<T>
    {
        MyStack<T> stk1;
        MyStack<T> stk2;

        public TwoStacksQ()
        {
            stk1 = new MyStack<T>();
            stk2 = new MyStack<T>();
        }

        public void Add(T item)
        {
            stk1.Push(item);
        }

        public T Remove()
        {
            while (! stk1.IsEmpty())
            {
                stk2.Push(stk1.Pop());
            }

            T item = stk2.Pop();

            while (! stk2.IsEmpty())
            {
                stk1.Push(stk2.Pop());
            }

            return item;
        }

        public bool IsEmpty()
        {
            return stk1.IsEmpty();
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
            if (this.IsEmpty()) throw new Exception("Stack plate is empty.");
            MyStack<T> stk = null;
            if (! plate.TryGetValue(SN, out stk)) throw new Exception("Non-exist Stack");
            T item = stk.Pop();
            curSize -= 1;
            if (curSize == 0)
            {
                plate.Remove(SN);
                SN -= 1;
                if (SN > 0)
                {
                    curSize = Threshold;
                }
            }
            else
            {
                plate[SN] = stk;
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
                    curSize -= 1;
                }
                plate.Remove(SN);
                SN -= 1;
                if (SN > 0)
                {
                    curSize = Threshold;
                }
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
            return SN == 0 && curSize == 0;
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
