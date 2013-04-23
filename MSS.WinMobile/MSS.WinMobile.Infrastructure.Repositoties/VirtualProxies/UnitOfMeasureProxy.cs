using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies
{
    public class UnitOfMeasureProxy : UnitOfMeasure
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
