namespace LeagueReplayFileToolkit.LRF;

public class MetadataIndex
{
    public string Key { get; set; }
    public MetadataIndexValue Value { get; set; }
}

public class MetadataIndexValue
{
    public int Size { get; set; }
    public int Offset { get; set; }
}