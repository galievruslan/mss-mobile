﻿namespace MSS.WinMobile.Infrastructure.WebRepositories.Dtos
{
    [UrlAttribute("synchronization/order_items.json")]
    public class OrderItemDto : Dto
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }
    }
}
