using System;
using Xunit;

namespace OdessaXUnit.Tests
{
    [CollectionDefinition(nameof(TestContext))]
    public class TestContextCollection : ICollectionFixture<TestContext>
    {
    }
}