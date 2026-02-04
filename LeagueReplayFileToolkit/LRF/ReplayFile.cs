namespace LeagueReplayFileToolkit.LRF;

public class ReplayFile
{
    // Format
    // 4 bytes - Magic
    // 4 byte - length
    // json
    public string FilePath { get; set; }
    public Metadata Metadata { get; set; }
}