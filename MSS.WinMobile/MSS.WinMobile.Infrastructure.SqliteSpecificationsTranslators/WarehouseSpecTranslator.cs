using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects.ISpecifications;
using MSS.WinMobile.UI.Presenters.Presenters.Specificarions;

namespace MSS.WinMobile.Infrastructure.Sqlite.SpecificationsTranslators {
    public class WarehouseSpecTranslator : CommonTranslator<Warehouse> {
        public override string Translate(ISpecification<Warehouse> specification) {
            try {
                return base.Translate(specification);
            }
            catch (TranslatorNotFoundExceprion) {
            }

            if (specification is DefaultWarehouseSpec) {
                return string.Format("[Default] = 1");
            }

            throw new TranslatorNotFoundExceprion(specification.GetType());
        }
    }
}
