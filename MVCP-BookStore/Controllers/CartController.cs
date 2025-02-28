using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCP_BookStore.Models;

namespace MVCP_BookStore.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly BookStoreDBContext _bookStoreDBContext;
        private readonly Cart _Cart;


        public CartController(Cart cart, BookStoreDBContext bookStoreDBContext)
        {
            _Cart = cart;
            _bookStoreDBContext = bookStoreDBContext;
        }

       
        [AllowAnonymous]
        public IActionResult Index()
        {
            var items = _Cart.GetCartItems();
            _Cart.CartItems = items;
            return View(_Cart);
        }

        [AllowAnonymous]
        public IActionResult AddToCart(int id)
        {
            var book = _bookStoreDBContext.Books.Find(id);
            if (book != null)
            {
                _Cart.AddToCart(book, 1);
            }
            return RedirectToAction("Index","Store");
        }

        public IActionResult RemoveFromCart(int id)
        {
            var book = _bookStoreDBContext.Books.Find(id);
            if (book != null)
            {
                _Cart.RemoveFromCart(book);
            }
            return RedirectToAction("Index");
        }

        public IActionResult ClearCart()
        {
            _Cart.ClearCart();
            return RedirectToAction("Index" );
        }

        public IActionResult ReduceQuantity(int id)
        {
            var book = _bookStoreDBContext.Books.Find(id);
            if (book != null)
            {
                _Cart.ReduceQuantity(book);
            }


            return RedirectToAction("Index");
        }
        public IActionResult IncreaseQuantity(int id)
        {
            var book = _bookStoreDBContext.Books.Find(id);
            if (book != null)
            {
                _Cart.IncreaseQuantity(book);
            }
            return RedirectToAction("Index");
        }

    }
}
