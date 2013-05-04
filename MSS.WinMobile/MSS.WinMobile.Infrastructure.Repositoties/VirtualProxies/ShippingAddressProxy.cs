using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.VirtualProxies
{
    public class ShippingAddressProxy : ShippingAddress
    {
        new public int Id
        {
            get { return base.Id; }
            set { base.Id = value; }
        }

        new public string Name
        {
            get { return base.Name; }
            set { base.Name = value; }
        }

        new public string Address
        {
            get { return base.Address; }
            set { base.Address = value; }
        }

        new public int CustomerId
        {
            get { return base.CustomerId; }
            set { base.CustomerId = value; }
        }

        new public bool Mine
        {
            get { return base.Mine; }
            set { base.Mine = value; }
        }
    }
}