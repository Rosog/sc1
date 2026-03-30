using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PriorityQueue;

namespace NUnityPriorityQueueTesting
{
    public class SortedLinkedPriorityQueueTests
    {
        [Test]
        public void TestNewQueueEmpty()
        {
            SortedLinkedPriorityQueue<string> queue = new SortedLinkedPriorityQueue<string>();
            Assert.That(queue.IsEmpty(), Is.True);
        }

        [Test]
        public void TestEmptyQueueThrowPeek()
        {
            SortedLinkedPriorityQueue<string> queue = new SortedLinkedPriorityQueue<string>();
            Assert.Throws<QueueUnderflowException>(() => queue.Peek());
        }

        [Test]
        public void TestEmptyQueueThrowDequeue()
        {
            SortedLinkedPriorityQueue<string> queue = new SortedLinkedPriorityQueue<string>();
            Assert.Throws<QueueUnderflowException>(() => queue.Dequeue());
        }

        [Test]
        public void TestReturnHighestPriorityItem()
        {
            SortedLinkedPriorityQueue<string> queue = new SortedLinkedPriorityQueue<string>();

            queue.Enqueue("Blue", 2);
            queue.Enqueue("Red", 5);
            queue.Enqueue("Green", 1);

            Assert.That(queue.Peek(), Is.EqualTo("Red"));
        }

        [Test]
        public void TestDequeueHighest()
        {
            SortedLinkedPriorityQueue<string> queue = new SortedLinkedPriorityQueue<string>();

            queue.Enqueue("Blue", 2);
            queue.Enqueue("Red", 5);
            queue.Enqueue("Green", 1);

            queue.Dequeue();

            Assert.That(queue.Peek(), Is.EqualTo("Blue"));
        }

        [Test]
        public void TestOneDequeue()
        {
            SortedLinkedPriorityQueue<string> queue = new SortedLinkedPriorityQueue<string>();

            queue.Enqueue("Blue", 2);
            queue.Dequeue();

            Assert.That(queue.IsEmpty(), Is.True);
        }

        [Test]
        public void TestMultipleDequeues()
        {
            SortedLinkedPriorityQueue<string> queue = new SortedLinkedPriorityQueue<string>();
            queue.Enqueue("Blue", 2);
            queue.Enqueue("Red", 5);
            queue.Enqueue("Green", 1);
            Assert.That(queue.Peek(), Is.EqualTo("Red"));
            queue.Dequeue();
            Assert.That(queue.Peek(), Is.EqualTo("Blue"));
            queue.Dequeue();
            Assert.That(queue.Peek(), Is.EqualTo("Green"));
        }
    }
}
