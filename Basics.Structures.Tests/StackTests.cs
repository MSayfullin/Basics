using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Basics.Structures.Tests
{
    [TestClass]
    public class StackTests
    {
        #region Stack on List

        [TestMethod]
        public void StackOnList_Empty_IEnumeratorTest()
        {
            var stack = new StackOnList<int>();
            CheckEmptyEnumerator(stack);
        }

        [TestMethod]
        public void StackOnList_Full_IEnumeratorTest()
        {
            var stack = new StackOnList<int>();
            CheckFullEnumerator(stack);
        }

        [TestMethod]
        public void StackOnList_Double_IEnumeratorTest()
        {
            var stack = new StackOnList<int>();
            CheckDoubleEnumerator(stack);
        }

        [TestMethod]
        public void StackOnList_PushTest()
        {
            var stack = new StackOnList<string>();
            CheckPush(stack);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void StackOnList_PopFromEmptyStackTest()
        {
            var stack = new StackOnList<string>();
            stack.Pop();
        }

        [TestMethod]
        public void StackOnList_PopTest()
        {
            var stack = new StackOnList<string>();
            CheckPop(stack);
        }

        [TestMethod]
        public void StackOnList_MultiplePopTest()
        {
            var stack = new StackOnList<string>();
            CheckMultiplePop(stack);
        }

        #endregion

        #region Checks

        private void CheckEmptyEnumerator<T>(IStack<T> stack)
        {
            foreach (var item in stack)
            {
                Assert.Fail("Check enumerator implementation. Stack is empty.");
            }
        }

        private void CheckFullEnumerator(IStack<int> stack)
        {
            int counter = 10;
            for (int i = 0; i < counter; i++)
            {
                stack.Push(i);
            }
            foreach (var item in stack)
            {
                Assert.AreEqual(--counter, item);
            }
        }

        private void CheckDoubleEnumerator(IStack<int> stack)
        {
            const int limit = 10;
            int counter1 = limit;
            for (int i = 0; i < counter1; i++)
            {
                stack.Push(i);
            }
            int counter2 = limit;
            foreach (var item1 in stack)
            {
                Assert.AreEqual(--counter1, item1);
                foreach (var item2 in stack)
                {
                    Assert.AreEqual(--counter2, item2);
                }
                counter2 = limit;
            }
        }

        private void CheckPush(IStack<string> stack)
        {
            Assert.IsTrue(stack.IsEmpty);
            Assert.AreEqual(0, stack.Size);

            stack.Push("test");

            Assert.IsFalse(stack.IsEmpty);
            Assert.AreEqual(1, stack.Size);
        }

        private void CheckPop(IStack<string> stack)
        {
            var testData = "test";
            stack.Push(testData);

            var poppedData = stack.Pop();

            Assert.IsTrue(stack.IsEmpty);
            Assert.AreEqual(0, stack.Size);
            Assert.AreEqual(testData, poppedData);
        }

        private void CheckMultiplePop(IStack<string> stack)
        {
            var testData = "test";
            stack.Push(testData);
            stack.Push("otherData");
            stack.Push("anotherData");

            var poppedData = stack.Pop();
            Assert.IsFalse(stack.IsEmpty);
            Assert.AreEqual(2, stack.Size);
            Assert.AreNotEqual(testData, poppedData);

            poppedData = stack.Pop();
            Assert.IsFalse(stack.IsEmpty);
            Assert.AreEqual(1, stack.Size);
            Assert.AreNotEqual(testData, poppedData);

            poppedData = stack.Pop();
            Assert.IsTrue(stack.IsEmpty);
            Assert.AreEqual(0, stack.Size);
            Assert.AreEqual(testData, poppedData);
        }

        #endregion
    }
}
