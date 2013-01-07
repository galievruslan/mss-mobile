using OpenNETCF.ORM;

namespace Mss.WinMobile.Domain.Model
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
