using System;
using System.Diagnostics;

namespace Basics.Structures.Graphs
{
    [DebuggerDisplay("{Source}->{Target}")]
    public class Edge<T> : IEquatable<Edge<T>> where T : IEquatable<T>
    {
        public Edge(T source, T target)
        {
            Source = source;
            Target = target;
        }

        public T Source { get; private set; }

        public T Target { get; private set; }

        public bool IsSelfLooped
        {
            get { return Source.Equals(Target); }
        }

        public static bool operator ==(Edge<T> a, Edge<T> b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(Edge<T> a, Edge<T> b)
        {
            return !a.Equals(b);
        }

        public bool Equals(Edge<T> other)
        {
            return
                !Object.ReferenceEquals(other, null)
                && this.Source.Equals(other.Source)
                && this.Target.Equals(other.Target);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Edge<T>);
        }

        public override int GetHashCode()
        {
            return Source.GetHashCode() ^ Target.GetHashCode();
        }

        public override string ToString()
        {
            return Source + "->" + Target;
        }
    }
}
