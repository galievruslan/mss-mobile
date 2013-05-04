using System;

namespace MSS.WinMobile.Infrastructure.Web.Repositories.Dtos
{
    [Url("synchronization/orders.json")]
    public class OrderDto : Dto
    {
        public OrderDto()
        {
            Items = new OrderItemDto[0];
        }

        public int RoutePointId { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime ShippingDate { get; set; }

        public int PriceListId { get; set; }

        public int WarehouseId { get; set; }

        public int ShippindAddressId { get; set; }

        public OrderItemDto[] Items { get; set; }
    }
}
