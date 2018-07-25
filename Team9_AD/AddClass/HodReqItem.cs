using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team9_AD.AddClass
{
    public class HodReqItem
    {
        public string Category { get; set; }
        public string Description { get; set; }
        public string Quantity { get; set; }

        public HodReqItem(string category, string description, string quantity)
        {
            Category = category;
            Description = description;
            Quantity = quantity;
        }
    }
}