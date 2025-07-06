using AuthenticationApi.Models;

namespace AuthenticationApi.Services;

public interface ICrudService
{
    Task<List<User>> GetAllUsersAsync();
}