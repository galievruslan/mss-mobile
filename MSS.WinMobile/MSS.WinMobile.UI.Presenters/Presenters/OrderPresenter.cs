using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.UI.Presenters.Presenters.DataRetrievers;
using MSS.WinMobile.UI.Presenters.ViewModels;
using MSS.WinMobile.UI.Presenters.Views;
using log4net;

namespace MSS.WinMobile.UI.Presenters.Presenters
{
    public class OrderPresenter : IPresenter<OrderViewModel>, IListPresenter<OrderItemViewModel>
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(OrderPresenter));

        private readonly IOrderView _view;
        private readonly Order _order;

        private IUnitOfWork _unitOfWork;
        private IRepositoryFactory _repositoryFactory;
        private IDataPageRetriever<OrderItem> _orderItemRetriever;
        private Cache<OrderItem> _cache;

        public OrderPresenter(IOrderView view, IUnitOfWork unitOfWork, IRepositoryFactory repositoryFactory, IModelsFactory modelsFactory, int orderId)
        {
            _view = view;
            _unitOfWork = unitOfWork;
            _repositoryFactory = repositoryFactory;
            var orderRepository = _repositoryFactory.CreateRepository<Order>();
            _order = orderRepository.GetById(orderId);
            if (_order == null) {
                _order = modelsFactory.CreateOrder();
                _order = orderRepository.Save(_order);
            }

            _orderItemRetriever = new OrderItemRetriever(_order);
            _cache = new Cache<OrderItem>(_orderItemRetriever, 10);
        }

        public IDictionary<string, string> GetItemData(int index)
        {
            OrderItem item = _cache.RetrieveElement(index);
            return new Dictionary<string, string>
                {
                    //{"Name", item.Product.Name},
                    {"GetCount", item.Quantity.ToString(CultureInfo.InvariantCulture)}
                };
        }

        public void Save()
        {
            if (_viewModel.Validate()) {
                throw new NotImplementedException();
            }
            else {
                _view.DisplayErrors(_viewModel.Errors);
            }
        }

        public void Cancel()
        {
            _view.CloseView();
        }

        public void PickUpProducts()
        {
            //using (
            //    var pickUpProductView =
            //        NavigationContext.NavigateTo<IPickUpProductView>(new Dictionary<string, object>
            //            {
            //                {"OrderId", _order.Id}
            //            }))
            //{
            //    if (DialogViewResult.Ok == pickUpProductView.ShowDialogView())
            //    {
            //        IDictionary<int, int> collectedValues = pickUpProductView.GetValues();
            //        IList<OrderItem> orderItems = _order.Items().ToArray();
            //        foreach (var collectedValue in collectedValues)
            //        {
            //            KeyValuePair<int, int> value = collectedValue;
            //            OrderItem orderItem = orderItems.FirstOrDefault(item => item.Product.Id == value.Key);
            //            if (orderItem != null)
            //            {
            //                if (orderItem.Quantity != value.Value)
            //                {
            //                    orderItem.Quantity = value.Value;
            //                    orderItem.Save();
            //                }
            //            }
            //            else
            //            {
            //                _order.AddItem(Product.GetById(value.Key), value.Value);
            //            }
            //        }

            //        foreach (var orderItem in _order.Items())
            //        {
            //            OrderItem item = orderItem;
            //            if (collectedValues.All(pair => pair.Key != item.Product.Id))
            //                _order.RemoveItem(orderItem);
            //        }

            //        _orderItemRetriever = new OrderItemRetriever(_order);
            //        _cache = new Cache<OrderItem>(_orderItemRetriever, 10);
            //        _view.SetItemCount(_orderItemRetriever.Count);
            //    }
            //}
        }

        private OrderViewModel _viewModel;
        public OrderViewModel Initialize() {
            _viewModel = new OrderViewModel
            {
                CustomerId = _order.CustomerId,
                CustomerName = _order.CustomerName,
                ShippingAddressId = _order.ShippingAddressId,
                ShippingAddressName = _order.ShippingAddressName,
                PriceListId = _order.PriceListId,
                PriceListName = _order.PriceListName,
                WarehouseId = _order.WarehouseId,
                WarehouseName = _order.WarehouseAddress
            };
            return _viewModel;
        }

        public int InitializeList() {
            return _orderItemRetriever.Count;
        }

        public int InitializeListSize() {
            throw new NotImplementedException();
        }

        public OrderItemViewModel GetItem(int index) {
            throw new NotImplementedException();
        }

        public void Select(int index) {
            throw new NotImplementedException();
        }

        public OrderItemViewModel SelectedModel { get; private set; }
    }

    public class PriceListEmptyException : Exception
    {
    }
}
