using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team9_AD
{

    public class SupplierTrans
    {
        public int? Quantity { get; set; }
        public DateTime Date { get; set; }

        public SupplierTrans(int? quantity, DateTime date)
        {
            Quantity = quantity;
            Date = date;
        }
    }
    
}