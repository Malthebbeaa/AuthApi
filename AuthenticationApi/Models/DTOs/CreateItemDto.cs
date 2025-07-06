namespace AuthenticationApi.Models.DTOs;

public class CreateItemDto
{
    public string Name { get; set; }
    public double Price { get; set; }
    public Guid CategoryId { get; set; }
}