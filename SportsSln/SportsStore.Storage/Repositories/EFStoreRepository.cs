using SportsStore.Storage.Models;
using System.Linq;

namespace SportsStore.Storage.Repositories
{
    public class EFStoreRepository : IRepository<Product>
    {
        private readonly StoreDbContext _context;

        public EFStoreRepository(StoreDbContext context)
        {
            _context = context;
        }

        public IQueryable<Product> Items => _context.Products;

        public void Create(Product p)
        {
            _context.Add(p);
            _context.SaveChanges();
        }

        public void Delete(Product p)
        {
            _context.Remove(p);
            _context.SaveChanges();
        }

        public void Save(Product product) => 
            _context.SaveChanges();
    }
}
