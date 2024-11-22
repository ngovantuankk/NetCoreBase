using Microsoft.AspNetCore.Mvc;
using NetCoreBase.Application.Services;
using NetCoreBase.Contracts.Authentication;

namespace NetCoreBase.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthenticationController(IAuthService authService)
    {
        _authService = authService;
    }
    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        // xử lý đăng ký ở service application
        var authResult = _authService.Register(
            request.FirstName,
            request.LastName,
            request.Address,
            request.Email,
            request.Password
        );

        //từ kết quả xủ lý register ở service chuyển đổi sang dữ liệu trả về api với contract
        var userData = new UserData(
            authResult.User.Id,
            authResult.User.FirstName,
            authResult.User.LastName,
            authResult.User.Address,
            authResult.User.Email
        );
        var response = new AuthResponse(
            Message: "Register successfully.",
            Success: true,
            Data: userData,
            Token: authResult.Token
        );
        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        // xử lý đăng nhập ở application
        var authResult = _authService.Login(
            request.Email,
            request.Password
        );

        // chuyển đổi data sang contracts trước khi trả về client
        var userData = new UserData(
            Id: authResult.User.Id,
            FirstName: authResult.User.FirstName,
            LastName: authResult.User.LastName,
            Address: authResult.User.Address,
            Email: authResult.User.Email
        );
        var response = new AuthResponse(
            Message: "Login successfully.",
            Success: true,
            Data: userData,
            Token: authResult.Token
        );
        return Ok(response);
    }
}