using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.EntityFrameworkCore;
using Shop_MVC.Entities.Enums;

namespace Shop_MVC.Entities
{
    public class Product
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; } = default!;
        public string Img { get; set; } = default!;
        public decimal Price { get; set; }
        public Color Color { get; set; }
        public Company Company { get; set; }
        public Category Category { get; set; }
        public int Quantity { get; set; }
    }
}
