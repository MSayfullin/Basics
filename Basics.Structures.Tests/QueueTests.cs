using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Basics.Structures.Tests
{
    [TestClass]
    public class QueueTests
    {
        #region Queue on Array

        [TestMethod]
        public void QueueOnArray_Empty_IEnumeratorTest()
        {
            var queue = new QueueOnArray<int>();
            CheckEmptyEnumerator(queue);
        }

        [TestMethod]
        public void QueueOnArray_Full_IEnumeratorTest()
        {
            var queue = new QueueOnArray<int>();
            CheckFullEnumerator(queue);
        }

        [TestMethod]
        public void QueueOnArray_Full_AfterDequeue_IEnumeratorTest()
        {
            var queue = new QueueOnArray<int>();
            CheckFullEnumeratorAfterDequeue(queue);
        }

        [TestMethod]
        public void QueueOnArray_Double_IEnumeratorTest()
        {
            var queue = new QueueOnArray<int>();
            CheckDoubleEnumerator(queue);
        }

        [TestMethod]
        public void QueueOnArray_EnqueueTest()
        {
            var queue = new QueueOnArray<string>();
            CheckEnqueue(queue);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void QueueOnArray_DequeueFromEmptyQueueTest()
        {
            var queue = new QueueOnArray<string>();
            queue.Dequeue();
        }

        [TestMethod]
        public void QueueOnArray_DequeueTest()
        {
            var queue = new QueueOnArray<string>();
            CheckDequeue(queue);
        }

        [TestMethod]
        public void QueueOnArray_MultipleDequeueTest()
        {
            var queue = new QueueOnArray<string>();
            CheckMultipleDequeue(queue);
        }

        #endregion

        #region Checks

        private void CheckEmptyEnumerator<T>(IQueue<T> queue)
        {
            foreach (var item in queue)
            {
                Assert.Fail("Check enumerator implementation. Queue is empty.");
            }
        }

        private void CheckFullEnumerator(IQueue<int> queue)
        {
            for (int i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
            }
            int counter = 0;
            foreach (var item in queue)
            {
                Assert.AreEqual(counter++, item);
            }
        }

        private void CheckFullEnumeratorAfterDequeue(IQueue<int> queue)
        {
            for (int i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
            }
            queue.Dequeue();
            queue.Dequeue();
            int counter = 2;
            foreach (var item in queue)
            {
                Assert.AreEqual(counter++, item);
            }
        }

        private void CheckDoubleEnumerator(IQueue<int> queue)
        {
            int counter1 = 0;
            for (int i = 0; i < 10; i++)
            {
                queue.Enqueue(i);
            }
            int counter2 = 0;
            foreach (var item1 in queue)
            {
                Assert.AreEqual(counter1++, item1);
                foreach (var item2 in queue)
                {
                    Assert.AreEqual(counter2++, item2);
                }
                counter2 = 0;
            }
        }

        private void CheckEnqueue(IQueue<string> queue)
        {
            Assert.IsTrue(queue.IsEmpty);
            Assert.AreEqual(0, queue.Size);

            queue.Enqueue("test");

            Assert.IsFalse(queue.IsEmpty);
            Assert.AreEqual(1, queue.Size);
        }

        private void CheckDequeue(IQueue<string> queue)
        {
            var testData = "test";
            queue.Enqueue(testData);

            var dequeuedData = queue.Dequeue();

            Assert.IsTrue(queue.IsEmpty);
            Assert.AreEqual(0, queue.Size);
            Assert.AreEqual(testData, dequeuedData);
        }

        private void CheckMultipleDequeue(IQueue<string> queue)
        {
            var testData = "test";
            queue.Enqueue(testData);
            queue.Enqueue("otherData");
            queue.Enqueue("anotherData");
            queue.Enqueue("moreData");
            queue.Enqueue("evenMoreData");

            var dequeuedData = queue.Dequeue();
            Assert.IsFalse(queue.IsEmpty);
            Assert.AreEqual(4, queue.Size);
            Assert.AreEqual(testData, dequeuedData);

            dequeuedData = queue.Dequeue();
            Assert.IsFalse(queue.IsEmpty);
            Assert.AreEqual(3, queue.Size);
            Assert.AreNotEqual(testData, dequeuedData);

            dequeuedData = queue.Dequeue();
            Assert.IsFalse(queue.IsEmpty);
            Assert.AreEqual(2, queue.Size);
            Assert.AreNotEqual(testData, dequeuedData);

            dequeuedData = queue.Dequeue();
            Assert.IsFalse(queue.IsEmpty);
            Assert.AreEqual(1, queue.Size);
            Assert.AreNotEqual(testData, dequeuedData);

            dequeuedData = queue.Dequeue();
            Assert.IsTrue(queue.IsEmpty);
            Assert.AreEqual(0, queue.Size);
            Assert.AreNotEqual(testData, dequeuedData);
        }

        #endregion
    }
}
