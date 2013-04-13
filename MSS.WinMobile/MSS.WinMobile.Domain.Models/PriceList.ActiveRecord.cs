using System.Data;
using System.Linq;
using MSS.WinMobile.Domain.Models.ActiveRecord;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject.Conditions;

namespace MSS.WinMobile.Domain.Models
{
    public partial class PriceList : ActiveRecordBase
    {
        internal PriceList(IDataRecord record, string fieldPrefix)
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
                    case Table.Fields.NAME:
                        {
                            Name = record.GetString(i);
                            break;
                        }
                }
            }
        }

        public static class Table
        {
            public const string TABLE_NAME = "PriceLists";

            public static class Fields
            {
                public const string ID = "Id";
                public const string NAME = "Name";
            }    
        }

        public static PriceList GetById(int id)
        {
            return
                QueryObjectFactory.CreateQueryObject<PriceList>()
                                  .Where(Table.Fields.ID, new Equals(id))
                                  .FirstOrDefault();
        }

        public static QueryObject<PriceList> GetAll()
        {
            return QueryObjectFactory.CreateQueryObject<PriceList>();
        }
    }
}
