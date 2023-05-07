using System;
using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<ItemDto> GetItems()
        {
            var items = repository.GetItems().Select( item => item.AsDto());
            return items;
        }

        //get /items/{id}
        // Handles HTTP GET requests at the "/items/{id}" endpoint, where {id} is a placeholder for the item ID
        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id) // action return allows to return more than one data type
        {
            var item = repository.GetItem(id);

            if (item is null)
            {
                return NotFound();
            }

            return item.AsDto();
        }

        [HttpPost]
        public ActionResult<ItemDto> CreateItem(CreateItemDto itemDto)
        {
            Item item = new(){
                Id = Guid.NewGuid(),
                Name = itemDto.Name,
                Price = itemDto.Price,
                CreatedDate = DateTimeOffset.UtcNow
            };
            repository.CreateItem(item);

            return CreatedAtAction(nameof(GetItem), new {id = item.Id}, item.AsDto());
        }

        // PUT /items/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateItem(Guid id, UpdateItemDto itemDto){
            var existingItem = repository.GetItem(id);

            if(existingItem is null){
                return NotFound();
            }

            Item updatedItem = existingItem with 
            {
                Name = itemDto.Name,
                Price = itemDto.Price
            };

            repository.UpdateItem(updatedItem);
            return NoContent();
        }

        // Delete /items/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteItem(Guid id)
        {
            var existingItem = repository.GetItem(id);

            if(existingItem is null){
                return NotFound();
            }

            repository.DeleteItem(id);
            return NoContent();

        }
    }
}