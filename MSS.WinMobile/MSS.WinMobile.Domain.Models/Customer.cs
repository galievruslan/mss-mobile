using MSS.WinMobile.Domain.Models.ActiveRecord.QueryObject;

namespace MSS.WinMobile.Domain.Models
{
    public partial class Customer
    {
        public Customer(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Name { get; private set; }

        public QueryObject<ShippingAddress> ShippingAddresses()
        {
            return ShippingAddress.GetByCustomer(this);
        }

        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(object obj)
        {
            var customer = obj as Customer;
            if (customer != null)
            {
                return customer.Id == Id;
            }

            return false;
        }
    }
}
