using System;

namespace Basics.Algorithms
{
    public static class BinarySearch
    {
        /// <summary>
        /// Returns index of a key in an array using binary search algorithm.
        /// </summary>
        /// <typeparam name="T">
        /// Type of elements in an array.
        /// Type should implement <see cref="IComparable{T}"/> or <see cref="IComparable"/>
        /// </typeparam>
        /// <param name="source">Source array.</param>
        /// <param name="key">Key to search in an array.</param>
        /// <returns></returns>
        public static int IndexOf<T>(this T[] source, T key) where T : IComparable<T>, IComparable
        {
            return EthalonImplementation<T>(source, key);
            //return RecursiveImplementation<T>(source, key);
        }

        private static int EthalonImplementation<T>(T[] source, T key) where T : IComparable<T>, IComparable
        {
            int lo = 0;
            int hi = source.Length - 1;
            while (lo <= hi)
            {
                int middle = (hi - lo) / 2 + lo;
                int res = key.CompareTo(source[middle]);
                if (res < 0) hi = middle - 1;
                else if (res > 0) lo = middle + 1;
                else return middle;
            }
            return -1;
        }

        private static int RecursiveImplementation<T>(T[] source, T key) where T : IComparable<T>, IComparable
        {
            return RecursiveImplementation(source, key, lo: 0, hi: source.Length - 1);
        }

        private static int RecursiveImplementation<T>(T[] source, T key, int lo, int hi) where T : IComparable<T>, IComparable
        {
            if (lo > hi) return -1;

            int middle = (hi - lo) / 2 + lo;
            int res = key.CompareTo(source[middle]);
            if (res < 0)
                return RecursiveImplementation(source, key, lo: lo, hi: middle - 1);
            else if (res > 0)
                return RecursiveImplementation(source, key, lo: middle + 1, hi: hi);
            else return middle;
        }
    }
}
