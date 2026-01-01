namespace HttpContextExcercise.MySession;

// interface định nghĩa các phương thức lưu trữ session
public interface IMySessionStorageEngine
{
    Task<Dictionary<string, byte[]>> LoadAsync(string id, CancellationToken cancellationToken);
    Task CommitAsync(string id, Dictionary<string, byte[]> store, CancellationToken cancellationToken);
}