using Exiled.API.Features;
using Exiled.Events.EventArgs.Player;
using MEC;
using PlayerRoles;
using System;
using System.Collections.Generic;
using System.Linq;
using PlayerEvents = Exiled.Events.Handlers.Player;

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
            Log.Debug("TotalSeconds: " + Respawn.TimeUntilSpawnWave.TotalSeconds);
            if (Respawn.TimeUntilSpawnWave.TotalSeconds < Config.RespawnTiming)
                return;
                

            if (Config.CassieScanAnnounce)
            {
                Cassie.Message(Config.CassieAnnounceMessage, true, true, true);
            }

            Timing.CallDelayed(Config.ScanningTime, () => {
                list = Player.List.Where(x => !x.IsDead && !x.IsScp && !x.IsTutorial).ToList();
                if (list.Count == 1)
                {
                    Player ply = list.FirstOrDefault();
                    Log.Debug("Role: " + ply.Role.Name);
                    Log.Debug("Team: " + ply.Role.Team);
                    string roleName = ply.Role.Name;
                    if (ply.Role.Team == Team.FoundationForces && ply.Role != RoleTypeId.FacilityGuard)
                        roleName = "M T F";
                    if (ply.Role.Team == Team.ChaosInsurgency)
                        roleName = "ChaosInsurgency";
                    Cassie.Message("SPOTTED AT " + ply.CurrentRoom.Name + " as " + roleName.Replace("-",""), true, true, true);
                }
            });
        }
    }
}