using AuthenticationApi.Data;
using AuthenticationApi.Models;
using AuthenticationApi.Models.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationApi.Services;

public class CrudService(UserDbContext _context, IConfiguration _configuration): ICrudService
{
    public async Task<List<User>> GetAllUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User?> GetUserAsync(int id)
    {
        return await _context.Users.FirstOrDefaultAsync(user => user.Id == id);
    }

    public async Task<Item?> GetItemAsync(Guid id)
    {
        return await _context.Items.FirstOrDefaultAsync(item => item.Id == id);
    }

    public async Task<List<Item>?> GetAllItemsAsync()
    {
        return await _context.Items.ToListAsync();
    }

    public async Task<Item> CreateItemAsync(CreateItemDto request)
    {
        var item = await _context.Items.FirstOrDefaultAsync(i => i.Name == request.Name);

        if (item == null)
        {
            item = new Item()
            {
                Name = request.Name,
                Price = request.Price,
                CategoryId = request.CategoryId,
            };
            await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        return null;
    }

    public Task<Item> UpdateItemAsync(Item item)
    {
        throw new NotImplementedException();
    }

    public Task<Item> DeleteItemAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<Category> CreateCategoryAsync(CreateCategoryDto request)
    {
        var category = await _context.Categories.FirstOrDefaultAsync(c => c.Name == request.Name);
        if (category == null)
        {
            category = new Category()
            {
                Name = request.Name,
                Items = new List<Item>()
            };
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
                
            return category;
        }
        
        return null;
    }

    public Task<Category> UpdateCategoryAsync(Category category)
    {
        throw new NotImplementedException();
    }

    public Task<Category> DeleteCategoryAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public async Task<SerialNumber> CreateSerialNumber(CreateSerialNumberDto request)
    {
        var serialNumber = await _context.SerialNumbers.FirstOrDefaultAsync(sn => sn.Name == request.Name);

        if (serialNumber == null)
        {
            serialNumber = new SerialNumber()
            {
                ItemId = request.ItemId,
                Name = request.Name,
            };
            await _context.SerialNumbers.AddAsync(serialNumber);
            await _context.SaveChangesAsync();
            return serialNumber;
        }
        return null;
    }

    public Task<SerialNumber> UpdateSerialNumberAsync(SerialNumber serialNumber)
    {
        throw new NotImplementedException();
    }

    public Task<SerialNumber> DeleteSerialNumberAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}