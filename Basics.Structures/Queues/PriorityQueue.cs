using System;
using System.Collections;
using System.Collections.Generic;

namespace Basics.Structures.Queues
{
    public abstract class PriorityQueue<T> : IEnumerable<T> where T : IComparable<T>
    {
        private const int initialSize = 8;

        private int index;
        private T[] _elements;

        protected PriorityQueue()
        {
            index = 0;
            _elements = new T[initialSize];
        }

        /// <summary>
        /// Enqueues value to the queue.
        /// </summary>
        public void Enqueue(T value)
        {
            _elements[++index] = value;
            SwimFrom(index);

            if (index == _elements.Length - 1)
                _elements = _elements.ResizeTo(_elements.Length * 2);
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
            get { return index; }
        }

        /// <summary>
        /// Returns root element from queue without dequeueing it.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when queue is empty.</exception>
        protected T RootElement
        {
            get
            {
                if (Size == 0)
                    throw new InvalidOperationException("Queue is empty.");

                return _elements[1];
            }
        }

        /// <summary>
        /// Dequeues root element out of the queue.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when queue is empty.</exception>
        protected T DequeueRootElement()
        {
            if (Size == 0)
                throw new InvalidOperationException("Queue is empty.");

            var max = _elements[1];
            _elements.Exchange(1, index--);
            // clean up resources
            _elements[index + 1] = default(T);
            SinkFrom(1);

            if (_elements.Length > initialSize && index == _elements.Length / 4)
                _elements = _elements.ResizeTo(_elements.Length / 2);

            return max;
        }

        protected abstract bool ShouldExchange(T value, T otherValue);

        private void SwimFrom(int position)
        {
            while (position > 1 && ShouldExchange(_elements[position / 2], _elements[position]))
            {
                _elements.Exchange(position / 2, position);
                position = position / 2;
            }
        }

        private void SinkFrom(int position)
        {
            while (position * 2 <= index)
            {
                int j = position * 2;
                if (j < index && ShouldExchange(_elements[j], _elements[j + 1]))
                    j++;
                if (ShouldExchange(_elements[position], _elements[j]))
                {
                    _elements.Exchange(j, position);
                    position = j;
                }
                else break;
            }
        }

        #region IEnumerable Members

        // copy constructor, necessary for Enumerator implementation
        protected PriorityQueue(T[] source, int length)
        {
            _elements = new T[length];
            for (int i = 1; i < length; i++)
            {
                _elements[i] = source[i];
            }
            index = length - 1;
        }

        protected abstract PriorityQueue<T> GetCopy(T[] source, int length);

        public IEnumerator<T> GetEnumerator()
        {
            var queueCopy = GetCopy(_elements, index + 1);
            while (!queueCopy.IsEmpty)
                yield return queueCopy.DequeueRootElement();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
