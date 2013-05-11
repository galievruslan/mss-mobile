﻿using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties.QueryObjects.Specifications;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects.ISpecifications;

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

            throw new TranslatorNotFoundExceprion(specification.GetType());
        }
    }
}
