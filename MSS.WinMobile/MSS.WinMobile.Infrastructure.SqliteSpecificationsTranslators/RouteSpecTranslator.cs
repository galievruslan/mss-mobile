using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects.ISpecifications;
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

            throw new TranslatorNotFoundExceprion(specification.GetType());
        }
    }
}
