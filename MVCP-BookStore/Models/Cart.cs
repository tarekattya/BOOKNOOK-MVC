using Microsoft.EntityFrameworkCore;

namespace MVCP_BookStore.Models
{
    public class Cart
    {
        private readonly BookStoreDBContext _bookStoreDBContext;

        public Cart(BookStoreDBContext bookStoreDBContext)
        {
            _bookStoreDBContext = bookStoreDBContext;
        }
        // not id beaccuse the function need it string
        public string Id { get; set; }
        public virtual List<CartItem> CartItems { get; set; }

          //عشان نخزن الكتب جوا ال cart
            public static Cart GetCart(IServiceProvider services)
            {
                ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
                var context = services.GetService<BookStoreDBContext>();
                string cartId = session.GetString("Id") ?? Guid.NewGuid().ToString();
                session.SetString("Id", cartId);

                return new Cart(context) { Id = cartId };
            }

        public List<CartItem> GetCartItems()
        {

            return CartItems ??
                _bookStoreDBContext.CartItems.Where(c => c.CartId == Id).ToList();


        }

        public int GetTotalPrice()
        {
            return _bookStoreDBContext.CartItems.Where(c => c.CartId == Id).Select(c => c.Book.Price * c.Quantity).Sum();
        }

        public CartItem GetCartItem(Book book)
        {
            return _bookStoreDBContext.CartItems.FirstOrDefault(c => c.Book.Id == book.Id && c.CartId == Id);
        }

        public void AddToCart(Book book, int quantity)
        {
            var cartItem = GetCartItem(book);

            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    Book = book,
                    Quantity = quantity,
                    CartId = Id
                };

                _bookStoreDBContext.CartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity += quantity;
            }
            _bookStoreDBContext.SaveChanges();
        }

        public void RemoveFromCart(Book book)
        {
            var cartItem = GetCartItem(book);
            if (cartItem != null)
            {
                if (cartItem.Quantity >= 1)
                {
                    _bookStoreDBContext.CartItems.Remove(cartItem);
                }
                else
                {
                    ClearCart();
                }
              
                _bookStoreDBContext.SaveChanges();
            }
        }

        public void ReduceQuantity(Book book)
        {
            var cartItem = GetCartItem(book);
            if (cartItem != null)
            {
                if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity--;
                }
                else
                {
                    RemoveFromCart(book);
                }
                _bookStoreDBContext.SaveChanges();
            }
        }

        public void IncreaseQuantity(Book book)
        {
            var cartItem = GetCartItem(book);
            if (cartItem != null)
            {
                cartItem.Quantity++;
                _bookStoreDBContext.SaveChanges();
            }
        }
        public void ClearCart()
        {
            var cartItems = _bookStoreDBContext.CartItems.Where(c => c.CartId == Id);
            _bookStoreDBContext.CartItems.RemoveRange(cartItems);
            _bookStoreDBContext.SaveChanges();
        }

    }
}
