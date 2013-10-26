using System;
using System.Collections;
using System.Collections.Generic;

namespace Basics.Structures
{
    public class StackOnArray<T> : IStack<T>
    {
        private const int initialSize = 4;

        private int index = 0;
        private T[] _elements = new T[initialSize];

        /// <summary>
        /// Pushes value to the stack.
        /// </summary>
        public void Push(T value)
        {
            _elements[index++] = value;

            if (index == _elements.Length)
                Resize(_elements.Length * 2);
        }

        /// <summary>
        /// Pops value out of the stack.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when stack is empty.</exception>
        public T Pop()
        {
            if (index == 0)
                throw new InvalidOperationException("Stack is empty.");

            var element = _elements[--index];
            // clean up resources
            _elements[index] = default(T);

            if (_elements.Length > initialSize && index == _elements.Length / 4)
                Resize(_elements.Length / 2);

            return element;
        }

        /// <summary>
        /// Checks whether stack is empty.
        /// </summary>
        public bool IsEmpty
        {
            get { return index == 0; }
        }

        /// <summary>
        /// Returns size of the stack.
        /// </summary>
        public int Size
        {
            get { return index; }
        }

        private void Resize(int newSize)
        {
            var newArray = new T[newSize];
            for (int i = 0; i < index; i++)
            {
                newArray[i] = _elements[i];
            }
            _elements = newArray;
        }

        #region IEnumerable Members

        public IEnumerator<T> GetEnumerator()
        {
            return new ArrayEnumerator<T>(_elements, index);
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
                int enumerationIndex = index;
                while (enumerationIndex > 0)
                    yield return _elements[--enumerationIndex];
            }
        }

        private struct ArrayEnumerator<X> : IEnumerator<X>
        {
            private int index;
            private int startIndex;
            private X[] _elements;

            public ArrayEnumerator(X[] elements, int index)
            {
                startIndex = index;
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
                if (index == -1)
                    index = startIndex;

                index--;
                return index > 0;
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
