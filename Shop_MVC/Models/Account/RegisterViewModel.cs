using System.ComponentModel.DataAnnotations;

namespace Shop_MVC.Models.Account
{
    public class RegisterViewModel
    {
        [Required, EmailAddress]
        public string Email { get; set; } = default!;

        [Required]
        public string FirstName { get; set; } = default!;

        [Required]
        public string LastName { get; set; } = default!;

        [Required, DataType(DataType.Password)]
        public string Password { get; set; } = default!;

        [Required, DataType(DataType.Password), Compare("Password"), MinLength(4)]
        public string ConfirmPassword { get; set; } = default!;
    }
}
