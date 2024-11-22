using NetCoreBase.Application.Common;
using NetCoreBase.Application.Common.Persistence;
using NetCoreBase.Domain.Entities;

namespace NetCoreBase.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    private readonly IJwtGenerator _jwtGenerator;

    public AuthService(IJwtGenerator jwtGenerator, IUserRepository userRepository)
    {
        _jwtGenerator = jwtGenerator;
        _userRepository = userRepository;
    }

    public AuthResult Login(string email, string password)
    {
        // Csdl
        if (_userRepository.GetUserByEmail(email) is not User user || user.Password != password)
        {
            throw new Exception("Email or Password incorrect!");
        };
        // tạo token
        var token = _jwtGenerator.GenerateJwt(user);

        return new AuthResult(
            user,
            token
        );
    }

    public AuthResult Register(string firstName, string lastName, string address, string email, string password)
    {
        // xử lý logic, csdl,....
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception("Email aldready exists!");
        }

        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Address = address,
            Email = email,
            Password = password
        };

        _userRepository.CreateUser(user);

        // tạo token
        var token = _jwtGenerator.GenerateJwt(user);

        return new AuthResult(
            user,
            token
        );
    }
}