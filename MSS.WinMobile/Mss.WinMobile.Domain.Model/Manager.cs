using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mss.WinMobile.Domain.Model
{
    public class Manager : Entity
    {
        public Manager(int id, string name) 
            :base (id)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
