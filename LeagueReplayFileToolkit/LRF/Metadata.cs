namespace LeagueReplayFileToolkit.LRF;

public class Metadata
{
    public string QueueType { get; set; }
    public string ReplayVersion { get; set; }
    public int GameMode { get; set; }
    public int ServerPort { get; set; }
    public MetadataImage[] Screenshots { get; set; }
    public string ClientVersion { get; set; }
    public int MatchType { get; set; }
    public bool ObserverStream { get; set; }
    public long AccountID { get; set; }
    public int Map { get; set; }
    public string SummonerName { get; set; }
    public double MatchLength { get; set; }
    public long Timestamp { get; set; }
    public bool Ranked { get; set; }
    public MetadataIndex[] DataIndex { get; set; }
    public string ServerAddress { get; set; }
    public int WinningTeam { get; set; }
    public bool SpectatorMode { get; set; }
    public string Name { get; set; }
    public int FirstWinBonus { get; set; }
    public string Region { get; set; }
    public long MatchID { get; set; }
    public int ReplayID { get; set; }
    public object Teams { get; set; }
    public MetadataPlayer[] Players { get; set; }
    public int StatsVersion { get; set; }
    public string EncryptionKey { get; set; }
    public string ClientHash { get; set; }
}