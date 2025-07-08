using System.ComponentModel.DataAnnotations.Schema;

namespace AuthenticationApi.Models;

public class Product
{
    public Guid Id { get; set; } =  Guid.NewGuid();
    public string Name { get; set; } = string.Empty;
    public double Price { get; set; } = 0;
    public string Description { get; set; } = string.Empty;
    public Guid? ProductCategoryId { get; set; } =  Guid.NewGuid();
    [ForeignKey("ProductCategoryId")]
    public ProductCategory? ProductCategory { get; set; }
}