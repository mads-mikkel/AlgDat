using System;

namespace AlgDat.Dotnet.CSharp.DataStructures
{
    /// <summary>
    /// Represents the List data structure.
    /// </summary>
    /// <typeparam name="T">The type of the elements contained in the list.</typeparam>
    public class List<T>: LinearDataStructure<T>
    {
        private const int InitialCapacity = 16;

        /// <summary>
        /// Initializes a new list.
        /// </summary>
        public List() : base(InitialCapacity) { }

        /// <summary>
        /// Adds the provided element at the end of this list.
        /// </summary>
        /// <param name="element">The element to add.</param>
        public void Add(T element)
        {
            if(count == capacity)
                ResizeTo(capacity + 16);
            Insert(element, count);
        }

        /// <summary>
        /// Removes the element at the provided index.
        /// </summary>
        /// <param name="index">The index in this List</param>
        /// <exception cref="IndexOutOfRangeException"/>
        public void RemoveAt(in int index)
        {
            ThrowOnIndexOutOfBounds(index);
            Remove(index);
        }
    }
}