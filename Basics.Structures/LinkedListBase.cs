using System;
using System.Collections;
using System.Collections.Generic;

namespace Basics.Structures
{
    public abstract class LinkedListBase<T> : IEnumerable<T>
    {
        protected class Node<X>
        {
            public X Value { get; set; }
            public Node<X> Next { get; set; }
        }

        protected int _size = 0;
        protected Node<T> _head = null;

        protected LinkedListBase()
        {
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
