using System;
using System.Collections;
using System.Collections.Generic;

namespace Basics.Structures
{
    public class StackOnList<T> : IStack<T>
    {
        private class Node<X>
        {
            public X Value { get; set; }
            public Node<X> Next { get; set; }
        }

        private int _size = 0;
        private Node<T> _head = null;

        /// <summary>
        /// Pushes value to the stack.
        /// </summary>
        public void Push(T value)
        {
            _size++;
            _head = new Node<T>
            {
                Value = value,
                Next = _head
            };
        }

        /// <summary>
        /// Pops value out of the stack.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when stack is empty.</exception>
        public T Pop()
        {
            if (_head == null)
                throw new InvalidOperationException("Stack is empty.");

            _size--;
            var current = _head;
            _head = _head.Next;
            return current.Value;
        }

        /// <summary>
        /// Checks whether stack is empty.
        /// </summary>
        public bool IsEmpty
        {
            get { return _head == null; }
        }

        /// <summary>
        /// Returns size of the stack.
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

        private class LinkedListEnumerator<X> : IEnumerator<X>
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
