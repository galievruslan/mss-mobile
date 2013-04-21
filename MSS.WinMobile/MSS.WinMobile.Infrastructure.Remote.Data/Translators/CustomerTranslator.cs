﻿using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Server.Dtos;

namespace MSS.WinMobile.Infrastructure.Server.Translators
{
    public class CustomerTranslator : DtoTranslator<Customer, CustomerDto>
    {
        protected override CustomerDto ModelToDto(Customer value)
        {
            var customerDto = new CustomerDto { Id = value.Id, Name = value.Name };
            return customerDto;
        }

        protected override Customer DtoToModel(CustomerDto value)
        {
            return new Customer(value.Id, value.Name);
        }
    }
}
