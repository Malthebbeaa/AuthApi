using System.ComponentModel.DataAnnotations.Schema;

namespace AuthenticationApi.Models;

public class Item
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; }
    public double Price { get; set; }
    public Guid CategoryId { get; set; }
    public Category? Category { get; set; }
    public SerialNumber? SerialNumber { get; set; }
}