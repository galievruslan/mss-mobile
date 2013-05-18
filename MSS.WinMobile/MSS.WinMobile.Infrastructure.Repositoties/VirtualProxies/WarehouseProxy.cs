using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.VirtualProxies
{
    public class WarehouseProxy : Warehouse
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
    }
}
