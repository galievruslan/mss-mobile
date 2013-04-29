using System.Collections.Generic;
using System.Data;
using MSS.WinMobile.Infrastructure.Data;

namespace MSS.WinMobile.Infrastructure.SqliteRepositoties.Translators
{
    public abstract class DataRecordTranslator<TModel> : ITranslator<TModel, IDataReader>
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
