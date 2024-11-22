using NetCoreBase.Application.Common;

namespace NetCoreBase.Application.Services;

public class AuthService : IAuthService
{
    private readonly IJwtGenerator _jwtGenerator;

    public AuthService(IJwtGenerator jwtGenerator)
    {
        _jwtGenerator = jwtGenerator;
    }

    public AuthResult Login(string email, string password)
    {
        // Csdl

        // tạo token
        var token = _jwtGenerator.GenerateJwt(Guid.NewGuid(), "Tên trước", "Tên sau", "Địa chỉ....");

        return new AuthResult(
            Guid.NewGuid(),
            "Tên trước",
            "Tên sau",
            "Địa chỉ....",
            email,
            token
        );
    }

    public AuthResult Register(string firstName, string lastName, string address, string email, string password)
    {
        // xử lý logic, csdl,....

        // tạo token
        var token = _jwtGenerator.GenerateJwt(Guid.NewGuid(), firstName, lastName, address);

        return new AuthResult(
            Guid.NewGuid(),
            firstName,
            lastName,
            address,
            email,
            token
        );
    }
}