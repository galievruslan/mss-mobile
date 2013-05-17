﻿using MSS.WinMobile.Domain.Models;
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
        private readonly IDataPageRetriever<Warehouse> _warehouseRetriever;
        private readonly Cache<Warehouse> _cache;

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
            return new WarehouseViewModel {
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
                           ? new WarehouseViewModel {
                               Id = _selectedWarehouse.Id,
                               Address = _selectedWarehouse.Address
                           }
                           : null;
            }
        }
    }
}