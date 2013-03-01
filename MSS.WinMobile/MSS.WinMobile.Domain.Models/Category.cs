using MSS.WinMobile.Infrastructure.Data.Repositories;
using MSS.WinMobile.Infrastructure.Local.Attributes;

namespace MSS.WinMobile.Domain.Models
{
    [Table("Categories")]
    public class Category : IEntity
    {
        [Key("Id")]
        public int Id { get; set; }

        [StringColumn("Name", 255)]
        public string Name { get; set; }

        [Reference("Parent_Id", typeof(Category))]
        public int? ParentId { get; set; }
    }
}
