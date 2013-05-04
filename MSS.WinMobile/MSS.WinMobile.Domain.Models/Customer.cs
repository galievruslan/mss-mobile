using MSS.WinMobile.Infrastructure.Storage.QueryObjects;

namespace MSS.WinMobile.Domain.Models
{
    public abstract class Customer : Model
    {
        public string Name { get; protected set; }
        
        public abstract IQueryObject<ShippingAddress> ShippingAddresses { get; }
    }
}
