using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects.ISpecifications;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects.Specifications {
    public class WithIdSpec<TModel> : ISpecification<TModel> where TModel : IModel {
        public int Id { get; private set; }

        public WithIdSpec(int id) {
            Id = id;
        }
    }
}
