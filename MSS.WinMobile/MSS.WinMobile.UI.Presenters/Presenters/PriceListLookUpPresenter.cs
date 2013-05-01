using System.Collections.Generic;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties;
using MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers;
using MSS.WinMobile.UI.Presenters.Presenters.Exceptions;
using MSS.WinMobile.UI.Presenters.Views;
using log4net;

namespace MSS.WinMobile.UI.Presenters.Presenters
{
    public class PriceListLookUpPresenter : IPresenter
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(RoutePresenter));

        private readonly IPriceListLookUpView _view;
        private readonly PriceListRepository _priceListRepository;
        private readonly PriceListRetriever _priceListRetriever;
        private Cache<PriceList> _cache;

        public PriceListLookUpPresenter(IPriceListLookUpView view, PriceListRepository priceListRepository) {
            _priceListRepository = priceListRepository;
            _priceListRetriever = new PriceListRetriever(_priceListRepository);
            _cache = new Cache<PriceList>(_priceListRetriever, 10);
            _view = view;
        }

        public void InitializeView()
        {
            _view.SetItemCount(_priceListRetriever.Count);
        }

        private PriceList _selectedPriceList;

        public void SelectItem(int index)
        {
            _selectedPriceList = _cache.RetrieveElement(index);
        }

        public IDictionary<string, string> GetItemData(int index)
        {
            PriceList item = _cache.RetrieveElement(index);
            return new Dictionary<string, string> { { "Name", item.Name } };
        }

        public int GetSelectedItemId()
        {
            if (_selectedPriceList != null)
                return _selectedPriceList.Id;

            throw new NoSelectedItemsException();
        }

        public void Search(string criteria)
        {
            _priceListRetriever.SearchCriteria = criteria;
            _cache = new Cache<PriceList>(_priceListRetriever, 10);
            _view.SetItemCount(_priceListRetriever.Count);
        }
    }
}
