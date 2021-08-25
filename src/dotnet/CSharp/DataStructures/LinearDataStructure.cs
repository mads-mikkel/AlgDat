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
        /// The number of elements not yet utilized
        /// </summary>
        protected int EmptyCapacity => TotalCapacity - count;

        /// <summary>
        /// The capacity of the internal array.
        /// </summary>
        protected int TotalCapacity => array.Length;

        /// <summary>
        /// Initializes a new instance with the provided initial capacity.
        /// </summary>
        /// <param name="initialCapacity"></param>
        protected LinearDataStructure(in int initialCapacity)
        {
            if(initialCapacity < 1)
                throw new ArgumentException("Initial length mnust be positive");
            array = new T[initialCapacity];
        }

        /// <summary>
        /// Gets the current number of elements in the linear data structure.
        /// </summary>
        public int Count => count;

        /// <summary>
        /// Gets a value indicating whether or not this linear data structure is empty or not, i.e. contains one or more elements.
        /// </summary>
        public bool IsEmpty => count == 0;

        /// <summary>
        /// Gets a value indicating whether or not this linear data structure is full or not, i.e. all indices have an element.
        /// </summary>
        public bool IsFull => count == TotalCapacity;

        /// <summary>
        /// Gets a booolean value indicating whether or not the elements of the linear data structure can be sorted.
        /// </summary>
        /// <remarks>
        /// The elements are sortable by this determination, when the elements of type <see cref="{T}"/> implements <see cref="IComparable{T}"/>.
        /// </remarks>
        public virtual bool IsSortable => typeof(IComparable<T>).IsAssignableFrom(typeof(T));

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException"/>
        public T this[int index]
        {
            get
            {
                ThrowOnIndexOutOfBounds(index);
                return array[index];
            }
            set
            {
                ThrowOnIndexOutOfBounds(index);
                Insert(value, index);
            }
        }

        /// <summary>
        /// Copies all values of the internal array 
        /// </summary>
        /// <param name="newArray"></param>
        /// <exception cref="ArgumentNullException"/>
        /// <exception cref="InvalidOperationException">Thrown when the capacity of the new array is less than the capacity of the internal array.</exception>
        protected void CopyTo(T[] newArray)
        {
            if(newArray is null)
                throw new ArgumentNullException(nameof(newArray));
            if(newArray.Length < count)
                throw new InvalidOperationException("Cannot copy when all elements will not fit in new array.");
            if(count > 0)
                for(int i = 0; i < count; i++)
                    newArray[i] = array[i];
        }

        /// <summary>
        /// Throws an exception when the provided index is out of bounds of the internal array.
        /// </summary>
        /// <param name="index"></param>
        /// <exception cref="IndexOutOfRangeException"/>
        protected virtual void HandlePotentialOutOfBoundsIndexAccess(in int index)
        {
            string message = $"Requested index was {index}.";
            if(index < 0)
                ThrowIndexOutOfLowerBound(additionalMessage: message);
            else if(index >= TotalCapacity)
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
        /// Removes the element at the provided index from the internal array.
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
        /// <param name="newCapacity">The desired new length of the internal array.</param>
        protected void ResizeTo(in int newCapacity)
        {
            if(newCapacity < 0)
                throw new ArgumentException("Provided new capacity cannot be negative.");
            if(newCapacity == TotalCapacity)    // if equal size, nothing to resize.
                return;
            if(count > 0)
            {
                T[] newArray = new T[newCapacity];
                CopyTo(newArray);
                array = newArray;   // When TotalCapacity is invoked after this statement, the value will be correct.
            }
        }

        /// <summary>
        /// Determines whether or not the provided index is within the bounds og the internal array.
        /// </summary>
        protected bool IndexInRange(in int index)
            => index >= 0 && index < TotalCapacity;

        /// <summary>
        /// Checks whether the provided index is within the bound of the internal array. Throws <see cref="IndexOutOfRangeException"/> when the index is outside of the bounds.
        /// </summary>
        /// <param name="index">The index to determine whether or not is inside the bounds.</param>
        /// <exception cref="IndexOutOfRangeException"/>
        protected void ThrowOnIndexOutOfBounds(in int index)
        {
            if(!IndexInRange(index))
                HandlePotentialOutOfBoundsIndexAccess(index);
        }

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