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
        #region Depth Fisrt Search

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
            Assert.AreEqual(path.Length, idx);
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
            Assert.AreEqual(path.Length, pathIdx);
            Assert.AreEqual(lastVertices.Length, lastVerticesIdx);
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

        #region Breadth Fisrt Search

        [TestMethod]
        public void BFS_SmallGraphTest()
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
            var path = new[] { 1, 2, 3, 5, 4, 6, 7 };
            foreach (var vertex in graph.BFS(1))
            {
                Assert.AreEqual(path[idx++], vertex);
            }
            Assert.AreEqual(path.Length, idx);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void BFS_NoVertices_SmallGraphTest()
        {
            var graph = new AdjacencyListGraph<int>();

            foreach (var vertex in graph.BFS(1))
            {
            }
        }

        [TestMethod]
        public void BFS_1Vertex_SmallGraphTest()
        {
            var graph = new AdjacencyListGraph<int>();
            graph.AddVertex(1);

            foreach (var vertex in graph.BFS(1))
            {
                Assert.AreEqual(1, vertex);
            }
        }

        [TestMethod]
        public void BFSWithAction_SmallGraphTest()
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
            var lastVertices = new[] { 4, 6, 7 };
            var path = new[] { 1, 2, 3, 5, 4, 6, 7 };
            foreach (var vertex in graph.BFS(1, v => Assert.AreEqual(lastVertices[lastVerticesIdx++], v)))
            {
                Assert.AreEqual(path[pathIdx++], vertex);
            }
            Assert.AreEqual(path.Length, pathIdx);
            Assert.AreEqual(lastVertices.Length, lastVerticesIdx);
        }

        [TestMethod]
        [ExpectedException(typeof(KeyNotFoundException))]
        public void BFSWithAction_NoVertices_SmallGraphTest()
        {
            var graph = new AdjacencyListGraph<int>();

            foreach (var vertex in graph.BFS(1, v => { }))
            {
            }
        }

        [TestMethod]
        public void BFSWithAction_1Vertex_SmallGraphTest()
        {
            var graph = new AdjacencyListGraph<int>();
            graph.AddVertex(1);

            foreach (var vertex in graph.BFS(1, v => Assert.AreEqual(1, v)))
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
            var graph = LoadUndirectedGraph();
            var minCut = graph.RandomizedMinCut();
            // actual MinCut is 17 because graph is undirected
            Assert.AreEqual(34, minCut.Count());
        }

        private static IGraph<string> LoadUndirectedGraph()
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

        #region Dijkstra Shortest Path

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DijkstraShortestPath_NegativeEdgeTest()
        {
            var graph = new AdjacencyListGraph<int>();
            graph.AddEdge(1, 2, -7);
            graph.AddEdge(2, 1, -7);

            var path = graph.DijkstraShortestPath(1, 2);
        }

        [TestMethod]
        public void DijkstraShortestPath_EmptyGraphTest()
        {
            var graph = new AdjacencyListGraph<int>();
            var path = graph.DijkstraShortestPath(1, 10);

            Assert.AreEqual(0, path.Count());
        }

        [TestMethod]
        public void DijkstraShortestPath_1to1_SmallGraphTest()
        {
            DijkstraShortestPath_SmallGraphTest(1, 1, new int[0], 0);
        }

        [TestMethod]
        public void DijkstraShortestPath_1to5_SmallGraphTest()
        {
            DijkstraShortestPath_SmallGraphTest(1, 5, new[] { 3, 6, 5 }, 20);
        }

        [TestMethod]
        public void DijkstraShortestPath_1to4_SmallGraphTest()
        {
            DijkstraShortestPath_SmallGraphTest(1, 4, new[] { 3, 4 }, 20);
        }

        private static void DijkstraShortestPath_SmallGraphTest(int start, int finish, int[] targetPath, double weight)
        {
            var graph = new AdjacencyListGraph<int>();
            graph.AddEdge(1, 2, 7);
            graph.AddEdge(2, 1, 7);
            graph.AddEdge(1, 3, 9);
            graph.AddEdge(3, 1, 9);
            graph.AddEdge(1, 6, 14);
            graph.AddEdge(6, 1, 14);
            graph.AddEdge(2, 4, 15);
            graph.AddEdge(4, 2, 15);
            graph.AddEdge(3, 4, 11);
            graph.AddEdge(4, 3, 11);
            graph.AddEdge(3, 2, 10);
            graph.AddEdge(2, 3, 10);
            graph.AddEdge(6, 3, 2);
            graph.AddEdge(3, 6, 2);
            graph.AddEdge(6, 5, 9);
            graph.AddEdge(5, 6, 9);
            graph.AddEdge(5, 4, 6);
            graph.AddEdge(4, 5, 6);

            var path = graph.DijkstraShortestPath(start, finish);

            var idx = 0;
            var segmentsCount = 0;
            var pathWeight = 0.0;
            foreach (var edge in path)
            {
                segmentsCount++;
                pathWeight += edge.Weight;
                Assert.AreEqual(targetPath[idx++], edge.Target);
            }
            Assert.AreEqual(targetPath.Length, segmentsCount);
            Assert.AreEqual(weight, pathWeight);
        }

        [TestMethod]
        [DeploymentItem(@"Data\WeightedUndirectedGraph.txt")]
        public void DijkstraShortestPath_LargeGraphTest()
        {
            var targets = new[]
            {
                Tuple.Create(2, 2971.0),
                Tuple.Create(3, 2644.0),
                Tuple.Create(4, 3056.0),
                Tuple.Create(5, 2525.0),
                Tuple.Create(7, 2599.0),
                Tuple.Create(37, 2610.0),
                Tuple.Create(59, 2947.0),
                Tuple.Create(82, 2052.0),
                Tuple.Create(99, 2367.0),
                Tuple.Create(115, 2399.0),
                Tuple.Create(133, 2029.0),
                Tuple.Create(165, 2442.0),
                Tuple.Create(188, 2505.0),
                Tuple.Create(197, 3068.0),
                Tuple.Create(198, 1724.0),
                Tuple.Create(199, 815.0),
                Tuple.Create(200, 2060.0)
            };
            var graph = LoadWeightedGraph();
            foreach (var target in targets)
            {
                var path = graph.DijkstraShortestPath(1, target.Item1);

                Assert.AreEqual(target.Item2, path.Sum(p => p.Weight));
            }
        }

        [TestMethod, Description("Checks speed of algorithm, no assertion")]
        [DeploymentItem(@"Data\WeightedUndirectedGraph.txt")]
        public void DijkstraShortestPath_AllVertices_LargeGraphTest()
        {
            var graph = LoadWeightedGraph();
            foreach (var vertex in graph.GetVertices())
            {
                graph.DijkstraShortestPath(1, vertex);
            }
        }

        private static IGraph<int> LoadWeightedGraph()
        {
            var graph = new AdjacencyListGraph<int>();
            using (var file = File.OpenText("WeightedUndirectedGraph.txt"))
            {
                while (!file.EndOfStream)
                {
                    var str = file.ReadLine();
                    if (!str.StartsWith("#"))
                    {
                        var data = str.Split(new[] { '\t' }, StringSplitOptions.RemoveEmptyEntries);
                        var source = Int32.Parse(data[0]);
                        for (int i = 1; i < data.Length; i++)
                        {
                            var tuple = data[i].Split(',');
                            graph.AddEdge(source, Int32.Parse(tuple[0]), Double.Parse(tuple[1]));
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
