using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6._2._1
{
    public class CustomStack
    {
        private int[] stackArray;
        private int top;

        public CustomStack(int size)
        {
            stackArray = new int[size];
            top = -1;
        }

        // Push operation
        public void Push(int value)
        {
            if (top == stackArray.Length - 1)
            {
                Console.WriteLine("Stack overflow!");
                return;
            }
            stackArray[++top] = value;
        }

        // Pop operation
        public int Pop()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack underflow!");
                return -1;
            }
            return stackArray[top--];
        }

        // Peek operation
        public int Peek()
        {
            if (IsEmpty())
            {
                Console.WriteLine("Stack is empty!");
                return -1;
            }
            return stackArray[top];
        }

        public bool IsEmpty()
        {
            return top == -1;
        }
    }
}
