﻿using System;
using System.Collections.Generic;

namespace Basics.Structures.Queues
{
    public class MaxPriorityQueue<T> : PriorityQueue<T>, IEnumerable<T> where T : IComparable<T>
    {
        public MaxPriorityQueue() : base()
        {
        }

        /// <summary>
        /// Dequeues maximum value out of the queue.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when queue is empty.</exception>
        public T DequeueMax()
        {
            return DequeueRootElement();
        }

        /// <summary>
        /// Returns maximum value without dequeueing it.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when queue is empty.</exception>
        public T Max
        {
            get { return RootElement; }
        }

        protected override bool ShouldExchange(T value, T otherValue)
        {
            return value.IsLessThan(otherValue);
        }

        #region IEnumerable Members

        // copy constructor, necessary for Enumerator implementation
        private MaxPriorityQueue(T[] source, int length) : base(source, length)
        {
        }

        protected override PriorityQueue<T> GetCopy(T[] source, int length)
        {
            return new MaxPriorityQueue<T>(source, length);
        }

        #endregion
    }
}
