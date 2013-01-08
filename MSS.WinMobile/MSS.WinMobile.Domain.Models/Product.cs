using OpenNETCF.ORM;

namespace Mss.WinMobile.Domain.Model
{
    [Entity]
    public class Product : IEntity
    {
        [Field(IsPrimaryKey = true)]
        public int Id { get; set; }

        [Field]
        public string Name { get; set; }

        [Field]
        public decimal Price { get; set; }
    }
}
