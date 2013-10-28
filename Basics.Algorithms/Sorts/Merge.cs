using System;

namespace Basics.Algorithms.Sorts
{
    public static class Merge
    {
        private const int CutOff = 7;

        public static void Sort<T>(T[] array) where T : IComparable<T>
        {
            var aux = new T[array.Length];
            Sort(array, aux, 0, array.Length - 1);
        }

        private static void Sort<T>(T[] array, T[] aux, int lo, int hi) where T : IComparable<T>
        {
            //if (lo >= hi) return;

            if (hi - lo < CutOff)
                Insertion.Sort(array, lo, hi);
            else
            {
                var mid = (hi - lo) / 2 + lo;
                Sort(array, aux, lo, mid);
                Sort(array, aux, mid + 1, hi);

                // subarrays are already sorted
                if (array[mid].IsLessThan(array[mid + 1])) return;

                MergeImpl(array, aux, lo, mid, hi);
            }
        }

        private static void MergeImpl<T>(T[] array, T[] aux, int lo, int mid, int hi) where T : IComparable<T>
        {
            for (int k = lo; k <= hi; k++)
            {
                aux[k] = array[k];
            }

            int i = lo;
            int j = mid + 1;
            for (int k = lo; k <= hi; k++)
            {
                if (i > mid)
                    array[k] = aux[j++];
                else if (j > hi)
                    array[k] = aux[i++];
                else if (aux[i].IsLessThan(aux[j]))
                    array[k] = aux[i++];
                else
                    array[k] = aux[j++];
            }
        }
    }
}
