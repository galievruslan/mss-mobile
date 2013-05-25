using System.Globalization;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects.ISpecifications;
using MSS.WinMobile.UI.Presenters.Presenters.Specifications;

namespace MSS.WinMobile.Infrastructure.Sqlite.SpecificationsTranslators {
    public class PriceListSpecTranslator : CommonTranslator<PriceList> {
        public override string Translate(ISpecification<PriceList> specification) {
            try {
                return base.Translate(specification);
            }
            catch (TranslatorNotFoundExceprion) {
            }
            
            if (specification is PriceListWithNameLikeSpec) {
                string criteria = (specification as PriceListWithNameLikeSpec).Criteria;
                return string.Format("LOWER(Name) like '%{0}%'", criteria.ToLower());
            }

            throw new TranslatorNotFoundExceprion(specification.GetType());
        }
    }
}
