using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommandSystem.Commands;
using Exiled.API.Interfaces;
using Exiled.API.Features;
using CommandSystem;
using Exiled.Permissions.Extensions;

namespace SpotLastSurvivor
{
    [CommandHandler(typeof(RemoteAdminCommandHandler))]
    class ActivateScan : ICommand, IUsageProvider
    {
        public string Command => "togglescan";

        public string[] Aliases => new[] { "scan" };

        public string Description => "Activate or disactivate the scanning feature";

        public string[] Usage { get; } = new string[1]
        {
            "activatescan"
        };

        public bool Execute(ArraySegment<string> arguments, ICommandSender sender, out string response)
        {
            if (!sender.CheckPermission("scan"))
            {
                response = "You don't have the permission";
                return false;
            }

            Plugin.Active = !Plugin.Active;

            response = "Scanning is " + (Plugin.Active ? "Activated" : "Deactivated");
            return true;
        }
    }
}