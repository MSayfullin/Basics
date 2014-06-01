using System;
using Basics.Structures;

namespace Basics.Algorithms.Sorts
{
    public static class Quick3Way
    {
        public static void Sort<T>(T[] array) where T : IComparable<T>
        {
            array.Shuffle();

            Sort(array, 0, array.Length - 1);
        }

        private static void Sort<T>(T[] array, int lo, int hi) where T : IComparable<T>
        {
            if (hi <= lo) return;

            int lt = lo;
            int gt = hi;
            int i = lo + 1;
            var v = array[lo];
            while (i <= gt)
            {
                var cmp = array[i].CompareTo(v);
                if (cmp < 0)
                    array.Exchange(i++, lt++);
                else if (cmp > 0)
                    array.Exchange(i, gt--);
                else i++;
            }

            Sort(array, lo, lt - 1);
            Sort(array, gt + 1, hi);
        }
    }
}
