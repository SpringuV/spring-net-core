using System.Diagnostics.CodeAnalysis;

namespace HttpContextExcercise.MySession;

// MySession: an ISession implementation backed by an IMySessionStorageEngine
public class MySession(string id, IMySessionStorageEngine engine): ISession
{
    // In-memory store mapping keys to byte arrays
    private readonly Dictionary<string, byte[]> _store = new Dictionary<string, byte[]>();

    // IsAvailable indicates whether the session is ready. This implementation forces a synchronous
    // load on the first call by waiting on LoadAsync; in production prefer an async-first pattern.
    public bool IsAvailable
    {
        get
        {
            LoadAsync(CancellationToken.None).Wait();
            return true;
        }
    }

    // Session id exposed as a read-only property
    public string Id { get; } = id;
    // Expose the keys present in the in-memory store
    public IEnumerable<string> Keys => _store.Keys;

    // Load persisted session data from the storage engine and populate the in-memory dictionary
    public async Task LoadAsync(CancellationToken cancellationToken = default)
    {
        _store.Clear();
        var loadStore = await engine.LoadAsync(Id, cancellationToken);

        foreach (var item in loadStore)
        {
            _store[item.Key] = item.Value;
        }
    }

    // Commit current in-memory store to the storage engine
    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        await engine.CommitAsync(Id, _store, cancellationToken);
    }

    // Try to get a value by key; NotNullWhen attribute helps static analysis
    public bool TryGetValue(string key, [NotNullWhen(true)] out byte[]? value)
    {
        
        return _store.TryGetValue(key, out value);
    }

    // Set a value for a key (overwrite if present)
    public void Set(string key, byte[] value)
    {
        _store[key] = value;
    }

    // Remove a key from the store
    public void Remove(string key)
    {
        _store.Remove(key);
    }

    // Clear the in-memory store
    public void Clear()
    {
        _store.Clear();
    }
}