using AuthenticationApi.Models;
using AuthenticationApi.Models.DTOs;
using AuthenticationApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationApi.Controllers;

[Route("api/auth")]
[ApiController]
public class AuthController(IAuthService _authService) : Controller
{
    
    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDto request)
    {
        var user = await _authService.RegisterUserAsync(request);

        if (user == null)
        {
            return BadRequest("User already exists");
        }
        return Ok(user);
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto request)
    {
        var token = await _authService.LoginUserAsync(request);

        if (token == null)
        {
            return BadRequest("Invalid credentials");
        }
        return Ok(token);
    }

    [Authorize]
    [HttpGet("auth-only")]
    public IActionResult AuthenticatedEndpoint()
    {
        return Ok("You are authenticated");
    }
    
    [Authorize(Roles = "Admin")]
    [HttpGet("admin-only")]
    public IActionResult AdmingOnlyEndpoint()
    {
        return Ok("You are an admin");
    }
    
}