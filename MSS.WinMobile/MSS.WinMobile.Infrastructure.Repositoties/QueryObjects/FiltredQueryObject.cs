using System.Data.SQLite;
using System.Text;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.Translators;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects.ISpecifications;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects
{
    public class FiltredQueryObject<TModel> : QueryObject<TModel> where TModel : IModel {
        private readonly string _innerQuery;
        private readonly ISpecification<TModel> _specification;

        internal FiltredQueryObject(IStorage storage,
                                    ISpecificationTranslator<TModel> specificationTranslator,
                                    DataRecordTranslator<TModel> translator, string innerQuery,
                                    ISpecification<TModel> specification)
            : base(storage, specificationTranslator, translator) {
            _innerQuery = innerQuery;
            _specification = specification;
        }

        protected override string AsQuery()
        {
            var queryStringBuilder = new StringBuilder();
            queryStringBuilder.Append("SELECT * ");
            queryStringBuilder.Append(string.Format(" FROM ({0}) AS [source]", _innerQuery));
            queryStringBuilder.Append(string.Format(" WHERE {0}", SpecificationTranslator.Translate(_specification)));
            return queryStringBuilder.ToString();
        }
    }
}
