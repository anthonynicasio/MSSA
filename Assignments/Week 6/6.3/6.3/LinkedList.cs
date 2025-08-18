using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._3
{
    // Queue implemented with a singly linked list
    public class LinkedQueue<T> : IEnumerable<T>
    {
        private Node<T>? head; // front
        private Node<T>? tail; // back
        public int Count { get; private set; }

        public bool IsEmpty => Count == 0;

        public void Enqueue(T item)
        {
            var node = new Node<T>(item);
            if (IsEmpty)
            {
                head = tail = node;
            }
            else
            {
                tail!.Next = node;
                tail = node;
            }
            Count++;
        }

        public T Dequeue()
        {
            if (IsEmpty) throw new InvalidOperationException("Queue is empty.");
            var value = head!.Value;
            head = head.Next;
            if (head == null) tail = null;
            Count--;
            return value;
        }

        public T Peek()
        {
            if (IsEmpty) throw new InvalidOperationException("Queue is empty.");
            return head!.Value;
        }

        public void Clear()
        {
            head = tail = null;
            Count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
