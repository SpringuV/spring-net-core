namespace HttpContextExcercise.MySession;

public class FileMySessionStorageEngine: IMySessionStorageEngine
{
    private readonly string _directoryPath;

    public FileMySessionStorageEngine(string directoryPath)
    {
        _directoryPath = directoryPath;
    }
    
    public async Task<Dictionary<string, byte[]>> LoadAsync(string id, CancellationToken cancellationToken)
    {
        string filePath = Path.Combine(_directoryPath, id);
        if(!File.Exists(filePath))
        {
            return [];
        }
        using FileStream fs = new FileStream(filePath, FileMode.Open);
        using StreamReader reader = new StreamReader(fs);
        var json = await reader.ReadToEndAsync(cancellationToken);
        return System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, byte[]>>(json) ?? [];
    }

    public async Task CommitAsync(string id, Dictionary<string, byte[]> store, CancellationToken cancellationToken)
    {
        string filePath = Path.Combine(_directoryPath, id);
        using FileStream fs = new FileStream(filePath, FileMode.Create);
        using StreamWriter writer = new StreamWriter(fs);
        writer.Write(System.Text.Json.JsonSerializer.Serialize(store));
    }
}