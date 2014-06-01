using System;
using Basics.Structures;

namespace Basics.Algorithms.Sorts
{
    public static class Heap
    {
        public static void Sort<T>(T[] array) where T : IComparable<T>
        {
            var length = array.Length - 1;
            for (int i = length / 2; i >= 0; i--)
            {
                array.SinkFrom(i, length);
            }
            while (length > 0)
            {
                array.Exchange(0, length);
                array.SinkFrom(0, --length);
            }
        }

        private static void SinkFrom<T>(this T[] elements, int position, int length) where T : IComparable<T>
        {
            while (position * 2 + 1 <= length)
            {
                int j = position * 2 + 1;
                if (j < length && elements[j].IsLessThan(elements[j + 1]))
                    j++;
                if (elements[position].IsLessThan(elements[j]))
                {
                    elements.Exchange(j, position);
                    position = j;
                }
                else break;
            }
        }
    }
}
