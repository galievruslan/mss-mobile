using System.Collections.Generic;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Sqlite.Repositoties;
using MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers;
using MSS.WinMobile.UI.Presenters.Presenters.Exceptions;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;
using log4net;

namespace MSS.WinMobile.UI.Presenters.Presenters
{
    public class WarehouseLookUpPresenter : IListPresenter<WarehouseViewModel>
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(RoutePresenter));

        private readonly IWarehouseLookUpView _view;
        private readonly WarehouseStorageRepository _warehouseStorageRepository;
        private readonly IDataPageRetriever<Warehouse> _warehouseRetriever;
        private readonly Cache<Warehouse> _cache;

        public WarehouseLookUpPresenter(IWarehouseLookUpView view, WarehouseStorageRepository warehouseStorageRepository) {
            _warehouseStorageRepository = warehouseStorageRepository;
            _warehouseRetriever = new WarehouseRetriever(_warehouseStorageRepository);
            _cache = new Cache<Warehouse>(_warehouseRetriever, 10);
            _view = view;
        }

        private Warehouse _selectedWarehouse;

        public void SelectItem(int index)
        {
            _selectedWarehouse = _cache.RetrieveElement(index);
        }

        public int GetSelectedItemId()
        {
            if (_selectedWarehouse != null)
                return _selectedWarehouse.Id;

            throw new NoSelectedItemsException();
        }

        public int InitializeListSize() {
            return _warehouseRetriever.Count;
        }

        public WarehouseViewModel GetItem(int index) {
            Warehouse item = _cache.RetrieveElement(index);
            return new WarehouseViewModel {
                Address = item.Address
            };
        }
    }
}
