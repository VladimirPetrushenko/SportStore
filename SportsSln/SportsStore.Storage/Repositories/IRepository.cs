using System.Linq;

namespace SportsStore.Storage.Repositories
{
    public interface IRepository<T>
    {
        IQueryable<T> Items { get; }
        void Save(T item);
        void Create(T p);
        void Delete(T p);
    }
}
