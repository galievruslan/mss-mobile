using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies
{
    public class WarehouseProxy : Warehouse
    {
        new public int Id
        {
            get { return base.Id; }
            set { base.Id = value; }
        }

        new public string Address
        {
            get { return base.Address; }
            set { base.Address = value; }
        }
    }
}
