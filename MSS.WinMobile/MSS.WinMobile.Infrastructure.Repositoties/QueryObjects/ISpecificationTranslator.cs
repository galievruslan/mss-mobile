using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects.ISpecifications;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects {

    public interface ISpecificationTranslator<TModel> where TModel : IModel {
        string Translate(ISpecification<TModel> specification);
    }
}
