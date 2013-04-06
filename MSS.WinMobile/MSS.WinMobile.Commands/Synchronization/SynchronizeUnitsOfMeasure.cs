using System;
using System.Collections.Generic;
using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Domain.Models.ActiveRecord;
using MSS.WinMobile.Infrastructure.Server;

namespace MSS.WinMobile.Commands.Synchronization
{
    public class SynchronizeUnitsOfMeasure : Command<bool> {

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(SynchronizeUnitsOfMeasure));

        private readonly Server _server;

        public SynchronizeUnitsOfMeasure(Server server)
        {
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
                    var uom = new UnitOfMeasure(uomDto.Id, uomDto.Name);
                    uoms.Add(uom);
                }

                if (uoms.Any())
                {
                    ActiveRecordBase.BeginTransaction();
                    try
                    {
                        foreach (var unitOfMeasure in uoms) {
                            unitOfMeasure.Create();
                        }
                        ActiveRecordBase.Commit();
                    }
                    catch (Exception)
                    {
                        ActiveRecordBase.Rollback();
                    }
                }

                uoms.Clear();

                pageNumber++;
                uomsDtos = _server.UnitOfMeasureService.GetUnitsOfMeasures(pageNumber, itemsPerPage);
            }

            return true;
        }
    }
}
