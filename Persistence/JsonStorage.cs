using System.Text.Json;
using FinalProject.Core;

namespace FinalProject.Persistence;

public class JsonStorage
{
    private readonly string _path;

    public JsonStorage(string path)
    {
        _path = path;
    }

    public void Save(Game game)
    {
        var json = JsonSerializer.Serialize(game, new JsonSerializerOptions
        {
            WriteIndented = true
        });
        File.WriteAllText(_path, json);
    }

    public Game? Load()
    {
        if (!File.Exists(_path)) return null;
        var json = File.ReadAllText(_path);
        return JsonSerializer.Deserialize<Game>(json);
    }
}
