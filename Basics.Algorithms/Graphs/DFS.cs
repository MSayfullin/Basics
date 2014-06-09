﻿using System;
using System.Collections.Generic;
using Basics.Structures;
using Basics.Structures.Graphs;

namespace Basics.Algorithms.Graphs
{
    public static class DepthFirstSearch
    {
        public static IEnumerable<T> DFS<T>(this IGraph<T> graph, T startVertex) where T : IEquatable<T>
        {
            return graph.DFS(startVertex, v => { /* Do nothing */ });
        }

        public static IEnumerable<T> DFS<T>(this IGraph<T> graph, T startVertex, Action<T> lastVertexAction) where T : IEquatable<T>
        {
            var visited = new HashSet<T>();
            var stack = new StackOnList<T>();
            stack.Push(startVertex);
            T previous = startVertex;
            while (!stack.IsEmpty)
            {
                var current = stack.Pop();
                if (!visited.Contains(current))
                {
                    visited.Add(current);
                    // preserve edges order
                    var edges = new List<Edge<T>>(graph.EdgesOf(current));
                    for (int i = edges.Count - 1; i >= 0; i--)
                    {
                        stack.Push(edges[i].Target);
                    }
                    if (edges.Count == 0)
                    {
                        lastVertexAction(current);
                    }
                    yield return current;
                }
                else
                {
                    lastVertexAction(previous);
                }
                previous = current;
            }
        }
    }
}