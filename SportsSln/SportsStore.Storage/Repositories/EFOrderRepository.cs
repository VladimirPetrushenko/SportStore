using Microsoft.EntityFrameworkCore;
using SportsStore.Storage.Models;
using System;
using System.Linq;

namespace SportsStore.Storage.Repositories
{
    public class EFOrderRepository : IRepository<Order>
    {
        private readonly StoreDbContext _context;

        public EFOrderRepository(StoreDbContext context)
        {
            _context = context;
        }

        public IQueryable<Order> Items =>
            _context.Orders.Include(o => o.Lines).ThenInclude(l => l.Product);

        public void Create(Order p)
        {
            throw new NotImplementedException();
        }

        public void Delete(Order p)
        {
            throw new NotImplementedException();
        }

        public void Save(Order order)
        {
            _context.AttachRange(order.Lines.Select(l => l.Product));
            if(order.OrderID == 0)
            {
                _context.Orders.Add(order);
            }
            _context.SaveChanges();
        }
    }
}
