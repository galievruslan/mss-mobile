namespace MSS.WinMobile.Domain.Models
{
    public class Product : Model
    {
        public Product(int id, string name, int categoryId) :
            base(id)
        {
            Name = name;
            CategoryId = categoryId;
        }

        public string Name { get; private set; }

        public int CategoryId { get; private set; }
    }
}
