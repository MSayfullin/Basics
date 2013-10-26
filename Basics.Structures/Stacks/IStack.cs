using System;
using System.Collections.Generic;

namespace Basics.Structures
{
    public interface IStack<T> : IEnumerable<T>
    {
        /// <summary>
        /// Pushes value to the stack.
        /// </summary>
        void Push(T value);

        /// <summary>
        /// Pops value out of the stack.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when stack is empty.</exception>
        T Pop();

        /// <summary>
        /// Checks whether stack is empty.
        /// </summary>
        bool IsEmpty { get; }

        /// <summary>
        /// Returns size of the stack.
        /// </summary>
        int Size { get; }
    }
}
