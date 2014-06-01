using System;
using Basics.Structures;

namespace Basics.Algorithms
{
    public static class Inversion
    {
        /// <summary>
        /// For testing purposes only.
        /// </summary>
        internal static long CountBruteForce<T>(T[] array) where T : IComparable<T>, IComparable
        {
            long counter = 0;
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[i].IsGreaterThan(array[j])) counter++;
                }
            }
            return counter;
        }

        public static long Count<T>(T[] array) where T : IComparable<T>, IComparable
        {
            var aux = new T[array.Length];
            var copy = new T[array.Length];
            array.CopyTo(copy, 0);

            return Count<T>(copy, aux, 0, array.Length - 1);
        }

        private static long Count<T>(T[] array, T[] aux, int lo, int hi) where T : IComparable<T>, IComparable
        {
            if (lo >= hi) return 0;

            var mid = (hi - lo) / 2 + lo;
            var x = Count(array, aux, lo, mid);
            var y = Count(array, aux, mid + 1, hi);
            var z = MergeAndCount(array, aux, lo, mid, hi);
            return x + y + z;
        }

        private static long MergeAndCount<T>(T[] array, T[] aux, int lo, int mid, int hi) where T : IComparable<T>, IComparable
        {
            for (int k = lo; k <= hi; k++)
            {
                aux[k] = array[k];
            }

            int i = lo;
            int j = mid + 1;
            long counter = 0;
            for (int k = lo; k <= hi; k++)
            {
                if (i > mid)
                    array[k] = aux[j++];
                else if (j > hi)
                    array[k] = aux[i++];
                else if (aux[i].CompareTo(aux[j]) <= 0) // is less than or equal
                    array[k] = aux[i++];
                else
                {
                    array[k] = aux[j++];
                    counter += mid - i + 1;
                }
            }
            return counter;
        }
    }
}
