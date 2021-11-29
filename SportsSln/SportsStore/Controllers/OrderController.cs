using Microsoft.AspNetCore.Mvc;
using SportsStore.Storage.Models;
using SportsStore.Storage.Repositories;

namespace SportsStore.Controllers
{
    public class OrderController : Controller
    {
        private readonly IRepository<Order> _repository;
        private readonly Cart _cart;

        public OrderController(IRepository<Order> repository, Cart cart)
        {
            _repository = repository;
            _cart = cart;
        }

        public IActionResult Checkout() => View( new Order());

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if(_cart.Lines.Count == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }

            if (ModelState.IsValid)
            {
                order.Lines = _cart.Lines.ToArray();
                _repository.Save(order);
                _cart.Clear();

                return RedirectToPage("/Completed", new { order.OrderID }); 
            }
            else
            {
                return View();
            }
        }
    }
}
