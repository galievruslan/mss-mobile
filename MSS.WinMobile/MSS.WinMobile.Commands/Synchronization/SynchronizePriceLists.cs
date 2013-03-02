using System.Collections.Generic;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Data;
using MSS.WinMobile.Infrastructure.Remote.Data;

namespace MSS.WinMobile.Commands.Synchronization
{
    public class SynchronizePriceLists : SynchronizationCommand {

        private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(SynchronizePriceLists));

        private readonly Server _server;

        public SynchronizePriceLists(Server server, ISession session)
            :base(session) {
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
                    var priceList = new PriceList
                    {
                        Id = priceListDto.Id,
                        Name = priceListDto.Name
                    };
                    priceLists.Add(priceList);
                }

                SynchronizeEntity(priceLists);
                priceLists.Clear();

                pageNumber++;
                priceListsDtos = _server.PriceListService.GetPriceLists(pageNumber, itemsPerPage);
            }

            return true;
        }
    }
}
