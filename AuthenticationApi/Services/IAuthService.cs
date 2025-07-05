using AuthenticationApi.Models;
using AuthenticationApi.Models.DTOs;

namespace AuthenticationApi.Services;

public interface IAuthService
{
    Task<User?> RegisterUserAsync(RegisterDto request);
    Task<string> LoginUserAsync(LoginDto request);
}