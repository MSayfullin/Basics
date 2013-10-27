using System;

namespace Basics.Algorithms.Sorts
{
    public static class Selection
    {
        public static void Sort<T>(T[] array) where T : IComparable<T>
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j].IsLessThan(array[i]))
                        array.Exchange(i, j);
                }
            }
        }
    }
}
