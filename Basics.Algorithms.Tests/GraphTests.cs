using System;
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

        [TestMethod]
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
    }
}
