using Microsoft.EntityFrameworkCore;
using Shop_MVC.Entities;
using Shop_MVC.Models.UserManager;
using Shop_MVC.Services.Interfaces;

namespace Shop_MVC.Services
{
    public class UserManagerService : IUserManagerService
    {
        private readonly ShopDbContext dbCtx;
        public UserManagerService(ShopDbContext dbContext)
        {
            dbCtx = dbContext;
        }

        public IEnumerable<UserManagerViewModel> GetUsers() 
        {
            // baza mongoDb więc trzeba pobrać osobno
            var users = dbCtx.Users.ToList();
            var roles = dbCtx.Roles.ToList();

            // i dopiero teraz połączyć
            return users.Select(user =>
            {
                var role = roles.FirstOrDefault(r => r.Id == user.RoleId);
                var roleName = role != null ? role.Name : "User";
                return new UserManagerViewModel(user, roleName);
            }).ToList();
        }

        public void AddMoney(UserManagerViewModel user)
        {
            var dbUser = dbCtx.Users.FirstOrDefault(u => u.Email == user.Email);

            if (dbUser != null)
            {
                dbUser.Money = user.Money;
                dbCtx.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("User not found.");
            }
        }

        public UserManagerViewModel GetByEmail(string email)
        {
            var dbUser = dbCtx.Users.FirstOrDefault(u => u.Email == email);

            if (dbUser != null)
            {
                var role = dbCtx.Roles.FirstOrDefault(r => r.Id == dbUser.RoleId);
                var roleName = role != null ? role.Name : "User";
                return new UserManagerViewModel(dbUser, roleName);
            }
            else
            {
                throw new InvalidOperationException("User not found.");
            }
        }
    }
}
