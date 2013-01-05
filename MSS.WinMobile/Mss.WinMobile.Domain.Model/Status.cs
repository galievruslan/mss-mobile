using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mss.WinMobile.Domain.Model
{
    public class Status : Entity
    {
        public Status(int id, string name) 
            :base (id)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
