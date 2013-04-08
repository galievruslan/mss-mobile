using System;
using System.Collections.Generic;
using System.Linq;
using MSS.WinMobile.Common.Observable;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Domain.Models.ActiveRecord;
using MSS.WinMobile.Infrastructure.Server;

namespace MSS.WinMobile.Commands.Synchronization
{
    public class SynchronizeRouteTemplates : Command<bool> {

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(SynchronizeRouteTemplates));

        private readonly Server _server;

        public SynchronizeRouteTemplates(Server server)
        {
            _server = server;
        }

        protected override bool Execute() {
            var routeTemplates = new List<RouteTemplate>();
            var routePointTemplates = new List<RoutePointTemplate>();

            int managerId = Int32.Parse(ConfigurationManager.AppSettings["ContextManagerId"]);
            var routeTemplatesDtos = _server.RouteTemplateService.GetManagersTemplates(managerId);

            Notificate(
                    new TextNotification(string.Format("Synchronize RouteTemplates")));

            foreach (var routeTemplateDto in routeTemplatesDtos)
            {
                var routeTemplate = new RouteTemplate(routeTemplateDto.Id, routeTemplateDto.ManagerId, (DayOfWeek)routeTemplateDto.DatyOfWeek);
                routeTemplates.Add(routeTemplate);

                foreach (var routePointTemplateDto in routeTemplateDto.RoutePointTemplates)
                {
                    var routePointTemplate = new RoutePointTemplate(routePointTemplateDto.Id, routeTemplateDto.Id,
                                                                    routePointTemplateDto.ShippingAddressId);
                    routePointTemplates.Add(routePointTemplate);
                }
            }

            if (routeTemplates.Any())
            {
                ActiveRecordBase.BeginTransaction();
                try
                {
                    foreach (var routeTemplate in routeTemplates)
                    {
                        routeTemplate.Create();
                    }
                    ActiveRecordBase.Commit();
                }
                catch (Exception)
                {
                    ActiveRecordBase.Rollback();
                }
            }

            if (routePointTemplates.Any())
            {
                ActiveRecordBase.BeginTransaction();
                try
                {
                    foreach (var routePointTemplate in routePointTemplates)
                    {
                        routePointTemplate.Create();
                    }
                    ActiveRecordBase.Commit();
                }
                catch (Exception)
                {
                    ActiveRecordBase.Rollback();
                }
            }

            routeTemplates.Clear();
            routePointTemplates.Clear();

            return true;
        }
    }
}
