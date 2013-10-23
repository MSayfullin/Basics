using System;

namespace Basics.Structures.DynamicConnectivity
{
    public abstract class UnionFind
    {
        protected int[] elements;

        public UnionFind(int size)
        {
            elements = new int[size];
            for (int i = 0; i < size; i++)
            {
                elements[i] = i;
            }
        }

        public abstract bool IsConnected(int p, int q);
        public abstract void Union(int p, int q);

        public int Size()
        {
            return elements.Length;
        }
    }
}
