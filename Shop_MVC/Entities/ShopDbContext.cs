using Microsoft.EntityFrameworkCore;

namespace Shop_MVC.Entities
{
    public class ShopDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        

        public ShopDbContext(DbContextOptions options) : base(options)
        {
            this.Database.AutoTransactionBehavior = AutoTransactionBehavior.Never;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>();
            modelBuilder.Entity<Order>();
            modelBuilder.Entity<OrderItem>();
            modelBuilder.Entity<Comment>();
            modelBuilder.Entity<User>();
            modelBuilder.Entity<Role>();
        }
    }
}
