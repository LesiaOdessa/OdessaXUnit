using Xunit;
using Starcounter;
using System.Linq;
using System;

namespace OdessaXUnit.Tests
{
    public class UnitTest1 : BaseTest
    {
        [Fact]
        public void TestMethod1()
        {
            StarcounterContext.ScheduleTransact(() =>
            {
                // Any calls that require database access
            });
        }
    }
}