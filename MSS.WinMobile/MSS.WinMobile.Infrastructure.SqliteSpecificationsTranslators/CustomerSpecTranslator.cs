using System.Globalization;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects.ISpecifications;
using MSS.WinMobile.UI.Presenters.Presenters.Specifications;

namespace MSS.WinMobile.Infrastructure.Sqlite.SpecificationsTranslators {
    public class CustomerSpecTranslator : CommonTranslator<Customer> {
        public override string Translate(ISpecification<Customer> specification) {
            try {
                return base.Translate(specification);
            }
            catch (TranslatorNotFoundExceprion) {
            }
            
            if (specification is CustomerWithNameLikeSpec) {
                string criteria =
                    (specification as CustomerWithNameLikeSpec).Criteria;
                return string.Format("LOWER(Name) like '%{0}%'", criteria.ToLower());
            }

            throw new TranslatorNotFoundExceprion(specification.GetType());
        }
    }
}
