using System.Text;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views.LookUps;
using log4net;

namespace MSS.WinMobile.UI.Presenters.Presenters.LookUps
{
    public class WarehouseLookUpPresenter : IListPresenter<WarehouseViewModel>
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(RoutePresenter));

        private readonly IWarehouseLookUpView _view;
        private readonly IRepositoryFactory _repositoryFactory;
        private IDataPageRetriever<Warehouse> _warehouseRetriever;
        private Cache<Warehouse> _cache;

        public WarehouseLookUpPresenter(IWarehouseLookUpView view, IRepositoryFactory repositoryFactory) {
            _repositoryFactory = repositoryFactory;
            _warehouseRetriever = new WarehouseRetriever(_repositoryFactory.CreateRepository<Warehouse>());
            _cache = new Cache<Warehouse>(_warehouseRetriever, 10);
            _view = view;
        }

        public int InitializeListSize() {
            return _warehouseRetriever.Count;
        }

        public WarehouseViewModel GetItem(int index) {
            Warehouse item = _cache.RetrieveElement(index);
            return new WarehouseViewModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Address = item.Address
                };
        }

        private Warehouse _selectedWarehouse;
        public void Select(int index) {
            _selectedWarehouse = _cache.RetrieveElement(index);
        }

        public WarehouseViewModel SelectedModel {
            get {
                return _selectedWarehouse != null
                           ? new WarehouseViewModel
                               {
                                   Id = _selectedWarehouse.Id,
                                   Name = _selectedWarehouse.Name,
                                   Address = _selectedWarehouse.Address
                               }
                           : null;
            }
        }

        private string _searchCriteria;
        public void Search(string criteria) {
            _searchCriteria = criteria;
            _warehouseRetriever =
                new WarehouseRetriever(_repositoryFactory.CreateRepository<Warehouse>(),
                                      _searchCriteria);
            _cache = new Cache<Warehouse>(_warehouseRetriever, 100);
            _selectedWarehouse = null;
        }

        public void ClearSearch() {
            _searchCriteria = string.Empty;
            _warehouseRetriever =
                new WarehouseRetriever(_repositoryFactory.CreateRepository<Warehouse>());
            _cache = new Cache<Warehouse>(_warehouseRetriever, 100);
            _selectedWarehouse = null;
        }

        public void ShowDetails() {
            if (_selectedWarehouse != null) {
                var stringBuilder = new StringBuilder();
                stringBuilder.Append(string.Format("<b>{0} </b>", "Warehouse name:"));
                stringBuilder.Append(_selectedWarehouse.Name);
                stringBuilder.Append("</br>");
                stringBuilder.Append(string.Format("<b>{0} </b>", "Warehouse address:"));
                stringBuilder.Append(_selectedWarehouse.Address);

                _view.ShowDetails(stringBuilder.ToString());
            }
        }
    }
}
