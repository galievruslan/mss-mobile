using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects.ISpecifications;
using MSS.WinMobile.UI.Presenters.Presenters.Specificarions;

namespace MSS.WinMobile.Infrastructure.Sqlite.SpecificationsTranslators {
    public class PriceListSpecTranslator : CommonTranslator<PriceList> {
        public override string Translate(ISpecification<PriceList> specification) {
            try {
                return base.Translate(specification);
            }
            catch (TranslatorNotFoundExceprion) {
            }
            
            if (specification is PriceListWithNameLikeSpec) {
                return string.Format("UPPER(Name) like '%{0}%'",
                                     (specification as PriceListWithNameLikeSpec).Criteria.ToUpper());
            }

            throw new TranslatorNotFoundExceprion(specification.GetType());
        }
    }
}
