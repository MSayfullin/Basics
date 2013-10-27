using System;
using System.Collections;
using System.Collections.Generic;

namespace Basics.Structures
{
    public class QueueOnArray<T> : IQueue<T>
    {
        private const int initialSize = 4;

        private int headIndex = 0;
        private int tailIndex = 0;
        private T[] _elements = new T[initialSize];

        /// <summary>
        /// Enqueues value to the queue.
        /// </summary>
        public void Enqueue(T value)
        {
            _elements[tailIndex++] = value;

            if (tailIndex == _elements.Length)
                Resize(_elements.Length * 2);
        }

        /// <summary>
        /// Dequeues value out of the queue.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when queue is empty.</exception>
        public T Dequeue()
        {
            if (tailIndex == 0)
                throw new InvalidOperationException("Queue is empty.");

            var element = _elements[headIndex];
            // clean up resources
            _elements[headIndex++] = default(T);

            if (_elements.Length > initialSize && Size == _elements.Length / 4)
            {
                Resize(_elements.Length / 2);
                tailIndex = tailIndex - headIndex;
                headIndex = 0;
            }

            return element;
        }

        /// <summary>
        /// Checks whether queue is empty.
        /// </summary>
        public bool IsEmpty
        {
            get { return Size == 0; }
        }

        /// <summary>
        /// Returns size of the queue.
        /// </summary>
        public int Size
        {
            get { return tailIndex - headIndex; }
        }

        private void Resize(int newSize)
        {
            var newArray = new T[newSize];
            for (int i = headIndex; i < tailIndex; i++)
            {
                newArray[i - headIndex] = _elements[i];
            }
            _elements = newArray;
        }

        #region IEnumerable Members

        public IEnumerator<T> GetEnumerator()
        {
            return new ArrayEnumerator<T>(_elements, headIndex, tailIndex);
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
                int enumerationIndex = headIndex;
                int finish = tailIndex;
                while (enumerationIndex < finish)
                    yield return _elements[enumerationIndex++];
            }
        }

        private struct ArrayEnumerator<X> : IEnumerator<X>
        {
            private int index;
            private int start;
            private int finish;
            private X[] _elements;

            public ArrayEnumerator(X[] elements, int headIndex, int tailIndex)
            {
                start = headIndex;
                finish = tailIndex;
                this.index = -1;
                _elements = elements;
            }

            public X Current
            {
                get
                {
                    if (index == -1)
                        throw new InvalidOperationException("Current is undefined. Call MoveNext first.");

                    return _elements[index];
                }
            }

            public bool MoveNext()
            {
                index = index == -1 ? start : index + 1;

                return index < finish;
            }

            public void Reset()
            {
                index = -1;
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
