using ErrorOr;

namespace NetCoreBase.Application.Services;

public interface IAuthService
{
    ErrorOr<AuthResult> Register(string firstName, string lastName, string address, string email, string password);
    ErrorOr<AuthResult> Login(string email, string password);
}