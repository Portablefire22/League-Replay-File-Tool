using System.Text;
using System.Text.Json;

namespace LeagueReplayFileToolkit.LRF.Reader;

public class ReplayReader : IDisposable
{
    private Stream _stream;
    private BinaryReader _reader;

    private string _path;
    
    public ReplayReader(Stream stream, string path)
    {
        _stream = stream;
        _reader = new BinaryReader(_stream);
        _stream.Seek(4, SeekOrigin.Begin); // Skip the magic numbers
        _path = path;
    }

    public ReplayReader(string path) : this(new FileStream(path, FileMode.Open), path) { }

    public ReplayFile Read()
    {
        var length = _reader.ReadInt32();
        var bytes = _reader.ReadBytes(length);

        var json = Encoding.ASCII.GetString(bytes);

        var options = new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        };
        var metadata = JsonSerializer.Deserialize<Metadata>(json, options); 
        
        return new ReplayFile()
        {
            Metadata = metadata,
            FilePath = _path
        };
    }
    
    public void Dispose()
    {
        _stream.Dispose();
        _reader.Dispose();
    }
}