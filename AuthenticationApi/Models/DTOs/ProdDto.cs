namespace AuthenticationApi.Models.DTOs;

public class ProdDto
{
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; } = 0;
    public string Description { get; set; } = string.Empty;
    public Guid? ProductCategoryId { get; set; } =  Guid.NewGuid();
}