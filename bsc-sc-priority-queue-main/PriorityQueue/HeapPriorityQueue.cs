using System;

namespace PriorityQueue
{
    public class HeapPriorityQueue<T> : IPriorityQueue<T>
    {
        private PriorityItem<T>[] items;
        private int maxSize;
        private int count;

        public HeapPriorityQueue(int size)
        {
            items = new PriorityItem<T>[size];
            maxSize = size;
            count = 0;
        }

        public void Enqueue(T item, int priority)
        {
            if (count == maxSize)
            {
                throw new QueueOverflowException();
            }
            items[count] = new PriorityItem<T>(item, priority);
            int current = count;
            count++;
            while (current > 0)
            {
                int parent = (current - 1) / 2;
                if (items[current].Priority > items[parent].Priority)
                {
                    Swap(current, parent);
                    current = parent;
                }
                else
                {
                    break;
                }
            }
        }

        public T Peek()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }
            return items[0].Item;
        }

        public void Dequeue()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException();
            }
            items[0] = items[count - 1];
            items[count - 1] = null;
            count--;
            int current = 0;
            while (true)
            {
                int left = (current * 2) + 1;
                int right = (current * 2) + 2;
                int biggest = current;
                if (left < count && items[left].Priority > items[biggest].Priority)
                {
                    biggest = left;
                }
                if (right < count && items[right].Priority > items[biggest].Priority)
                {
                    biggest = right;
                }
                if (biggest == current)
                {
                    break;
                }
                Swap(current, biggest);
                current = biggest;
            }
        }

        private void Swap(int first, int second)
        {
            PriorityItem<T> temp = items[first];
            items[first] = items[second];
            items[second] = temp;
        }

        public bool IsEmpty()
        {
            return count == 0;
        }

        public override string ToString()
        {
            if (IsEmpty())
            {
                throw new QueueUnderflowException("Empty...");
            }
            string output = "[";
            for (int i = 0; i < count; i++)
            {
                output += items[i];

                if (i < count - 1)
                {
                    output += ", ";
                }
            }
            output += "]";
            return output;
        }

    }
}
