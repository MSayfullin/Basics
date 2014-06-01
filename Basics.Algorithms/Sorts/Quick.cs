using System;
using Basics.Structures;

namespace Basics.Algorithms.Sorts
{
    public static class Quick
    {
        public static void Sort<T>(T[] array) where T : IComparable<T>
        {
            array.Shuffle();

            Sort(array, 0, array.Length - 1);
        }

        /// <summary>
        /// Returns k-th minimum element from an array.
        /// </summary>
        /// <param name="k">Numerical order of an element to return</param>
        public static T Select<T>(T[] array, int k) where T : IComparable<T>
        {
            var copy = new T[array.Length];
            array.CopyTo(copy, 0);

            copy.Shuffle();

            int lo = 0;
            int hi = copy.Length - 1;
            int zeroBasedIdx = k - 1;
            while (lo <= hi)
            {
                int j = SimplePartition(copy, lo, hi);
                if (j < zeroBasedIdx)
                    lo = j + 1;
                else if (j > zeroBasedIdx)
                    hi = j - 1;
                else
                    return copy[zeroBasedIdx];
            }
            return copy[zeroBasedIdx];
        }

        private static void Sort<T>(T[] array, int lo, int hi) where T : IComparable<T>
        {
            if (hi <= lo) return;

            int j = SimplePartition(array, lo, hi);
            Sort(array, lo, j - 1);
            Sort(array, j + 1, hi);
        }

        private static int SimplePartition<T>(T[] array, int lo, int hi) where T : IComparable<T>
        {
            int i = lo;
            var pivot = array[lo];
            for (int j = lo + 1; j <= hi; j++)
            {
                if (array[j].IsLessThan(pivot))
                {
                    array.Exchange(++i, j);
                }
            }
            array.Exchange(lo, i);
            return i;
        }

        private static int Partition<T>(T[] array, int lo, int hi) where T : IComparable<T>
        {
            int i = lo;
            int j = hi + 1;
            var v = array[lo];
            while (true)
            {
                while (array[++i].IsLessThan(v))
                    if (i >= hi) break;

                while (array[--j].IsGreaterThan(v))
                    if (j <= lo) break;

                if (i >= j) break;

                array.Exchange(i, j);
            }
            array.Exchange(lo, j);
            return j;
        }
    }
}
