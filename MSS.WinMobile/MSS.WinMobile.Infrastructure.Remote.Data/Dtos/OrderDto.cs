using System;

namespace MSS.WinMobile.Infrastructure.Remote.Data.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int ShippindAddressId { get; set; }

        public int ManagerId { get; set; }

        public OrderItemDto[] Items { get; set; }
    }
}
