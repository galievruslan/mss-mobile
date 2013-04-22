namespace MSS.WinMobile.Domain.Models
{
    public class ManagersShippingAddress : Model
    {
        public ManagersShippingAddress(int id, int managerId, int shippingAddressId, string shippingAddressName)
            :base(id)
        {
            ManagerId = managerId;
            ShippingAddressId = shippingAddressId;
            ShippingAddressName = shippingAddressName;
        }

        public int ManagerId { get; private set; }

        public int ShippingAddressId { get; private set; }

        public string ShippingAddressName { get; private set; }
    }
}
