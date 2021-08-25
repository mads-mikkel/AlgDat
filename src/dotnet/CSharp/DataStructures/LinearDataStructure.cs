using System;

namespace AlgDat.Dotnet.CSharp.DataStructures
{
    public abstract class LinearDataStructure<T>
    {
        private T[] array;
        protected int count;
        protected int length;

        protected LinearDataStructure(in int initialLength)
        {
            if(initialLength < 1)
                throw new ArgumentException("Initial length mnust be positive");
            array = new T[initialLength];
        }

        protected void Insert(in T element, in int index)
        {            
            if(index < 0)   // Don't check T, just allow nulls.
                throw new IndexOutOfRangeException("Requested index was outside the negative bound.");
            if(index > length)
                throw new IndexOutOfRangeException("Requested index was outside the positive bound.");
            array[index] = element;
            count++;
        }

        protected void Remove(in int index)
        {

        }

        public virtual bool IsSortable => typeof(IComparable<T>).IsAssignableFrom(typeof(T));
    }
}
