using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mss.WinMobile.Domain.Model
{
    public class OrderItem : Entity
    {
        public OrderItem(int id, Order order, Product product, int quantity) 
            :base (id)
        {
            Order = order;
            Product = product;
            Quantity = quantity;
        }

        public Order Order { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
