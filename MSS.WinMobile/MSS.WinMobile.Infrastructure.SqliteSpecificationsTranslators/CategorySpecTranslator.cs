using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects.ISpecifications;
using MSS.WinMobile.UI.Presenters.Presenters.Specifications;

namespace MSS.WinMobile.Infrastructure.Sqlite.SpecificationsTranslators {
    public class CategorySpecTranslator : CommonTranslator<Category> {
        public override string Translate(ISpecification<Category> specification) {
            try {
                return base.Translate(specification);
            }
            catch (TranslatorNotFoundExceprion) {
            }

            if (specification is RootCategoriesSpec) {
                return string.Format("Parent_Id = 0");
            }
            if (specification is ChildCategoriesSpec) {
                return string.Format("Parent_Id = {0}",
                                     (specification as ChildCategoriesSpec).Category.Id);
            }

            throw new TranslatorNotFoundExceprion(specification.GetType());
        }
    }
}
