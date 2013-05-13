using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using MSS.WinMobile.Domain.Models;
using MSS.WinMobile.Infrastructure.Storage;
using MSS.WinMobile.Infrastructure.Web;
using MSS.WinMobile.Infrastructure.Web.Repositories.Utilites;
using MSS.WinMobile.Synchronizer.Specifications;

namespace MSS.WinMobile.Synchronizer {
    public class OrdersSynchronization : Command<Route, string> {

        private readonly IWebServer _webServer;
        private readonly IStorageRepository<Order> _orderRepository;
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;
        public OrdersSynchronization(IWebServer webServer,
            IStorageRepository<Order> orderRepository,
            IUnitOfWorkFactory unitOfWorkFactory) {
            _webServer = webServer;
            _orderRepository = orderRepository;
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public override void Execute() {
            var ordersToSync = _orderRepository.Find().Where(new OrdersToSyncSpec()).ToArray();

            foreach (var order in ordersToSync) {
                IDictionary<string, object> orderDictionary = OrderToDictionary(order);
                IWebConnection webConnection = _webServer.Connect();
                var httpWebRequest = RequestFactory.CreatePostRequest(webConnection,
                                                                      "synchronization/orders.json",
                                                                      orderDictionary);
                string result = webConnection.Post(httpWebRequest);

                using (var unitOfWork = _unitOfWorkFactory.CreateUnitOfWork()) {
                    unitOfWork.BeginTransaction();
                    order.Synchronized = true;
                    unitOfWork.Commit();
                }
            }
        }

        private IDictionary<string, object> OrderToDictionary(Order order) {
            var rootDictionary = new Dictionary<string, object>();
            var orderAttributesDictionary = new  Dictionary<string, object>();
            rootDictionary.Add("order", orderAttributesDictionary);
            orderAttributesDictionary.Add("date", order.OrderDate.ToString("dd.MM.yyyy"));
            orderAttributesDictionary.Add("shipping_date", order.ShippingDate.ToString("dd.MM.yyyy"));
            orderAttributesDictionary.Add("shipping_address_id", order.ShippingAddressId);
            orderAttributesDictionary.Add("warehouse_id", order.WarehouseId);
            orderAttributesDictionary.Add("price_list_id", order.PriceListId);
            orderAttributesDictionary.Add("comment", order.Note);
            var orderPointsAttributesDictionary = new Dictionary<string, object>();
            orderAttributesDictionary.Add("order_items_attributes", orderPointsAttributesDictionary);
            var orderItems = order.Items.ToArray();
            for (int i = 0; i < orderItems.Length; i++) {
                var routePointAttributesDictionary = new Dictionary<string, object>();
                orderPointsAttributesDictionary.Add(i.ToString(CultureInfo.InvariantCulture), routePointAttributesDictionary);
                routePointAttributesDictionary.Add("product_id", orderItems[i].ProductId);
                routePointAttributesDictionary.Add("unit_of_measure_id", orderItems[i].UnitOfMeasureId);
                routePointAttributesDictionary.Add("quantity", orderItems[i].Quantity);
            }

            return rootDictionary;
        }
    }
}
