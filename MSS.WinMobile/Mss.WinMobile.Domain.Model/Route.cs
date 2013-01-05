using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mss.WinMobile.Domain.Model
{
    public class Route : Entity
    {
        public Route(int id, DateTime date) 
            :base (id)
        {
            Date = date;
        }

        public DateTime Date { get; set; }
    }
}
