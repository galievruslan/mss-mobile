using System.Collections.Generic;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data;
using MSS.WinMobile.Infrastructure.Remote.Data;

namespace MSS.WinMobile.Commands.Synchronization
{
    public class SynchronizeUnitsOfMeasure : SynchronizationCommand {

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(SynchronizeUnitsOfMeasure));

        private readonly Server _server;

        public SynchronizeUnitsOfMeasure(Server server, ISession session)
            :base(session) {
            _server = server;
        }

        protected override bool Execute() {
            var uoms = new List<UnitOfMeasure>();

            int pageNumber = 1;
            const int itemsPerPage = 100;
            var uomsDtos = _server.UnitOfMeasureService.GetUnitsOfMeasures(pageNumber, itemsPerPage);
            while (uomsDtos.Length > 0)
            {
                foreach (var uomDto in uomsDtos)
                {
                    var uom = new UnitOfMeasure
                    {
                        Id = uomDto.Id,
                        Name = uomDto.Name
                    };
                    uoms.Add(uom);
                }
                SynchronizeEntity(uoms);
                uoms.Clear();

                pageNumber++;
                uomsDtos = _server.UnitOfMeasureService.GetUnitsOfMeasures(pageNumber, itemsPerPage);
            }

            return true;
        }
    }
}
