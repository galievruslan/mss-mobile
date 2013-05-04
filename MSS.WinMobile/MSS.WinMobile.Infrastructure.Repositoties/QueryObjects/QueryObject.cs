using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Text;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.Translators;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects.ISpecifications;
using log4net;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects
{
    public abstract class QueryObject<TModel> : IQueryObject<TModel> where TModel : IModel
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(QueryObject<TModel>));

        protected IStorage Storage { get; private set; }
        protected ISpecificationTranslator<TModel> SpecificationTranslator { get; private set; }
        protected DataRecordTranslator<TModel> Translator { get; private set; }

        protected QueryObject(IStorage storage,
                              ISpecificationTranslator<TModel> specificationTranslator,
                              DataRecordTranslator<TModel> translator) {
            Storage = storage;
            SpecificationTranslator = specificationTranslator;
            Translator = translator;
        }

        public IQueryObject<TModel> Where(ISpecification<TModel> specification) {
            return new FiltredQueryObject<TModel>(Storage, SpecificationTranslator,
                                                  Translator, AsQuery(),
                                                  specification);
        }

        public IQueryObject<TModel> OrderBy(string fieldName, OrderDirection orderDirection) {
            return new OrderedQueryObject<TModel>(Storage, SpecificationTranslator,
                                                  Translator, AsQuery(),
                                                  fieldName, orderDirection);
        }

        public IPagedQueryObject<TModel> Paged(int countToSkip, int countToTake) {
            return new PagedQueryObject<TModel>(Storage, SpecificationTranslator,
                                                Translator, AsQuery(),
                                                countToSkip, countToTake);
        }

        public int Count() {
            var queryStringBuilder = new StringBuilder();
            queryStringBuilder.Append("SELECT COUNT(*)");
            queryStringBuilder.Append(string.Format(" FROM ({0}) AS [source]", AsQuery()));
            string commandText = queryStringBuilder.ToString();

            int count;
            IDbConnection connection = Storage.Connect();
            using (IDbCommand command = connection.CreateCommand()) {
                command.CommandText = commandText;

                object result = command.ExecuteScalar();

                count = Convert.ToInt32(result);
            }

            return count;
        }

        protected abstract string AsQuery();

        protected virtual TModel[] Execute()
        {
            Log.DebugFormat("Select from database.");
            string commandText = AsQuery(); 

            try
            {
                IDbConnection connection = Storage.Connect();
                using (IDbCommand command = connection.CreateCommand())
                {   
                    command.CommandText = commandText;
                    using (IDataReader reader = command.ExecuteReader(CommandBehavior.SingleResult))
                    {
                        return Translator.Translate(reader);
                    }
                }
            }
            catch (Exception exception)
            {
                Log.Error(string.Format("Query: {0}", commandText), exception);
            }

            return new TModel[0];
        }

        public IEnumerator<TModel> GetEnumerator()
        {
            return new ObjectEnumerator<TModel>(Execute());
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    public class FieldNotExistException : Exception
    {
        public FieldNotExistException(string tableName, string filedName)
            :base(string.Format(@"Field ""{0}"" not exist in table ""{1}""", filedName, tableName))
        {
        }
    }
}
