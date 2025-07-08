using AuthenticationApi.Models;
using AuthenticationApi.Models.DTOs;
using AuthenticationApi.Models.ReturnDtos;

namespace AuthenticationApi.Services;

public interface IProdService
{
    //Gets
    public Task<List<ProdReturnDto>> GetProductsAsync();
    public Task<ProdReturnDto?> GetProductAsync(Guid id);
    public Task<ProductCategory?> GetProductCategoryAsync(Guid id);
    public Task<List<ProductCategory>> GetProductCategoriesAsync();
    
    //Posts
    public Task<Product> CreateProductAsync(ProdDto request);
    public Task<ProductCategory> CreateProductCategoryAsync(ProdCategoryDto request);
    
}