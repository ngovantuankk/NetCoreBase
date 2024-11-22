using NetCoreBase.Domain.Entities;

namespace NetCoreBase.Application.Common;

public interface IJwtGenerator
{
    string GenerateJwt(User user);
}