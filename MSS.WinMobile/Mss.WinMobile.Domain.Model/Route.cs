using System;
using OpenNETCF.ORM;

namespace Mss.WinMobile.Domain.Model
{
    [Entity]
    public class Route : IEntity
    {
        [Field(IsPrimaryKey = true)]
        public int Id { get; set; }

        [Field]
        public DateTime Date { get; set; }
    }
}
