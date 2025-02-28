using System.ComponentModel.DataAnnotations.Schema;

namespace MVCP_BookStore.Models
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        [ForeignKey("order")]
        public int OrderId { get; set; }
        [ForeignKey("book")]
        public int BookId { get; set; }
        public virtual Order order { get; set; }
        public virtual Book book { get; set; }

    }
}
