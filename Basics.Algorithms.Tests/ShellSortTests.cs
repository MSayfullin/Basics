using Basics.Algorithms.Sorts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Basics.Algorithms.Tests
{
    [TestClass]
    public class ShellSortTests
    {
        [TestMethod]
        public void ShellSort_Int_TestOnEmptyArray()
        {
            var array = new int[] { };
            Shell.Sort(array);
            Assert.IsTrue(array.IsSorted());
        }

        [TestMethod]
        public void ShellSort_Int_TestOnArrayWithOneElement()
        {
            var array = new int[] { 1 };
            Shell.Sort(array);
            Assert.IsTrue(array.IsSorted());
        }

        [TestMethod]
        public void ShellSort_Int_TestOnSortedArray()
        {
            var array = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            Shell.Sort(array);
            Assert.IsTrue(array.IsSorted());
        }

        [TestMethod]
        public void ShellSort_Int_TestOnReverseSortedArray()
        {
            var array = new int[] { 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            Shell.Sort(array);
            Assert.IsTrue(array.IsSorted());
        }

        [TestMethod]
        public void ShellSort_Int_TestOnUnsortedArray()
        {
            var array = new int[] { 12, 0, 3, 9, 1, 10, 4, 15, 5, 2, 13, 7, 8, 6, 11, 14 };
            Shell.Sort(array);
            Assert.IsTrue(array.IsSorted());
        }

        [TestMethod]
        public void ShellSort_Int_TestOnUnsortedArrayWithDuplicates()
        {
            var array = new int[] { 12, 0, 3, 9, 1, 3, 4, 15, 5, 2, 13, 7, 8, 12, 11, 14, 15, 15 };
            Shell.Sort(array);
            Assert.IsTrue(array.IsSorted());
        }

        [TestMethod]
        public void ShellSort_String_TestOnSortedArray()
        {
            var array = new string[] { "a", "b", "c", "d", "e", "f", "g" };
            Shell.Sort(array);
            Assert.IsTrue(array.IsSorted());
        }

        [TestMethod]
        public void ShellSort_String_TestOnUnsortedArray()
        {
            var array = new string[] { "f", "b", "g", "d", "e", "a", "c" };
            Shell.Sort(array);
            Assert.IsTrue(array.IsSorted());
        }

        [TestMethod]
        public void ShellSort_String_TestOnUnsortedArrayWithDuplicates()
        {
            var array = new string[] { "f", "b", "g", "a", "d", "e", "a", "c", "b" };
            Shell.Sort(array);
            Assert.IsTrue(array.IsSorted());
        }
    }
}
