using System;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage.QueryObjects.ISpecifications;

namespace MSS.WinMobile.UI.Presenters.Presenters.Specificarions {
    public class RouteTemplateByDayOfWeekSpec : ISpecification<RouteTemplate> {

        public DayOfWeek DayOfWeek { get; private set; }
        public RouteTemplateByDayOfWeekSpec(DayOfWeek dayOfWeek) {
            DayOfWeek = dayOfWeek;
        }
    }
}
