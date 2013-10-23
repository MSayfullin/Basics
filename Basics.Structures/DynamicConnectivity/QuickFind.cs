using System;

namespace Basics.Structures.DynamicConnectivity
{
    public class QuickFind : UnionFind
    {
        public QuickFind(int size) : base(size)
        {
        }

        public override bool IsConnected(int p, int q)
        {
            return elements[p] == elements[q];
        }

        public override void Union(int p, int q)
        {
            var pid = elements[p];
            var qid = elements[q];
            for (int i = 0; i < elements.Length; i++)
            {
                if (elements[i] == pid) elements[i] = qid;
            }
        }
    }
}
