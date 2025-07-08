namespace AuthenticationApi.Models;

public class ProductCategory
{
    public Guid Id { get; set; } =  Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public List<Product> Products { get; set; } = new List<Product>();
}