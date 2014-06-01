using Basics.Algorithms.Sorts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Basics.Algorithms.Tests
{
    [TestClass]
    public class QuickSelectTests
    {
        [TestMethod]
        public void QuickSelectTest_Int()
        {
            var array = new int[] { 1, 6, 7, 3, 8, 0, 2, 4 };
            Assert.AreEqual(2, Quick.Select(array, 3));
        }

        [TestMethod]
        public void QuickSelectTest_String()
        {
            var array = new string[] { "1", "6", "7", "3", "8", "0", "2", "4" };
            Assert.AreEqual("7", Quick.Select(array, 7));
        }

        [TestMethod]
        public void QuickSelectTest_Char()
        {
            var array = new int[] { '1', '6', '7', '3', '8', '0', '2', '4' };
            Assert.AreEqual('4', Quick.Select(array, 5));
        }
    }
}
