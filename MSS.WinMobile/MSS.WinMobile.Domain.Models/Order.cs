using System;

namespace MSS.WinMobile.Domain.Models
{
    public partial class Order
    {
        public Order()
        {
            Date = DateTime.Now;
        }

        public DateTime Date { get; private set; }

        public int ShippindAddressId { get; private set; }

        public int ManagerId { get; private set; }

        public string Note { get; private set; }
    }
}
