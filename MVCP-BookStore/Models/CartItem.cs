﻿namespace MVCP_BookStore.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        public virtual Book Book { get; set; }
        public int Quantity { get; set; }
        public string CartId { get; set; }

    }
}
