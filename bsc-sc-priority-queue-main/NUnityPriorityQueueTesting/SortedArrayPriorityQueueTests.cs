using PriorityQueue;

namespace NUnityPriorityQueueTesting
{
    public class SortedArrayPriorityQueueTests
    {
        [Test]
        public void TestNewQueueEmpty()
        {
            SortedArrayPriorityQueue<string> queue = new SortedArrayPriorityQueue<string>(5);
            Assert.That(queue.IsEmpty(), Is.True);
        }

        [Test]
        public void TestEmptyQueueThrowPeek()
        {
            SortedArrayPriorityQueue<string> queue = new SortedArrayPriorityQueue<string>(5);
            Assert.Throws<QueueUnderflowException>(() => queue.Peek());
        }

        [Test]
        public void TestEmptyQueueThrowDequeue()
        {
            SortedArrayPriorityQueue<string> queue = new SortedArrayPriorityQueue<string>(5);
            Assert.Throws<QueueUnderflowException>(() => queue.Dequeue());
        }

        [Test]
        public void TestReturnHighestPriorityItem()
        {
            SortedArrayPriorityQueue<string> queue = new SortedArrayPriorityQueue<string>(5);
            queue.Enqueue("Blue", 2);
            queue.Enqueue("Red", 5);
            queue.Enqueue("Green", 1);
            Assert.That(queue.Peek(), Is.EqualTo("Red"));
        }

        [Test]
        public void TestFullQueue()
        {
            SortedArrayPriorityQueue<string> queue = new SortedArrayPriorityQueue<string>(2);
            queue.Enqueue("Blue", 2);
            queue.Enqueue("Red", 5);
            Assert.Throws<QueueOverflowException>(() => queue.Enqueue("Green", 1));
        }

        [Test]
        public void TestDequeueRemoveHighest()
        {
            SortedArrayPriorityQueue<string> queue = new SortedArrayPriorityQueue<string>(5);
            queue.Enqueue("Blue", 2);
            queue.Enqueue("Red", 5);
            queue.Enqueue("Green", 1);
            queue.Dequeue();
            Assert.That(queue.Peek(), Is.EqualTo("Blue"));
        }

        [Test]
        public void TestOneItemDequeue()
        {
            SortedArrayPriorityQueue<string> queue = new SortedArrayPriorityQueue<string>(5);
            queue.Enqueue("Blue", 2);
            queue.Dequeue();
            Assert.That(queue.IsEmpty(), Is.True);
        }

    }
}
