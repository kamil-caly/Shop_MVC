using MongoDB.Bson;

namespace Shop_MVC.Entities
{
    public class User
    {
        public ObjectId Id { get; set; }
        public string Email { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateTime? DateOfBirth { get; set; }
        public string PasswordHash { get; set; } = default!;
        public decimal money { get; set; }
        public ObjectId RoleId { get; set; }
    }
}
