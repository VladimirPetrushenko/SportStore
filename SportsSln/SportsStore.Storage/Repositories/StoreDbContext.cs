using Microsoft.EntityFrameworkCore;
using SportsStore.Storage.Models;

namespace SportsStore.Storage.Repositories
{
    public class StoreDbContext : DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options)
            : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
