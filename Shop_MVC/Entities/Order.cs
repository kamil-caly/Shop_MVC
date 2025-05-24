using MongoDB.Bson;

namespace Shop_MVC.Entities
{
    public class Order
    {
        public ObjectId Id { get; set; }
        public string UserEmail { get; set; } = default!;
        public decimal TotalPrice { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
