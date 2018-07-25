using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team9_AD.AddClass
{
    public class EmployeeMakeReq
    {
        public String Description { get; set; }

        public int Quantity { get; set; }

        public EmployeeMakeReq(string description, int quantity)
        {
            Description = description;
            Quantity = quantity;
        }
    }
}