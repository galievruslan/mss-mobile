using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects.Specifications;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects.ISpecifications;
using MSS.WinMobile.Synchronizer.Specifications;
using MSS.WinMobile.UI.Presenters.Presenters.Specifications;

namespace MSS.WinMobile.Infrastructure.Sqlite.SpecificationsTranslators {
    public class OrderSpecTranslator : CommonTranslator<Order> {
        public override string Translate(ISpecification<Order> specification) {
            try {
                return base.Translate(specification);
            }
            catch (TranslatorNotFoundExceprion) {
            }

            if (specification is RoutePointsOrdersSpec) {
                return string.Format("RoutePoint_Id = {0}",
                                     (specification as RoutePointsOrdersSpec).RoutePoint.Id);
            }
            if (specification is OrdersToSyncSpec) {
                return "Synchronized = 0";
            }
            if (specification is OrdersOnDateSpec) {
                return string.Format("[OrderDate] = '{0}'",
                                     (specification as OrdersOnDateSpec).Date.Date.ToString("yyyy-MM-dd HH:mm:ss"));
            }

            throw new TranslatorNotFoundExceprion(specification.GetType());
        }
    }
}
