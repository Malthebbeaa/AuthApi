using AuthenticationApi.Data;
using AuthenticationApi.Models;
using AuthenticationApi.Models.DTOs;
using AuthenticationApi.Models.ReturnDtos;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationApi.Services;

public class ProdService(UserDbContext _context): IProdService
{
    public async Task<List<ProdReturnDto>> GetProductsAsync()
    {
        var products = await _context.Products.Include(p => p.ProductCategory).ToListAsync();

        var prodDtos = products.Select(p => new ProdReturnDto()
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price,
            Description = p.Description,
            ProductCategory = p.ProductCategory?.Name
        }).ToList();
        return prodDtos;
    }

    public async Task<ProdReturnDto?> GetProductAsync(Guid id)
    {
        var product = await _context.Products.Include(p => p.ProductCategory).FirstOrDefaultAsync(p => p.Id == id);

        if (product != null)
        {
            var prodDto = new ProdReturnDto()
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                ProductCategory = product.ProductCategory?.Name
            };
            
            return prodDto;
        }

        return null;
    }

    public async Task<ProductCategory?> GetProductCategoryAsync(Guid id)
    {
        var productCategory =  await _context.ProductCategories.FirstOrDefaultAsync(p => p.Id == id);
        return productCategory;
    }

    public async Task<List<ProductCategory>> GetProductCategoriesAsync()
    {
        var productCategories = await _context.ProductCategories.ToListAsync();
        return productCategories;
    }

    public async Task<Product> CreateProductAsync(ProdDto request)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Name == request.Name);

        if (product == null)
        {
            product = new Product()
            {
                Name = request.Name,
                Description = request.Description,
                Price = request.Price,
                ProductCategoryId = request.ProductCategoryId
            };
        
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        return null;
    }

    public async Task<ProductCategory> CreateProductCategoryAsync(ProdCategoryDto request)
    {
        var productCategory = await _context.ProductCategories.FirstOrDefaultAsync(p => p.Name == request.Name);

        if (productCategory == null)
        {
            productCategory = new ProductCategory()
            {
                Name = request.Name
            };
            await _context.ProductCategories.AddAsync(productCategory);
            await _context.SaveChangesAsync();
            return productCategory;
        }
        return null;
    }
}