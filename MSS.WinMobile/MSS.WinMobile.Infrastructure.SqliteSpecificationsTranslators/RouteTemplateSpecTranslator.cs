using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects.ISpecifications;
using MSS.WinMobile.UI.Presenters.Presenters.Specificarions;

namespace MSS.WinMobile.Infrastructure.Sqlite.SpecificationsTranslators {
    public class RouteTemplateSpecTranslator : CommonTranslator<RouteTemplate> {
        public override string Translate(ISpecification<RouteTemplate> specification) {
            try {
                return base.Translate(specification);
            }
            catch (TranslatorNotFoundExceprion) { }

            if (specification is RouteTemplateByDayOfWeekSpec) {
                return string.Format("DayOfWeek = {0}",
                                     (int)(specification as RouteTemplateByDayOfWeekSpec).DayOfWeek);
            }

            throw new TranslatorNotFoundExceprion(specification.GetType());
        }
    }
}
