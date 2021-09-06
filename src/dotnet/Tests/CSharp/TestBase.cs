using Xunit.Abstractions;

namespace Tests.CSharp
{
    public abstract class TestBase
    {
        protected readonly ITestOutputHelper output;

        protected TestBase() { }
    }
}