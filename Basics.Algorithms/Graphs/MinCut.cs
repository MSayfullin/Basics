using System;
using System.Collections.Generic;
using Basics.Structures.Graphs;

namespace Basics.Algorithms.Graphs
{
    public static class MinCut
    {
        public static IEnumerable<Edge<T>> RandomizedMinCut<T>(this IGraph<T> graph) where T : IEquatable<T>
        {
            var rnd = new Random();
            List<Edge<T>> minCut = null;
            for (int i = 0; i < graph.VertexCount; i++)
            {
                var edges = CollapseEdges(rnd, graph.VertexCount, graph.GetEdges());
                if (minCut == null || edges.Count < minCut.Count)
                {
                    minCut = edges;
                }
            }
            return minCut;
        }

        private static List<Edge<T>> CollapseEdges<T>(Random rnd, int nodeCount, IEnumerable<Edge<T>> edges) where T : IEquatable<T>
        {
            var edgesList = new List<Edge<T>>(edges);
            while (nodeCount > 2)
            {
                nodeCount--;
                var idx = rnd.Next(edgesList.Count);
                var current = edgesList[idx];
                edgesList.RemoveAt(idx);

                var copy = new List<Edge<T>>();
                foreach (var edge in edgesList)
                {
                    var correctedEdge =
                        edge.Source.Equals(current.Target) ? new Edge<T>(current.Source, edge.Target)
                        : edge.Target.Equals(current.Target) ? new Edge<T>(edge.Source, current.Source)
                        : edge;

                    if (!correctedEdge.IsSelfLooped)
                    {
                        copy.Add(correctedEdge);
                    }
                }
                edgesList = copy;
            }
            return edgesList;
        }
    }
}
