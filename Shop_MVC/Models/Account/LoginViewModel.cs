using System.ComponentModel.DataAnnotations;

namespace Shop_MVC.Models.Account
{
    public class LoginViewModel
    {
        [Required, EmailAddress]
        public string Email { get; set; } = default!;

        [Required, DataType(DataType.Password), MinLength(4)]
        public string Password { get; set; } = default!;
    }
}
