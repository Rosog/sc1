using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using PriorityQueue;

namespace NUnityPriorityQueueTesting
{
    public class UnsortedLinkedPriorityQueueTests
    {
        [Test]
        public void TestNewQueueEmpty()
        {
            UnsortedLinkedPriorityQueue<string> queue = new UnsortedLinkedPriorityQueue<string>();
            Assert.That(queue.IsEmpty(), Is.True);
        }

        [Test]
        public void TestEmptyQueueThrowPeek()
        {
            UnsortedLinkedPriorityQueue<string> queue = new UnsortedLinkedPriorityQueue<string>();
            Assert.Throws<QueueUnderflowException>(() => queue.Peek());
        }

        [Test]
        public void TestEmptyQueueThrowDequeue()
        {
            UnsortedLinkedPriorityQueue<string> queue = new UnsortedLinkedPriorityQueue<string>();
            Assert.Throws<QueueUnderflowException>(() => queue.Dequeue());
        }

        [Test]
        public void TestReturnHighestPriorityItem()
        {
            UnsortedLinkedPriorityQueue<string> queue = new UnsortedLinkedPriorityQueue<string>();
            queue.Enqueue("Blue", 2);
            queue.Enqueue("Red", 5);
            queue.Enqueue("Green", 1);
            Assert.That(queue.Peek(), Is.EqualTo("Red"));
        }

        [Test]
        public void TestDequeueRemoveHighest()
        {
            UnsortedLinkedPriorityQueue<string> queue = new UnsortedLinkedPriorityQueue<string>();
            queue.Enqueue("Blue", 2);
            queue.Enqueue("Red", 5);
            queue.Enqueue("Green", 1);
            queue.Dequeue();
            Assert.That(queue.Peek(), Is.EqualTo("Blue"));
        }

        [Test]
        public void TestOneItemDequeue()
        {
            UnsortedLinkedPriorityQueue<string> queue = new UnsortedLinkedPriorityQueue<string>();
            queue.Enqueue("Blue", 2);
            queue.Dequeue();
            Assert.That(queue.IsEmpty(), Is.True);
        }
    }
}
