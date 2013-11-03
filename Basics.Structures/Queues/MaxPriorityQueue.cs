using System;
using System.Collections;
using System.Collections.Generic;
using Basics.Algorithms;
using Basics.Algorithms.Sorts;

namespace Basics.Structures.Queues
{
    public class MaxPriorityQueue<T> : IEnumerable<T> where T : IComparable<T>
    {
        private const int initialSize = 8;

        private int index;
        private T[] _elements;

        public MaxPriorityQueue()
        {
            index = 0;
            _elements = new T[initialSize];
        }

        // need this constructor only for Enumerator implementation
        private MaxPriorityQueue(T[] source, int length)
        {
            _elements = new T[length];
            for (int i = 1; i < length; i++)
            {
                _elements[i] = source[i];
            }
            index = length - 1;
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
        /// Dequeues maximum value out of the queue.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when queue is empty.</exception>
        public T DequeueMax()
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

        /// <summary>
        /// Returns maximum value without dequeueing it.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when queue is empty.</exception>
        public T Max
        {
            get
            {
                if (Size == 0)
                    throw new InvalidOperationException("Queue is empty.");

                return _elements[1];
            }
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

        private void SwimFrom(int position)
        {
            while (position > 1 && _elements[position / 2].IsLessThan(_elements[position]))
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
                if (j < index && _elements[j].IsLessThan(_elements[j + 1]))
                    j++;
                if (_elements[position].IsLessThan(_elements[j]))
                {
                    _elements.Exchange(j, position);
                    position = j;
                }
                else break;
            }
        }

        #region IEnumerable Members

        public IEnumerator<T> GetEnumerator()
        {
            var queueCopy = new MaxPriorityQueue<T>(_elements, index + 1);
            while (!queueCopy.IsEmpty)
                yield return queueCopy.DequeueMax();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion
    }
}
