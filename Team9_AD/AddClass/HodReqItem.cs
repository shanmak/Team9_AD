using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team9_AD.AddClass
{
    public class HodReqItem
    {

        public string Itemnumber { get; set; }
        public string Quantity { get; set; }

      public string description { get; set; }

        public HodReqItem(string itemnumber, string quantity, string description)
        {
            Itemnumber = itemnumber;
            Quantity = quantity;
            this.description = description;
        }
    }
}