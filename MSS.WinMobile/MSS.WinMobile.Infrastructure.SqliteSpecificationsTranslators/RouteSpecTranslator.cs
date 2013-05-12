using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects.ISpecifications;
using MSS.WinMobile.Synchronizer.Specifications;
using MSS.WinMobile.UI.Presenters.Presenters.Specificarions;

namespace MSS.WinMobile.Infrastructure.Sqlite.SpecificationsTranslators {
    public class RouteSpecTranslator : CommonTranslator<Route> {
        public override string Translate(ISpecification<Route> specification) {
            try {
                return base.Translate(specification);
            }
            catch (TranslatorNotFoundExceprion) { }

            if (specification is RouteOnDateSpec) {
                return string.Format("Date = '{0}'",
                                     (specification as RouteOnDateSpec).Date.ToString("yyyy-MM-dd HH:mm:ss"));
            }
            if (specification is RoutesToSyncSpec) {
                return "Id in (select distinct Route_Id from RoutePoints where Synchronized = 0)";
            }

            throw new TranslatorNotFoundExceprion(specification.GetType());
        }
    }
}
