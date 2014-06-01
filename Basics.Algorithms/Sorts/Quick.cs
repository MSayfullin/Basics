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

        public static T Select<T>(T[] array, int k) where T : IComparable<T>
        {
            array.Shuffle();

            int lo = 0;
            int hi = array.Length - 1;
            while (lo <= hi)
            {
                int j = Partition(array, lo, hi);
                if (j < k)
                    lo = j + 1;
                else if (j > k)
                    hi = j - 1;
                else
                    return array[k];
            }
            return array[k];
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
