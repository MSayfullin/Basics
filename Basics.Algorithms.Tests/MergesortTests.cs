using Basics.Algorithms.Sorts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Basics.Algorithms.Tests
{
    [TestClass]
    public class MergesortTests
    {
        [TestMethod]
        public void Mergesort_Int_TestOnEmptyArray()
        {
            var array = new int[] { };
            Merge.Sort(array);
            Assert.IsTrue(array.IsSorted());
        }

        [TestMethod]
        public void Mergesort_Int_TestOnArrayWithOneElement()
        {
            var array = new int[] { 1 };
            Merge.Sort(array);
            Assert.IsTrue(array.IsSorted());
        }

        [TestMethod]
        public void Mergesort_Int_TestOnSortedArray()
        {
            var array = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Merge.Sort(array);
            Assert.IsTrue(array.IsSorted());
        }

        [TestMethod]
        public void Mergesort_Int_TestOnReverseSortedArray()
        {
            var array = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            Merge.Sort(array);
            Assert.IsTrue(array.IsSorted());
        }

        [TestMethod]
        public void Mergesort_Int_TestOnUnsortedArray()
        {
            var array = new int[] { 0, 3, 9, 1, 4, 5, 2, 7, 8, 6 };
            Merge.Sort(array);
            Assert.IsTrue(array.IsSorted());
        }

        [TestMethod]
        public void Mergesort_Int_TestOnUnsortedArrayWithDuplicates()
        {
            var array = new int[] { 0, 3, 9, 7, 1, 4, 5, 2, 7, 8, 6, 3, 1 };
            Merge.Sort(array);
            Assert.IsTrue(array.IsSorted());
        }

        [TestMethod]
        public void Mergesort_String_TestOnSortedArray()
        {
            var array = new string[] { "a", "b", "c", "d", "e", "f", "g" };
            Merge.Sort(array);
            Assert.IsTrue(array.IsSorted());
        }

        [TestMethod]
        public void Mergesort_String_TestOnUnsortedArray()
        {
            var array = new string[] { "f", "b", "g", "d", "e", "a", "c" };
            Merge.Sort(array);
            Assert.IsTrue(array.IsSorted());
        }

        [TestMethod]
        public void Mergesort_String_TestOnUnsortedArrayWithDuplicates()
        {
            var array = new string[] { "f", "b", "g", "a", "d", "e", "a", "c", "b" };
            Merge.Sort(array);
            Assert.IsTrue(array.IsSorted());
        }
    }
}
