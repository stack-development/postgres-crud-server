using Server.Models;

namespace Server.Services;

public interface IItemService
{
    public Task<Item> Create(CreateItemDto dto);
    public Task<Item?> Read(int Id);
    public Task<List<Item?>?> Read();
    public Task<bool> Delete(int Id);
    public Task<bool> Update(UpdateItemDto dto, int id);
}