using Microsoft.EntityFrameworkCore;
using New_CRUDTask.Model;

namespace New_CRUDTask.Server
{
    public class DbContextServer:DbContext
    {
        public DbContextServer(DbContextOptions<DbContextServer> o) : base(o)
        {
            
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductOrder>()
            .HasKey(op => new { op.OrderId, op.ProductId });


            //  Users
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, FirstName = "Rohit", LastName = "Sharma", Gmail = "RohitSharma@gmail.com", Password = "264", IsActive = true },
                new User { UserId = 2, FirstName = "Virat", LastName = "Kohli", Gmail = "ViratKohli@gmail.com", Password = "51", IsActive = true }
            );

            //  Categories
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Electronics", IsActive = true },
                new Category { CategoryId = 2, Name = "Clothing", IsActive = true }
            );

            //  Products
            modelBuilder.Entity<Product>().HasData(
                new Product { ProductId = 1, ProductName = "Laptop", Pirce = 800, IsActive = true, CategoryId = 1 },
                new Product { ProductId = 2, ProductName = "Smartphone", Pirce = 600, IsActive = true, CategoryId = 1 },
                new Product { ProductId = 3, ProductName = "Jeans", Pirce = 50, IsActive = true, CategoryId = 2 }
            );

            //  Orders
            modelBuilder.Entity<Order>().HasData(
                new Order { OrderId = 1, UserId = 1 }, 
                new Order { OrderId = 2, UserId = 2 }  
            );

            //  ProductOrders (Many-to-Many Relationship)
            modelBuilder.Entity<ProductOrder>().HasData(
                new ProductOrder { OrderId = 1, ProductId = 1, Quntity = 2 },
                new ProductOrder { OrderId = 1, ProductId = 3, Quntity = 1 },
                new ProductOrder { OrderId = 2, ProductId = 2, Quntity = 1 }  
            );
        }
    }
}
