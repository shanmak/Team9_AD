using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Team9_AD.Entity;

namespace Team9_AD
{

    public class ChartBusinessLogic
    {
        static Logic_University_Entity model = new Logic_University_Entity();
        public List<String> getDepartmentNames()
        {
             List<String> deptnm = new List<String>();
                foreach (Department d in model.Departments)
                {
                    deptnm.Add(d.Department_Name.ToString());

                }
                return deptnm;
        }

        public List<String> getDescriptiontNames()
        {
           
                List<String> descnm = new List<String>();
                foreach (Inventory i in model.Inventories)
                {
                    descnm.Add(i.Description.ToString());

                }
                return descnm;
         
        }
        public List<String> getSupplierNames()
        {
            
                List<String> supName = new List<String>();
                foreach (Supplier i in model.Suppliers)
                {
                    supName.Add(i.Supplier_ID.ToString());

                }
                return supName;
        }
    }
}