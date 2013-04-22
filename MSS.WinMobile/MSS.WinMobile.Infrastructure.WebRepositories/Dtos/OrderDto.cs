using System;
using MSS.WinMobile.Infrastructure.Server.Dtos;

namespace MSS.WinMobile.Infrastructure.WebRepositories.Dtos
{
    public class OrderDto
    {
        public OrderDto()
        {
            Items = new OrderItemDto[0];
        }

        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int ShippindAddressId { get; set; }

        public int ManagerId { get; set; }

        public OrderItemDto[] Items { get; set; }
    }
}
