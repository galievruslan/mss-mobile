﻿using System.Data;
using System.Linq;
using MSS.WinMobile.Domain.Models.ActiveRecord;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject;
using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject.Conditions;

namespace MSS.WinMobile.Domain.Models
{
    public partial class Product : ActiveRecordBase
    {
        internal Product(IDataRecord record, string fieldPrefix)
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
                    case Table.Fields.CATEGORY_ID:
                        {
                            CategoryId = record.GetInt32(i);
                            break;
                        }
                }
            }
        }

        public static class Table
        {
            public const string TABLE_NAME = "Products";

            public static class Fields
            {
                public const string ID = "Id";
                public const string NAME = "Name";
                public const string CATEGORY_ID = "Category_Id";
            }    
        }

        public static Product GetById(int id)
        {
            return QueryObjectFactory.CreateQueryObject<Product>().Where(Table.Fields.ID, new Equals(id)).FirstOrDefault();
        }
    }
}