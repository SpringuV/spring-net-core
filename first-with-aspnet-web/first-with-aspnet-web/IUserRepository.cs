namespace first_with_aspnet_web;

public interface IUserRepository
{
    void Add(string userName);
    IEnumerable<string> GetUsers { get; }
}