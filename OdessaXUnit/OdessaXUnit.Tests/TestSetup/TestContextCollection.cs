using System;
using Xunit;

namespace OdessaXUnit.Tests
{
    // Xunit collection fixture:
    // https://xunit.github.io/docs/shared-context.html#collection-fixture
    [CollectionDefinition(nameof(TestContext))]
    public class TestContextCollection : ICollectionFixture<TestContext>
    {
    }
}