namespace MSS.WinMobile.Domain.Models
{
    public class Warehouse : Model
    {
        public Warehouse(int id, string address)
            :base(id)
        {
            Address = address;
        }

        public string Address { get; private set; }
    }
}
