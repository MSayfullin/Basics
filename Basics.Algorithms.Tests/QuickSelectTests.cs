using Basics.Algorithms.Sorts;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Basics.Algorithms.Tests
{
    [TestClass]
    public class QuickSelectTests
    {
        [TestMethod]
        public void QuickSelectTest()
        {
            var array = new int[] { 1, 6, 7, 3, 8, 0, 2, 4 };
            Assert.AreEqual(3, Quick.Select(array, 3));
        }
    }
}
