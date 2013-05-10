using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;
using log4net;

namespace MSS.WinMobile.UI.Presenters.Presenters
{
    public class PriceListLookUpPresenter : IListPresenter<PriceListViewModel>
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(RoutePresenter));

        private readonly IPriceListLookUpView _view;
        private readonly IRepositoryFactory _repositoryFactory;
        private PriceListRetriever _priceListRetriever;
        private Cache<PriceList> _cache;

        public PriceListLookUpPresenter(IPriceListLookUpView view, IRepositoryFactory repositoryFactory) {
            _view = view;
            _repositoryFactory = repositoryFactory;

            _priceListRetriever = new PriceListRetriever(_repositoryFactory.CreateRepository<PriceList>());
            _cache = new Cache<PriceList>(_priceListRetriever, 10);
        }

        public int InitializeListSize() {
            return _priceListRetriever.Count;
        }

        public PriceListViewModel GetItem(int index) {
            PriceList item = _cache.RetrieveElement(index);
            return new PriceListViewModel {
                Id = item.Id,
                Name = item.Name
            };
        }

        private PriceList _selectedPriceList;
        public void Select(int index) {
            _selectedPriceList = _cache.RetrieveElement(index);
        }

        public PriceListViewModel SelectedModel {
            get {
                return _selectedPriceList != null
                           ? new PriceListViewModel {
                               Id = _selectedPriceList.Id,
                               Name = _selectedPriceList.Name
                           }
                           : null;
            }
        }
    }
}
