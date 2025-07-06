using System.ComponentModel.DataAnnotations.Schema;

namespace AuthenticationApi.Models;

public class SerialNumber
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    
    public Guid ItemId { get; set; }
    public Item? Item { get; set; }
}