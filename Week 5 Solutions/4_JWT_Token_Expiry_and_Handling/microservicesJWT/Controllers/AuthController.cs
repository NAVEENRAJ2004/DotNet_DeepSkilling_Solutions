using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;

    public AuthController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] User model)
    {
        if (IsValidUser(model))
        {
            var token = GenerateJwtToken(model.username);
            return Ok(new { Token = token });
        }
        return Unauthorized();
    }

    private bool IsValidUser(User model)
    {
        return model.username == "Naveen" && model.password == "Naveen007";
    }

    private string GenerateJwtToken(string username)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, "Admin")  
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? "ThisIsASecretKeyForJwtToken1234567890"));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        double durationInMinutes = double.Parse(_configuration["Jwt:DurationInMinutes"] ?? "30");
        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"] ?? "MyAuthServer",
            audience: _configuration["Jwt:Audience"] ?? "MyApiUsers",
            claims: claims,
            expires: DateTime.Now.AddMinutes(0.3),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
