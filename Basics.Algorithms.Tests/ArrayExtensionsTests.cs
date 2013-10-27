using System;
using Basics.Algorithms.Sorts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Basics.Algorithms.Tests
{
    [TestClass]
    public class ArrayExtensionsTests
    {
        [TestMethod]
        public void Int_TestIsSorted()
        {
            var array = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Assert.IsTrue(array.IsSorted());
        }

        [TestMethod]
        public void Int_TestIsNotSorted()
        {
            var array = new int[] { 0, 3, 9, 1, 4, 5, 2, 7, 8, 6 };
            Assert.IsFalse(array.IsSorted());
        }

        [TestMethod]
        public void Double_TestIsSorted()
        {
            var array = new double[] { 0, 1.0, 2.1, 3.3, 4, 5, 6, 7, 8, 9 };
            Assert.IsTrue(array.IsSorted());
        }

        [TestMethod]
        public void Double_TestIsNotSorted()
        {
            var array = new double[] { 0, 3, 9.1, 1, 4.5, 5, 2.8, 7, 8, 6 };
            Assert.IsFalse(array.IsSorted());
        }

        [TestMethod]
        public void String_TestIsSorted()
        {
            var array = new string[] { "a", "b", "c", "d", "e", "f", "g" };
            Assert.IsTrue(array.IsSorted());
        }

        [TestMethod]
        public void String_TestIsNotSorted()
        {
            var array = new string[] { "f", "b", "g", "d", "e", "a", "c" };
            Assert.IsFalse(array.IsSorted());
        }

        private class GenericComparableData : IComparable<GenericComparableData>
        {
            private int _value;

            public GenericComparableData(int value)
            {
                _value = value;
            }

            public int CompareTo(GenericComparableData other)
            {
                return _value.CompareTo(other._value);
            }
        }

        [TestMethod]
        public void GenericComparable_TestIsSorted()
        {
            var array = new GenericComparableData[]
            {
                new GenericComparableData(0),
                new GenericComparableData(1),
                new GenericComparableData(2),
                new GenericComparableData(3)
            };
            Assert.IsTrue(array.IsSorted());
        }

        [TestMethod]
        public void GenericComparable_TestIsNotSorted()
        {
            var array = new GenericComparableData[]
            {
                new GenericComparableData(0),
                new GenericComparableData(3),
                new GenericComparableData(2),
                new GenericComparableData(1)
            };
            Assert.IsFalse(array.IsSorted());
        }
    }
}
