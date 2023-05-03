using System;
using System.Collections.Generic;
using System.Linq;
using Catalog.Entities;
namespace Catalog.Repositories
{


    public class InMemItemsRepository : IItemsRepository
    {
        private readonly List<Item> items = new List<Item>()
        {
            new Item { Id = Guid.NewGuid(), Name = "Potion", Price = 9, CreatedDate = DateTime.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Iron Sword", Price = 20, CreatedDate = DateTime.UtcNow },
            new Item { Id = Guid.NewGuid(), Name = "Bronze shield", Price = 18, CreatedDate = DateTime.UtcNow },
        };

        public IEnumerable<Item> GetItems()
        {
            return items;
        }
        public Item GetItem(Guid id)
        {
            return items.Where(item => item.Id == id).SingleOrDefault();
        }

    }
}