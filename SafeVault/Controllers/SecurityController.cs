using Microsoft.AspNetCore.Mvc;

namespace SafeVault.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SecurityController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("SafeVault API Running");
    }
}