using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PriorityQueue;

namespace NUnityPriorityQueueTesting
{
    public class HeapPriorityQueueTests
    {
        [Test]
        public void TestNewQueueEmpty()
        {
            HeapPriorityQueue<string> queue = new HeapPriorityQueue<string>(5);
            Assert.That(queue.IsEmpty(), Is.True);
        }

        [Test]
        public void TestEmptyQueueThrowPeek()
        {
            HeapPriorityQueue<string> queue = new HeapPriorityQueue<string>(5);
            Assert.Throws<QueueUnderflowException>(() => queue.Peek());
        }

        [Test]
        public void TestEmptyQueueThrowDequeue()
        {
            HeapPriorityQueue<string> queue = new HeapPriorityQueue<string>(5);
            Assert.Throws<QueueUnderflowException>(() => queue.Dequeue());
        }

        [Test]
        public void TestReturnHighestPriorityItem()
        {
            HeapPriorityQueue<string> queue = new HeapPriorityQueue<string>(5);
            queue.Enqueue("Blue", 2);
            queue.Enqueue("Red", 5);
            queue.Enqueue("Green", 1);
            Assert.That(queue.Peek(), Is.EqualTo("Red"));
        }

        [Test]
        public void TestFullQueue()
        {
            HeapPriorityQueue<string> queue = new HeapPriorityQueue<string>(2);
            queue.Enqueue("Blue", 2);
            queue.Enqueue("Red", 5);
            Assert.Throws<QueueOverflowException>(() => queue.Enqueue("Green", 1));
        }

        [Test]
        public void TestDequeueRemoveHighest()
        {
            HeapPriorityQueue<string> queue = new HeapPriorityQueue<string>(5);
            queue.Enqueue("Blue", 2);
            queue.Enqueue("Red", 5);
            queue.Enqueue("Green", 1);
            queue.Dequeue();
            Assert.That(queue.Peek(), Is.EqualTo("Blue"));
        }

        [Test]
        public void TestOneItemDequeue()
        {
            HeapPriorityQueue<string> queue = new HeapPriorityQueue<string>(5);
            queue.Enqueue("Blue", 2);
            queue.Dequeue();
            Assert.That(queue.IsEmpty(), Is.True);
        }

        [Test]
        public void TestMultipleDequeue()
        {
            HeapPriorityQueue<string> queue = new HeapPriorityQueue<string>(10);
            queue.Enqueue("Blue", 2);
            queue.Enqueue("Red", 5);
            queue.Enqueue("Green", 1);
            queue.Enqueue("Yellow", 8);
            Assert.That(queue.Peek(), Is.EqualTo("Yellow"));
            queue.Dequeue();
            Assert.That(queue.Peek(), Is.EqualTo("Red"));
            queue.Dequeue();
            Assert.That(queue.Peek(), Is.EqualTo("Blue"));
            queue.Dequeue();
            Assert.That(queue.Peek(), Is.EqualTo("Green"));
        }
    }
}
