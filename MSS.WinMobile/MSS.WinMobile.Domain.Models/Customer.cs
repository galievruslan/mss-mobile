﻿using System.Data;
using MSS.WinMobile.Infrastructure.Data.Repositories;
using MSS.WinMobile.Infrastructure.Local.Attributes;

namespace MSS.WinMobile.Domain.Models
{
    [Table("Customers")]
    public class Customer : IEntity
    {
        [Key("Id")]
        public int Id { get; set; }

        [StringColumn("Name", 255)]
        public string Name { get; set; }
    }
}
