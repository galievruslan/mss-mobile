using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects.Specifications;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects.ISpecifications;

namespace MSS.WinMobile.Infrastructure.Sqlite.SpecificationsTranslators {
    public class RoutePointSpecTranslator : CommonTranslator<RoutePoint> {
        public override string Translate(ISpecification<RoutePoint> specification) {
            try {
                return base.Translate(specification);
            }
            catch (TranslatorNotFoundExceprion) {}

            if (specification is RoutesPointsSpec) {
                return string.Format("Route_Id = {0}",
                                     (specification as RoutesPointsSpec).Route.Id);
            }

            throw new TranslatorNotFoundExceprion(specification.GetType());
        }
    }
}
