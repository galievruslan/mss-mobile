using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.QueryObjects
{
    public class ManagerQueryObject : QueryObject<Manager>
    {
        public ManagerQueryObject(ITranslator<Manager> translator)
            : base(translator)
        {
        }

        public ManagerQueryObject(IQueryObject<Manager, string> queryObject)
            : base(queryObject)
        {
        }

        private const string SelectQuery = "SELECT Id, Name FROM Managers";
        public override string AsQuery()
        {
            return SelectQuery;
        }
    }
}
