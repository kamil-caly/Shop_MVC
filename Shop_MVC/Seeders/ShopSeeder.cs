using Shop_MVC.Entities;
using Shop_MVC.Entities.Enums;

namespace Shop_MVC.Seeders
{
    public class ShopSeeder
    {
        private readonly ShopDbContext dbContext;

        public ShopSeeder(ShopDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Seed()
        {
            if (dbContext.Database.CanConnect())
            {
                if (!dbContext.Products.Any())
                {
                    dbContext.Products.AddRange(GetProducts());
                    dbContext.SaveChanges();
                }

                if (!dbContext.Roles.Any())
                {
                    dbContext.Roles.AddRange(GetRoles());
                    dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Product> GetProducts()
        {
            var products = new List<Product>
            {
                new Product { Name = "Nike Air Monarch IV", Img = "https://m.media-amazon.com/images/I/6125yAfsJKL._AC_UX575_.jpg", Price = 140, Color = Color.White, Company = Company.Nike, Category = Category.Sneakers, Quantity = 200 },
                new Product { Name = "Nike Air Vapormax Plus", Img = "https://m.media-amazon.com/images/I/519MRhRKGFL._AC_UX575_.jpg", Price = 145, Color = Color.Red, Company = Company.Nike, Category = Category.Sneakers, Quantity = 150 },
                new Product { Name = "Nike Waffle One Sneaker", Img = "https://m.media-amazon.com/images/I/51+P9uAvb1L._AC_UY695_.jpg", Price = 200, Color = Color.Green, Company = Company.Nike, Category = Category.Sneakers, Quantity = 180 },
                new Product { Name = "Nike Running Shoe", Img = "https://m.media-amazon.com/images/I/71oEKkghg-L._AC_UX575_.jpg", Price = 210, Color = Color.Black, Company = Company.Adidas, Category = Category.Sneakers, Quantity = 170 },
                new Product { Name = "Flat Slip On Pumps", Img = "https://m.media-amazon.com/images/I/41M54ztS6IL._AC_SY625._SX._UX._SY._UY_.jpg", Price = 190, Color = Color.Green, Company = Company.Vans, Category = Category.Flats, Quantity = 120 },
                new Product { Name = "Knit Ballet Flat", Img = "https://m.media-amazon.com/images/I/71zKuNICJAL._AC_UX625_.jpg", Price = 50, Color = Color.Black, Company = Company.Adidas, Category = Category.Flats, Quantity = 160 },
                new Product { Name = "Loafer Flats", Img = "https://m.media-amazon.com/images/I/61V9APfz97L._AC_UY695_.jpg", Price = 130, Color = Color.White, Company = Company.Vans, Category = Category.Flats, Quantity = 140 },
                new Product { Name = "Nike Zoom Freak", Img = "https://m.media-amazon.com/images/I/71VaQ+V6XnL._AC_UY695_.jpg", Price = 200, Color = Color.Green, Company = Company.Nike, Category = Category.Sneakers, Quantity = 190 },
                new Product { Name = "Nike Men's Sneaker", Img = "https://m.media-amazon.com/images/I/61-cBsLhJHL._AC_UY695_.jpg", Price = 200, Color = Color.Blue, Company = Company.Adidas, Category = Category.Sneakers, Quantity = 130 },
                new Product { Name = "PUMA BLACK-OCE", Img = "https://m.media-amazon.com/images/I/81xXDjojYKS._AC_UX575_.jpg", Price = 150, Color = Color.Green, Company = Company.Puma, Category = Category.Sneakers, Quantity = 180 },
                new Product { Name = "Pacer Future Sneaker", Img = "https://m.media-amazon.com/images/I/71E75yRwCDL._AC_UY575_.jpg", Price = 150, Color = Color.Red, Company = Company.Puma, Category = Category.Sneakers, Quantity = 170 },
                new Product { Name = "Unisex-Adult Super", Img = "https://m.media-amazon.com/images/I/71jeoX0rMBL._AC_UX575_.jpg", Price = 150, Color = Color.Black, Company = Company.Puma, Category = Category.Sneakers, Quantity = 190 },
                new Product { Name = "Roma Basic Sneaker", Img = "https://m.media-amazon.com/images/I/61TM6Q9dvxL._AC_UX575_.jpg", Price = 170, Color = Color.White, Company = Company.Puma, Category = Category.Sneakers, Quantity = 200 },
                new Product { Name = "Pacer Future Doubleknit", Img = "https://m.media-amazon.com/images/I/7128-af7joL._AC_UY575_.jpg", Price = 170, Color = Color.Black, Company = Company.Puma, Category = Category.Sneakers, Quantity = 200 },
                new Product { Name = "Fusion Evo Golf Shoe", Img = "https://m.media-amazon.com/images/I/81xXDjojYKS._AC_UX575_.jpg", Price = 100, Color = Color.Green, Company = Company.Puma, Category = Category.Sneakers, Quantity = 160 },
                new Product { Name = "Rainbow Chex Skate", Img = "https://m.media-amazon.com/images/I/719gdz8lsTS._AC_UX575_.jpg", Price = 130, Color = Color.Red, Company = Company.Vans, Category = Category.Flats, Quantity = 120 },
                new Product { Name = "Low-Top Trainers", Img = "https://m.media-amazon.com/images/I/71gpFHJlnoL._AC_UX575_.jpg", Price = 100, Color = Color.White, Company = Company.Vans, Category = Category.Sandals, Quantity = 150 },
                new Product { Name = "Vans Unisex Low-Top", Img = "https://m.media-amazon.com/images/I/71pf7VFs9CL._AC_UX575_.jpg", Price = 160, Color = Color.Blue, Company = Company.Vans, Category = Category.Sandals, Quantity = 150 },
                new Product { Name = "Classic Bandana Sneakers", Img = "https://m.media-amazon.com/images/I/61N4GyWcHPL._AC_UY575_.jpg", Price = 50, Color = Color.Black, Company = Company.Nike, Category = Category.Sandals, Quantity = 140 },
                new Product { Name = "Chunky High Heel", Img = "https://m.media-amazon.com/images/I/61bncQ44yML._AC_UX695_.jpg", Price = 150, Color = Color.Black, Company = Company.Vans, Category = Category.Heels, Quantity = 110 },
                new Product { Name = "Slip On Stiletto High Heel", Img = "https://m.media-amazon.com/images/I/71czu7WgGuL._AC_UY695_.jpg", Price = 150, Color = Color.Black, Company = Company.Puma, Category = Category.Heels, Quantity = 180 },
                new Product { Name = "DREAM PAIRS Court Shoes", Img = "https://m.media-amazon.com/images/I/61men05KRxL._AC_UY625_.jpg", Price = 210, Color = Color.Red, Company = Company.Nike, Category = Category.Heels, Quantity = 190 },
                new Product { Name = "Nike Air Vapormax Plus", Img = "https://m.media-amazon.com/images/I/519MRhRKGFL._AC_UX575_.jpg", Price = 110, Color = Color.Red, Company = Company.Nike, Category = Category.Sneakers, Quantity = 280 },
                new Product { Name = "Low Mid Block Heels", Img = "https://m.media-amazon.com/images/I/51PGWTXgf-L._AC_UY625_.jpg", Price = 200, Color = Color.Black, Company = Company.Nike, Category = Category.Heels, Quantity = 100 },
                new Product { Name = "Chunky High Heel", Img = "https://m.media-amazon.com/images/I/616sA5XUKtL._AC_UY675_.jpg", Price = 230, Color = Color.Black, Company = Company.Adidas, Category = Category.Heels, Quantity = 170 },
                new Product { Name = "Amore Fashion Stilettos", Img = "https://m.media-amazon.com/images/I/71h5+MbEK7L._AC_UY625_.jpg", Price = 240, Color = Color.White, Company = Company.Adidas, Category = Category.Heels, Quantity = 190 },
                new Product { Name = "Bridal Sandals Glitter", Img = "https://m.media-amazon.com/images/I/61uw5RDxKQL._AC_UY625_.jpg", Price = 270, Color = Color.Black, Company = Company.Adidas, Category = Category.Heels, Quantity = 290 },
                new Product { Name = "Wedding Prom Bridal", Img = "https://m.media-amazon.com/images/I/71yhoZP0l6L._AC_UY695_.jpg", Price = 170, Color = Color.Black, Company = Company.Adidas, Category = Category.Flats, Quantity = 130 },
            };

            return products;
        }

        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>
            {
                new Role { Name = "Admin" },
                new Role { Name = "User" }
            };
            return roles;
        }

    }
}
