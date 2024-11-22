namespace NetCoreBase.Contracts.Authentication;

public record UserData(
    Guid Id,
    string FirstName,
    string LastName,
    string Address,
    string Email
);
public record AuthResponse(
    string Message,
    bool Success,
    UserData? Data,
    string Token
);