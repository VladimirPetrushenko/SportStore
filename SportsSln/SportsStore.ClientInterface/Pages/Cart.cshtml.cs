using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportsStore.Storage.Models;
using SportsStore.Storage.Repositories;
using System.Linq;

namespace SportsStore.ClientInterface.Pages
{
    public class CartModel : PageModel
    {
        private readonly IRepository<Product> _repository;

        public CartModel(IRepository<Product> repository, Cart carService)
        {
            _repository = repository;
            Cart = carService;
        }

        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(long productId, string returnUrl)
        {
            Product product = _repository.Items
                .FirstOrDefault(p => p.ProductID == productId);

            Cart.AddItem(product, 1);

            return RedirectToPage(new { returnUrl });
        }

        public IActionResult OnPostRemove(long productId, string returnUrl)
        {
            Cart.RemoveLine(
                Cart.Lines.First(l => l.Product.ProductID == productId).Product
            );
            return RedirectToPage(new { returnUrl });
        }
    }
}