using System;
using System.Collections.Generic;
using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Domain.Models.ActiveRecord;
using MSS.WinMobile.Infrastructure.Server;

namespace MSS.WinMobile.Commands.Synchronization
{
    public class SynchronizeWarehouses : Command<bool> {

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(SynchronizeWarehouses));

        private readonly Server _server;

        public SynchronizeWarehouses(Server server)
        {
            _server = server;
        }

        protected override bool Execute() {
            var warehouses = new List<Warehouse>();

            int pageNumber = 1;
            const int itemsPerPage = 100;
            var warehousesDtos = _server.WarehouseService.GetWarehouses(pageNumber, itemsPerPage);
            while (warehousesDtos.Length > 0) {
                foreach (var warehouseDto in warehousesDtos)
                {
                    var warehouse = new Warehouse(warehouseDto.Id, warehouseDto.Address);
                    warehouses.Add(warehouse);
                }

                if (warehouses.Any())
                {
                    ActiveRecordBase.BeginTransaction();
                    try
                    {
                        foreach (var warehouse in warehouses)
                        {
                            if (Warehouse.GetById(warehouse.Id) != null)
                                warehouse.Update();
                            else
                                warehouse.Create();
                        }
                        ActiveRecordBase.Commit();
                    }
                    catch (Exception)
                    {
                        ActiveRecordBase.Rollback();
                    }
                }

                warehouses.Clear();

                pageNumber++;
                warehousesDtos = _server.WarehouseService.GetWarehouses(pageNumber, itemsPerPage);
            }

            return true;
        }
    }
}
