using WestCoastEducation.Interfaces;

using System.Text.Json;
using System.Text.Json.Serialization;

namespace WestCoastEducation.Repositories;



public class JsonStorageService : IStorageProvider
{


    private JsonSerializerOptions _options = new JsonSerializerOptions
    {
        WriteIndented = true,
        PropertyNameCaseInsensitive = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        // Saves enums as text ("Remote") and can still read old number values
        Converters = { new JsonStringEnumConverter() },
    };


    public T? Get<T>(string id)
    {
        try
        {
            string path = GetFilePath<T>(id);
            string jsonString = File.ReadAllText(path);

            return JsonSerializer.Deserialize<T>(jsonString, _options);
        }
        catch (DirectoryNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
            return default;
        }
        catch (FileNotFoundException ex)
        {
            Console.WriteLine(ex.Message);
            return default;
        }
    }

    public void Delete(string id)
    {
        var files = Directory.GetFiles(Path.Combine(Environment.CurrentDirectory, "Data"), "*.json", SearchOption.AllDirectories);
        foreach (var file in files)
        {
            if (Path.GetFileNameWithoutExtension(file) == id)
            {
                File.Delete(file);
            }
        }
    }

    public List<T> GetAll<T>()
    {
        // No folder yet just means nothing of this type has been saved
        if (!Directory.Exists(GetDirectory<T>()))
        {
            return [];
        }

        string[] files = Directory.GetFiles(GetDirectory<T>(), "*.json");

        List<T> entries = [];

        foreach (var entry in files)
        {
            string content = File.ReadAllText(entry);
            T parsedEntry = JsonSerializer.Deserialize<T>(content, _options)!;
            entries.Add(parsedEntry!);
        }

        return entries;
    }



    public void Save<T>(T obj) where T : IStorageObject
    {
        var directory = Path.Combine(Environment.CurrentDirectory, "Data", obj.GetType().Name);

        Directory.CreateDirectory(directory);

        var jsonString = JsonSerializer.Serialize(obj,obj.GetType(), _options);

        var path = Path.Combine(directory, $"{obj.Id}.json");

        File.WriteAllText(path, jsonString.Trim());
    }
    private string GetFilePath<T>(string id) => $"{Environment.CurrentDirectory}/Data/{typeof(T).Name}/{id}.json";
    private string GetDirectory<T>() => $"{Environment.CurrentDirectory}/Data/{typeof(T).Name}";



}
