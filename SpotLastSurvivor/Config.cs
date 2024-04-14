using Exiled.API.Interfaces;
using System.ComponentModel;

namespace SpotLastSurvivor
{
    public class Config : IConfig
    {

        [Description("Should SpotLastSurvivor be enabled?")]
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;

        [Description("Enable Cassie throwing an annonce of a scan")]
        public bool CassieScanAnnounce { get; set; } = true;

        [Description("Cassie scan message")]
        public string CassieAnnounceMessage { get; set; } = "SCANNING FOR LAST HUMAN";

        [Description("Time cassie take before telling where the last survivor is (seconds) after the scan")]
        public float ScanningTime { get; set; } = 30f;

        [Description("Time before the respawn where no scan will be performed")]
        public float MTFTiming { get; set; } = 90f;
    }
}