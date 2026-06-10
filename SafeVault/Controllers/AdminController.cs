using Microsoft.AspNetCore.Mvc;

namespace SafeVault.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdminController : ControllerBase
{
    [HttpGet]
    public IActionResult Dashboard(
        [FromHeader] string role)
    {
        if (role != "Admin")
        {
            return Forbid();
        }

        return Ok(
            "Welcome to Admin Dashboard");
    }
}