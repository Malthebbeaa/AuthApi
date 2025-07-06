using AuthenticationApi.Models;
using AuthenticationApi.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationApi.Services;

public interface ICrudService
{
    Task<List<User>> GetAllUsersAsync();
    Task<User?> GetUserAsync(int id);
    Task<Item?> GetItemAsync(Guid id);
    Task<List<Item>?> GetAllItemsAsync();
    
    //Items
    Task<Item> CreateItemAsync(CreateItemDto request);
    Task<Item> UpdateItemAsync(Item item);
    Task<Item> DeleteItemAsync(Guid id);
    
    //Categories
    Task<Category> CreateCategoryAsync(CreateCategoryDto request);
    Task<Category> UpdateCategoryAsync(Category category);
    Task<Category> DeleteCategoryAsync(Guid id);
    
    //SerialNumbers
    Task<SerialNumber> CreateSerialNumber(CreateSerialNumberDto request);
    Task<SerialNumber> UpdateSerialNumberAsync(SerialNumber serialNumber);
    Task<SerialNumber> DeleteSerialNumberAsync(Guid id);
    
    
}