using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Server.Models;
using Server.Services;

namespace Server.Controllers;

[ApiController]
[Route("items")]
public class ItemsControllers : ControllerBase
{
    private readonly IItemService _itemService;

    public ItemsControllers(IItemService service) => _itemService = service;

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Item?>?>?> GetItems() =>
        Ok(await _itemService.Read());

    [HttpGet("{id}")]
    public async Task<ActionResult<Item>> GetItem(int id)
    {
        var item = await _itemService.Read(id);

        if (item is null)
        {
            return NotFound(); 
        }

        return Ok(item); 
    }

    [HttpPost]
    public async Task<ActionResult<Item>> CreateItem([FromBody] CreateItemDto dto)
    {
        var created = await _itemService.Create(dto);
        return CreatedAtAction(nameof(GetItem), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateItem(int id, [FromBody] UpdateItemDto dto)
    {
        var success = await _itemService.Update(dto, id);
        if (!success) return NotFound();
        return NoContent();
    }
}