using System;
using Basics.Structures.Queues;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Basics.Structures.Tests
{
    [TestClass]
    public class PriorityQueueTests
    {
        #region Max Priority Queue

        [TestMethod]
        public void MaxPriorityQueue_SingleEnqueueDequeueTest()
        {
            string test = "test";
            var queue = new MaxPriorityQueue<string>();
            queue.Enqueue(test);

            Assert.IsFalse(queue.IsEmpty);
            Assert.AreEqual(1, queue.Size);

            var dequeued = queue.DequeueMax();

            Assert.IsTrue(queue.IsEmpty);
            Assert.AreEqual(0, queue.Size);
            Assert.AreEqual(test, dequeued);
        }

        [TestMethod]
        public void MaxPriorityQueue_MultipleEnqueueDequeueTest()
        {
            var testData = new int[] { 12, 0, 3, 9, 1, 3, 4, 4, 5, 2, 13, 7, 8, 3, 11, 14, 15 };
            var queue = new MaxPriorityQueue<int>();
            foreach (var item in testData)
            {
                queue.Enqueue(item);
            }

            Assert.IsFalse(queue.IsEmpty);
            Assert.AreEqual(testData.Length, queue.Size);

            var dequeued = queue.DequeueMax();

            Assert.IsFalse(queue.IsEmpty);
            Assert.AreEqual(testData.Length - 1, queue.Size);
            Assert.AreEqual(15, dequeued);

            dequeued = queue.DequeueMax();

            Assert.IsFalse(queue.IsEmpty);
            Assert.AreEqual(testData.Length - 2, queue.Size);
            Assert.AreEqual(14, dequeued);

            dequeued = queue.Max;

            Assert.IsFalse(queue.IsEmpty);
            Assert.AreEqual(testData.Length - 2, queue.Size);
            Assert.AreEqual(13, dequeued);

            dequeued = queue.DequeueMax();

            Assert.IsFalse(queue.IsEmpty);
            Assert.AreEqual(testData.Length - 3, queue.Size);
            Assert.AreEqual(13, dequeued);

            dequeued = queue.DequeueMax();

            Assert.IsFalse(queue.IsEmpty);
            Assert.AreEqual(testData.Length - 4, queue.Size);
            Assert.AreEqual(12, dequeued);

            dequeued = queue.DequeueMax();

            Assert.IsFalse(queue.IsEmpty);
            Assert.AreEqual(testData.Length - 5, queue.Size);
            Assert.AreEqual(11, dequeued);

            dequeued = queue.DequeueMax();

            Assert.IsFalse(queue.IsEmpty);
            Assert.AreEqual(testData.Length - 6, queue.Size);
            Assert.AreEqual(9, dequeued);

            dequeued = queue.DequeueMax();

            Assert.IsFalse(queue.IsEmpty);
            Assert.AreEqual(testData.Length - 7, queue.Size);
            Assert.AreEqual(8, dequeued);

            dequeued = queue.DequeueMax();

            Assert.IsFalse(queue.IsEmpty);
            Assert.AreEqual(testData.Length - 8, queue.Size);
            Assert.AreEqual(7, dequeued);

            dequeued = queue.DequeueMax();

            Assert.IsFalse(queue.IsEmpty);
            Assert.AreEqual(testData.Length - 9, queue.Size);
            Assert.AreEqual(5, dequeued);

            dequeued = queue.DequeueMax();

            Assert.IsFalse(queue.IsEmpty);
            Assert.AreEqual(testData.Length - 10, queue.Size);
            Assert.AreEqual(4, dequeued);

            dequeued = queue.DequeueMax();

            Assert.IsFalse(queue.IsEmpty);
            Assert.AreEqual(testData.Length - 11, queue.Size);
            Assert.AreEqual(4, dequeued);

            dequeued = queue.DequeueMax();

            Assert.IsFalse(queue.IsEmpty);
            Assert.AreEqual(testData.Length - 12, queue.Size);
            Assert.AreEqual(3, dequeued);

            dequeued = queue.DequeueMax();

            Assert.IsFalse(queue.IsEmpty);
            Assert.AreEqual(testData.Length - 13, queue.Size);
            Assert.AreEqual(3, dequeued);

            dequeued = queue.DequeueMax();

            Assert.IsFalse(queue.IsEmpty);
            Assert.AreEqual(testData.Length - 14, queue.Size);
            Assert.AreEqual(3, dequeued);

            dequeued = queue.DequeueMax();

            Assert.IsFalse(queue.IsEmpty);
            Assert.AreEqual(testData.Length - 15, queue.Size);
            Assert.AreEqual(2, dequeued);

            dequeued = queue.DequeueMax();

            Assert.IsFalse(queue.IsEmpty);
            Assert.AreEqual(testData.Length - 16, queue.Size);
            Assert.AreEqual(1, dequeued);

            dequeued = queue.DequeueMax();

            Assert.IsTrue(queue.IsEmpty);
            Assert.AreEqual(0, queue.Size);
            Assert.AreEqual(0, dequeued);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void MaxPriorityQueue_GetMaxFromEmptyQueueTest()
        {
            var queue = new MaxPriorityQueue<string>();
            var max = queue.Max;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void MaxPriorityQueue_DequeueMaxFromEmptyQueueTest()
        {
            var queue = new MaxPriorityQueue<string>();
            queue.DequeueMax();
        }

        [TestMethod]
        public void MaxPriorityQueue_Empty_EnumeratorTest()
        {
            var queue = new MaxPriorityQueue<string>();

            Assert.IsTrue(queue.IsEmpty);
            Assert.AreEqual(0, queue.Size);
            foreach (var item in queue)
            {
                Assert.Fail("Check enumerator implementation. Queue is empty.");
            }
        }

        [TestMethod]
        public void MaxPriorityQueue_Full_EnumeratorTest()
        {
            var testData = new int[] { 12, 0, 3, 9, 1, 10, 4, 15, 5, 2, 13, 7, 8, 6, 11, 14 };
            var queue = new MaxPriorityQueue<int>();
            foreach (var item in testData)
            {
                queue.Enqueue(item);
            }

            Assert.IsFalse(queue.IsEmpty);
            Assert.AreEqual(testData.Length, queue.Size);

            int value = 15;
            foreach (var item in queue)
            {
                Assert.AreEqual(value--, item);
            }
            Assert.AreEqual(-1, value);
        }

        #endregion

        #region Min Priority Queue

        [TestMethod]
        public void MinPriorityQueue_SingleEnqueueDequeueTest()
        {
            string test = "test";
            var queue = new MinPriorityQueue<string>();
            queue.Enqueue(test);

            Assert.IsFalse(queue.IsEmpty);
            Assert.AreEqual(1, queue.Size);

            var dequeued = queue.DequeueMin();

            Assert.IsTrue(queue.IsEmpty);
            Assert.AreEqual(0, queue.Size);
            Assert.AreEqual(test, dequeued);
        }

        [TestMethod]
        public void MinPriorityQueue_MultipleEnqueueDequeueTest()
        {
            var testData = new int[] { 12, 0, 3, 9, 1, 3, 4, 4, 5, 2, 13, 7, 8, 3, 11, 14, 15 };
            var queue = new MinPriorityQueue<int>();
            foreach (var item in testData)
            {
                queue.Enqueue(item);
            }

            Assert.IsFalse(queue.IsEmpty);
            Assert.AreEqual(testData.Length, queue.Size);

            var dequeued = queue.DequeueMin();

            Assert.IsFalse(queue.IsEmpty);
            Assert.AreEqual(testData.Length - 1, queue.Size);
            Assert.AreEqual(0, dequeued);

            dequeued = queue.DequeueMin();

            Assert.IsFalse(queue.IsEmpty);
            Assert.AreEqual(testData.Length - 2, queue.Size);
            Assert.AreEqual(1, dequeued);

            dequeued = queue.Min;

            Assert.IsFalse(queue.IsEmpty);
            Assert.AreEqual(testData.Length - 2, queue.Size);
            Assert.AreEqual(2, dequeued);

            dequeued = queue.DequeueMin();

            Assert.IsFalse(queue.IsEmpty);
            Assert.AreEqual(testData.Length - 3, queue.Size);
            Assert.AreEqual(2, dequeued);

            dequeued = queue.DequeueMin();

            Assert.IsFalse(queue.IsEmpty);
            Assert.AreEqual(testData.Length - 4, queue.Size);
            Assert.AreEqual(3, dequeued);

            dequeued = queue.DequeueMin();

            Assert.IsFalse(queue.IsEmpty);
            Assert.AreEqual(testData.Length - 5, queue.Size);
            Assert.AreEqual(3, dequeued);

            dequeued = queue.DequeueMin();

            Assert.IsFalse(queue.IsEmpty);
            Assert.AreEqual(testData.Length - 6, queue.Size);
            Assert.AreEqual(3, dequeued);

            dequeued = queue.DequeueMin();

            Assert.IsFalse(queue.IsEmpty);
            Assert.AreEqual(testData.Length - 7, queue.Size);
            Assert.AreEqual(4, dequeued);

            dequeued = queue.DequeueMin();

            Assert.IsFalse(queue.IsEmpty);
            Assert.AreEqual(testData.Length - 8, queue.Size);
            Assert.AreEqual(4, dequeued);

            dequeued = queue.DequeueMin();

            Assert.IsFalse(queue.IsEmpty);
            Assert.AreEqual(testData.Length - 9, queue.Size);
            Assert.AreEqual(5, dequeued);

            dequeued = queue.DequeueMin();

            Assert.IsFalse(queue.IsEmpty);
            Assert.AreEqual(testData.Length - 10, queue.Size);
            Assert.AreEqual(7, dequeued);

            dequeued = queue.DequeueMin();

            Assert.IsFalse(queue.IsEmpty);
            Assert.AreEqual(testData.Length - 11, queue.Size);
            Assert.AreEqual(8, dequeued);

            dequeued = queue.DequeueMin();

            Assert.IsFalse(queue.IsEmpty);
            Assert.AreEqual(testData.Length - 12, queue.Size);
            Assert.AreEqual(9, dequeued);

            dequeued = queue.DequeueMin();

            Assert.IsFalse(queue.IsEmpty);
            Assert.AreEqual(testData.Length - 13, queue.Size);
            Assert.AreEqual(11, dequeued);

            dequeued = queue.DequeueMin();

            Assert.IsFalse(queue.IsEmpty);
            Assert.AreEqual(testData.Length - 14, queue.Size);
            Assert.AreEqual(12, dequeued);

            dequeued = queue.DequeueMin();

            Assert.IsFalse(queue.IsEmpty);
            Assert.AreEqual(testData.Length - 15, queue.Size);
            Assert.AreEqual(13, dequeued);

            dequeued = queue.DequeueMin();

            Assert.IsFalse(queue.IsEmpty);
            Assert.AreEqual(testData.Length - 16, queue.Size);
            Assert.AreEqual(14, dequeued);

            dequeued = queue.DequeueMin();

            Assert.IsTrue(queue.IsEmpty);
            Assert.AreEqual(0, queue.Size);
            Assert.AreEqual(15, dequeued);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void MinPriorityQueue_GetMinFromEmptyQueueTest()
        {
            var queue = new MinPriorityQueue<string>();
            var max = queue.Min;
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void MinPriorityQueue_DequeueMinFromEmptyQueueTest()
        {
            var queue = new MinPriorityQueue<string>();
            queue.DequeueMin();
        }

        [TestMethod]
        public void MinPriorityQueue_Empty_EnumeratorTest()
        {
            var queue = new MinPriorityQueue<string>();

            Assert.IsTrue(queue.IsEmpty);
            Assert.AreEqual(0, queue.Size);
            foreach (var item in queue)
            {
                Assert.Fail("Check enumerator implementation. Queue is empty.");
            }
        }

        [TestMethod]
        public void MinPriorityQueue_Full_EnumeratorTest()
        {
            var testData = new int[] { 12, 0, 3, 9, 1, 10, 4, 15, 5, 2, 13, 7, 8, 6, 11, 14 };
            var queue = new MinPriorityQueue<int>();
            foreach (var item in testData)
            {
                queue.Enqueue(item);
            }

            Assert.IsFalse(queue.IsEmpty);
            Assert.AreEqual(testData.Length, queue.Size);

            int value = 0;
            foreach (var item in queue)
            {
                Assert.AreEqual(value++, item);
            }
            Assert.AreEqual(16, value);
        }

        #endregion
    }
}
