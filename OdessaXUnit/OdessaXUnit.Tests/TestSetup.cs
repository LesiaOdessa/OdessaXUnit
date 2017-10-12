using OdessaXUnit.Tests.Components;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace OdessaXUnit.Tests
{
    public class TestSetup
    {
        readonly string databaseName;
        private ICommandRunner CommandRunner { get; }
        private Host Host { get; }
        private Server Server { get; }

        public TestSetup(string databaseName)
        {
            this.databaseName = databaseName;
            this.CommandRunner = new StarAdmin();
            this.Host = new Host(new Database(CommandRunner, databaseName));
            this.Server = new Server(CommandRunner);
        }

        public TestSetup StartServer()
        {
            Server.Run();
            return this;
        }

        public TestSetup StopHost()
        {
            Host.Stop();
            return this;
        }

        public TestSetup DeleteDatabase()
        {
            Host.Database.Delete();
            return this;
        }

        public TestSetup CreateDatabase()
        {
            Host.Database.Create();
            return this;
        }

        public TestSetup RecreateDatabase()
        {
            Host.Database.Recreate();
            return this;
        }
    }
}