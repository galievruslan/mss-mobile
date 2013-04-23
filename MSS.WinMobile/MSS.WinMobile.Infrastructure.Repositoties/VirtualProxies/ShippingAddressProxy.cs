using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies
{
    public class ShippingAddressProxy : ShippingAddress
    {
        internal void SetId(int id)
        {
            Id = id;
        }

        internal void SetAddress(string address)
        {
            Address = address;
        }

        internal void SetName(string name)
        {
            Name = name;
        }

        internal void SetCustomerId(int customerId)
        {
            CustomerId = customerId;
        }

        internal void SetMine(bool mine)
        {
            Mine = mine;
        }
    }
}