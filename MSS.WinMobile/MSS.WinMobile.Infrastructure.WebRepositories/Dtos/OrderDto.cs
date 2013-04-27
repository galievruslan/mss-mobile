﻿using System;

namespace MSS.WinMobile.Infrastructure.WebRepositories.Dtos
{
    [UrlAttribute("synchronization/orders.json")]
    public class OrderDto : Dto
    {
        public OrderDto()
        {
            Items = new OrderItemDto[0];
        }

        public DateTime Date { get; set; }

        public int ShippindAddressId { get; set; }

        public OrderItemDto[] Items { get; set; }
    }
}
