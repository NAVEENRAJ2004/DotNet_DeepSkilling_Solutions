using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

[ApiController]
[Route("api/[controller]")]
public class SecureController : ControllerBase
{
    [HttpGet("data")]
    [Authorize]
    public IActionResult GetSecureData()
    {
        var username = User.Identity?.Name;

        return Ok(new
        {
            Success = true,
            Message = $"Authentication successful! Welcome, {username}.",
            Timestamp = DateTime.UtcNow
        });
    }
}