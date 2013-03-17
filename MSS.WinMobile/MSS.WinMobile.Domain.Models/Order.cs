using System;

namespace MSS.WinMobile.Domain.Models
{
    public partial class Order
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int ShippindAddressId { get; set; }

        public int ManagerId { get; set; }

        public string Note { get; set; }
    }
}
