namespace AuthenticationApi.Models.ReturnDtos;

public class ProdReturnDto
{
    public Guid Id { get; set; }
    public string Name { get; set; } = String.Empty;
    public double Price { get; set; } = 0.0;
    public string Description { get; set; } = String.Empty;
    public string? ProductCategory { get; set; } =  String.Empty;
}