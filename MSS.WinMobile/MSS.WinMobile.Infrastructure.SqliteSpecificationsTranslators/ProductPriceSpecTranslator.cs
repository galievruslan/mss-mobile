using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects.Specifications;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects.ISpecifications;
using MSS.WinMobile.UI.Presenters.Presenters.Specificarions;

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
            if (specification is PriceOfProductWithCategorySpec) {
                return string.Format("Product_Category_Id = {0}",
                                     (specification as PriceOfProductWithCategorySpec).Category.Id);
            }
            if (specification is ProductPriceWithNameLikeSpec) {
                return string.Format("Product_Name like '%{0}%'",
                                     (specification as ProductPriceWithNameLikeSpec).Criteria);
            }

            throw new TranslatorNotFoundExceprion(specification.GetType());
        }
    }
}
