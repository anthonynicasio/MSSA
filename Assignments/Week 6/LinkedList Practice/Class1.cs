using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedList_Practice
{
    class Node
    {
        public int data;
        public Node next;

        public Node(int value)
        {
            data = value;
            next = null
        }
    }

    class LList
    {
        private Node head;
        private Node tail;
        private int size;

        public int Size
        {
            get { return size; }
        }

        public LList()
        {
            head = null;
            tail = null;
            size = 0;
        }


    }
}
