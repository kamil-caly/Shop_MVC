using MongoDB.Bson;

namespace Shop_MVC.Entities
{
    public class Role
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; } = default!;
    }
}
