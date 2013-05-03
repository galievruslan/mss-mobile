using System;

namespace MSS.WinMobile.Domain.Models
{
    public class Route : Model
    {
        protected Route() {
        }

        public Route(DateTime date) {
            Date = date;
        }

        public DateTime Date { get; protected set; }
    }
}
