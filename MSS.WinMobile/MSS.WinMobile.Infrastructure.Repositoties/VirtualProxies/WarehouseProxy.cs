using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies
{
    public class WarehouseProxy : Warehouse
    {
        internal void SetId(int id)
        {
            Id = id;
        }

        internal void SetAddress(string address)
        {
            Address = address;
        }
    }
}
