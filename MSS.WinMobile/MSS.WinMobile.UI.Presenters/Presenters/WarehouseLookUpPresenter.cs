using System.Collections.Generic;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers;
using MSS.WinMobile.UI.Presenters.Presenters.Exceptions;
using MSS.WinMobile.UI.Presenters.Views;
using log4net;

namespace MSS.WinMobile.UI.Presenters.Presenters
{
    public class WarehouseLookUpPresenter : IPresenter
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(RoutePresenter));

        private readonly IWarehouseLookUpView _view;
        private readonly IDataPageRetriever<Warehouse> _warehouseRetriever;
        private readonly Cache<Warehouse> _cache;

        public WarehouseLookUpPresenter(IWarehouseLookUpView view)
        {
            _warehouseRetriever = new WarehouseRetriever();
            _cache = new Cache<Warehouse>(_warehouseRetriever, 10);
            _view = view;
        }

        public void InitializeView()
        {
            _view.SetItemCount(_warehouseRetriever.Count);
        }

        private Warehouse _selectedWarehouse;

        public void SelectItem(int index)
        {
            _selectedWarehouse = _cache.RetrieveElement(index);
        }

        public IDictionary<string, string> GetItemData(int index)
        {
            Warehouse item = _cache.RetrieveElement(index);
            return new Dictionary<string, string> {{"Address", item.Address}};
        }

        public int GetSelectedItemId()
        {
            if (_selectedWarehouse != null)
                return _selectedWarehouse.Id;

            throw new NoSelectedItemsException();
        }
    }
}
