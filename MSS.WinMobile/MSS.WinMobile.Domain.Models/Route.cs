using System;
using MSS.WinMobile.Infrastructure.Data.Repositories;
using MSS.WinMobile.Infrastructure.Local.Attributes;

namespace MSS.WinMobile.Domain.Models
{
    [Table("Routes")]
    public class Route : IEntity
    {
        [Key("Id")]
        public int Id { get; set; }

        [Column("Date")]
        public DateTime Date { get; set; }

        [Reference("Manager_Id", typeof(Manager))]
        public int ManagerId { get; set; }
    }
}
