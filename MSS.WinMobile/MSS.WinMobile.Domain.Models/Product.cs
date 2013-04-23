namespace MSS.WinMobile.Domain.Models
{
    public class Product : Model
    {
        public string Name { get; protected set; }

        public int CategoryId { get; protected set; }
    }
}
