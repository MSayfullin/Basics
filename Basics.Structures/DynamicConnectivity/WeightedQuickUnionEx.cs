using System;

namespace Basics.Structures.DynamicConnectivity
{
    /// <summary>
    /// Weighted QuickUnion with Path Compression
    /// </summary>
    public class WeightedQuickUnionEx : WeightedQuickUnion
    {
        public WeightedQuickUnionEx(int size) : base(size)
        {
        }

        protected override int RootRecursive(int x)
        {
            elements[x] = elements[elements[x]];
            int xid = elements[x];
            if (x == xid)
                return x;
            return RootRecursive(xid);
        }

        protected override int Root(int x)
        {
            while (x != elements[x])
            {
                elements[x] = elements[elements[x]];
                x = elements[x];
            }
            return x;
        }
    }
}
