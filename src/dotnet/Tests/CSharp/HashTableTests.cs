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
        public void Works()
        {
            // Assert:
            HashTable<string, string> phoneBook = new();
            string aspitKey = "AspIT", aspitPhone = "33 34 49 01";
            (string key, string value) kvPair = (aspitKey, aspitPhone);

            // Act:
            phoneBook.Add(kvPair);
            var s = phoneBook.ToString();
            int keyIndex = phoneBook.IndexOf(aspitKey);
            
            // 
            Assert.True(phoneBook.Count == 1);
            Assert.True(phoneBook.IsEmpty == false);
            s += $" |Index: {keyIndex}";
            output.WriteLine(s);
        }
    }
}
