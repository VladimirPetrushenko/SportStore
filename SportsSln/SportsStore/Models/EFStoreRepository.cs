using System.Linq;

namespace SportsStore.Models
{
    public class EFStoreRepository : IRepository<Product>
    {
        private readonly StoreDbContext _context;

        public EFStoreRepository(StoreDbContext context)
        {
            _context = context;
        }

        public IQueryable<Product> Items => _context.Products;

        public void SaveOrder(Product order)
        {
            _context.SaveChanges();
        }
    }
}
