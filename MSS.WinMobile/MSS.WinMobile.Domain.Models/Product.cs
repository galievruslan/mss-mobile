namespace MSS.WinMobile.Domain.Models
{
    public partial class Product
    {
        public Product(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public Product(int id, string name, int categoryId)
            :this(id, name)
        {
            CategoryId = categoryId;
        }

        public string Name { get; private set; }

        public int? CategoryId { get; private set; }
    }
}
