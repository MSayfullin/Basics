using System;

namespace Basics.Structures
{
    public class StackOnList<T> : LinkedListBase<T>, IStack<T>
    {
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
    }
}
