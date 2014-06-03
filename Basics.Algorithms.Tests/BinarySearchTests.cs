using System;
using Basics.Algorithms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Basics.Algorithms.Tests
{
    [TestClass]
    public class BinarySearchTests
    {
        [TestMethod]
        public void BinarySearch_NoKeyFound()
        {
            var array = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var index  = array.IndexOf(10);
            Assert.AreEqual(-1, index);
        }

        [TestMethod]
        public void BinarySearch_KeyExists()
        {
            var array = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var index = array.IndexOf(3);
            Assert.AreEqual(3, index);
        }

        [TestMethod]
        public void BinarySearch_FirstKey()
        {
            var array = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var index = array.IndexOf(0);
            Assert.AreEqual(0, index);
        }

        [TestMethod]
        public void BinarySearch_LastKey()
        {
            var array = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var index = array.IndexOf(9);
            Assert.AreEqual(9, index);
        }

        [TestMethod]
        public void BinarySearch_MiddleKey()
        {
            var array = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            var index = array.IndexOf(5);
            Assert.AreEqual(5, index);
        }
    }
}
