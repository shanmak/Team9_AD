using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Team9_AD.Entity;

namespace Team9_AD
{
    public partial class ClerkHistoryDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*Code by Mani & Prasanth*/
            int id = Convert.ToInt32(Request.QueryString["ID"]);

            string host = Application["host"].ToString();
            if (!IsPostBack)
            {
                Employee emp = (Employee)Session["user"];
                if (emp.Employee_Role != "Store-Clerk")
                {
                    Response.Redirect("LoginPage.aspx");
                }
                using (WebClient webClient = new WebClient())
                {
                    //String rawJSON = webClient.DownloadString("http://" + host + "/AD_Service/WCF/Service1.svc/listClerkRequest/"+id);
                    //List<Store_Request_items> store_Requests_items = JsonConvert.DeserializeObject<List<Store_Request_items>>(rawJSON);

                  //  var storeRequestsitems = ClerkBusinessLogic.storeRequestItems(id);

                    Logic_University_Entity model = new Logic_University_Entity();
                   List<Store_Request_items> HistoryDetails= model.Store_Request_items.Where(x => x.StoreRequest_ID.Equals(id) && x.Status.Equals("Done")).ToList<Store_Request_items>();

                    if (!HistoryDetails.Count().Equals(0))
                    {
                        GridView1.DataSource = HistoryDetails;
                        GridView1.DataBind();
                    }
                    else
                    {
                        Response.Write("Record Not Found");
                    }
                }
            }
        }
    }
}