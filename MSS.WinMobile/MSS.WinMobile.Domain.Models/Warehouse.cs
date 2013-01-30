using MSS.WinMobile.Infrastructure.Data.Repositories;
using MSS.WinMobile.Infrastructure.Local.Attributes;

namespace MSS.WinMobile.Domain.Models
{
    [Table("Warehouses")]
    public class Warehouse : IEntity
    {
        [Key("Id")]
        public int Id { get; set; }

        [StringColumn("Address", 255)]
        public string Address { get; set; }
    }
}
