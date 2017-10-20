using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdessaXUnit.Tests.Components
{
    public class Database
    { 
        private StarAdmin StarAdmin { get; }

        public string Name { get; }

        public Database(StarAdmin starAdmin, string name)
        {
            this.StarAdmin = starAdmin ?? throw new NullReferenceException(nameof(starAdmin));
            this.Name = name ?? throw new NullReferenceException(nameof(name));
        }

        public void Delete()
        {
            StarAdmin.Run($"-d={Name} delete --force db");
        }

        public void Create()
        {
            StarAdmin.Run($"-d={Name} new db");
        }

        public void Recreate()
        {
            this.Delete();
            this.Create();
        }
    }
}
