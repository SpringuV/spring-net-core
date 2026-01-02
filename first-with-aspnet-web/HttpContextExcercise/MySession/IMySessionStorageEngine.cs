namespace HttpContextExcercise.MySession;

// Interface defines methods needed to persist/load session dictionaries by id
public interface IMySessionStorageEngine
{
    // Loads the session dictionary for the given id
    Task<Dictionary<string, byte[]>> LoadAsync(string id, CancellationToken cancellationToken);

    // Commits the given session dictionary to the store with the associated id
    Task CommitAsync(string id, Dictionary<string, byte[]> store, CancellationToken cancellationToken);
}