using Microsoft.AspNetCore.Mvc;
using SportsStore.Storage.Models;
using SportsStore.Storage.Repositories;
using System.Linq;

namespace SportsStore.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private readonly IRepository<Product> _repository;

        public NavigationMenuViewComponent(IRepository<Product> repository)
        {
            _repository = repository;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(_repository.Items
                .Select(x => x.Category)
                .Distinct()
                .OrderBy(x=>x));
        }
    }
}
