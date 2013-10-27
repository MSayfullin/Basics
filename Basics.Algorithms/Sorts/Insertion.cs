using System;

namespace Basics.Algorithms.Sorts
{
    public static class Insertion
    {
        public static void Sort<T>(T[] array) where T : IComparable<T>
        {
            //EthalonImplementation(array);
            ImplementationWithWhile(array);
        }

        private static void EthalonImplementation<T>(T[] array) where T : IComparable<T>
        {
            for (int i = 1; i < array.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (array[j].IsLessThan(array[j - 1]))
                        array.Exchange(j, j - 1);
                    else break;
                }
            }
        }

        private static void ImplementationWithWhile<T>(T[] array) where T : IComparable<T>
        {
            for (int i = 1; i < array.Length; i++)
            {
                int j = i;
                while (j > 0 && array[j].IsLessThan(array[j - 1]))
                {
                    array.Exchange(j, j - 1);
                    j--;
                }
            }
        }
    }
}
