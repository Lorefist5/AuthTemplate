using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthTemplate.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IdentityController : ControllerBase
{
    [HttpPost("login")]
    public async  Task<IActionResult> Login()
    {
        return Ok(new { });
    }
}
