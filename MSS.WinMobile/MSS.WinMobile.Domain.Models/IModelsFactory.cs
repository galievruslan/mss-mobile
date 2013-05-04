using System;

namespace MSS.WinMobile.Domain.Models
{
    // TODO realize model instatiation via Factories and Factory methods
    public interface IModelsFactory {
        Route CreateRoute(DateTime date);
        Order CreateOrder();
    }
}
