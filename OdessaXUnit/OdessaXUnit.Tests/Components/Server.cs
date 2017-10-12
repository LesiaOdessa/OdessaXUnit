using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdessaXUnit.Tests.Components
{
    public class Server
    {
        private ICommandRunner CommandRunner { get; }

        public Server(ICommandRunner commandRunner)
        {
            this.CommandRunner = commandRunner;
        }

        public void Run()
        {
            CommandRunner.Run("start server");
        }
    }
}
