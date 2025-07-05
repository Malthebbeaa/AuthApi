namespace AuthenticationApi.Models;

public class User
{
    public int Id { get; set; }
    public string Username { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public byte[] PasswordSalt { get; set; } =  Array.Empty<byte>();
    public string Role { get; set; } = string.Empty;
}