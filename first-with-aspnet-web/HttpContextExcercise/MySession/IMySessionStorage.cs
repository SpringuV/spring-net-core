namespace HttpContextExcercise;

public interface IMySessionStorage
{
    ISession Create();

    ISession Get(string id); // id của session

}