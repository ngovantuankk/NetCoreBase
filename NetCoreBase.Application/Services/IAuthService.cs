namespace NetCoreBase.Application.Services;

public interface IAuthService
{
    AuthResult Register(string firstName, string lastName, string address, string email, string password);
    AuthResult Login(string email, string password);
}