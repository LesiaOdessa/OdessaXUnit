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

        // Constructor that runs before every test run
        public TestContext()
        {
            // Database name, can be set to any string
            string databaseName = typeof(TestContext)
                .Assembly.GetName().Name
                .Replace(".", string.Empty);

            // Recreate database before every run to have a clean database 
            var setup = new TestSetup(databaseName)
                .StartServer()
                .StopHost()
                .RecreateDatabase();

            // Get the assembly from the application to test
            // Will not compile until you have referenced an assembly
            // with a public Program class
            var assembly = typeof(Program).Assembly;

            // Create the self-hosted app host and 
            // specify the application to test
            host = new AppHostBuilder()
                .UseDatabase(databaseName)
                .UseApplication(assembly)
                .Build();

            host.Start();
        }

        void IDisposable.Dispose()
        {
            host.Dispose();
        }
    }
}