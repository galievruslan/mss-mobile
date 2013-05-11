using System;
using System.Linq;

namespace MSS.WinMobile.UI.Presenters.ViewModels
{
    public class OrderViewModel : ViewModel
    {
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime ShippingDate { get; set; }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        public int ShippingAddressId { get; set; }
        public string ShippingAddressName { get; set; }

        public int PriceListId { get; set; }
        public string PriceListName { get; set; }

        public int WarehouseId { get; set; }
        public string WarehouseAddress { get; set; }

        public string Description {
            get { return string.Format("Order {0} from {1}", OrderId, OrderDate); }
        }

        public override bool Validate() {
            base.Validate();
            if (CustomerId == 0)
                ErrorList.Add("Customer must be selected.");

            if (string.IsNullOrEmpty(CustomerName))
                ErrorList.Add("Customer must be selected.");

            if (ShippingAddressId == 0)
                ErrorList.Add("Shipping address must be selected.");

            if (string.IsNullOrEmpty(ShippingAddressName))
                ErrorList.Add("Shipping address must be selected.");

            if (PriceListId == 0)
                ErrorList.Add("Price list must be selected.");

            if (string.IsNullOrEmpty(PriceListName))
                ErrorList.Add("Price list must be selected.");

            if (WarehouseId == 0)
                ErrorList.Add("Warehouse must be selected.");

            if (string.IsNullOrEmpty(WarehouseAddress))
                ErrorList.Add("Warehouse must be selected.");

            return !ErrorList.Any();
        }
    }
}
