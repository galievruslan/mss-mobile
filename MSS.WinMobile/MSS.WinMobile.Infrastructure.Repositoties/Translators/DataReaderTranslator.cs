using System.Collections.Generic;
using System.Data;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.Translators
{
    public abstract class DataRecordTranslator<TModel>
    {
        public TModel[] Translate(IDataReader queryResult)
        {
            var models = new List<TModel>(); 
            while (queryResult.Read())
            {
                models.Add(TranslateOne(queryResult));
            }
            return models.ToArray();
        }

        protected abstract TModel TranslateOne(IDataRecord record);
    } 
}
