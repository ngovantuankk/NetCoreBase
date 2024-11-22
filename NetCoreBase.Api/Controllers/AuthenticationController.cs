using Microsoft.AspNetCore.Mvc;
using NetCoreBase.Contracts.Authentication;

namespace NetCoreBase.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : ControllerBase
{
    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var userData = new UserData(
            Guid.NewGuid(),
            request.FirstName,
            request.LastName,
            request.Email,
            request.Address
        );
        var response = new AuthResponse(
            "Register successfully.",
            true,
            userData,
            "token"
        );
        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var userData = new UserData(
            Guid.NewGuid(),
            "Nguyễn",
            "Khuyến",
            "Việt nam",
            request.Email
        );
        var response = new AuthResponse(
            "Login successfully.",
            true,
            userData,
            "Token..."
        );
        return Ok(response);
    }
}