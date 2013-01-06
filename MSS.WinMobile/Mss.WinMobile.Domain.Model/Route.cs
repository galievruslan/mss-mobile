using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mss.WinMobile.Domain.Model
{
    public class Route : IEntity
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }
    }
}
