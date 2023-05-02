using System;

namespace Catalog.Entities
{

    public record Item
    {
        public Guid Id { get; init; } // for imitable properties we can use init
        public string Name { get; init; }
        public decimal Price { get; init; }
        public DateTimeOffset CreatedDate { get; init; }       
    }
}