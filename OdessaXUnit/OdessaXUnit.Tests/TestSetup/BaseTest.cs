using Xunit;

namespace OdessaXUnit.Tests
{
    // Xunit collection fixture:
    // https://xunit.github.io/docs/shared-context.html#collection-fixture
    [Collection(nameof(TestContext))]
    public abstract class BaseTest
    {
    }
}