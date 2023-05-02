using System;
using System.Collections.Generic;
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
        private readonly InMemItemsRepository repository;

        public ItemsController()
        {
            repository = new InMemItemsRepository();
        }

        // get /items
        //Handles HTTP GET requests at the "/items" endpoint
        [HttpGet]
        public IEnumerable<Item> GetItems()
        {
            var items = repository.GetItems();
            return items;
        }

        //get /items/{id}
        // Handles HTTP GET requests at the "/items/{id}" endpoint, where {id} is a placeholder for the item ID
        [HttpGet("{id}")]
        public ActionResult<Item> GetItem(Guid id) // action return allows to return more than one data type
        {
            var item = repository.GetItem(id);

            if (item is null)
            {
                return NotFound();
            }

            return item;
        }

    }
}