namespace HttpContextExcercise.MySession;

public interface IMySessionStorage
{
    ISession Create(); // Create a new ISession instance with a new id

    ISession Get(string id); // Retrieve an existing session by id (or create a new one)

}