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
        private ICommandRunner CommandRunner { get; }

        public Host(Database database)
        {
            this.Database = database;
            this.CommandRunner = new StarAdmin()
            {
                AllowedExits = new int[]
                {
                    KnownExitCodes.HostNotRunning,
                    KnownExitCodes.DatabaseDoesNotExist
                }
            };
        }

        public void Stop()
        {
            CommandRunner.Run($"-d={Database.Name} stop host");
        }
    }
}
