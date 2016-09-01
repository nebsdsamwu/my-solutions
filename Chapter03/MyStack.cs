using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter03
{
    public class MyStack<T>
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
