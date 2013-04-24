using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.VirtualProxies
{
    public class CategoryProxy : Category
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

        new public int ParentId
        {
            get { return base.ParentId; }
            set { base.ParentId = value; }
        }
    }
}
