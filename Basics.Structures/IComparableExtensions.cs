using System;

namespace Basics.Structures
{
    public static class IComparableExtensions
    {
        public static bool IsLessThan<T>(this IComparable<T> source, T value)
        {
            return source.CompareTo(value) < 0;
        }

        public static bool IsLessThanOrEqual<T>(this IComparable<T> source, T value)
        {
            return source.CompareTo(value) <= 0;
        }

        public static bool IsGreaterThan<T>(this IComparable<T> source, T value)
        {
            return source.CompareTo(value) > 0;
        }

        public static bool IsGreaterThanOrEqual<T>(this IComparable<T> source, T value)
        {
            return source.CompareTo(value) >= 0;
        }

        public static bool IsLessThan(this IComparable source, object value)
        {
            return source.CompareTo(value) < 0;
        }

        public static bool IsLessThanOrEqual(this IComparable source, object value)
        {
            return source.CompareTo(value) <= 0;
        }

        public static bool IsGreaterThan(this IComparable source, object value)
        {
            return source.CompareTo(value) > 0;
        }

        public static bool IsGreaterThanOrEqual(this IComparable source, object value)
        {
            return source.CompareTo(value) >= 0;
        }
    }
}
