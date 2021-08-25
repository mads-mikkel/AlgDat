using System;
using Xunit;
using AlgDat.Dotnet.CSharp.DataStructures;

namespace AlgDat.Dotnet.Tests.CSharp
{
    public class StackTests
    {
        [Fact]
        public void CanPushOne()
        {
            // Arrange:
            Stack<string> stringStack = new();
            string s = "Hello, stack";

            // Act:
            stringStack.Push(s);

            // Assert:
            Assert.True(stringStack.Count == 1);
        }

        [Fact]
        public void CanPopOne()
        {
            // Arrange:
            Stack<string> stringStack = new();

            // Actsert:
            Assert.Equal(0, stringStack.Count);
            string s = "Pop me!";

            stringStack.Push(s);
            Assert.Equal(1, stringStack.Count);

            string popper = stringStack.Pop();
            Assert.Equal(0, stringStack.Count);
            Assert.Equal(s, popper);
        }

        [Fact]
        public void CanPushAndPopALot()
        {
            // Arrange:
            Stack<string> stringStack = new();
            string s = "Pop me!";

            // Actsert
            Assert.Equal(0, stringStack.Count);
            stringStack.Push(s);
            Assert.Equal(1, stringStack.Count);
            stringStack.Push(s);
            Assert.Equal(2, stringStack.Count);
            stringStack.Pop();
            Assert.Equal(1, stringStack.Count);
            stringStack.Push(s);
            Assert.Equal(2, stringStack.Count);
            stringStack.Pop();
            Assert.Equal(1, stringStack.Count);
            stringStack.Pop();
            Assert.Equal(0, stringStack.Count);
        }

        [Fact]
        public void CanPeek()
        {
            // Arrange:
            Stack<int> stack = new();
            stack.Push(42);
            Assert.Equal(1, stack.Count);

            // Actsert:
            int top = stack.Peek();
            Assert.Equal(1, stack.Count);
            Assert.Equal(42, top);
            stack.Push(47);
            Assert.Equal(2, stack.Count);
            top = stack.Peek();
            Assert.Equal(47, top);
        }
    }
}