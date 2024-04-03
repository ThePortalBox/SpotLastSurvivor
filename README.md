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
| bool | CassieScan  | true | Enable Cassie throwing an annonce of a scan when only one survivor remains |
| string | CassieAnnounce  | "SCANNING" | Cassie scan message |
| float | ScanningTime  | 30f | Time cassie take before telling where the last survivor is (seconds) after the scan message |



    [Description("Should SpotLastSurvivor be enabled?")]
    public bool IsEnabled { get; set; } = true;

    public bool Debug { get; set; } = false;

    [Description("Enable Cassie throwing an annonce of a scan when only one survivor remains")]
    public bool CassieScan { get; set; } = true;

    [Description("Cassie scan message")]
    public string CassieAnnounce { get; set; } = "SCANNING";

    [Description("Time cassie take before telling where the last survivor is (seconds) after the scan message")]
    public float ScanningTime { get; set; } = 30f;

# Description

When the second to last player dies cassie starts scanning the whole facility to find the last human survivor by default it takes 30 seconds and then make an announcement where the player is located.