using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Starcounter;
using Starcounter.Hosting;

namespace OdessaXUnit.Tests
{
    public class TestContext : IDisposable
    {
        readonly ICodeHost host;

        public string DatabaseName { get; } = typeof(TestContext).Assembly.GetName().Name.Replace(".", string.Empty);

        public TestContext()
        {
            var setup = new TestSetup(DatabaseName)
                .StartServer()
                .StopHost()
                .RecreateDatabase();

            host = new AppHostBuilder()
                .UseDatabase(DatabaseName)
                .UseApplication(typeof(Program).Assembly)
                .Build();

            host.Start();
        }

        void IDisposable.Dispose()
        {
            host.Dispose();
        }
    }
}