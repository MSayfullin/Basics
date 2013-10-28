using Basics.Algorithms.Sorts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Basics.Algorithms.Tests
{
    [TestClass]
    public class InertionSortTests
    {
        [TestMethod]
        public void InsertionSort_Int_TestOnEmptyArray()
        {
            var array = new int[] { };
            Insertion.Sort(array);
            Assert.IsTrue(array.IsSorted());
        }

        [TestMethod]
        public void InsertionSort_Int_TestOnArrayWithOneElement()
        {
            var array = new int[] { 1 };
            Insertion.Sort(array);
            Assert.IsTrue(array.IsSorted());
        }

        [TestMethod]
        public void InsertionSort_Int_TestOnSortedArray()
        {
            var array = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Insertion.Sort(array);
            Assert.IsTrue(array.IsSorted());
        }

        [TestMethod]
        public void InsertionSort_Int_TestOnUnsortedArray()
        {
            var array = new int[] { 0, 3, 9, 1, 4, 5, 2, 7, 8, 6 };
            Insertion.Sort(array);
            Assert.IsTrue(array.IsSorted());
        }

        [TestMethod]
        public void InsertionSortRange_Int_TestOnUnsortedArray()
        {
            var array = new int[] { 0, 3, 9, 1, 4, 5, 2, 7, 8, 6 };
            Insertion.Sort(array, 5, 9);
            Assert.IsTrue(array.IsSorted(5, 9));
        }

        [TestMethod]
        public void InsertionSort_Int_TestOnUnsortedArrayWithDuplicates()
        {
            var array = new int[] { 0, 3, 9, 7, 1, 4, 5, 2, 7, 8, 6, 3, 1 };
            Insertion.Sort(array);
            Assert.IsTrue(array.IsSorted());
        }

        [TestMethod]
        public void InsertionSort_String_TestOnSortedArray()
        {
            var array = new string[] { "a", "b", "c", "d", "e", "f", "g" };
            Insertion.Sort(array);
            Assert.IsTrue(array.IsSorted());
        }

        [TestMethod]
        public void InsertionSort_String_TestOnUnsortedArray()
        {
            var array = new string[] { "f", "b", "g", "d", "e", "a", "c" };
            Insertion.Sort(array);
            Assert.IsTrue(array.IsSorted());
        }

        [TestMethod]
        public void InsertionSort_String_TestOnUnsortedArrayWithDuplicates()
        {
            var array = new string[] { "f", "b", "g", "a", "d", "e", "a", "c", "b" };
            Insertion.Sort(array);
            Assert.IsTrue(array.IsSorted());
        }
    }
}
