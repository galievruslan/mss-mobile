namespace MSS.WinMobile.Domain.Models
{
    public class Customer : Model
    {
        public Customer(int id, string name)
            :base(id)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
