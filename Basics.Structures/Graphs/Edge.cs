using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;

namespace Basics.Structures.Graphs
{
    [DebuggerDisplay("{Source}-({Weight})->{Target}")]
    public class Edge<T> : IEquatable<Edge<T>> where T : IEquatable<T>
    {
        public Edge(T source, T target, double weight = 1.0)
        {
            Source = source;
            Target = target;
            Weight = weight;
        }

        public T Source { get; private set; }

        public T Target { get; private set; }

        public double Weight { get; private set; }

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
            var sourceHashCode = Source.GetHashCode();
            return ((sourceHashCode << 5) + sourceHashCode) ^ Target.GetHashCode();
        }

        public override string ToString()
        {
            return Source + "-(" + Weight.ToString("N1", CultureInfo.CurrentCulture) + ")->" + Target;
        }
    }
}
