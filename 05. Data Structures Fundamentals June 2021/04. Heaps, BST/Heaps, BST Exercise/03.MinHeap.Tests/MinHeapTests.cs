namespace _03.MinHeap.Tests
{
    using NUnit.Framework;
    using System.Collections.Generic;

    public class MinHeapTests
    {
        [Test]
        public void TestHeapifyUpAddOne()
        {
            var integerHeap = new MinHeap<int>();
            integerHeap.Add(13);
            Assert.AreEqual(13, integerHeap.Peek());
        }

        [Test]
        public void TestHeapifyUpAddMany()
        {
            var integerHeap = new MinHeap<int>();
            var elements = new List<int>() { 15, 6, 9, 5, 25, 8, 17, 16 };
            foreach (var el in elements)
            {
                integerHeap.Add(el);
            }
            Assert.AreEqual(5, integerHeap.Peek());
        }

        [Test]
        public void TestSizeShouldBeCorrect()
        {
            var integerHeap = new MinHeap<int>();
            var elements = new List<int>() { 15, 25, 6, 9, 5, 8, 17, 16 };
            foreach (var el in elements)
            {
                integerHeap.Add(el);
            }
            Assert.AreEqual(8, integerHeap.Size);
        }

        [Test]
        public void TestDequeueSingleElement()
        {
            var priorityQueue = new MinHeap<int>();
            priorityQueue.Add(13);
            Assert.AreEqual(13, priorityQueue.Dequeue());
        }

        [Test]
        public void TestDequeueMultipleElements()
        {
            var queue = new MinHeap<int>();
            var elements = new List<int>() { 15, 25, 6, 9, 5, 8, 17, 16 };
            foreach (var element in elements)
            {
                queue.Add(element);
            }
            int[] expected = { 5, 6, 8, 9, 15, 16, 17, 25 };
            int index = 0;
            Assert.AreEqual(expected.Length, queue.Size);
            while (queue.Size != 0)
            {
                Assert.AreEqual(expected[index++], queue.Dequeue());
            }
        }
    }
}