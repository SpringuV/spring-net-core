// FileMySessionStorageEngine.cs
// Summary: A simple session storage engine that persists session data as JSON files in a directory.
// - LoadAsync reads a file named by session id and deserializes it to a dictionary of byte arrays.
// - CommitAsync serializes the dictionary and writes it back to a file.
// This file adds inline comments for each line and fixes a few small syntax issues (empty dictionary literal and
// StreamReader.ReadToEndAsync overload) so the code compiles and behaves as intended.

namespace HttpContextExcercise.MySession;

public class FileMySessionStorageEngine: IMySessionStorageEngine
{
    // Directory where session files are stored
    private readonly string _directoryPath;

    // Constructor: accepts the directory path to use for storage
    public FileMySessionStorageEngine(string directoryPath)
    {
        _directoryPath = directoryPath; // store the provided path in a readonly field
    }
    
    // LoadAsync: load the session store from disk for a given id
    public async Task<Dictionary<string, byte[]>> LoadAsync(string id, CancellationToken cancellationToken)
    {
        // Build the full file path by combining directory path and session id
        string filePath = Path.Combine(_directoryPath, id);

        // If the file doesn't exist, return an empty dictionary (no session data)
        if(!File.Exists(filePath))
        {
            return new Dictionary<string, byte[]>(); // previously '[]' which is invalid in C#
        }

        // Open the file for reading
        using FileStream fs = new FileStream(filePath, FileMode.Open);
        // Wrap the FileStream in a StreamReader for reading text
        using StreamReader reader = new StreamReader(fs);
        // Read the entire file contents as a JSON string (no cancellation token overload for ReadToEndAsync)
        var json = await reader.ReadToEndAsync();
        // Deserialize the JSON into a Dictionary<string, byte[]>; if null, return an empty dictionary
        return System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, byte[]>>(json) ?? new Dictionary<string, byte[]>();
    }

    // CommitAsync: persist the session store dictionary to disk for a given id
    public async Task CommitAsync(string id, Dictionary<string, byte[]> store, CancellationToken cancellationToken)
    {
        // Build the full file path by combining directory path and session id
        string filePath = Path.Combine(_directoryPath, id);
        // Open (or create) the file for writing
        using FileStream fs = new FileStream(filePath, FileMode.Create);
        // Wrap the FileStream in a StreamWriter for writing text
        using StreamWriter writer = new StreamWriter(fs);
        // Serialize the dictionary to JSON
        var json = System.Text.Json.JsonSerializer.Serialize(store);
        // Write the JSON to disk asynchronously
        await writer.WriteAsync(json);
        // Optionally flush to ensure data is written before disposing (Dispose will flush, but explicit flush is fine)
        await writer.FlushAsync();
    }
}