using Microsoft.AspNetCore.Mvc;
using SafeVault.Helpers;
using SafeVault.Models;

namespace SafeVault.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        [HttpPost]
        public IActionResult Submit(User user)
        {
            user.Username =
                InputValidator.SanitizeInput(user.Username);

            user.Email =
                InputValidator.SanitizeInput(user.Email);

            return Ok(user);
        }
    }
}