using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace OdessaXUnit.Tests.Components
{
    public class StarAdmin : ICommandRunner
    {
        private IEnumerable<int> _allowedExits = new[] { 0 };

        public IEnumerable<int> AllowedExits
        {
            get => _allowedExits.Concat(new[] { 0 });
            set => _allowedExits = value;
        }

        public void Run(string args)
        {
            var process = Process.Start(GetProcessInfo(args));

            process.WaitForExit();

            if (!AllowedExits.Contains(process.ExitCode))
            {
                throw new Exception($"'staradmin {args}' exited with unexpected code {process.ExitCode}");
            }
        }

        private ProcessStartInfo GetProcessInfo(string args)
        {
            return new ProcessStartInfo(
                fileName: "staradmin",
                arguments: args)
            {
                CreateNoWindow = true,
                UseShellExecute = false
            };
        }
    }
}
