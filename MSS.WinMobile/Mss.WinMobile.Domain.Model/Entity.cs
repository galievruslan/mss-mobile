using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mss.WinMobile.Domain.Model
{
    public abstract class Entity
    {
        public Entity(int id) {
            Id = id;
        }

        public int Id { get; private set; }
    }
}
