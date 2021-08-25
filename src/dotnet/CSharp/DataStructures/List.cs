using System;

namespace AlgDat.Dotnet.CSharp.DataStructures
{
    public class List<T>: LinearDataStructure<T>
    {
        public List() : base(16) { }

        public void Add(T element)
        {
            if(count == capacity)
                ResizeTo(capacity + 16);
            Insert(element, count);
        }
    }
}
