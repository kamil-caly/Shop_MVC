using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using Shop_MVC.Entities;
using Shop_MVC.Models.Basket;
using Shop_MVC.Services.Interfaces;
using System.Security.Claims;

namespace Shop_MVC.Services
{
    public class OrderService : IOrderService
    {
        private readonly ShopDbContext dbCtx;
        private readonly IHttpContextAccessor httpContextAccessor;
        public OrderService(ShopDbContext dbContext, IHttpContextAccessor httpContextAcc)
        {
            dbCtx = dbContext;
            httpContextAccessor = httpContextAcc;
        }

        public bool Buy(IEnumerable<BasketProductLocalStorage> basketProducts)
        {
            if (basketProducts == null || !basketProducts.Any())
            {
                throw new Exception("Basket is empty");
            }

            var dbProducts = dbCtx.Products
                .Where(p => basketProducts.Select(bp => bp.Id).ToList().Contains(p.Id.ToString()))
                .ToList();

            decimal totalPrice = 0;
            foreach (var bProd in basketProducts)
            {
                var dbProd = dbProducts.First(p => p.Id.ToString() == bProd.Id);
                if (dbProd.Quantity < bProd.Quantity)
                {
                    throw new Exception($"Not enough product in the store: ${dbProd.Name}");
                }
                dbProd.Quantity -= bProd.Quantity;
                totalPrice += dbProd.Price * bProd.Quantity;
            }

            var userId = httpContextAccessor.HttpContext!.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = dbCtx.Users.FirstOrDefault(u => u.Id.ToString() == userId);

            if (user == null)
            {
                throw new Exception("Logged user not found");
            }

            if (totalPrice > user.Money)
            {
                throw new Exception("Not enough money on user account to purchase");
            }

            user.Money -= totalPrice;

            var order = new Order
            {
                CreatedAt = DateTime.UtcNow,
                TotalPrice = totalPrice,
                UserEmail = user.Email
            };

            dbCtx.Users.Update(user);
            dbCtx.Orders.Add(order);
            dbCtx.Products.UpdateRange(dbProducts);
            dbCtx.SaveChanges();

            var orderItems = new List<OrderItem>();
            foreach (var bProd in basketProducts)
            {
                var orderItem = new OrderItem
                {
                    OrderId = order.Id,
                    Quantity = bProd.Quantity,
                    Price = dbProducts.First(p => p.Id.ToString() == bProd.Id).Price * bProd.Quantity,
                    ProductId = ObjectId.Parse(bProd.Id)
                };

                orderItems.Add(orderItem);
            }

            dbCtx.OrderItems.AddRange(orderItems);
            dbCtx.SaveChanges();

            return true;
        }
    }
}
