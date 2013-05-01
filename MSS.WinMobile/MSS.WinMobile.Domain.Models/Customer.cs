using System.Collections.Generic;

namespace MSS.WinMobile.Domain.Models
{
    public class Customer : Model
    {
        protected Customer() {
            _shippingAddresses = new List<ShippingAddress>();
        }

        public string Name { get; protected set; }

        readonly List<ShippingAddress> _shippingAddresses;
        public virtual IEnumerable<ShippingAddress> ShippingAddresses {
            get { return _shippingAddresses; }
        }
    }
}
