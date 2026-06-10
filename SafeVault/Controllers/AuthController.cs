using Microsoft.AspNetCore.Mvc;
using SafeVault.Models;
using SafeVault.Services;

namespace SafeVault.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly AuthService authService;

    public AuthController(
        AuthService authService)
    {
        this.authService = authService;
    }

    [HttpPost("login")]
    public IActionResult Login(
        LoginRequest request)
    {
        var user =
            authService.Authenticate(
                request.Username,
                request.Password);

        if (user == null)
        {
            return Unauthorized(
                "Invalid credentials");
        }

        return Ok(new
        {
            user.Username,
            user.Role
        });
    }
}