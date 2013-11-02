using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Basics.Structures.Tests
{
    [TestClass]
    public class ArrayExtensionsTests
    {
        [TestMethod]
        public void ArrayExtensions_ResizeToBiggerTest()
        {
            var array = new int[] { 0, 1, 2, 3 };
            var newArray = array.ResizeTo(8);

            Assert.AreEqual(8, newArray.Length);
            for (int i = 0; i < array.Length; i++)
            {
                Assert.AreEqual(array[i], newArray[i]);
            }
        }

        [TestMethod]
        public void ArrayExtensions_ResizeToSmallerTest()
        {
            var array = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 };
            var newArray = array.ResizeTo(4);

            Assert.AreEqual(4, newArray.Length);
            for (int i = 0; i < newArray.Length; i++)
            {
                Assert.AreEqual(array[i], newArray[i]);
            }
        }

        [TestMethod]
        public void ArrayExtensions_ResizeToSameSizeTest()
        {
            var array = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 };
            var newArray = array.ResizeTo(8);

            Assert.AreEqual(8, newArray.Length);
            for (int i = 0; i < newArray.Length; i++)
            {
                Assert.AreEqual(array[i], newArray[i]);
            }
        }

        [TestMethod]
        public void ArrayExtensions_ResizeToBiggerForRangeTest()
        {
            var array = new int[] { 0, 1, 2, 3 };
            var newArray = array.ResizeTo(8, start: 0, finish: 2);

            Assert.AreEqual(8, newArray.Length);
            for (int i = 0; i < 2; i++)
            {
                Assert.AreEqual(array[i], newArray[i]);
            }
        }

        [TestMethod]
        public void ArrayExtensions_ResizeToSmallerForRangeTest()
        {
            int start = 3;
            int finish = 6;
            var array = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 };
            var newArray = array.ResizeTo(4, start, finish);

            Assert.AreEqual(4, newArray.Length);
            for (int i = 0; i < finish - start; i++)
            {
                Assert.AreEqual(array[i + start], newArray[i]);
            }
            for (int i = finish - start; i < newArray.Length; i++)
            {
                Assert.AreEqual(0, newArray[i]);
            }
        }

        [TestMethod]
        public void ArrayExtensions_ResizeToSameSizeForRangeTest()
        {
            int start = 2;
            int finish = 5;
            var array = new int[] { 0, 1, 2, 3, 4, 5, 6, 7 };
            var newArray = array.ResizeTo(8, start, finish);

            Assert.AreEqual(8, newArray.Length);
            for (int i = 0; i < finish - start; i++)
            {
                Assert.AreEqual(array[i + start], newArray[i]);
            }
            for (int i = finish - start; i < array.Length; i++)
            {
                Assert.AreEqual(0, newArray[i]);
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ArrayExtensions_WrongNewSizeTest()
        {
            var array = new int[] { 0, 1, 2, 3 };
            var newArray = array.ResizeTo(-7);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ArrayExtensions_WrongNewSizeForRangeTest()
        {
            var array = new int[] { 0, 1, 2, 3 };
            var newArray = array.ResizeTo(-7, start: 0, finish: 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ArrayExtensions_WrongStartIndexTest()
        {
            var array = new int[] { 0, 1, 2, 3 };
            var newArray = array.ResizeTo(8, start: 2, finish: 0);
        }
    }
}
