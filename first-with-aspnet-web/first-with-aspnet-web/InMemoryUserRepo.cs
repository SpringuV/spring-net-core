namespace first_with_aspnet_web;

using System;
using System.Collections.Generic;

public class InMemoryUserRepo: IUserRepository
{
    private readonly List<string> _users = new();
    private readonly object _lock = new();
    public void Add(string userName)
    {
        // Validate input
        if (string.IsNullOrWhiteSpace(userName))
        {
            throw new ArgumentException("userName must be provided", nameof(userName));
        }

        // Thread-safe add and avoid duplicates
        lock (_lock)
        {
            if (!_users.Contains(userName))
            {
                _users.Add(userName);
            }
        }
    }

    public IEnumerable<string> GetUsers => _users;
}