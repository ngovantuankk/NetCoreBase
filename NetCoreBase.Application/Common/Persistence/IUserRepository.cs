using NetCoreBase.Domain.Entities;

namespace NetCoreBase.Application.Common.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);

    void CreateUser(User user);
}