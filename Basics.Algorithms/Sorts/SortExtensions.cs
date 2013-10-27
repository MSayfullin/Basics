using System;

namespace Basics.Algorithms.Sorts
{
    public static class SortExtensions
    {
        public static bool IsLessThan<T>(this IComparable<T> source, T value)
        {
            return source.CompareTo(value) < 0;
        }

        public static bool IsGreaterThan<T>(this IComparable<T> source, T value)
        {
            return source.CompareTo(value) > 0;
        }

        public static bool IsLessThan(this IComparable source, object value)
        {
            return source.CompareTo(value) < 0;
        }

        public static bool IsGreaterThan(this IComparable source, object value)
        {
            return source.CompareTo(value) > 0;
        }

        /// <summary>
        /// Checks whether array is sorted.
        /// Empty and arrays with one element are consedered as sorted.
        /// </summary>
        /// <returns>True if array is sorted, false otherwise.</returns>
        public static bool IsSorted<T>(this T[] source) where T : IComparable<T>
        {
            if (source.Length < 1)
                return true;

            for (int i = 1; i < source.Length; i++)
            {
                if (source[i].IsLessThan(source[i - 1]))
                    return false;
            }
            return true;
        }
    }
}
