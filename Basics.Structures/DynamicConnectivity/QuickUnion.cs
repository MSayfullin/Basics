using System;

namespace Basics.Structures.DynamicConnectivity
{
    public class QuickUnion : UnionFind
    {
        public QuickUnion(int size) : base(size)
        {
        }

        protected virtual int RootRecursive(int x)
        {
            int xid = elements[x];
            if (x == xid)
                return x;
            return RootRecursive(xid);
        }

        protected virtual int Root(int x)
        {
            while (x != elements[x])
                x = elements[x];
            return x;
        }

        public override bool IsConnected(int p, int q)
        {
            return Root(p) == Root(q);
            //return RootRecursive(p) == RootRecursive(q);
        }

        public override void Union(int p, int q)
        {
            // roots are indexes themselves
            // so we can easily use them to navigate inside array
            var pRoot = Root(p);
            var qRoot = Root(q);
            //var pRoot = RootRecursive(p);
            //var qRoot = RootRecursive(q);
            elements[pRoot] = qRoot;
        }
    }
}
