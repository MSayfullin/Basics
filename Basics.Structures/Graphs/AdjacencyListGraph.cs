using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Basics.Structures.Graphs
{
    [DebuggerDisplay("Vertices: {VertexCount}, Edges: {EdgeCount}")]
    public class AdjacencyListGraph<T> : IGraph<T> where T : IEquatable<T>
    {
        private HashSet<Edge<T>> _edges = new HashSet<Edge<T>>();
        private Dictionary<T, List<Edge<T>>> _edgesMap = new Dictionary<T, List<Edge<T>>>();

        public bool IsEmpty
        {
            get { return _edgesMap.Count == 0; }
        }

        public int VertexCount
        {
            get { return _edgesMap.Keys.Count; }
        }

        public void AddVertex(T vertex)
        {
            if (!TryAddVertex(vertex))
            {
                throw new ArgumentException("Vertex already exists in graph", "vertex");
            }
        }

        private bool TryAddVertex(T vertex)
        {
            if (_edgesMap.ContainsKey(vertex))
            {
                return false;
            }
            _edgesMap.Add(vertex, new List<Edge<T>>());
            return true;
        }

        public IEnumerable<T> GetVertices()
        {
            return _edgesMap.Keys;
        }

        public IEnumerable<Edge<T>> EdgesOf(T vertex)
        {
            return _edgesMap[vertex];
        }

        public int EdgeCount
        {
            get { return _edges.Count; }
        }

        public void AddEdge(Edge<T> edge)
        {
            if (!TryAddEdge(edge))
            {
                throw new ArgumentException("Edge already exists in graph", "edge");
            }
        }

        public void AddEdge(T source, T target)
        {
            AddEdge(new Edge<T>(source, target));
        }

        private bool TryAddEdge(Edge<T> edge)
        {
            if (_edges.Contains(edge))
            {
                return false;
            }
            TryAddVertex(edge.Source);
            TryAddVertex(edge.Target);
            _edges.Add(edge);
            _edgesMap[edge.Source].Add(edge);
            return true;
        }

        public IEnumerable<Edge<T>> GetEdges()
        {
            return _edges;
        }

        public IGraph<T> Reverse()
        {
            var reversed = new AdjacencyListGraph<T>();
            foreach (var edge in _edges)
            {
                reversed.AddEdge(edge.Target, edge.Source);
            }
            return reversed;
        }
    }
}
