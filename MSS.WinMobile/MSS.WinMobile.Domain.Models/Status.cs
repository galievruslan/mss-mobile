using OpenNETCF.ORM;

namespace Mss.WinMobile.Domain.Model
{
    [Entity]
    public class Status : IEntity
    {
        [Field(IsPrimaryKey = true)]
        public int Id { get; set; }

        [Field]
        public string Name { get; set; }
    }
}
