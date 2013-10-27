using System;

namespace Basics.Algorithms.Sorts
{
    public static class Shell
    {
        public static void Sort<T>(T[] array) where T : IComparable<T>
        {
            int increment = 1;
            while (increment < array.Length / 3)
                increment = 3 * increment + 1;

            while (increment >= 1)
            {
                for (int i = increment; i < array.Length; i++)
                {
                    for (int j = i; j >= increment; j -= increment)
                    {
                        if (array[j].IsLessThan(array[j - increment]))
                            array.Exchange(j, j - increment);
                    }
                }
                increment = increment / 3;
            }
        }
    }
}
