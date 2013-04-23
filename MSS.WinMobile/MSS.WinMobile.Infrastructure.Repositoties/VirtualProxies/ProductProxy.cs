using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies
{
    public class ProductProxy : Product
    {
        internal void SetId(int id)
        {
            Id = id;
        }

        internal void SetName(string name)
        {
            Name = name;
        }

        internal void SetCategoryId(int categoryId)
        {
            CategoryId = categoryId;
        }
    }
}
