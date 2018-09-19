using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team9_AD.Entity;

namespace Team9_AD
{
    public static class BizLogic
    {
        static Logic_University_Entity entities = new Logic_University_Entity();
        static int requestid;
        public static void AddRequest(string description, int quantity)
        {
            var xy = (from z in entities.Inventories where z.Description == description select z.Item_Number).SingleOrDefault();
            string itemnumber = xy.ToString();
            Emp_Request_items item = new Emp_Request_items();
            item.Item_Number = itemnumber;
            item.Quantity = quantity;
            item.Status = "Pending";
            entities.Emp_Request_items.Add(item);
            entities.SaveChanges();
        }
        public static void AddReq()
        {
            requestid = getRequestId() + 1;
            Employee_Request req = new Employee_Request();
            req.Department_ID = "CMC";
            req.Employee_ID = "CMC003";
            req.Date_of_Request = System.DateTime.Now;
            entities.Employee_Request.Add(req);
            entities.SaveChanges();
        }
        
        public static int getRequestId()
        {
            Emp_Request_items em = entities.Emp_Request_items.ToList<Emp_Request_items>().Last();
            return requestid;
        }
    }
}