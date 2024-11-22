namespace NetCoreBase.Application.Services;

public class AuthService : IAuthService
{
    public AuthResult Login(string email, string password)
    {
        // xử lý logic....

        return new AuthResult(
            Guid.NewGuid(),
            "Tên trước lấy từ csdl",
            "Tên sau csdl",
            "Địa chỉ ....",
            email,
            "Token .........................."
        );
    }

    public AuthResult Register(string firstName, string lastName, string address, string email, string password)
    {
        // xử lý logic, csdl,....

        return new AuthResult(
            Guid.NewGuid(),
            firstName,
            lastName,
            address,
            email,
            "token ...."
        );
    }
}