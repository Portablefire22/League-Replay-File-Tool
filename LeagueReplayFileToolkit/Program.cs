using System.Text.Json;
using LeagueReplayFileToolkit.LRF;
using LeagueReplayFileToolkit.LRF.Reader;

namespace LeagueReplayFileToolkit;

class Program
{
    static void Main(string[] args)
    {
        string path;
        if (args.Length > 0)
        {
            path = args[0];
        }
        else
        {
            Console.Write("Replays Directory: ");
            path = Console.ReadLine()!;
        }

        var files = Directory.GetFiles(path, "*.lrf");

        var versionDict = new Dictionary<string, List<ReplayFile>>();
        
        foreach (var filePath in files)
        {
            try
            {
                using (var reader = new ReplayReader(filePath))
                {
                    var file = reader.Read();
                    var clientVer = file.Metadata.ClientVersion;
                    if (!versionDict.ContainsKey(clientVer)) versionDict.Add(clientVer, new List<ReplayFile>());
                    versionDict[clientVer].Add(file);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"File: {filePath} Exception: {e}");
            }
        }

        var json = JsonSerializer.Serialize(versionDict, new JsonSerializerOptions()
        {
            WriteIndented = true
        });
        File.WriteAllText(Path.Combine(path, "CombinedMetadata.json"), json);

        foreach (var (version, replayFiles) in versionDict)
        {
            var newPath = Path.Combine(path, version);
            if (!Directory.Exists(newPath)) Directory.CreateDirectory(newPath);
            foreach (var tmpFile in replayFiles)
            {
                var name = tmpFile.FilePath.Remove(0, path.Length+1);
                Console.WriteLine($"File Name: {name}");
                Console.WriteLine($"Moving {tmpFile.FilePath} to {Path.Combine(newPath,name)}");
                File.Move(tmpFile.FilePath, Path.Combine(newPath, name));
            }
        }
        
        
    }
}