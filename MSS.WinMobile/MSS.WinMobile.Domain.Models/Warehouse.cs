namespace MSS.WinMobile.Domain.Models
{
    public partial class Warehouse
    {
        public Warehouse(int id, string address)
        {
            Id = id;
            Address = address;
        }

        public string Address { get; private set; }

        public override int GetHashCode()
        {
            return Id;
        }

        public override bool Equals(object obj)
        {
            var warehouse = obj as Warehouse;
            if (warehouse != null)
            {
                return warehouse.Id == Id;
            }

            return false;
        }
    }
}
