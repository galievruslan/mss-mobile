using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects.Specifications;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects.ISpecifications;

namespace MSS.WinMobile.Infrastructure.Sqlite.SpecificationsTranslators {
    public class ProductsUnitOfMeasureSpecTranslator : CommonTranslator<ProductsUnitOfMeasure> {
        public override string Translate(ISpecification<ProductsUnitOfMeasure> specification) {
            try {
                return base.Translate(specification);
            }
            catch (TranslatorNotFoundExceprion) { }

            if (specification is ProductUnitsOfMeasuresSpec) {
                return string.Format("Product_Id = {0}",
                                     (specification as ProductUnitsOfMeasuresSpec).Product.Id);
            }

            throw new TranslatorNotFoundExceprion(specification.GetType());
        }
    }
}
