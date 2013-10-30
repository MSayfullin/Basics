using System;

namespace Basics.Algorithms.Sorts
{
    public static class Quick
    {
        public static void Sort<T>(T[] array) where T : IComparable<T>
        {
            array.Shuffle();

            Sort(array, 0, array.Length - 1);
        }

        private static void Sort<T>(T[] array, int lo, int hi) where T : IComparable<T>
        {
            if (hi <= lo) return;

            int j = Partition(array, lo, hi);
            Sort(array, lo, j - 1);
            Sort(array, j + 1, hi);
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
