using MSS.WinMobile.Infrastructure.Data.Repositories;
using MSS.WinMobile.Infrastructure.Local.Attributes;

namespace MSS.WinMobile.Domain.Models
{
    [Table("Managers")]
    public class Manager : IEntity
    {
        [Key("Id")]
        public int Id { get; set; }

        [StringColumn("Name", 255)]
        public string Name { get; set; }
    }
}
