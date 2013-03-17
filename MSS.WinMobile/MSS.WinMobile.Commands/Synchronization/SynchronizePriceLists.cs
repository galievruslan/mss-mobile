using System;
using System.Collections.Generic;
using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Domain.Models.ActiveRecord;
using MSS.WinMobile.Infrastructure.Server;

namespace MSS.WinMobile.Commands.Synchronization
{
    public class SynchronizePriceLists : Command<bool> {

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(SynchronizePriceLists));

        private readonly Server _server;

        public SynchronizePriceLists(Server server)
        {
            _server = server;
        }

        protected override bool Execute() {
            var priceLists = new List<PriceList>();

            int pageNumber = 1;
            const int itemsPerPage = 1;
            var priceListsDtos = _server.PriceListService.GetPriceLists(pageNumber, itemsPerPage);
            while (priceListsDtos.Length > 0)
            {
                foreach (var priceListDto in priceListsDtos)
                {
                    var priceList = new PriceList(priceListDto.Id, priceListDto.Name);
                    priceLists.Add(priceList);
                }

                if (priceLists.Any())
                {
                    ActiveRecordBase.BeginTransaction();
                    try
                    {
                        foreach (var priceList in priceLists)
                        {
                            if (PriceList.GetById(priceList.Id) != null)
                                priceList.Update();
                            else
                                priceList.Create();
                        }
                        ActiveRecordBase.Commit();
                    }
                    catch (Exception)
                    {
                        ActiveRecordBase.Rollback();
                    }
                }

                priceLists.Clear();

                pageNumber++;
                priceListsDtos = _server.PriceListService.GetPriceLists(pageNumber, itemsPerPage);
            }

            return true;
        }
    }
}
