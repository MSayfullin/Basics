using Basics.Algorithms.Sorts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Basics.Algorithms.Tests
{
    [TestClass]
    public class HeapsortTests
    {
        [TestMethod]
        public void Heapsort_Int_TestOnEmptyArray()
        {
            var array = new int[] { };
            Heap.Sort(array);
            Assert.IsTrue(array.IsSorted());
        }

        [TestMethod]
        public void Heapsort_Int_TestOnArrayWithOneElement()
        {
            var array = new int[] { 1 };
            Heap.Sort(array);
            Assert.IsTrue(array.IsSorted());
        }

        [TestMethod]
        public void Heapsort_Int_TestOnSortedArray()
        {
            var array = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Heap.Sort(array);
            Assert.IsTrue(array.IsSorted());
        }

        [TestMethod]
        public void Heapsort_Int_TestOnReverseSortedArray()
        {
            var array = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            Heap.Sort(array);
            Assert.IsTrue(array.IsSorted());
        }

        [TestMethod]
        public void Heapsort_Int_TestOnUnsortedArray()
        {
            var array = new int[] { 0, 3, 9, 1, 4, 5, 2, 7, 8, 6 };
            Heap.Sort(array);
            Assert.IsTrue(array.IsSorted());
        }

        [TestMethod]
        public void Heapsort_Int_TestOnUnsortedArrayWithDuplicates()
        {
            var array = new int[] { 0, 3, 9, 7, 1, 4, 5, 2, 7, 8, 6, 3, 1 };
            Heap.Sort(array);
            Assert.IsTrue(array.IsSorted());
        }

        [TestMethod]
        public void Heapsort_String_TestOnSortedArray()
        {
            var array = new string[] { "a", "b", "c", "d", "e", "f", "g" };
            Heap.Sort(array);
            Assert.IsTrue(array.IsSorted());
        }

        [TestMethod]
        public void Heapsort_String_TestOnUnsortedArray()
        {
            var array = new string[] { "f", "b", "g", "d", "e", "a", "c" };
            Heap.Sort(array);
            Assert.IsTrue(array.IsSorted());
        }

        [TestMethod]
        public void Heapsort_String_TestOnUnsortedArrayWithDuplicates()
        {
            var array = new string[] { "f", "b", "g", "a", "d", "e", "a", "c", "b" };
            Heap.Sort(array);
            Assert.IsTrue(array.IsSorted());
        }
    }
}
