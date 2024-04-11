using System;
using Exiled.API.Features;
using PlayerEvents = Exiled.Events.Handlers.Player;
using ServerEvents = Exiled.Events.Handlers.Server;
using Exiled.Events.EventArgs.Player;
using Exiled.CustomRoles.API.Features;
using System.Linq;
using Exiled.CustomRoles.API;
using MEC;
using System.Collections.Generic;

namespace SpotLastSurvivor
{

    public class Plugin : Plugin<Config>
    {
        public override string Name { get; } = "SpotLastSurvivor";
        public override string Author { get; } = "Antoniofo";

        public override Version Version => new Version(1, 0, 0);

        public override string Prefix => "sls";

        public static Plugin instance;
        public override void OnEnabled()
        {
            Plugin.instance = this;
            PlayerEvents.Died += OnPlayerDied;
        }

        public override void OnDisabled()
        {
            PlayerEvents.Died -= OnPlayerDied;
            Plugin.instance = null;
            Timing.KillCoroutines();
        }
        public void OnPlayerDied(DiedEventArgs ev)
        {
            List<Player> list = Player.List.Where(x => !x.IsDead && !x.IsScp && !x.IsTutorial).ToList();
            if (list.Count != 1)
                return;
            Log.Debug("TotalMinutes: " +Respawn.TimeUntilSpawnWave.TotalMinutes);
            Log.Debug("TotalSeconds: " + Respawn.TimeUntilSpawnWave.TotalSeconds);
            if (!((Respawn.TimeUntilSpawnWave.TotalMinutes > 0.9) && (Respawn.TimeUntilSpawnWave.TotalSeconds > Config.ScanningTime)))
                return;
                

            if (Config.CassieScan)
            {
                Cassie.Message(Config.CassieAnnounce, true, false, true);
            }

            Timing.CallDelayed(Config.ScanningTime, () => {
                list = Player.List.Where(x => !x.IsDead && !x.IsScp && !x.IsTutorial).ToList();
                if (list.Count == 1)
                {
                    Player ply = list.FirstOrDefault();                   
                    Cassie.Message("SPOTTED AT " + ply.CurrentRoom.Name, true, false, true);
                }               
            });
        }
    }
}