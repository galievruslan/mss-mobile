using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects.Specifications;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects.ISpecifications;

namespace MSS.WinMobile.Infrastructure.Sqlite.SpecificationsTranslators {
    public class OrderItemSpecTranslator : CommonTranslator<OrderItem> {
        public override string Translate(ISpecification<OrderItem> specification) {
            try {
                return base.Translate(specification);
            }
            catch (TranslatorNotFoundExceprion) {}

            if (specification is OrdersItemsSpec) {
                return string.Format("Order_Id = {0}",
                                     (specification as OrdersItemsSpec).Order.Id);
            }

            throw new TranslatorNotFoundExceprion(specification.GetType());
        }
    }
}
