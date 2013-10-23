using Basics.Structures.DynamicConnectivity;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Basics.Structures.Tests
{
    [TestClass]
    public class DynamicConnectivityTests
    {
        private void ReflexiveCheck(UnionFind unionFind)
        {
            Assert.IsTrue(unionFind.IsConnected(2, 2));
            Assert.IsFalse(unionFind.IsConnected(4, 7));
        }

        [TestMethod]
        public void QuickFind_ReflexiveCheck()
        {
            var quickFind = new QuickFind(10);
            ReflexiveCheck(quickFind);
        }

        [TestMethod]
        public void QuickUnion_ReflexiveCheck()
        {
            var quickFind = new QuickUnion(10);
            ReflexiveCheck(quickFind);
        }

        [TestMethod]
        public void WeightedQuickUnion_ReflexiveCheck()
        {
            var quickFind = new WeightedQuickUnion(10);
            ReflexiveCheck(quickFind);
        }

        [TestMethod]
        public void WeightedQuickUnionEx_ReflexiveCheck()
        {
            var quickFind = new WeightedQuickUnionEx(10);
            ReflexiveCheck(quickFind);
        }

        private void SymmetricCheck(UnionFind unionFind)
        {
            unionFind.Union(1, 6);

            Assert.IsTrue(unionFind.IsConnected(1, 6));
            Assert.IsTrue(unionFind.IsConnected(6, 1));
            Assert.IsFalse(unionFind.IsConnected(3, 9));
        }

        [TestMethod]
        public void QuickFind_SymmetricCheck()
        {
            var quickFind = new QuickFind(10);
            SymmetricCheck(quickFind);
        }

        [TestMethod]
        public void QuickUnion_SymmetricCheck()
        {
            var quickFind = new QuickUnion(10);
            SymmetricCheck(quickFind);
        }

        [TestMethod]
        public void WeightedQuickUnion_SymmetricCheck()
        {
            var quickFind = new WeightedQuickUnion(10);
            SymmetricCheck(quickFind);
        }

        [TestMethod]
        public void WeightedQuickUnionEx_SymmetricCheck()
        {
            var quickFind = new WeightedQuickUnionEx(10);
            SymmetricCheck(quickFind);
        }

        private void TransitiveCheck(UnionFind unionFind)
        {
            unionFind.Union(3, 7);
            unionFind.Union(7, 1);

            Assert.IsTrue(unionFind.IsConnected(3, 1));
            Assert.IsTrue(unionFind.IsConnected(1, 3));
            Assert.IsFalse(unionFind.IsConnected(1, 5));
        }

        [TestMethod]
        public void QuickFind_TransitiveCheck()
        {
            var quickFind = new QuickFind(10);
            TransitiveCheck(quickFind);
        }

        [TestMethod]
        public void QuickUnion_TransitiveCheck()
        {
            var quickFind = new QuickUnion(10);
            TransitiveCheck(quickFind);
        }

        [TestMethod]
        public void WeightedQuickUnion_TransitiveCheck()
        {
            var quickFind = new WeightedQuickUnion(10);
            TransitiveCheck(quickFind);
        }

        [TestMethod]
        public void WeightedQuickUnionEx_TransitiveCheck()
        {
            var quickFind = new WeightedQuickUnionEx(10);
            TransitiveCheck(quickFind);
        }

        private void TwoSitesCheck(UnionFind unionFind)
        {
            unionFind.Union(2, 8);

            Assert.IsTrue(unionFind.IsConnected(2, 8));
            Assert.IsFalse(unionFind.IsConnected(1, 5));
        }

        [TestMethod]
        public void QuickFind_TwoSites()
        {
            var quickFind = new QuickFind(10);
            TwoSitesCheck(quickFind);
        }

        [TestMethod]
        public void QuickUnion_TwoSites()
        {
            var quickFind = new QuickUnion(10);
            TwoSitesCheck(quickFind);
        }

        [TestMethod]
        public void WeightedQuickUnion_TwoSites()
        {
            var quickFind = new WeightedQuickUnion(10);
            TwoSitesCheck(quickFind);
        }

        [TestMethod]
        public void WeightedQuickUnionEx_TwoSites()
        {
            var quickFind = new WeightedQuickUnionEx(10);
            TwoSitesCheck(quickFind);
        }

        private void AllConnectedCheck(UnionFind unionFind)
        {
            unionFind.Union(0, 1);
            unionFind.Union(1, 2);
            unionFind.Union(2, 3);
            unionFind.Union(3, 4);
            unionFind.Union(4, 5);
            unionFind.Union(5, 6);
            unionFind.Union(6, 7);
            unionFind.Union(7, 8);
            unionFind.Union(8, 9);

            Assert.IsTrue(unionFind.IsConnected(0, 9));
        }

        [TestMethod]
        public void QuickFind_AllConnected()
        {
            var quickFind = new QuickFind(10);
            AllConnectedCheck(quickFind);
        }

        [TestMethod]
        public void QuickUnion_AllConnected()
        {
            var quickFind = new QuickUnion(10);
            AllConnectedCheck(quickFind);
        }

        [TestMethod]
        public void WeightedQuickUnion_AllConnected()
        {
            var quickFind = new WeightedQuickUnion(10);
            AllConnectedCheck(quickFind);
        }

        [TestMethod]
        public void WeightedQuickUnionEx_AllConnected()
        {
            var quickFind = new WeightedQuickUnionEx(10);
            AllConnectedCheck(quickFind);
        }
    }
}
