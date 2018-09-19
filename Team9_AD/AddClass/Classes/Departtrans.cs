using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team9_AD
{
    public class Departtrans
    {
        public int? Quantity { get; set; }
        public DateTime Date { get; set; }

        public Departtrans(int? quantity, DateTime date)
        {
            Quantity = quantity;
            Date = date;
        }
    }
}