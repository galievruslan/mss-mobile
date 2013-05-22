using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects.ISpecifications;
using MSS.WinMobile.UI.Presenters.Presenters.Specificarions;

namespace MSS.WinMobile.Infrastructure.Sqlite.SpecificationsTranslators {
    public class CustomerSpecTranslator : CommonTranslator<Customer> {
        public override string Translate(ISpecification<Customer> specification) {
            try {
                return base.Translate(specification);
            }
            catch (TranslatorNotFoundExceprion) {
            }
            
            if (specification is CustomerWithNameLikeSpec) {
                return string.Format("Name like '%{0}%'",
                                     (specification as CustomerWithNameLikeSpec).Criteria);
            }

            throw new TranslatorNotFoundExceprion(specification.GetType());
        }
    }
}
