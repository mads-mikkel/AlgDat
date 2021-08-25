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
        public void Test()
        {            

        }
    }
}
