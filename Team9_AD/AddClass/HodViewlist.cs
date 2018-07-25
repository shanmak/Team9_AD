using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team9_AD.AddClass
{
    public class HodViewlist
    {
        public DateTime Date_of_Request { get; set; }
        public string Department_ID { get; set; }
        public string Employee_ID { get; set; }
        public string Employee_Name { get; set; }
        public int Request_ID { get; set; }
        public string Status { get; set; }

        public HodViewlist( int request_ID, string employee_Name, string status)
        {
            Employee_Name = employee_Name;
            Request_ID = request_ID;
            Status = status;
        }
    }
    }