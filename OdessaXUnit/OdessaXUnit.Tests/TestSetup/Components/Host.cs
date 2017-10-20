using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdessaXUnit.Tests.Components
{
    public class Host
    {
        public Database Database { get; }
        private StarAdmin StarAdmin { get; }

        public Host(Database database)
        {
            this.Database = database;

            var allowedExits = new Dictionary<string, int>()
            {
                { "HostNotRunning", 10024 },
                { "DatabaseDoesNotExist", 10002 }
            };

            this.StarAdmin = new StarAdmin()
            {
                AllowedExits = allowedExits.Values
            };
        }

        public void Stop()
        {
            StarAdmin.Run($"-d={Database.Name} stop host");
        }
    }
}
