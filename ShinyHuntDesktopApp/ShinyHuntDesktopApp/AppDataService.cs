using System;
using System.IO;
using System.Text.Json;

public class AppDataService
{
     private readonly string _basePath;
    public AppDataService()
    {
        _basePath = AppDomain.CurrentDomain.BaseDirectory;
    }
    public List<string> LoadPokemonNames()
    {
        string path = Path.Combine(_basePath, "Data", "pokemon_names.json");
        string json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<List<string>>(json) ?? new List<string>();
    }
}
