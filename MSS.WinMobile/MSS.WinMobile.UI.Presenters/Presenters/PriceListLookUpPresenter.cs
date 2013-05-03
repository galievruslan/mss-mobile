using System.Collections.Generic;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.SqliteRepositoties;
using MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers;
using MSS.WinMobile.UI.Presenters.Presenters.Exceptions;
using MSS.WinMobile.UI.Presenters.Views;
using log4net;

namespace MSS.WinMobile.UI.Presenters.Presenters
{
    public class PriceListLookUpPresenter : IListPresenter
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(RoutePresenter));

        private readonly IPriceListLookUpView _view;
        private SqLiteUnitOfWork _unitOfWork;
        private PriceListRetriever _priceListRetriever;
        private Cache<PriceList> _cache;

        public PriceListLookUpPresenter(IPriceListLookUpView view, SqLiteUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
            _view = view;
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

        public void Search(string criteria) {
            _searchCriteria = criteria;
        }

        private string _searchCriteria;
        public int InitializeList() {

            _priceListRetriever = new PriceListRetriever(new PriceListRepository(_unitOfWork));
            if (!string.IsNullOrEmpty(_searchCriteria))
                _priceListRetriever.SearchCriteria = _searchCriteria;

            _cache = new Cache<PriceList>(_priceListRetriever, 10);
            return _priceListRetriever.Count;
        }
    }
}
