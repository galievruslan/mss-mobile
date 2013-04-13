using System.Data;
using System.Linq;
using MSS.WinMobile.Domain.Models.ActiveRecord;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject.Conditions;

namespace MSS.WinMobile.Domain.Models
{
    public partial class RoutePointTemplate : ActiveRecordBase
    {
        internal RoutePointTemplate(IDataRecord record, string fieldPrefix)
        {
            for (int i = 0; i < record.FieldCount; i++)
            {
                if (record.IsDBNull(i))
                    continue;

                string fieldName = record.GetName(i);
                if (fieldPrefix != string.Empty)
                    fieldName = fieldName.Replace(fieldPrefix, string.Empty);

                switch (fieldName)
                {
                    case Table.Fields.ID:
                        {
                            Id = record.GetInt32(i);
                            break;
                        }
                    case Table.Fields.ROUTE_TEMPLATE_ID:
                        {
                            RouteTemplateId = record.GetInt32(i);
                            break;
                        }
                    case Table.Fields.SHIPPING_ADDRESS_ID:
                        {
                            ShippingAddressId = record.GetInt32(i);
                            ShippingAddress = new ShippingAddress(record, ShippingAddress.Table.TABLE_NAME + "_");
                            break;
                        }
                }
            }
        }

        public static class Table
        {
            public const string TABLE_NAME = "RoutePointTemplates";

            public static class Fields
            {
                public const string ID = "Id";
                public const string ROUTE_TEMPLATE_ID = "RouteTemplate_Id";
                public const string SHIPPING_ADDRESS_ID = "ShippingAddress_Id";
            }    
        }

        public static RoutePointTemplate GetById(int id)
        {
            return
                QueryObjectFactory.CreateQueryObject<RoutePointTemplate>()
                    .Where(Table.Fields.ID, new Equals(id))
                    .FirstOrDefault();
        }

        public static QueryObject<RoutePointTemplate> GetByRouteTemplate(RouteTemplate routeTemplate)
        {
            return QueryObjectFactory.CreateQueryObject<RoutePointTemplate>()
                                     .Where(Table.Fields.ROUTE_TEMPLATE_ID, new Equals(routeTemplate.Id));
        }
    }
}
