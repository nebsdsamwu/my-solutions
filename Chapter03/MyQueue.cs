using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chapter03
{
    public class MyQueue<T>
    {
        public class QueueNode<T>
        {
            public T data { get; set; }
            public QueueNode<T> next { get; set; }

            public QueueNode(T item)
            {
                this.data = item;
            }
        }

        private QueueNode<T> first;
        private QueueNode<T> last;

        public void Add(T item)
        {
            QueueNode<T> t = new QueueNode<T>(item);
            if (last != null)
            {
                last.next = t;
            }
            last = t;
            if (first == null)
            {
                first = last;
            }
        }

        public T Remove()
        {
            if (first == null) throw new Exception("Queue empty");
            T data = first.data;
            first = first.next;
            if (first == null)
            {
                last = null;
            }
            return data;
        }

        public T Peak()
        {
            if (first == null) throw new Exception("Queue Empty");
            return first.data;
        }

        public bool IsEmpty()
        {
            return first == null;
        }
    }
}
