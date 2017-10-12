using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdessaXUnit.Tests.Components
{
    public class Database
    { 
        private ICommandRunner CommandRunner { get; }

        public string Name { get; }

        public Database(ICommandRunner commandRunner, string name)
        {
            this.CommandRunner = commandRunner ?? throw new NullReferenceException(nameof(commandRunner));
            this.Name = name ?? throw new NullReferenceException(nameof(name));
        }

        public void Delete()
        {
            CommandRunner.Run($"-d={Name} delete --force db");
        }

        public void Create()
        {
            CommandRunner.Run($"-d={Name} new db");
        }

        public void Recreate()
        {
            this.Delete();
            this.Create();
        }
    }
}
