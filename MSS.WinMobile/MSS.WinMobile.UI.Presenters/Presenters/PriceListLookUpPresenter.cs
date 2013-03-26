using MSS.WinMobile.Domain.Models;
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
        private readonly IDataPageRetriever<PriceList> _priceListRetriever;
        private readonly Cache<PriceList> _cache;

        public PriceListLookUpPresenter(IPriceListLookUpView view)
        {
            _priceListRetriever = new PriceListRetriever();
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

        public string GetItemName(int index)
        {
            return _cache.RetrieveElement(index).Name;
        }

        public int GetSelectedItemId()
        {
            if (_selectedPriceList != null)
                return _selectedPriceList.Id;

            throw new NoSelectedItemsException();
        }
    }
}
