using Shop_MVC.Models.Account;
using Shop_MVC.Models.Account.Enums;

namespace Shop_MVC.Services.Interfaces
{
    public interface IAccountService
    {
        RegisterResult Register(RegisterViewModel model);
        LoginResult Login(LoginViewModel model);

        void Logout();
    }
}
