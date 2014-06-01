using System;

namespace Basics.Structures
{
    public static class ArrayExtensions
    {
        /// <summary>
        /// Swaps two elements of an array inplace.
        /// </summary>
        public static void Exchange<T>(this T[] source, int i, int j)
        {
            var tmp = source[i];
            source[i] = source[j];
            source[j] = tmp;
        }

        /// <summary>
        /// Resizes array to the given new size.
        /// </summary>
        /// <param name="newSize">Size of the new array.</param>
        /// <returns>
        /// New array with the size specified.
        /// Elements that suit new size are transfered as well.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when new size is negative.</exception>
        public static T[] ResizeTo<T>(this T[] source, int newSize)
        {
            return source.ResizeTo(newSize, 0, Math.Min(source.Length, newSize));
        }

        /// <summary>
        /// Resizes array to the given new size with specifying boundaries for elements copying.
        /// </summary>
        /// <param name="newSize">Size of the new array.</param>
        /// <param name="start">Start index in source array for copying elements.</param>
        /// <param name="finish">Exclusive finish index in source array for copying elements.</param>
        /// <returns>
        /// New array with the size specified.
        /// Elements from start to finish indexes are transfered as well.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when new size is negative or start index is less than finish index.
        /// </exception>
        public static T[] ResizeTo<T>(this T[] source, int newSize, int start, int finish)
        {
            if (newSize < 0)
                throw new ArgumentOutOfRangeException("New size cannot be negative.");

            if (start > finish)
                throw new ArgumentOutOfRangeException("Finish index cannot be less than start index.");

            var newArray = new T[newSize];
            for (int i = start; i < finish; i++)
            {
                newArray[i - start] = source[i];
            }
            return newArray;
        }
    }
}
