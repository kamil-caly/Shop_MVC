using MongoDB.Bson;

namespace Shop_MVC.Entities
{
    public class Comment
    {
        public ObjectId Id { get; set; }
        public string Author { get; set; } = default!;
        public string? Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public int Rating { get; set; }
        public ObjectId ProductId { get; set; }
    }
}
