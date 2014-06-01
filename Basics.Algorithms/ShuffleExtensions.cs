using System;
using Basics.Structures;

namespace Basics.Algorithms
{
    public static class ShuffleExtensions
    {
        public static void Shuffle<T>(this T[] source)
        {
            var rnd = new Random();
            for (int i = 1; i < source.Length; i++)
            {
                source.Exchange(i, rnd.Next(i));
            }
        }
    }
}
