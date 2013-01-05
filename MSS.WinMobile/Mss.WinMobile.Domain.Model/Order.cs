using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Mss.WinMobile.Domain.Model
{
    public class Order : Entity
    {
        public Order(int id, DateTime date, Customer customer, Manager manager) 
            :base (id)
        {
            Date = date;
            Customer = customer;
            Manager = manager;
        }

        public DateTime Date { get; set; }

        public Customer Customer { get; set; }

        public Manager Manager { get; set; }
    }
}
