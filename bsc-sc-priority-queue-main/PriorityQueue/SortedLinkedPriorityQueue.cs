using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    public class SortedLinkedPriorityQueue<T> : IPriorityQueue<T>
    {

        private Node head;

        private class Node
        {
            public PriorityItem<T> data;
            public Node next;
            public Node(T item, int priority)
            {
                data = new PriorityItem<T>(item, priority);
                next = null;
            }
        }

        public SortedLinkedPriorityQueue()
        {
            head = null;
        }

        public void Enqueue(T item, int priority)
        {
            Node newNode = new Node(item, priority);
            if (head == null || priority > head.data.Priority)
            {
                newNode.next = head;
                head = newNode;
            }
            else
            {
                Node current = head;
                while (current.next != null && current.next.data.Priority >= priority)
                {
                    current = current.next;
                }
                newNode.next = current.next;
                current.next = newNode;
            }
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }
            return head.data.Item;
        }

        public void Dequeue()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }
            head = head.next;
        }

        public bool IsEmpty()
        {
            return head == null;
        }

        public override string ToString()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException("Empty...");
            }
            string output = "[";
            Node current = head;
            while (current != null)
            {
                output += current.data;

                if (current.next != null)
                {
                    output += ", ";
                }

                current = current.next;
            }
            output += "]";
            return output;
        }
    }

}

