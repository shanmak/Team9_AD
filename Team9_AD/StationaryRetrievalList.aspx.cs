using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team9_AD.Models;
using System.Data.SqlClient;
using System.Data;


namespace Team9_AD
{
    public partial class Stationary_Retrieval__List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using (Logic_University_Model m = new Logic_University_Model())
            {
                var result = m.Store_Request_items.Where(x => x.Status.Equals("Pending")).GroupBy(rd => rd.Item_Number, rd => rd.Req_Quantity, (item, qunty) => new
                {

                    Item_Number = item,
                    Req_Quantity = qunty.Sum()

                });

                var result1 = from x in m.Store_Request_items
                              where x.Status == "Pending"
                              group x by new { x.Item_Number, x.Description, x.Status } into g

                              select new { Itemnumber = g.Key.Item_Number, Description = g.Key.Description, Qunty = g.Sum(y => y.Req_Quantity), Status = g.Key.Status };
                        

                //var result = m.Inventories.Where(x => x.Category.Contains(valu)).Distinct().Select(x => x.Category).ToList();

                var result2 = m.Store_Request.Where(x => x.Status.Equals("Pending")).Join(m.Store_Request_items,sq=> sq.StoreRequest_ID,sql=> sql.StoreRequest_ID,(sq,sql) => new { sq,sql}).GroupBy(rd => new { rd.sql.Item_Number, rd.sql.Inventory,rd.sql.Status }).Select(x => new { ItemCode = x.Key.Item_Number, Quty = x.Sum(a => a.sql.Req_Quantity), location = x.Key.Inventory.Bin_number,Status=x.Key.Status,ava=x.Key.Inventory.Quantity });

                GridView1.DataSource = result2.ToList();
                GridView1.DataBind();
            }
        }
    }
}