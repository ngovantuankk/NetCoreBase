namespace NetCoreBase.Application.Services;

public record AuthResult(
    Guid Id,
    string FirstName,
    string LastName,
    string Address,
    string Email,
    string Token
);