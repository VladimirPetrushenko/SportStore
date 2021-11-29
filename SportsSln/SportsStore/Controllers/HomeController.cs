using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using System.Linq;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Product> _repository;
        public int PageSize = 4;

        public HomeController(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public ViewResult Index(string category, int productPage = 1) =>
            View(new ProductsListViewModel {
                Products = _repository.Items
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.ProductID)
                    .Skip((productPage - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ? 
                        _repository.Items.Count() :
                        _repository.Items
                            .Where(p=>p.Category==category)
                            .Count()
                }
            });
    }
}
