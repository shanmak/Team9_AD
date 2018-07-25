using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Team9_AD
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=MANIPC\MANI;Initial Catalog=Team_9_AD_DB;Integrated Security=True";
            string sql = "SELECT Store_Request_items.Item_Number, Inventory.Category, Inventory.Description, Inventory.Bin_number, SUM(Store_Request_items.Req_Quantity) AS Req_Qunty ,Inventory.Quantity as Available FROM Store_Request INNER JOIN Store_Request_items ON Store_Request.StoreRequest_ID = Store_Request_items.StoreRequest_ID INNER JOIN Inventory ON Store_Request_items.Item_Number = Inventory.Item_Number GROUP BY Store_Request_items.Item_Number, Inventory.Category, Inventory.Description, Inventory.Bin_number,Inventory.Quantity";
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);

                List<ArrayList> newval = new List<ArrayList>();
                foreach (DataRow dRow in ds.Tables[0].Rows)
                {
                    ArrayList values = new ArrayList();
                    foreach (object value in dRow.ItemArray)
                        values.Add(value);
                    newval.Add(values);
                }

                GridView1.DataSource = ds;
                GridView1.DataBind();



            }
            catch (Exception)
            {
                Response.Write("hello");
            }
            finally
            {
                conn.Close();
            }
        }
    }
}