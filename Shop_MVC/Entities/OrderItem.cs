using MongoDB.Bson;

namespace Shop_MVC.Entities
{
    public class OrderItem
    {
        public ObjectId Id { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public ObjectId OrderId { get; set; }
        public ObjectId ProductId { get; set; }
    }
}
