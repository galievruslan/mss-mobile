namespace MSS.WinMobile.Domain.Models
{
    public partial class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int? CategoryId { get; set; }
    }
}
