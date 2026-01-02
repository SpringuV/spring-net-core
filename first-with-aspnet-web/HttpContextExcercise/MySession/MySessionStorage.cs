namespace HttpContextExcercise.MySession;

public class MySessionStorage: IMySessionStorage
{
    private readonly IMySessionStorageEngine _storageEngine;
    private readonly Dictionary<string, ISession> _sessions = new();
    public MySessionStorage(IMySessionStorageEngine storageEngine)
    {
        _storageEngine = storageEngine; // store injected storage engine
    }
    public ISession Create()
    {
        // Trước: var newSession = new MySession(Guid.NewGuid().ToString("New"), _storageEngine);
        // Sửa thành 1 trong các lựa chọn sau:

        // A) dùng mặc định (D) — có dấu gạch ngang:
        // var newSession = new MySession(Guid.NewGuid().ToString(), _storageEngine);

        // hoặc B) dùng dạng N (32 ký tự, không dấu):
        // var newSession = new MySession(Guid.NewGuid().ToString("N"), _storageEngine);

        // hoặc C) tốt hơn: truyền Guid chứ không phải string (nếu MySession hỗ trợ):
        // var newSession = new MySession(Guid.NewGuid(), _storageEngine);

        // Current choice: use the N format (32-char hex without dashes)
        var newSession =  new MySession(Guid.NewGuid().ToString("N"), _storageEngine);
        _sessions[newSession.Id] = newSession; // keep in-memory reference for reuse
        return newSession;
    }

    public ISession Get(string id)
    {
        if (_sessions.ContainsKey(id))
        {
            return _sessions[id]; // return cached session when present
        }

        return Create(); // otherwise create a new session
    }
}