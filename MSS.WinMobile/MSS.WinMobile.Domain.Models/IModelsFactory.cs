using System;

namespace MSS.WinMobile.Domain.Models
{
    public interface IModelsFactory {
        Route CreateRoute(DateTime date);
        Order CreateOrder();
    }
}
