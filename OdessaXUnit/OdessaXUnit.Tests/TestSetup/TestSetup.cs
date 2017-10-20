using OdessaXUnit.Tests.Components;

namespace OdessaXUnit.Tests
{
    public class TestSetup
    {
        readonly string databaseName;
        private StarAdmin StarAdmin { get; }
        private Host Host { get; }
        private Server Server { get; }

        public TestSetup(string databaseName)
        {
            this.databaseName = databaseName;
            this.StarAdmin = new StarAdmin();
            this.Host = new Host(new Database(StarAdmin, databaseName));
            this.Server = new Server(StarAdmin);
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