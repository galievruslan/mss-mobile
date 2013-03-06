using System.Collections.Generic;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Server;

namespace MSS.WinMobile.Commands.Synchronization
{
    public class SynchronizeManagers : Command<bool>
    {

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(SynchronizeManagers));

        private readonly Server _server;

        public SynchronizeManagers(Server server) {
            _server = server;
        }

        protected override bool Execute() {
            var managers = new List<Manager>();

            int pageNumber = 1;
            const int itemsPerPage = 100;
            var managersDtos = _server.ManagerService.GetManagers(pageNumber, itemsPerPage);
            while (managersDtos.Length > 0)
            {
                foreach (var managerDto in managersDtos)
                {
                    var manager = new Manager
                    {
                        Id = managerDto.Id,
                        Name = managerDto.Name
                    };
                    managers.Add(manager);
                }
                //SynchronizeEntity(managers);
                managers.Clear();

                pageNumber++;
                managersDtos = _server.ManagerService.GetManagers(pageNumber, itemsPerPage);
            }

            return true;
        }
    }
}
