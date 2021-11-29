using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public interface IRepository<T>
    {
        IQueryable<T> Items { get; }
        void SaveOrder(T order);
    }
}
