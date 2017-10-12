using Xunit;
using Starcounter;
using System.Linq;
using System;

namespace OdessaXUnit.Tests
{
    public class DatabaseTest : BaseTest
    {
        [Fact]
        public void DatabaseAccessTest()
        {
            StarcounterContext.ScheduleTransact(() =>
            {
                Db.SQL<Person>($"SELECT c FROM {typeof(Person)} c");
            });
        }
    }
}