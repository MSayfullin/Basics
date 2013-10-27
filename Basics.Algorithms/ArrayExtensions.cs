using System;

namespace Basics.Algorithms
{
    internal static class ArrayExtensions
    {
        public static void Exchange<T>(this T[] source, int i, int j)
        {
            var tmp = source[i];
            source[i] = source[j];
            source[j] = tmp;
        }
    }
}
