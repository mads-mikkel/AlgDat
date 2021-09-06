using System;
using Xunit;
using CSharp.DataStructures;

namespace AlgDat.Dotnet.Tests.CSharp
{
    public class ListTests
    {
        [Fact]
        public void IComparableIsSortable()
        {
            // Arrange:
            List<int> intList = new();

            // Act:
            bool isSortable = intList.IsSortable;

            // Arrange:
            Assert.True(isSortable);
        }

        [Fact]
        public void CanAddFirstElement()
        {
            // Arrange:
            List<int> intList = new();
            int element = 42;
            
            // Act:
            intList.Add(element);

            // Arrange:
            Assert.True(intList.Count == 1);
            Assert.False(intList.IsEmpty);
        }

        [Fact]
        public void CanRemoveElementAtSpecificIndex()
        {
            // Arrange:
            List<int> intList = new();
            int element = 42;
            intList.Add(element);

            // Act:
            intList.RemoveAt(0);

            // Arrange:
            Assert.True(intList.IsEmpty);
        }

        [Fact]
        public void LLtest()
        {
            LinkedList<int> linkedList = new();
            linkedList.Add(45);
            linkedList.Add(100);
        }
    }
}