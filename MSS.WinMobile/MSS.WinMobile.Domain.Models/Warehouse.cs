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
    }
}
