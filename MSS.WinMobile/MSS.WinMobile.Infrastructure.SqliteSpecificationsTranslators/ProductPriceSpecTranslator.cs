using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects.Specifications;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects.ISpecifications;

namespace MSS.WinMobile.Infrastructure.Sqlite.SpecificationsTranslators {
    public class ProductPriceSpecTranslator : CommonTranslator<ProductsPrice> {
        public override string Translate(ISpecification<ProductsPrice> specification) {
            try {
                return base.Translate(specification);
            }
            catch (TranslatorNotFoundExceprion) {}

            if (specification is PricesLinesSpec) {
                return string.Format("PriceList_Id = {0}",
                                     (specification as PricesLinesSpec).PriceList.Id);
            }

            throw new TranslatorNotFoundExceprion(specification.GetType());
        }
    }
}
