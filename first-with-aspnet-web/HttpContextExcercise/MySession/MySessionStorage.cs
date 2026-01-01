namespace HttpContextExcercise.MySession;

public class MySessionStorage: IMySessionStorage
{
    private readonly IMySessionStorageEngine _storageEngine;
    private readonly Dictionary<string, ISession> sessions = new();
    public MySessionStorage(IMySessionStorageEngine storageEngine)
    {
        _storageEngine = storageEngine;
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

        var newSession =  new MySession(Guid.NewGuid().ToString("N"), _storageEngine);
        sessions[newSession.Id] = newSession;
        return newSession;
    }

    public ISession Get(string id)
    {
        if (sessions.ContainsKey(id))
        {
            return sessions[id];
        }

        return Create();
    }
}