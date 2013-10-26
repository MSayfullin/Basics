using System;
using System.Collections.Generic;

namespace Basics.Structures
{
    public interface IQueue<T> : IEnumerable<T>
    {
        /// <summary>
        /// Enqueues value to the queue.
        /// </summary>
        void Enqueue(T value);

        /// <summary>
        /// Dequeues value out of the queue.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when queue is empty.</exception>
        T Dequeue();

        /// <summary>
        /// Checks whether queue is empty.
        /// </summary>
        bool IsEmpty { get; }

        /// <summary>
        /// Returns size of the queue.
        /// </summary>
        int Size { get; }
    }
}
