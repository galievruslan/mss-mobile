using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies
{
    public class PriceListProxy : PriceList
    {
        internal void SetId(int id)
        {
            Id = id;
        }

        internal void SetName(string name)
        {
            Name = name;
        }
    }
}
