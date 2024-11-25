using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using NetCoreBase.Application.Services;
using NetCoreBase.Contracts.Authentication;
using NetCoreBase.Domain.Common.Errors;

namespace NetCoreBase.Api.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly IAuthService _authService;

    public AuthenticationController(IAuthService authService)
    {
        _authService = authService;
    }
    [HttpPost("register")]
    public IActionResult Register([FromBody] RegisterRequest request)
    {
        // xử lý đăng ký ở service application
        ErrorOr<AuthResult> authResult = _authService.Register(
            request.FirstName,
            request.LastName,
            request.Address,
            request.Email,
            request.Password
        );

        return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors)
        );
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        // xử lý đăng nhập ở application
        var authResult = _authService.Login(
            request.Email,
            request.Password
        );
        if (authResult.IsError && authResult.FirstError == Errors.Authentication.InvalidCredentials)
        {
            return Problem(
                statusCode: StatusCodes.Status401Unauthorized,
                title: authResult.FirstError.Description
            );
        }
        return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors)
        );
    }

    private static AuthResponse MapAuthResult(AuthResult authResult)
    {
        //từ kết quả xủ lý register ở service chuyển đổi sang dữ liệu trả về api với contract
        var userData = new UserData(
            authResult.User.Id,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Address,
            authResult.User.Email
        );
        return new AuthResponse(
            Message: "Successfully.",
            Success: true,
            Data: userData,
            Token: authResult.Token
        );
    }
}