using System;

namespace MSS.WinMobile.Domain.Models
{
    public class Order : Model
    {
        public Order(int id,
                     DateTime orderDate,
                     DateTime shippingDate,
                     int customerId,
                     string customerName,
                     int shippingAddressId,
                     string shippingAddressName,
                     int managerId,
                     string managerName,
                     int priceListId,
                     string priceListName,
                     int warehouseId,
                     string warehouseAddress,
                     int orderStatus,
                     string note)
            :base(id)
        {
            OrderDate = orderDate;
            ShippingDate = shippingDate;
            CustomerId = customerId;
            CustomerName = customerName;
            ShippingAddressId = shippingAddressId;
            ShippingAddressName = shippingAddressName;
            ManagerId = managerId;
            ManagerName = managerName;
            PriceListId = priceListId;
            PriceListName = priceListName;
            WarehouseId = warehouseId;
            WarehouseAddress = warehouseAddress;
            OrderStatus = (OrderStatus)orderStatus;
            Note = note;
        }

        //public Order(RoutePoint routePoint)
        //{
        //    var configurationManager = new Application.Configuration.ConfigurationManager(Environments.AppPath);

        //    Date = DateTime.Now;
        //    Manager = Manager.GetById(configurationManager.GetConfig("Common").GetSection("ExecutionContext").GetSetting("ManagerId").As<int>());
        //    ShippingAddress = routePoint.ShippingAddress;
        //}

        public DateTime OrderDate { get; private set; }
        public DateTime ShippingDate { get; private set; }

        public int CustomerId { get; private set; }
        public string CustomerName { get; private set; }

        public int ShippingAddressId { get; private set; }
        public string ShippingAddressName { get; private set; }

        public int ManagerId { get; private set; }
        public string ManagerName { get; private set; }

        public int PriceListId { get; private set; }
        public string PriceListName { get; private set; }

        public int WarehouseId { get; private set; }
        public string WarehouseAddress { get; private set; }

        public OrderStatus OrderStatus { get; private set; }
        public string Note { get; set; }

        //public void SetPriceList(PriceList priceList)
        //{
        //    PriceList = priceList;
        //}

        //public void SetWarehouse(Warehouse warehouse)
        //{
        //    Warehouse = warehouse;
        //}

        //public QueryObject<OrderItem> Items()
        //{
        //    return OrderItem.GetByOrder(this);
        //}

        //public void AddItem(Product product, int quantity)
        //{
        //    var orderItem = new OrderItem(this, product) {Quantity = quantity};
        //    orderItem.Save();
        //}

        //public void RemoveItem(OrderItem item)
        //{
        //    if (Id == item.OrderId)
        //    {
        //        item.Delete();
        //    }
        //}
    }

    public enum OrderStatus
    {
        New = 0,
        Sended = 1
    }
}
