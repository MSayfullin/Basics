using System;

namespace Basics.Algorithms.Sorts
{
    public static class SortExtensions
    {
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

        /// <summary>
        /// Checks whether array is sorted.
        /// Empty and arrays with one element are consedered as sorted.
        /// </summary>
        /// <returns>True if array is sorted, false otherwise.</returns>
        public static bool IsSorted<T>(this T[] source, int lo, int hi) where T : IComparable<T>
        {
            if (hi - lo < 1)
                return true;

            for (int i = lo + 1; i <= hi; i++)
            {
                if (source[i].IsLessThan(source[i - 1]))
                    return false;
            }
            return true;
        }
    }
}
