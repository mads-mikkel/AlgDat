using System;

namespace AlgDat.Dotnet.CSharp.DataStructures
{
    public class Stack<T>: LinearDataStructure<T>
    {
        private const int InitialCapacity = 1;

        public Stack() : base(InitialCapacity) { }

        /// <summary>
        /// Returns the top element without removing it from the stack.
        /// </summary>
        /// <returns>The top element of the stack</returns>
        public T Peek()
        {
            if(!IsEmpty)
                return this[count - 1];
            else
                throw new InvalidOperationException("Stack is empty. Nothing to peek");
        }

        /// <summary>
        /// Pops the top elements off of the stack.
        /// </summary>
        /// <returns>The element popped from the stack.</returns>
        public virtual T Pop()
        {
            if(!IsEmpty)
            {
                T popper = this[count - 1]; // Extract last element.
                Remove(count - 1);          // Sets the element at the index to default, and decrements the count by one.
                ResizeTo(count);            // Resize to the new count.
                return popper;              // Return the element
            }
            else throw new InvalidOperationException("The stack is empty, and therefore nothing can pop from it.");
        }

        /// <summary>
        /// Pushes the provided element ontop of the stack.
        /// </summary>
        /// <param name="element">The element to push onto the stack.</param>
        public virtual void Push(T element)
        {
            ResizeTo(TotalCapacity + 1);        // make internal array one bigger
            Insert(element, TotalCapacity - 1); // Insert as last element
        }
    }
}