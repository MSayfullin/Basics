using System;

namespace Basics.Structures
{
    public class QueueOnList<T> : LinkedListBase<T>, IQueue<T>
    {
        private Node<T> _tail = null;

        /// <summary>
        /// Enqueues value to the queue.
        /// </summary>
        public void Enqueue(T value)
        {
            _size++;
            var node = new Node<T> { Value = value };
            if (_tail != null)
                _tail.Next = node;
            else
                _head = node;
            _tail = node;
        }

        /// <summary>
        /// Dequeues value out of the queue.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when queue is empty.</exception>
        public T Dequeue()
        {
            if (_head == null)
                throw new InvalidOperationException("Queue is empty.");

            _size--;
            var current = _head;
            _head = _head.Next;
            return current.Value;
        }

        /// <summary>
        /// Checks whether queue is empty.
        /// </summary>
        public bool IsEmpty
        {
            get { return _head == null; }
        }

        /// <summary>
        /// Returns size of the queue.
        /// </summary>
        public int Size
        {
            get { return _size; }
        }
    }
}
