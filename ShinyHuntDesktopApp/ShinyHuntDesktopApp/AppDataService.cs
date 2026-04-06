using System;
using System.IO;
using System.Text.Json;
using System.IO.Ports;
public class AppDataService
{
    private readonly string _basePath;
    public AppDataService()
    {
        _basePath = AppDomain.CurrentDomain.BaseDirectory;
    }
    public List<string> LoadPokemonNames()
    {
        return LoadJson<List<string>>("pokemon_names.json");
    }
    public List<string> LoadMethodTypes()
    {
        return LoadJson<List<string>>("method_types.json");
    }
    public List<string> LoadComPorts()
    {
        string[] ports = SerialPort.GetPortNames();
        return ports.ToList<string>();
    }
    private T LoadJson<T>(string filename) where T : new()
    {
        string path = Path.Combine(_basePath, "Data", filename);
        string json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<T>(json) ?? new T();
    }
}
