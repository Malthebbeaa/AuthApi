using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AuthenticationApi.Models;
using AuthenticationApi.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AuthenticationApi.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController(IConfiguration configuration) : Controller
{
    public static User user = new();
    
    [HttpPost("register")]
    public IActionResult Register([FromBody] UserDto request)
    {
        var hashedPassword = new PasswordHasher<User>().HashPassword(user, request.Password);
        
        user.Username = request.Username;
        user.PasswordHash = hashedPassword;

        return Ok(user);
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] UserDto request)
    {
        if (request.Username != user.Username)
        {
            return BadRequest("User not found");
        }

        if (new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash,  request.Password) == PasswordVerificationResult.Failed)
        {
            return BadRequest("Passwords do not match");
        }

        string token = CreateToken(user);
        return Ok(token);
    }
    
    [HttpGet("users")]
    public IActionResult Users()
    {
        user.Id = 1;
        user.Username = "Malthe";
        user.PasswordHash = "P@$$w0rd";
        user.PasswordSalt = new byte[] {1};

        
        return Ok(user);
    }

    private string CreateToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Username)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("AppSettings:Token")!));
        
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

        var tokenDescriptor = new JwtSecurityToken(
            issuer: configuration.GetValue<string>("AppSettings:Issuer"),
            audience: configuration.GetValue<string>("AppSettings:Audience"),
            claims: claims,
            expires: DateTime.Now.AddHours(2),
            signingCredentials: creds
        );
        
        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }
}