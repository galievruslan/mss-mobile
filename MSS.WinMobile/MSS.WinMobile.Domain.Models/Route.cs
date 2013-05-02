using System;

namespace MSS.WinMobile.Domain.Models
{
    public class Route : Model
    {
        public Route(DateTime date) {
            Date = date;
        }

        public DateTime Date { get; protected set; }
    }
}
