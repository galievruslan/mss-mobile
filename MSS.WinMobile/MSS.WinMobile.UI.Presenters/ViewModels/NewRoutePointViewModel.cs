using System.Linq;

namespace MSS.WinMobile.UI.Presenters.ViewModels {
    public class NewRoutePointViewModel : ViewModel {
        public int RouteId { get; set; }

        public int CustomerId { get; set; }
        public string CustomerName { get; set; }

        public int ShippingAddressId { get; set; }
        public string ShippingAddressName { get; set; }

        public override bool Validate() {
            base.Validate();
            if (CustomerId == 0 ||
                string.IsNullOrEmpty(CustomerName))
                ErrorList.Add("Customer must be selected.");

            if (ShippingAddressId == 0 ||
                string.IsNullOrEmpty(ShippingAddressName))
                ErrorList.Add("Shipping address must be selected.");

            return !ErrorList.Any();
        }
    }
}
