using System.Data;
using System.Linq;
using MSS.WinMobile.Domain.Models.ActiveRecord;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject.Conditions;

namespace MSS.WinMobile.Domain.Models
{
    public partial class ProductsUnitOfMeasure : ActiveRecordBase
    {
        internal ProductsUnitOfMeasure(IDataRecord record, string fieldPrefix)
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
                    case Table.Fields.UOM_ID:
                        {
                            UnitOfMeasureId = record.GetInt32(i);
                            break;
                        }
                    case Table.Fields.PRODUCT_ID:
                        {
                            ProductId = record.GetInt32(i);
                            break;
                        }
                }
            }
        }

        public static class Table
        {
            public const string TABLE_NAME = "ProductsUnitOfMeasures";

            public static class Fields
            {
                public const string ID = "Id";
                public const string PRODUCT_ID = "Product_Id";
                public const string UOM_ID = "UnitOfMeasure_Id";
                public const string BASE = "Base";
            }    
        }

        public static ProductsUnitOfMeasure GetById(int id)
        {
            return QueryObjectFactory.CreateQueryObject<ProductsUnitOfMeasure>().Where(Table.Fields.ID, new Equals(id)).FirstOrDefault();
        }
    }
}
