using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects.Specifications;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects.ISpecifications;

namespace MSS.WinMobile.Infrastructure.Sqlite.SpecificationsTranslators {
    public class RoutePointTemplateSpecTranslator : CommonTranslator<RoutePointTemplate> {
        public override string Translate(ISpecification<RoutePointTemplate> specification) {
            try {
                return base.Translate(specification);
            }
            catch (TranslatorNotFoundExceprion) {}

            if (specification is RouteTemplatesPointsSpec) {
                return string.Format("RouteTemplate_Id = {0}",
                                     (specification as RouteTemplatesPointsSpec).RouteTemplate.Id);
            }

            throw new TranslatorNotFoundExceprion(specification.GetType());
        }
    }
}
