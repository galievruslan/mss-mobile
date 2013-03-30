using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject;

namespace MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers
{
    public class CustomerRetriever : IDataPageRetriever<Customer>
    {
        public int Count {
            get
            {
                return Customer.GetAll().Count();
            }
        }

        public Customer[] SupplyPageOfData(int lowerPageBoundary, int rowsPerPage)
        {
            return
                Customer.GetAll()
                        .OrderBy(Customer.Table.Fields.NAME, OrderDirection.Asceding)
                        .Skip(lowerPageBoundary)
                        .Take(rowsPerPage)
                        .ToArray();
        }
    }
}