using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    public class UnsortedLinkedPriorityQueue<T> : IPriorityQueue<T>
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

        public UnsortedLinkedPriorityQueue()
        {
            head = null;
        }

        public void Enqueue(T item, int priority)
        {
            Node newNode = new Node(item, priority);
            newNode.next = head;
            head = newNode;
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }
            Node current = head;
            Node highest = head;
            while (current != null)
            {
                if (current.data.Priority > highest.data.Priority)
                {
                    highest = current;
                }
                current = current.next;
            }
            return highest.data.Item;
        }

        public void Dequeue()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }
            Node current = head;
            Node previous = null;
            Node highest = head;
            Node highestPrevious = null;
            while (current != null)
            {
                if (current.data.Priority > highest.data.Priority)
                {
                    highest = current;
                    highestPrevious = previous;
                }
                previous = current;
                current = current.next;
            }
            if (highestPrevious == null)
            {
                head = head.next;
            }
            else
            {
                highestPrevious.next = highest.next;
            }
        }

        public bool IsEmpty()
        {
            return head == null;
        }

        public override string ToString()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException("Empty..");
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
