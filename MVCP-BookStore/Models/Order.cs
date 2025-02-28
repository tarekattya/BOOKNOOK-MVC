namespace MVCP_BookStore.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int OrderTotal { get; set; }
        public DateTime orderPlaced { get; set; }
        public virtual List<OrderItem> OrderItems { get; set; } = new();
    }
}
