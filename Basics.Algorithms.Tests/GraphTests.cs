using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Basics.Algorithms.Graphs;
using Basics.Structures.Graphs;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Basics.Algorithms.Tests
{
    [TestClass]
    public class GraphTests
    {
        #region DFS

        [TestMethod]
        public void DFS_SmallGraphTest()
        {
            var graph = new AdjacencyListGraph<int>();
            graph.AddEdge(1, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(1, 5);
            graph.AddEdge(2, 4);
            graph.AddEdge(2, 6);
            graph.AddEdge(3, 7);
            graph.AddEdge(5, 6);

            int idx = 0;
            var path = new[] { 1, 2, 4, 6, 3, 7, 5 };
            foreach (var vertex in graph.DFS(1))
            {
                Assert.AreEqual(path[idx++], vertex);
            }
            Assert.AreEqual(7, idx);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void DFS_NoVertices_SmallGraphTest()
        {
            var graph = new AdjacencyListGraph<int>();

            foreach (var vertex in graph.DFS(1))
            {
            }
        }

        [TestMethod]
        public void DFS_1Vertex_SmallGraphTest()
        {
            var graph = new AdjacencyListGraph<int>();
            graph.AddVertex(1);

            foreach (var vertex in graph.DFS(1))
            {
                Assert.AreEqual(1, vertex);
            }
        }

        [TestMethod]
        public void DFSWithAction_SmallGraphTest()
        {
            var graph = new AdjacencyListGraph<int>();
            graph.AddEdge(1, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(1, 5);
            graph.AddEdge(2, 4);
            graph.AddEdge(2, 6);
            graph.AddEdge(3, 7);
            graph.AddEdge(5, 6);

            int pathIdx = 0;
            int lastVerticesIdx = 0;
            var lastVertices = new[] { 4, 6, 7, 5 };
            var path = new[] { 1, 2, 4, 6, 3, 7, 5 };
            foreach (var vertex in graph.DFS(1, v => Assert.AreEqual(lastVertices[lastVerticesIdx++], v)))
            {
                Assert.AreEqual(path[pathIdx++], vertex);
            }
            Assert.AreEqual(7, pathIdx);
            Assert.AreEqual(4, lastVerticesIdx);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void DFSWithAction_NoVertices_SmallGraphTest()
        {
            var graph = new AdjacencyListGraph<int>();

            foreach (var vertex in graph.DFS(1, v => { }))
            {
            }
        }

        [TestMethod]
        public void DFSWithAction_1Vertex_SmallGraphTest()
        {
            var graph = new AdjacencyListGraph<int>();
            graph.AddVertex(1);

            foreach (var vertex in graph.DFS(1, v => Assert.AreEqual(1, v)))
            {
                Assert.AreEqual(1, vertex);
            }
        }

        #endregion

        #region MinCut

        [TestMethod]
        public void MinCut_SmallGraphTest()
        {
            var graph = new AdjacencyListGraph<int>();
            graph.AddEdge(1, 2);
            graph.AddEdge(1, 3);
            graph.AddEdge(1, 4);
            graph.AddEdge(2, 3);
            graph.AddEdge(3, 4);

            var minCut = graph.RandomizedMinCut();
            Assert.AreEqual(2, minCut.Count());
        }

        [TestMethod, Ignore]
        [DeploymentItem(@"Data\UndirectedGraph.txt")]
        public void MinCut_LargeGraphTest()
        {
            var graph = LoadGraph();
            var minCut = graph.RandomizedMinCut();
            // actual MinCut is 17 because graph is undirected
            Assert.AreEqual(34, minCut.Count());
        }

        private static IGraph<string> LoadGraph()
        {
            var graph = new AdjacencyListGraph<string>();
            using (var file = File.OpenText("UndirectedGraph.txt"))
            {
                while (!file.EndOfStream)
                {
                    var str = file.ReadLine();
                    if (!str.StartsWith("#"))
                    {
                        var data = str.Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                        var source = data[0];
                        for (int i = 1; i < data.Length; i++)
                        {
                            var target = data[i];
                            graph.AddEdge(source, target);
                        }
                    }
                }
                Assert.AreEqual(200, graph.VertexCount);
            }
            return graph;
        }

        #endregion
    }
}
