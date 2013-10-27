using Basics.Algorithms.Sorts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Basics.Algorithms.Tests
{
    [TestClass]
    public class SelectionSortTests
    {
        [TestMethod]
        public void SelectionSort_Int_TestOnEmptyArray()
        {
            var array = new int[] { };
            Selection.Sort(array);
            Assert.IsTrue(array.IsSorted());
        }

        [TestMethod]
        public void SelectionSort_Int_TestOnArrayWithOneElement()
        {
            var array = new int[] { 1 };
            Selection.Sort(array);
            Assert.IsTrue(array.IsSorted());
        }

        [TestMethod]
        public void SelectionSort_Int_TestOnSortedArray()
        {
            var array = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Selection.Sort(array);
            Assert.IsTrue(array.IsSorted());
        }

        [TestMethod]
        public void SelectionSort_Int_TestOnUnsortedArray()
        {
            var array = new int[] { 0, 3, 9, 1, 4, 5, 2, 7, 8, 6 };
            Selection.Sort(array);
            Assert.IsTrue(array.IsSorted());
        }

        [TestMethod]
        public void SelectionSort_Int_TestOnUnsortedArrayWithDuplicates()
        {
            var array = new int[] { 0, 3, 9, 7, 1, 4, 5, 2, 7, 8, 6, 3, 1 };
            Selection.Sort(array);
            Assert.IsTrue(array.IsSorted());
        }

        [TestMethod]
        public void SelectionSort_String_TestOnSortedArray()
        {
            var array = new string[] { "a", "b", "c", "d", "e", "f", "g" };
            Selection.Sort(array);
            Assert.IsTrue(array.IsSorted());
        }

        [TestMethod]
        public void SelectionSort_String_TestOnUnsortedArray()
        {
            var array = new string[] { "f", "b", "g", "d", "e", "a", "c" };
            Selection.Sort(array);
            Assert.IsTrue(array.IsSorted());
        }

        [TestMethod]
        public void SelectionSort_String_TestOnUnsortedArrayWithDuplicates()
        {
            var array = new string[] { "f", "b", "g", "a", "d", "e", "a", "c", "b" };
            Selection.Sort(array);
            Assert.IsTrue(array.IsSorted());
        }
    }
}
