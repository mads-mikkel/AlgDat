using System;
using Xunit;
using Xunit.Abstractions;

using CSharp.DataStructures;

namespace Tests.CSharp
{
    public class HashTableTests//:TestBase
    {
        protected readonly ITestOutputHelper output;
        public HashTableTests(ITestOutputHelper output) => this.output = output;

        [Fact]
        public void CanAddOne()
        {
            // Arrange:
            HashTable<string, string> phoneBook = new(10);
            string aspitKey = "AspIT", aspitPhone = "33 34 49 01";
            (string key, string value) kvPair = (aspitKey, aspitPhone);

            // Act:
            phoneBook.Add(kvPair);
            var s = phoneBook.ToString();
            int keyIndex = phoneBook.IndexOf(aspitKey);

            // Assert:
            Assert.True(phoneBook.Count == 1);
            Assert.True(phoneBook.IsEmpty == false);
            s += $" |Index: {keyIndex}";
            output.WriteLine(s);
        }


        [Fact]
        public void CanAddManyValueTypes()
        {
            // Arrange:
            HashTable<string, char> charMap = new(200);
            
            // Act:
            for(char c = '\u0020'; c < '\u007E'; c++)
                charMap.Add(($"{c}", c));
            
            output.WriteLine(charMap.ToString());
            Assert.Equal(94, charMap.Count);
        }

        [Fact]
        public void CanAddManyReferenceTypes()
        {
            // Arrange:
            HashTable<string, int> stringMap = new(200);
            Random generator = new();
            // Act:
            for(int i = 0; i < 10000; i++)
            {
                int randomNumber = generator.Next();
                stringMap.Add((randomNumber.ToString(), randomNumber));
            }

            output.WriteLine(stringMap.ToString());
            Assert.Equal(10000, stringMap.Count);
        }
    }
}
