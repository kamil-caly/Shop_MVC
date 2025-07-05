using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Bson;
using Shop_MVC.Entities;
using Shop_MVC.Models.Account;
using Shop_MVC.Models.Account.Enums;
using Shop_MVC.Services.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Shop_MVC.Services
{
    public class AccountService : IAccountService
    {
        private readonly ShopDbContext dbCtx;
        private readonly IConfiguration config;
        private readonly IHttpContextAccessor httpContextAccessor;
        public AccountService(ShopDbContext dbContext, IConfiguration config, IHttpContextAccessor httpContextAccessor)
        {
            dbCtx = dbContext;
            this.config = config;
            this.httpContextAccessor = httpContextAccessor;
        }

        public LoginResult Login(LoginViewModel model)
        {
            var user = dbCtx.Users.FirstOrDefault(u => u.Email == model.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
                return LoginResult.WrongEmailOrPassword;

            var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, dbCtx.Roles.FirstOrDefault(r => r.Id == user.RoleId)?.Name ?? "User")
                };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);

            httpContextAccessor.HttpContext!.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                principal,
                new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddHours(1)
                }
            ).Wait();

            return LoginResult.Success;
        }

        public RegisterResult Register(RegisterViewModel model)
        {
            var exists = dbCtx.Users.Any(u => u.Email == model.Email);
            if (exists)
            {
                return RegisterResult.EmailAlreadyExists;
            }

            var roleId = dbCtx.Roles.First(r => r.Name == "User").Id;

            var user = new User
            {
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password),
                Money = 0,
                RoleId = roleId // domyślnie użytkownik ma rolę User
            };

            dbCtx.Users.Add(user);
            dbCtx.SaveChanges();

            return RegisterResult.Success;
        }

        public void Logout()
        {
            httpContextAccessor.HttpContext!.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme).Wait();
        }

        public decimal GetBalance()
        {
            var userId = httpContextAccessor.HttpContext!.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = dbCtx.Users.FirstOrDefault(u => u.Id.ToString() == userId);

            if (user == null)
            {
                throw new Exception("User not found");
            }

            return user.Money;
        }
    }
}
