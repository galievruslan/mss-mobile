using System;
using System.Collections.Generic;
using System.Linq;
using MSS.WinMobile.Common.Observable;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Domain.Models.ActiveRecord;
using MSS.WinMobile.Infrastructure.Server;

namespace MSS.WinMobile.Commands.Synchronization
{
    public class SynchronizeStatuses : Command<bool> {

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(SynchronizeStatuses));

        private readonly Server _server;

        public SynchronizeStatuses(Server server)
        {
            _server = server;
        }

        protected override bool Execute() {
            var statuses = new List<Status>();

            int pageNumber = 1;
            const int itemsPerPage = 100;
            var statusesDtos = _server.StatusService.GetStatuses(pageNumber, itemsPerPage);
            while (statusesDtos.Length > 0)
            {
                Notificate(
    new TextNotification(string.Format("Synchronize Statuses from {0} to {1}.",
                                       (pageNumber - 1) * itemsPerPage,
                                       (pageNumber - 1) * itemsPerPage + itemsPerPage)));

                foreach (var statusDto in statusesDtos)
                {
                    var status = new Status(statusDto.Id, statusDto.Name);
                    statuses.Add(status);
                }

                if (statuses.Any())
                {
                    ActiveRecordBase.BeginTransaction();
                    try
                    {
                        foreach (var price in statuses) {
                            price.Create();
                        }
                        ActiveRecordBase.Commit();
                    }
                    catch (Exception)
                    {
                        ActiveRecordBase.Rollback();
                    }
                }

                statuses.Clear();

                pageNumber++;
                statusesDtos = _server.StatusService.GetStatuses(pageNumber, itemsPerPage);
            }

            return true;
        }
    }
}
