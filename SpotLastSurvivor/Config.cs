using Exiled.API.Interfaces;
using System.ComponentModel;

namespace SpotLastSurvivor
{
    public class Config : IConfig
    {

        [Description("Should SpotLastSurvivor be enabled?")]
        public bool IsEnabled { get; set; } = true;
        public bool Debug { get; set; } = false;

        [Description("Enable Cassie throwing an annonce of a scan when only one survivor remains")]
        public bool CassieScan { get; set; } = true;

        [Description("Cassie scan message")]
        public string CassieAnnounce { get; set; } = "SCANNING";

        [Description("Time cassie take before telling where the last survivor is (seconds) after the scan")]
        public float ScanningTime { get; set; } = 30f;
    }
}