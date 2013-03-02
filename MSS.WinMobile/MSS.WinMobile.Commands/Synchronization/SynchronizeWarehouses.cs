using System.Collections.Generic;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data;
using MSS.WinMobile.Infrastructure.Remote.Data;

namespace MSS.WinMobile.Commands.Synchronization
{
    public class SynchronizeWarehouses : SynchronizationCommand {

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(SynchronizeWarehouses));

        private readonly Server _server;

        public SynchronizeWarehouses(Server server, ISession session)
            :base(session) {
            _server = server;
        }

        protected override bool Execute() {
            var warehouses = new List<Warehouse>();

            int pageNumber = 1;
            const int itemsPerPage = 100;
            var warehousesDtos = _server.WarehouseService.GetWarehouses(pageNumber, itemsPerPage);
            while (warehousesDtos.Length > 0) {
                foreach (var warehouseDto in warehousesDtos) {
                    var warehouse = new Warehouse
                        {
                            Id = warehouseDto.Id,
                            Address = warehouseDto.Address
                        };
                    warehouses.Add(warehouse);
                }
                SynchronizeEntity(warehouses);
                warehouses.Clear();

                pageNumber++;
                warehousesDtos = _server.WarehouseService.GetWarehouses(pageNumber, itemsPerPage);
            }

            return true;
        }
    }
}
