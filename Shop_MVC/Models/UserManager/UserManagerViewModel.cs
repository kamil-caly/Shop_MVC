using Shop_MVC.Entities;

namespace Shop_MVC.Models.UserManager
{
    public class UserManagerViewModel
    {
        public string Email { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public DateTime? DateOfBirth { get; set; }
        public decimal Money { get; set; }
        public string Role { get; set; } = default!;

        public UserManagerViewModel()
        {
            
        }
        public UserManagerViewModel(User user, string role)
        {
            Email = user.Email;
            FirstName = user.FirstName;
            LastName = user.LastName;
            DateOfBirth = user.DateOfBirth;
            Money = user.Money;
            Role = role;
        }
    }
}
