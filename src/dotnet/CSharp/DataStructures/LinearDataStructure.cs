using System;

namespace AlgDat.Dotnet.CSharp.DataStructures
{
    /// <summary>
    /// Abstract base class for all linear data structures.
    /// </summary>
    /// <remarks>
    /// A derived class must call the protected constructor to initialize a new instance.
    /// </remarks>
    /// <typeparam name="T">The type of the elements in the linear data structure.</typeparam>
    public abstract class LinearDataStructure<T>
    {
        /// <summary>
        /// The internal array to hold the elements.
        /// </summary>
        private T[] array;

        /// <summary>
        /// The current count of elements in the internal array.
        /// </summary>
        protected int count;

        /// <summary>
        /// The capacity of the internal array.
        /// </summary>
        protected int capacity;

        /// <summary>
        /// Initializes a new instance with the provided initial capacity.
        /// </summary>
        /// <param name="initialCapacity"></param>
        protected LinearDataStructure(in int initialCapacity)
        {
            if(initialCapacity < 1)
                throw new ArgumentException("Initial length mnust be positive");
            array = new T[initialCapacity];
            capacity = array.Length;
        }

        /// <summary>
        /// Gets the current number of elements in the linear data structure.
        /// </summary>
        public int Count => count;

        /// <summary>
        /// Gets a booolean value indicating whether or not the elements of the linear data structure can be sorted.
        /// </summary>
        /// <remarks>
        /// The elements are sortable by this determination, when the elements of type <see cref="{T}"/> implements <see cref="IComparable{T}"/>.
        /// </remarks>
        public virtual bool IsSortable => typeof(IComparable<T>).IsAssignableFrom(typeof(T));

        /// <summary>
        /// Copies all values of the internal array 
        /// </summary>
        /// <param name="newArray"></param>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="InvalidOperationException">Thrown when the capacity of the new array is less than the capacity of the internal array.</exception>
        protected virtual void CopyTo(T[] newArray)
        {
            if(newArray is null)
                throw new ArgumentNullException(nameof(newArray));
            if(newArray.Length < capacity)
                throw new InvalidOperationException("Cannot copy when all elements will not fit in new array.");
            for(int i = 0; i < capacity; i++)
                newArray[i] = array[i];
        }

        /// <summary>
        /// Throws an exception when the provided index is out of bounds of the internal array.
        /// </summary>
        /// <param name="index"></param>
        protected virtual void HandlePotentialOutOfBoundsIndexAccess(in int index)
        {
            string message = $"Requested index was {index}.";
            if(index < 0)
                ThrowIndexOutOfLowerBound(additionalMessage: message);
            else if(index >= capacity)
                ThrowIndexOutOfUpperBound(additionalMessage: message);
        }

        /// <summary>
        /// Inserts the provided element at the provided index into the internal array.
        /// </summary>
        /// <param name="element">The element to insert</param>
        /// <param name="index">The index to insert the element</param>
        /// <exception cref="IndexOutOfRangeException"/>
        protected void Insert(in T element, in int index)
        {
            if(!IndexInRange(index))
                HandlePotentialOutOfBoundsIndexAccess(index);
            array[index] = element;
            count++;
        }

        /// <summary>
        /// Removes the element at the prvided index from the internal array.
        /// </summary>
        /// <exception cref="IndexOutOfRangeException"/>
        protected void Remove(in int index)
        {
            if(!IndexInRange(index))
                HandlePotentialOutOfBoundsIndexAccess(index);
            array[index] = default;
            count--;
        }

        /// <summary>
        /// Resizes the internal array to the new disired size. This operation is O(n).
        /// </summary>
        /// <remarks>
        /// The resizing discards all elements with indices > newLength - 1.
        /// </remarks>
        /// <param name="newLength">The desired new length of the internal array.</param>
        protected void ResizeTo(in int newLength)
        {
            if(newLength == capacity) return;
            T[] newArray = new T[newLength];
            CopyTo(newArray);
            array = newArray;
            capacity = array.Length;
        }

        /// <summary>
        /// Determines whether or not the provided index is within the bounds og the internal array.
        /// </summary>
        protected bool IndexInRange(in int index)
            => index >= 0 && index < capacity;

        protected static void ThrowIndexOutOfLowerBound(string additionalMessage = "")
        {
            const string outOfLower = "Index was outside lower bound.";
            string message = $"{outOfLower}{(additionalMessage != "" ? $" {additionalMessage}" : String.Empty)}";
            throw new IndexOutOfRangeException(message);
        }

        protected static void ThrowIndexOutOfUpperBound(string additionalMessage = "")
        {
            const string outOfUpper = "Index was outside upper bound.";
            string message = $"{outOfUpper}{(additionalMessage != "" ? $" {additionalMessage}" : String.Empty)}";
            throw new IndexOutOfRangeException(message);
        }
    }
}