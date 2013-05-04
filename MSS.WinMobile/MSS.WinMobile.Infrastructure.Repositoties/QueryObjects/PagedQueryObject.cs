using System.Text;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.Translators;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects
{
    public class PagedQueryObject<TModel> : QueryObject<TModel>, IPagedQueryObject<TModel> where TModel : IModel {
        private readonly string _innerQuery;
        public int CountToSkip { get; protected set; }
        public int CountToTake { get; protected set; }

        public PagedQueryObject(IStorage storage,
                                ISpecificationTranslator<TModel> specificationTranslator,
                                DataRecordTranslator<TModel> translator, string innerQuery,
                                int countToSkip, int countToTake)
            : base(storage, specificationTranslator, translator) {
            _innerQuery = innerQuery;
            CountToSkip = countToSkip;
            CountToTake = countToTake;
        }

        protected override string AsQuery()
        {
            var queryStringBuilder = new StringBuilder();
            queryStringBuilder.Append(string.Format("{0} LIMIT {1} OFFSET {2}", _innerQuery, CountToTake, CountToSkip));
            return queryStringBuilder.ToString();
        }
    }
}
