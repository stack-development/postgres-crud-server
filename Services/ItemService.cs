using Server.Data;
using Server.Models;
using Microsoft.EntityFrameworkCore;

namespace Server.Services;

public class ItemService : IItemService
{
    private readonly AppDbContext _dbContext;

    public ItemService(AppDbContext context) => _dbContext = context;

    public async Task<Item> Create(CreateItemDto dto)
    {
        var item = new Item()
        {
            Name = dto.Name,
            Description = dto.Description,
            Price = dto.Price
        };

        await _dbContext.AddAsync(item);
        await _dbContext.SaveChangesAsync();

        return item;
    }

    public async Task<Item?> Read(int id) => 
        await _dbContext.FindAsync<Item>(id);
    
    public async Task<List<Item?>?> Read() => 
        await _dbContext.Set<Item>()
            .Select(item => (Item?)item)
            .ToListAsync();

    public async Task<bool> Delete(int id)
    {
        var item = await _dbContext.Set<Item>().FindAsync(id);
            
        if (item is null)
            return false;
    
        _dbContext.Remove(item);
        await _dbContext.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Update(UpdateItemDto dto, int id)
    {
        var itemGet = await _dbContext.FindAsync<Item>(id);
        if (itemGet is null) return false;

        itemGet.Name = dto.Name;
        itemGet.Description = dto.Description;
        itemGet.Price = dto.Price;

        await _dbContext.SaveChangesAsync();
        return true;
    }
}
