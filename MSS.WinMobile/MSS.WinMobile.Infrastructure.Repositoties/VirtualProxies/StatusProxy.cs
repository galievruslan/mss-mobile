using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies
{
    public class StatusProxy : Status
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
