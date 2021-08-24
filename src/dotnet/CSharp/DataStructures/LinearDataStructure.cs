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
                throw new ArgumentException("initial length mnust be positive");
            array = new T[initialLength];
        }

        protected virtual void Insert(T element, int index)
        {
            // Don't check T, just allow nulls.
            if(index < 0)
                throw new IndexOutOfRangeException("Requested index was outside the negative bound.");
            if(index > length)
                throw new IndexOutOfRangeException("Requested index was outside the positive bound.");
            array[index] = element;
        }

        public virtual bool IsSortable => typeof(T) is IComparable<T>;
    }
}
