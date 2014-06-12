using System;
using System.Collections.Generic;
using Basics.Structures;
using Basics.Structures.Graphs;

namespace Basics.Algorithms.Graphs
{
    public static class BreadthFirstSearch
    {
        public static IEnumerable<T> BFS<T>(this IGraph<T> graph, T startVertex) where T : IEquatable<T>
        {
            return graph.BFS(startVertex, v => { /* Do nothing */ });
        }

        public static IEnumerable<T> BFS<T>(this IGraph<T> graph, T startVertex, HashSet<T> visitedVertices) where T : IEquatable<T>
        {
            return graph.BFS(startVertex, visitedVertices, v => { /* Do nothing */ });
        }

        public static IEnumerable<T> BFS<T>(this IGraph<T> graph, T startVertex, Action<T> lastVertexAction) where T : IEquatable<T>
        {
            return graph.BFS(startVertex, new HashSet<T>(), lastVertexAction);
        }

        public static IEnumerable<T> BFS<T>(this IGraph<T> graph, T startVertex, HashSet<T> visitedVertices, Action<T> lastVertexAction) where T : IEquatable<T>
        {
            var queue = new QueueOnArray<T>();
            queue.Enqueue(startVertex);
            while (!queue.IsEmpty)
            {
                var current = queue.Dequeue();
                if (!visitedVertices.Contains(current))
                {
                    visitedVertices.Add(current);
                    var noChildren = true;
                    foreach (var edge in graph.EdgesOf(current))
                    {
                        noChildren = false;
                        queue.Enqueue(edge.Target);
                    }
                    if (noChildren)
                    {
                        lastVertexAction(current);
                    }
                    yield return current;
                }
            }
        }
    }
}
