using System.Diagnostics.CodeAnalysis;

namespace HttpContextExcercise.MySession;

public class MySession(string id, IMySessionStorageEngine engine): ISession
{
    private readonly Dictionary<string, byte[]> _store = new Dictionary<string, byte[]>();

    public bool IsAvailable
    {
        get
        {
            LoadAsync(CancellationToken.None).Wait();
            return true;
        }
    }

    public string Id { get; } = id;
    public IEnumerable<string> Keys => _store.Keys;

    public async Task LoadAsync(CancellationToken cancellationToken = default)
    {
        _store.Clear();
        var loadStore = await engine.LoadAsync(Id, cancellationToken);

        foreach (var item in loadStore)
        {
            _store[item.Key] = item.Value;
        }
    }

    public async Task CommitAsync(CancellationToken cancellationToken = default)
    {
        await engine.CommitAsync(Id, _store, cancellationToken);
    }

    public bool TryGetValue(string key, [NotNullWhen(true)] out byte[]? value)
    {
        
        return _store.TryGetValue(key, out value);
    }

    public void Set(string key, byte[] value)
    {
        _store[key] = value;
    }

    public void Remove(string key)
    {
        _store.Remove(key);
    }

    public void Clear()
    {
        _store.Clear();
    }
}