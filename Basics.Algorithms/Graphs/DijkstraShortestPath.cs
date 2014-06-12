using System;
using System.Collections.Generic;
using System.Diagnostics;
using Basics.Structures.Graphs;
using Basics.Structures.Queues;

namespace Basics.Algorithms.Graphs
{
    public static class Dijkstra
    {
        [DebuggerDisplay("...-({PathWeight})->{Edge.Target}")]
        private class Weight<T> : IComparable<Weight<T>> where T : IEquatable<T>
        {
            public Edge<T> Edge { get; set; }
            public double PathWeight { get; set; }

            public int CompareTo(Weight<T> other)
            {
                return other == null ? 1 : PathWeight.CompareTo(other.PathWeight);
            }
        }

        private class Path<T> where T : IEquatable<T>
        {
            public double Weight { get; set; }
            public List<Edge<T>> Edges { get; set; }
        }

        public static IEnumerable<Edge<T>> DijkstraShortestPath<T>(this IGraph<T> graph, T startVertex, T finishVertex) where T : IEquatable<T>
        {
            var currentVertex = startVertex;
            var weigths = new MinPriorityQueue<Weight<T>>();
            var paths = new Dictionary<T, Path<T>>
            {
                { startVertex, new Path<T> { Weight = 0.0, Edges = new List<Edge<T>>() } }
            };
            while (paths.Count < graph.VertexCount)
            {
                foreach (var edge in graph.EdgesOf(currentVertex))
                {
                    if (edge.Weight < 0)
                    {
                        throw new ArgumentOutOfRangeException(
                            "Edge.Weight", edge.Weight,
                            "Dijkstra's algorithm for shortest paths does not support negative weights.");
                    }
                    if (!paths.ContainsKey(edge.Target))
                    {
                        weigths.Enqueue(new Weight<T>
                        {
                            Edge = edge,
                            PathWeight = paths[edge.Source].Weight + edge.Weight
                        });
                    }
                }

                Weight<T> smallest;
                do
                {
                    // skip obsolete edges
                    smallest = weigths.DequeueMin();
                } while (paths.ContainsKey(smallest.Edge.Target));

                var pathToSource = paths[smallest.Edge.Source];
                var path = new List<Edge<T>>(pathToSource.Edges);
                path.Add(smallest.Edge);

                if (smallest.Edge.Target.Equals(finishVertex))
                {
                    return path;
                }

                currentVertex = smallest.Edge.Target;
                paths.Add(smallest.Edge.Target, new Path<T> { Weight = smallest.PathWeight, Edges = path });
            }
            return new Edge<T>[0];
        }
    }
}
