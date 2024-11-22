using NetCoreBase.Domain.Entities;

namespace NetCoreBase.Application.Services;

public record AuthResult(
    User User,
    string Token
);