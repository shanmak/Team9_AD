using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Team9_AD.AddClass
{
    public class ClerkViewRequest
    {

     public   int StoreRequest_ID { get; set; }

        public string Department_ID { get; set; }

        public string Department_Name { get; set; }

        public string Employee_Name { get; set; }

        public string  Request_Date { get; set; }

        public string  Status { get; set; }

        public string itemnumber { get; set; }

        public string description { get; set; }

        public int? Quty { get; set; }

        public string location { get; set; }

        public int? ava { get; set; }


        public string category { get; set; }


        public int CollectedQuntity { get; set; }
        public int  DamagedQuantity { get; set; }


        public int? Requried_qunty { get; set; }

        public int? delivered_qunty { get; set; }


        public ClerkViewRequest()
        {

        }
        public ClerkViewRequest(int storeRequest_ID, string department_Name, string employee_Name, DateTime? request_Date, string status)
        {
            StoreRequest_ID = storeRequest_ID;
            Department_Name = department_Name;
            Employee_Name = employee_Name;

            DateTime date =(DateTime) request_Date;

            var dat = date.ToString("yyyy-MM-dd");

            Request_Date = dat;
            Status = status;
        }

        public ClerkViewRequest(string itemnumber, string category,string description, int? Quty, string location, string Status, int? ava)
        {
            this.itemnumber = itemnumber;
            this.category = category;
            this.description = description;
            this.Quty = Quty;
            this.location = location;
            this.Status = Status;
            this.ava = ava;
        }

        public ClerkViewRequest(string itemnumber, string category, string description, int? Quty, string location, int? ava,int CollectedQuntity,int DamagedQuantity)
        {
            this.itemnumber = itemnumber;
            this.category = category;
            this.description = description;
            this.Quty = Quty;
            this.location = location;          
            this.ava = ava;
            this.CollectedQuntity = CollectedQuntity;
            this.DamagedQuantity = DamagedQuantity;
        }


    }
}