using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.Dtos;
using Catalog.Entities;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{
    // Get / items
    // or controller
    [ApiController]
    [Route("items")]
    public class ItemsController : ControllerBase
    {
        // creating instance of database 
        private readonly IItemsRepository repository;

        // Passing interface
        // Dependency injection 
        public ItemsController(IItemsRepository repository)
        {
            this.repository = repository;
        }

        // get /items
        //Handles HTTP GET requests at the "/items" endpoint
        [HttpGet]
        public async Task<IEnumerable<ItemDto>> GetItemsAsync()
        {
            var items = (await repository.GetItemsAsync()) // (first we find item)
                        .Select(item => item.AsDto()); // then we select it
            return items; // then return it
        }

        //get /items/{id}
        // Handles HTTP GET requests at the "/items/{id}" endpoint, where {id} is a placeholder for the item ID
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetItemAsync(Guid id) // action return allows to return more than one data type
        {
            var item = await repository.GetItemAsync(id);

            if (item is null)
            {
                return NotFound();
            }

            return item.AsDto();
        }

        [HttpPost]
        public async Task<ActionResult<ItemDto>> CreateItemAsync(CreateItemDto itemDto)
        {
            Item item =  new()
            {
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };
            await repository.CreateItemAsync(item);

            return CreatedAtAction(nameof(GetItemAsync), new { id = item.Id }, item.AsDto());
        }

        // PUT /items/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateItemAsync(Guid id, UpdateItemDto itemDto)
        {
            var existingItem = await repository.GetItemAsync(id);

            if (existingItem is null)
            {
                return NotFound();
            }

            Item updatedItem = existingItem with
            {
                Name = itemDto.Name,
                Price = itemDto.Price
            };

            await repository.UpdateItemAsync(updatedItem);
            return NoContent();
        }

        // Delete /items/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItem(Guid id)
        {
            var existingItem = await repository.GetItemAsync(id);

            if (existingItem is null)
            {
                return NotFound();
            }

            await repository.DeleteItemAsync(id);
            return NoContent();

        }
    }
}