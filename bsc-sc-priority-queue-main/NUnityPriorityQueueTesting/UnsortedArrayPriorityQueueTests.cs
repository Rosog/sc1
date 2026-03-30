using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PriorityQueue;


namespace NUnityPriorityQueueTesting
{
    public class UnsortedArrayPriorityQueueTests
    {
        [Test]
        public void TestNewQueueEmpty()
        {
            UnsortedArrayPriorityQueue<string> queue = new UnsortedArrayPriorityQueue<string>(5);
            Assert.That(queue.IsEmpty(), Is.True);
        }

        [Test]
        public void TestEmptyQueueThrowPeek()
        {
            UnsortedArrayPriorityQueue<string> queue = new UnsortedArrayPriorityQueue<string>(5);
            Assert.Throws<QueueUnderflowException>(() => queue.Peek());
        }

        [Test]
        public void TestEmptyQueueThrowDequeue()
        {
            UnsortedArrayPriorityQueue<string> queue = new UnsortedArrayPriorityQueue<string>(5);
            Assert.Throws<QueueUnderflowException>(() => queue.Dequeue());
        }

        [Test]
        public void TestDequeueRemoveHighest()
        {
            UnsortedArrayPriorityQueue<string> queue = new UnsortedArrayPriorityQueue<string>(5);
            queue.Enqueue("Blue", 2);
            queue.Enqueue("Red", 5);
            queue.Enqueue("Green", 1);
            queue.Dequeue();
            Assert.That(queue.Peek(), Is.EqualTo("Blue"));
        }

        [Test]
        public void TestOneItemDequeue()
        {
            UnsortedArrayPriorityQueue<string> queue = new UnsortedArrayPriorityQueue<string>(5);
            queue.Enqueue("Blue", 2);
            queue.Dequeue();
            Assert.That(queue.IsEmpty(), Is.True);
        }

        [Test]
        public void TestReturnHighestPriorityItem()
        {
            UnsortedArrayPriorityQueue<string> queue = new UnsortedArrayPriorityQueue<string>(5);
            queue.Enqueue("Blue", 2);
            queue.Enqueue("Red", 5);
            queue.Enqueue("Green", 1);
            Assert.That(queue.Peek(), Is.EqualTo("Red"));
        }

        [Test]
        public void TestFullQueue()
        {
            UnsortedArrayPriorityQueue<string> queue = new UnsortedArrayPriorityQueue<string>(2);
            queue.Enqueue("Blue", 2);
            queue.Enqueue("Red", 5);
            Assert.Throws<QueueOverflowException>(() => queue.Enqueue("Green", 1));
        }
    }
}
