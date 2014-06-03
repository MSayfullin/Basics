using System;
using Basics.Structures.Graphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Basics.Structures.Tests
{
    [TestClass]
    public class GraphTests
    {
        [TestMethod]
        public void EdgeEquals_Null_Test()
        {
            var edge = new Edge<int>(1, 2);

            Assert.IsFalse(edge == null);
            Assert.IsTrue(edge != null);
            Assert.IsFalse(edge.Equals(null));
        }

        [TestMethod]
        public void EdgeEquals_Edge_Test()
        {
            var edge = new Edge<int>(1, 2);
            var other = new Edge<int>(1, 2);

            Assert.IsTrue(edge == other);
            Assert.IsFalse(edge != other);
            Assert.IsTrue(edge.Equals(other));
            Assert.IsTrue(edge.Equals(other as object));
        }

        [TestMethod]
        public void EdgeEquals_DifferentEdge_Test()
        {
            var edge = new Edge<int>(1, 2);
            var other = new Edge<int>(5, 3);

            Assert.IsFalse(edge == other);
            Assert.IsTrue(edge != other);
            Assert.IsFalse(edge.Equals(other));
            Assert.IsFalse(edge.Equals(other as object));
        }

        [TestMethod]
        public void EdgeEquals_Object_Test()
        {
            var edge = new Edge<int>(1, 2);
            var obj = new object();

            Assert.IsFalse(edge.Equals(obj));
            Assert.IsFalse(edge.Equals(obj as Edge<int>));
        }

        [TestMethod]
        public void SmallGraphTest()
        {
            var graph = new AdjacencyListGraph<int>();
            graph.AddEdge(1, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(1, 4);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 4);

            Assert.AreEqual(4, graph.VertexCount);
            Assert.AreEqual(5, graph.EdgeCount);
        }
    }
}
