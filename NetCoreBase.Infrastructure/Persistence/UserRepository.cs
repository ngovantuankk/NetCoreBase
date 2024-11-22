using NetCoreBase.Application.Common.Persistence;
using NetCoreBase.Domain.Entities;

namespace NetCoreBase.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _users = new();
    public void CreateUser(User user)
    {
        // csdl
        _users.Add(user);
        Console.WriteLine("check list user: " + _users);

    }

    public User? GetUserByEmail(string email)
    {
        // csdl
        Console.WriteLine("check list user: " + _users);
        return _users.SingleOrDefault(user => user.Email == email);
    }
}