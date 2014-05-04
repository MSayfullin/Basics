using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Basics.Algorithms.Tests
{
    [TestClass]
    public class InversionCountTests
    {
        private const string DataFilePath = @"Data\IntegerArray.txt";

        private static List<int> _integers = new List<int>();

        [ClassInitialize]
        [DeploymentItem(DataFilePath)]
        public static void LoadTestData(TestContext context)
        {
            using (var file = File.OpenText(DataFilePath))
            {
                while (!file.EndOfStream)
	            {
                    int val;
                    var str = file.ReadLine();
                    if (!str.StartsWith("#") && Int32.TryParse(str, out val))
                    {
                        _integers.Add(val);
                    }
                }
                Assert.AreEqual(100000, _integers.Count);
            }
        }

        [TestMethod]
        public void InversionCount_BruteForce_Int_TestOnEmptyArray()
        {
            var array = new int[] { };
            var count = Inversion.CountBruteForce(array);
            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void InversionCount_BruteForce_Int_TestOnArrayWithOneElement()
        {
            var array = new int[] { 1 };
            var count = Inversion.CountBruteForce(array);
            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void InversionCount_BruteForce_Int_TestOnSortedArray()
        {
            var array = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var count = Inversion.CountBruteForce(array);
            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void InversionCount_BruteForce_Int_TestOnReverseSortedArray()
        {
            var array = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            var count = Inversion.CountBruteForce(array);
            Assert.AreEqual(45, count);
        }

        [TestMethod]
        public void InversionCount_BruteForce_Int_TestOnUnsortedArray()
        {
            var array = new int[] { 0, 3, 9, 1, 4, 5, 2, 7, 8, 6 };
            var count = Inversion.CountBruteForce(array);
            Assert.AreEqual(13, count);
        }

        [TestMethod]
        public void InversionCount_BruteForce_Int_TestOnUnsortedArrayWithDuplicates()
        {
            var array = new int[] { 0, 3, 9, 7, 1, 4, 5, 2, 7, 8, 6, 3, 1 };
            var count = Inversion.CountBruteForce(array);
            Assert.AreEqual(36, count);
        }

        [TestMethod]
        public void InversionCount_Int_TestOnEmptyArray()
        {
            var array = new int[] { };
            var ethalon = Inversion.CountBruteForce(array);
            var count = Inversion.Count(array);
            Assert.AreEqual(ethalon, count);
        }

        [TestMethod]
        public void InversionCount_Int_TestOnArrayWithOneElement()
        {
            var array = new int[] { 1 };
            var ethalon = Inversion.CountBruteForce(array);
            var count = Inversion.Count(array);
            Assert.AreEqual(ethalon, count);
        }

        [TestMethod]
        public void InversionCount_Int_TestOnSortedArray()
        {
            var array = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            var ethalon = Inversion.CountBruteForce(array);
            var count = Inversion.Count(array);
            Assert.AreEqual(ethalon, count);
        }

        [TestMethod]
        public void InversionCount_Int_TestOnReverseSortedArray()
        {
            // inversion count = 45
            // formula: max inversion count = n(n-1)/2
            var array = new int[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 };
            var ethalon = Inversion.CountBruteForce(array);
            var count = Inversion.Count(array);
            Assert.AreEqual(ethalon, count);
        }

        [TestMethod]
        public void InversionCount_Int_TestOnUnsortedArray()
        {
            // inversion count = 13
            var array = new int[] { 0, 3, 9, 1, 4, 5, 2, 7, 8, 6 };
            var ethalon = Inversion.CountBruteForce(array);
            var count = Inversion.Count(array);
            Assert.AreEqual(ethalon, count);
        }

        [TestMethod]
        public void InversionCount_Int_TestOnUnsortedArrayWithDuplicates()
        {
            // inversion count = 36
            var array = new int[] { 0, 3, 9, 7, 1, 4, 5, 2, 7, 8, 6, 3, 1 };
            var ethalon = Inversion.CountBruteForce(array);
            var count = Inversion.Count(array);
            Assert.AreEqual(ethalon, count);
        }

        [TestMethod]
        public void InversionCount_String_TestOnSortedArray()
        {
            var array = new string[] { "a", "b", "c", "d", "e", "f", "g" };
            var ethalon = Inversion.CountBruteForce(array);
            var count = Inversion.Count(array);
            Assert.AreEqual(ethalon, count);
        }

        [TestMethod]
        public void InversionCount_String_TestOnUnsortedArray()
        {
            // inversion count = 14
            var array = new string[] { "f", "b", "g", "d", "e", "a", "c" };
            var ethalon = Inversion.CountBruteForce(array);
            var count = Inversion.Count(array);
            Assert.AreEqual(ethalon, count);
        }

        [TestMethod]
        public void InversionCount_String_TestOnUnsortedArrayWithDuplicates()
        {
            // inversion count = 22
            var array = new string[] { "f", "b", "g", "a", "d", "e", "a", "c", "b" };
            var ethalon = Inversion.CountBruteForce(array);
            var count = Inversion.Count(array);
            Assert.AreEqual(ethalon, count);
        }

        [TestMethod]
        public void InversionCount_Int_TestOnLargeData()
        {
            var count = Inversion.Count(_integers.ToArray());
            Assert.AreEqual(2407905288, count);
        }
    }
}
