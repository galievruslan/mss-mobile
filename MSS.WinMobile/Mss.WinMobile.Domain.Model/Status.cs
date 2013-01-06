using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mss.WinMobile.Domain.Model
{
    public class Status : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
