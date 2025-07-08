using AuthenticationApi.Data;
using AuthenticationApi.Models;
using AuthenticationApi.Models.DTOs;
using AuthenticationApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationApi.Controllers;

[ApiController]
[Route("api/product")]
public class ProductController(IProdService _prodService) : Controller
{
    [Authorize (Roles = "Admin, Employee")]
    [HttpPost("product")]
    public async Task<IActionResult> CreateProductAsync(ProdDto request)
    {
        var response = await _prodService.CreateProductAsync(request);

        if (response == null)
        {
            return BadRequest("Could not create product");
        }
        
        return Ok(response);
    }
    
    [Authorize (Roles = "Admin, Employee")]
    [HttpPost("prodCategory")]
    public async Task<IActionResult> CreateProductCategoryAsync(ProdCategoryDto request)
    {
        var response = await _prodService.CreateProductCategoryAsync(request);

        if (response == null)
        {
            return BadRequest("Could not create category");
        }
        
        return Ok(response);
    }


    [Authorize]
    [HttpGet("products")]
    public async Task<IActionResult> GetProductsAsync()
    {
        var response = await _prodService.GetProductsAsync();
        return Ok(response);
    }

    [Authorize]
    [HttpGet("prodCategories")]
    public async Task<IActionResult> GetProductsCategoryAsync()
    {
        var response = await _prodService.GetProductCategoriesAsync();
        return Ok(response);
    }
    
    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetProductAsync(Guid id)
    {
        var response = await _prodService.GetProductAsync(id);
        return Ok(response);
    }
}