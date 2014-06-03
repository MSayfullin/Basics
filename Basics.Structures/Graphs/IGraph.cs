using System;
using System.Collections.Generic;

namespace Basics.Structures.Graphs
{
    public interface IGraph<T> where T : IEquatable<T>
    {
        int VertexCount { get; }
        void AddVertex(T value);
        IEnumerable<T> GetVertices();

        int EdgeCount { get; }
        void AddEdge(Edge<T> edge);
        void AddEdge(T source, T target);
        IEnumerable<Edge<T>> GetEdges();
    }
}
