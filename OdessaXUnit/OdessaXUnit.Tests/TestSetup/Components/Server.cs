using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdessaXUnit.Tests.Components
{
    public class Server
    {
        private StarAdmin StarAdmin { get; }

        public Server(StarAdmin starAdmin)
        {
            this.StarAdmin = starAdmin;
        }

        public void Run()
        {
            StarAdmin.Run("start server");
        }
    }
}
