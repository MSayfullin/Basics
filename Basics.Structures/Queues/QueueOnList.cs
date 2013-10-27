using System;
using System.Collections;
using System.Collections.Generic;

namespace Basics.Structures
{
    public class QueueOnList<T> : IQueue<T>
    {
        private class Node<X>
        {
            public X Value { get; set; }
            public Node<X> Next { get; set; }
        }

        private int _size = 0;
        private Node<T> _head = null;
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

        #region IEnumerable Members

        public IEnumerator<T> GetEnumerator()
        {
            return new LinkedListEnumerator<T>(_head);
            //return YieldEnumerator;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        #region Enumerators

        private IEnumerator<T> YieldEnumerator
        {
            get
            {
                var current = _head;
                while (current != null)
                {
                    yield return current.Value;
                    current = current.Next;
                }
            }
        }

        private struct LinkedListEnumerator<X> : IEnumerator<X>
        {
            private readonly Node<X> _head;
            private Node<X> _current;

            public LinkedListEnumerator(Node<X> head)
            {
                _head = head;
                _current = null;
            }

            public X Current
            {
                get
                {
                    if (_current == null)
                        throw new InvalidOperationException("Current is undefined. Call MoveNext first.");

                    return _current.Value;
                }
            }

            public bool MoveNext()
            {
                _current = _current == null ? _head : _current.Next;
                return _current != null;
            }

            public void Reset()
            {
                _current = null;
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            #region IDisposable Members

            public void Dispose()
            {
                // nothing to dispose
            }

            #endregion
        }

        #endregion
    }
}
