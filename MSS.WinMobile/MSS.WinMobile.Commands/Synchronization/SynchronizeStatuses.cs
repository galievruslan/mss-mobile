using System.Collections.Generic;
using MSS.WinMobile.Domain.Models;
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
                foreach (var statusDto in statusesDtos)
                {
                    var status = new Status
                    {
                        Id = statusDto.Id,
                        Name = statusDto.Name
                    };
                    statuses.Add(status);
                }
                //SynchronizeEntity(statuses);
                statuses.Clear();

                pageNumber++;
                statusesDtos = _server.StatusService.GetStatuses(pageNumber, itemsPerPage);
            }

            return true;
        }
    }
}
