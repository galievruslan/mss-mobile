﻿namespace MSS.WinMobile.Domain.Models
{
    public partial class PriceList
    {
        public PriceList(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Name { get; private set; }
    }
}
