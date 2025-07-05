using Shop_MVC.Entities;
using Shop_MVC.Models.UserManager;

namespace Shop_MVC.Services.Interfaces
{
    public interface IUserManagerService
    {
        public IEnumerable<UserManagerViewModel> GetUsers();

        public void AddMoney(UserManagerViewModel user);

        public UserManagerViewModel GetByEmail(string email);
    }
}
