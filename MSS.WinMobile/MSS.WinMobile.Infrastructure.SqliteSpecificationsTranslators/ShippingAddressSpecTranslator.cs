using System.Globalization;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects.Specifications;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects.ISpecifications;
using MSS.WinMobile.UI.Presenters.Presenters.Specifications;

namespace MSS.WinMobile.Infrastructure.Sqlite.SpecificationsTranslators {
    public class ShippingAddressSpecTranslator : CommonTranslator<ShippingAddress> {
        public override string Translate(ISpecification<ShippingAddress> specification) {
            try {
                return base.Translate(specification);
            }
            catch (TranslatorNotFoundExceprion) {}

            if (specification is CustomersShippingAddressesSpec) {
                return string.Format("Customer_Id = {0}",
                                     (specification as CustomersShippingAddressesSpec).Customer.Id);
            }
            if (specification is ShippingAddressWithNameOrAddressLikeSpec) {
                string criteria =
                    (specification as ShippingAddressWithNameOrAddressLikeSpec).Criteria;
                return string.Format("LOWER(Name) like '%{0}%' Or LOWER(Address) like '%{0}%'",
                                     criteria.ToLower());
            }

            throw new TranslatorNotFoundExceprion(specification.GetType());
        }
    }
}
