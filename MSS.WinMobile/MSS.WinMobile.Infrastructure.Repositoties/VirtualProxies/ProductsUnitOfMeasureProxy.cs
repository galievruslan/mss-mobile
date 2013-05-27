using MSS.WinMobile.Domain.Models;

namespace MSS.WinMobile.Infrastructure.Sqlite.Repositoties.VirtualProxies {
    public class ProductsUnitOfMeasureProxy : ProductsUnitOfMeasure {
        public new int Id {
            get { return base.Id; }
            set { base.Id = value; }
        }

        public new int UnitOfMeasureId {
            get { return base.UnitOfMeasureId; }
            set { base.UnitOfMeasureId = value; }
        }

        public new string UnitOfMeasureName {
            get { return base.UnitOfMeasureName; }
            set { base.UnitOfMeasureName = value; }
        }

        public new int ProductId {
            get { return base.ProductId; }
            set { base.ProductId = value; }
        }

        public new float CountInBaseUnit {
            get { return base.CountInBaseUnit; }
            set { base.CountInBaseUnit = value; }
        }

        public new bool Base {
            get { return base.Base; }
            set { base.Base = value; }
        }
    }
}