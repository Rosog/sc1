using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriorityQueue
{
    public class UnsortedArrayPriorityQueue<T> : IPriorityQueue<T>
    {

        private PriorityItem<T>[] items;
        private int maxSize;
        private int last;

        public UnsortedArrayPriorityQueue(int size)
        {
            items = new PriorityItem<T>[size];
            last = -1;
            maxSize = size;
        }

        public void Enqueue(T item, int priority)
        {
            if (last == maxSize - 1)
            {
                throw new QueueOverflowException();
            }
            last++;
            items[last] = new PriorityItem<T>(item, priority);
        }

        public T Peek()
        {           
            if (IsEmpty())
            {
                throw new QueueUnderflowException("Empty...");
            }
            int highIndex = GetHighIndex();
            return items[highIndex].Item;
        }

        public void Dequeue()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }
            int highIndex = GetHighIndex();     
            for (int i = highIndex; i < last; i++)
            {
                items[i] = items[i + 1];
            }
            items[last] = null;
            last--;
        }

        private int GetHighIndex()
        {
            int highIndex = 0;
            for(int i = 1; i <= last; i++)
            {
                if (items[i].Priority > items[highIndex].Priority)
                {
                    highIndex = i;
                }
            }
            return highIndex;
        }

        public bool IsEmpty()
        {
            return last == -1;
        }

        public override string ToString()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }
            string output = "[";
            for (int i = 0; i <= last; i++)
            {
                output += items[i];
                if (i < last)
                {
                    output += ", ";
                }
            }
            output += "]";
            return output;
        }

    }
}
