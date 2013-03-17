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
    }
}
