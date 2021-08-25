using System;
using Xunit;
using AlgDat.Dotnet.CSharp.DataStructures;

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
        }
    }
}