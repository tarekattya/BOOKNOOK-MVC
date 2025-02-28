using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCP_BookStore.Models;

namespace MVCP_BookStore.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly BookStoreDBContext _Context;
        private readonly Cart _Cart;
        public OrderController(BookStoreDBContext context, Cart cart)
        {
            _Context = context;
            _Cart = cart;
        }
        public IActionResult Checkout()
        {
            return View();
        }
        public IActionResult CheckoutComplete(Order order)
        {
            return View(order);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Checkout(Order order)
        {
            var cartItems = _Cart.GetCartItems();
            _Cart.CartItems = cartItems;
            if (_Cart.CartItems.Count == 0)
            {
                ModelState.AddModelError("", "Cart is Empty Please Add Products First");
            }
            if (ModelState.IsValid)
            {
                CreateOrder(order);
                _Cart.ClearCart();
                return View("CheckoutComplete",order);
            }
            return View(order);

        }
        public void CreateOrder(Order order)
        {
            if (order != null)
            {
                order.orderPlaced = DateTime.Now;
                var cartItems = _Cart.CartItems;
                foreach (var item in cartItems)
                {
                    OrderItem order1 = new()
                    {
                        Quantity = item.Quantity,
                        OrderId = order.Id,
                        BookId = item.Book.Id,
                        Price = item.Book.Price * item.Quantity,
                    };
                    order.OrderItems.Add(order1);
                    order.OrderTotal += order1.Price;
                }
                _Context.orders.Add(order);
                _Context.SaveChanges();

            }
        }
    }
}
