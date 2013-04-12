using System;

namespace MSS.WinMobile.Domain.Models
{
    public partial class OrderItem
    {
        public OrderItem()
        {
        }

        public int OrderId { get; private set; }

        public Product Product { get; private set; }

        public int Quantity { get; private set; }
    }
}
