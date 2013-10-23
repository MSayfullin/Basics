using System;

namespace Basics.Structures.DynamicConnectivity
{
    public class WeightedQuickUnion : QuickUnion
    {
        private int[] sizes;

        public WeightedQuickUnion(int size) : base(size)
        {
            sizes = new int[size];
            for (int i = 0; i < size; i++)
            {
                sizes[i] = 1;
            }
        }

        public override void Union(int p, int q)
        {
            EthalonImplementation(p, q);
            //OptimizedVersion(p, q);
        }

        private void EthalonImplementation(int p, int q)
        {
            // roots are indexes themselves
            // so we can easily use them to navigate inside array
            var pRoot = Root(p);
            var qRoot = Root(q);
            //var pRoot = RootRecursive(p);
            //var qRoot = RootRecursive(q);
            if (sizes[pRoot] < sizes[qRoot])
            {
                elements[pRoot] = qRoot;
                sizes[pRoot] += sizes[qRoot];
            }
            else
            {
                elements[qRoot] = pRoot;
                sizes[qRoot] += sizes[pRoot];
            }
        }

        private void OptimizedVersion(int p, int q)
        {
            // roots are indexes themselves
            // so we can easily use them to navigate inside array
            var xRoot = Root(p);
            var yRoot = Root(q);
            //var xRoot = RootRecursive(p);
            //var yRoot = RootRecursive(q);
            if (sizes[xRoot] >= sizes[yRoot])
            {
                var tmp = yRoot;
                yRoot = xRoot;
                xRoot = tmp;
            }
            elements[xRoot] = yRoot;
            sizes[xRoot] += sizes[yRoot];
        }
    }
}
