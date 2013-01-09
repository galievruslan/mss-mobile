using OpenNETCF.ORM;

namespace MSS.WinMobile.Domain.Models
{
    [Entity]
    public class Manager : IEntity
    {
        [Field(IsPrimaryKey = true)]
        public int Id { get; set; }

        [Field]
        public string Name { get; set; }
    }
}
