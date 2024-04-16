[![Release]][Link]
<!----------------------------------------------------------------------------->
[Link]: https://github.com/Antoniofo/SpotLastSurvivor/releases
<!---------------------------------[ Buttons ]--------------------------------->
[Release]: https://img.shields.io/badge/Release-EFFDE?style=for-the-badge&logoColor=white&logo=DocuSign


# Installation:

You can install this plugin by downloading the [.dll](https://github.com/Antoniofo/SpotLastSurvivor/releases) file and placeing it in ``%AppData%\Roaming\EXILED\Plugins`` (Windows) or ``~/.config/EXILED/Plugins`` (Linux)

# Configuration

| Type | Name | Default Value | Description |
|------|------|----------------|---------|
| bool | IsEnabled | true | Should SpotLastSurvivor be enabled? |
| bool | IsDebug  | false | Should Debug mod be enabled? |
| bool | CassieScanAnnounce  | true | Enable Cassie throwing an annonce of a scan when only one survivor remains |
| string | CassieAnnounceMessage  | "SCANNING FOR LAST HUMAN" | Cassie scan message |
| float | ScanningTime  | 30f | Time cassie take before telling where the last survivor is (seconds) after the scan message |
| float | RespawnTiming  | 90f | Time before a respawn where no scan will be performed |

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
    public float RespawnTiming { get; set; } = 90f;

# Description

When the second to last player dies cassie starts scanning the whole facility to find the last human survivor by default it takes 30 seconds and then make an announcement where the player is located.