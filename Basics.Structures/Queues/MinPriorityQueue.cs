using System;
using System.Collections.Generic;

namespace Basics.Structures.Queues
{
    public class MinPriorityQueue<T> : PriorityQueue<T>, IEnumerable<T> where T : IComparable<T>
    {
        public MinPriorityQueue() : base()
        {
        }

        /// <summary>
        /// Dequeues minimum value out of the queue.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when queue is empty.</exception>
        public T DequeueMin()
        {
            return DequeueRootElement();
        }

        /// <summary>
        /// Returns minimum value without dequeueing it.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when queue is empty.</exception>
        public T Min
        {
            get { return RootElement; }
        }

        protected override bool ShouldExchange(T value, T otherValue)
        {
            return value.IsGreaterThan(otherValue);
        }

        #region IEnumerable Members

        // copy constructor, necessary for Enumerator implementation
        private MinPriorityQueue(T[] source, int length) : base(source, length)
        {
        }

        protected override PriorityQueue<T> GetCopy(T[] source, int length)
        {
            return new MinPriorityQueue<T>(source, length);
        }

        #endregion
    }
}
