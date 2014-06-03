using System;
using System.Collections.Generic;

namespace Basics.Structures.Graphs
{
    public class AdjacencyListGraph<T> : IGraph<T> where T : IEquatable<T>
    {
        private HashSet<T> _vertices = new HashSet<T>();
        private HashSet<Edge<T>> _edges = new HashSet<Edge<T>>();

        public int VertexCount
        {
            get { return _vertices.Count; }
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
            if (_vertices.Contains(vertex))
            {
                return false;
            }
            _vertices.Add(vertex);
            return true;
        }

        public IEnumerable<T> GetVertices()
        {
            return _vertices;
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

        private bool TryAddEdge(Edge<T> edge)
        {
            if (_edges.Contains(edge))
            {
                return false;
            }
            TryAddVertex(edge.Source);
            TryAddVertex(edge.Target);
            _edges.Add(edge);
            return true;
        }

        public void AddEdge(T source, T target)
        {
            AddEdge(new Edge<T>(source, target));
        }

        public IEnumerable<Edge<T>> GetEdges()
        {
            return _edges;
        }
    }
}
