﻿namespace MSS.WinMobile.Domain.Models
{
    public partial class OrderItem
    {
        public int Id { get; set; }
        
        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
