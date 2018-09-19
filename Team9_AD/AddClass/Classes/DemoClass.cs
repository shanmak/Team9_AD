using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team9_AD.Entity;

namespace Team9_AD
{
    public class DemoClass
    {
      public  string Department_ID { get; set; }

      public  string Item_Number { get; set; }

        public string Description { get; set; }

      public  int? qunty { get; set; }

        public virtual Department Department { get; set; }

        public virtual Inventory Inventory { get; set; }


    }
}